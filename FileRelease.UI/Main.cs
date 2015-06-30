using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileRelease.UI
{
    using System.IO;
    using FileRelease.BLL;
    using FileRelease.DAL;
    using FileRelease.Model;
    using FileRelease.Utils;
    using Util.Convert;
    using Util;

    public partial class Main : Form
    {
        #region 初始化

        //记录单击时间
        private static DateTime _clickTime = DateTime.MinValue;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Main()
        {
            InitializeComponent();
            BindProjects();
            InitControls();
        }

        /// <summary>
        /// 初始化控件状态
        /// </summary>
        private void InitControls()
        {
            //DataGridView
            this.dgvProject.Columns[0].Visible = false;
            this.dgvProject.Columns[0].FillWeight = 5;
            this.dgvProject.Columns[1].FillWeight = 12;
            this.dgvProject.Columns[2].FillWeight = 40;
            this.dgvProject.Columns[3].FillWeight = 28;
            this.dgvProject.Columns[4].FillWeight = 15;
            this.dgvProject.MultiSelect = false;
            this.dgvProject.AutoGenerateColumns = false;
            this.dgvProject.BackgroundColor = Color.White;
            this.dgvProject.DefaultCellStyle.BackColor = Color.White;
            this.dgvProject.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvProject.DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
            this.dgvProject.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.dgvProject.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProject.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        #endregion

        #region 控件事件

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Project project = new Project
            {
                Id = Guid.NewGuid(),
                Name = txtName.Text,
                UIFolder = cmbUIFolder.Text,
                ReleaseFolder = cmbReleaseFolder.Text,
                LastTime = DateTime.Now
            };

            if (CommonBLL.EditId != Guid.Empty)
            {
                project.Id = CommonBLL.EditId;
            }

            if (ProjectDAL.QueryOne(project.Id) == null)
            {
                ProjectDAL.Insert(project);

                //添加默认filter
                Filter filter = new Filter();

                if (ckbCode.Checked)
                {
                    filter.Id = project.Id;
                    filter.Folders = BuildText(FilterForm.DefaultCodeFolders);
                    filter.Types = BuildText(FilterForm.DefaultCodeTypes);
                }
                else
                {
                    filter.Id = project.Id;
                    filter.Files = BuildText(FilterForm.DefaultFiles);
                    filter.Folders = BuildText(FilterForm.DefaultFolders);
                    filter.KeyWords = BuildText(FilterForm.DefaultKeyWords);
                    filter.Types = BuildText(FilterForm.DefaultTypes);
                }

                project.SetFilter(filter);

                FilterDAL.SaveOrUpdate(filter);
            }
            else
            {
                ProjectDAL.Update(project);
            }

            BindProjects();

            //清空编辑框
            txtName.Text = cmbUIFolder.Text = cmbReleaseFolder.Text = "";

            CommonBLL.EditId = Guid.Empty;
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRelease_Click(object sender, EventArgs e)
        {
            btnRelease.Enabled = false;

            Project project = this.cmbProject.SelectedItem as Project;

            if (!project.UIFolder.ExistsEx())
            {
                MessageBox.Show("当前发布项目的路径无效!");
                this.btnRelease.Enabled = true;
                return;
            }

            //验证发布路径是否有效
            foreach (var item in project.ReleaseFolder.Split(','))
            {
                if (!item.ExistsEx())
                {
                    MessageBox.Show("当前发布项目的路径或发布包存放路径无效!");
                    this.btnRelease.Enabled = true;
                    return;
                }
            }

            //上一次发布时间
            DateTime lastTime = cbIncrease.Checked ? project.LastTime : DateTime.MinValue;

            String releasedFolder = String.Empty;

            if (project.GetFilter() == null)
            {
                project.SetFilter(FilterDAL.QueryOne(project));
            }

            //异步发布文件
            MethodInvoker invoker = new MethodInvoker(() =>
            {
                ReleaseFileHelper.Release(project.Name, project.UIFolder, project.ReleaseFolder, lastTime, this.cbReleaseFolder.Checked, project, ref releasedFolder);
            });

            invoker.BeginInvoke(p => FormInvoke(() =>
            {
                var privatePath = CommonBLL.GetPrivatePath(releasedFolder);
                if (privatePath != String.Empty)
                {
                    ReleaseFileHelper.MoveDLLs(releasedFolder, Path.Combine(releasedFolder, privatePath));
                }

                if (ckbRAR.Checked)
                {
                    ZipCreator.CompressFoder(releasedFolder, releasedFolder + ".rar");
                    Directory.Delete(releasedFolder, true);
                }

                //更新最后发布时间
                project.LastTime = DateTime.Now;
                ProjectDAL.Update(project);

                BindProjects();

                btnRelease.Enabled = true;
                OpenFolder(project.ReleaseFolder);
            }), null);
        }

        /// <summary>
        /// 右键-编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiEdit_Click(object sender, EventArgs e)
        {
            Guid id = SelectedRowId();
            if (id == Guid.Empty) return;

            Project project = ProjectDAL.QueryOne(id);

            //绑定到编辑框
            txtName.Text = project.Name;
            cmbUIFolder.Text = project.UIFolder;
            cmbReleaseFolder.Text = project.ReleaseFolder;

            CommonBLL.EditId = id;
        }

        /// <summary>
        /// 右键-删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiDelete_Click(object sender, EventArgs e)
        {
            Guid id = SelectedRowId();
            if (id == Guid.Empty) return;

            var project = ProjectDAL.QueryOne(id);

            //删除项目数据
            ProjectDAL.Delete(project);

            //删除filter
            var filter = FilterDAL.QueryOne(new { Id = id });
            if (filter != null) FilterDAL.Delete(id);

            BindProjects();
        }

        /// <summary>
        /// 右键菜单启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsProject_Opening(object sender, CancelEventArgs e)
        {
            if (dgvProject.CurrentRow == null)
                e.Cancel = true;
        }

        /// <summary>
        /// 打开项目文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_UIView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var project = cmbProject.SelectedItem as Project;

            OpenFolder(project.UIFolder);
        }

        /// <summary>
        /// 打开发布文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_ReleasePackageView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var project = cmbProject.SelectedItem as Project;

            OpenFolder(project.ReleaseFolder);
        }

        /// <summary>
        /// 项目信息双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProject.CurrentRow == null) return;

            var project = cmbProject.SelectedItem as Project;

            FilterForm form = new FilterForm(project);

            form.ShowDialog(this);
        }

        /// <summary>
        /// CheckBox ReleaseFolder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbReleaseFolder_CheckedChanged(object sender, EventArgs e)
        {
            ckbRAR.Enabled = cbReleaseFolder.Checked;
            if (!ckbRAR.Enabled) ckbRAR.Checked = false;
        }

        /// <summary>
        /// 双击打开UIFolder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUIFolder_MouseClick(object sender, MouseEventArgs e)
        {
            if (_clickTime.AddMilliseconds(200) >= DateTime.Now)
            {
                OpenFolder(cmbUIFolder.Text);
            }

            _clickTime = DateTime.Now;
        }

        /// <summary>
        /// 双击打开ReleaseFolder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbReleaseFolder_MouseClick(object sender, MouseEventArgs e)
        {
            if (_clickTime.AddMilliseconds(200) >= DateTime.Now)
            {
                OpenFolder(cmbReleaseFolder.Text);
            }

            _clickTime = DateTime.Now;
        }

        /// <summary>
        /// 打包代码Check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbCode_CheckedChanged(object sender, EventArgs e)
        {
            BindProjects();
        }

        /// <summary>
        /// Release选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbRelease_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbRelease.Checked)
            {
                cmbUIFolder.Text = cmbUIFolder.Text.Replace("Debug", "Release");
            }
            else
            {
                cmbUIFolder.Text = cmbUIFolder.Text.Replace("Release", "Debug");
            }
        }

        /// <summary>
        /// UI路径选项改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUIFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定项目名称
            this.txtName.Text = GetProjectNameByPath(cmbUIFolder.Text);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 绑定GridView
        /// </summary>
        private void BindProjects()
        {
            var projects = ProjectDAL.Query().OrderBy(p => p.Name).ToList();

            //最后发布时间
            DateTime recentTime = projects.Count == 0 ? DateTime.MinValue : projects.Max(p => p.LastTime);

            //绑定DataGridView
            dgvProject.DataSource = projects;

            //绑定项目列表
            cmbProject.DisplayMember = "Name";
            cmbProject.DataSource = projects;
            cmbProject.SelectedIndex = projects.FindIndex(p => p.LastTime == recentTime);

            //绑定UIFolder
            cmbUIFolder.DataSource = RegeditBLL.GetRecentProjects(!ckbCode.Checked);

            List<String> cmbReleaseFolders = projects.Select(p => p.ReleaseFolder).Distinct().ToList();

            if (cmbReleaseFolders.Count == 0)
            {
                cmbReleaseFolders = CommonBLL.GetReleaseFolders(cmbUIFolder.Text);
            }

            //绑定ReleaseFolder
            cmbReleaseFolder.DataSource = cmbReleaseFolders;
        }

        /// <summary>
        /// 获取项目名称
        /// </summary>
        /// <param name="filePath">项目文件路径</param>
        /// <returns>项目名称</returns>
        private String GetProjectNameByPath(String filePath)
        {
            if (!filePath.ExistsEx()) return String.Empty;

            try
            {
                if (ckbCode.Checked)
                {
                    return Path.GetFileName(filePath);
                }
                else
                {
                    return Directory.GetParent(filePath).Parent.Name;
                }
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// 选中行Id
        /// </summary>
        /// <returns></returns>
        private Guid SelectedRowId()
        {
            Guid id;
            if (!ConvertUtil.TryParseToGuid(dgvProject.CurrentRow.Cells[0].Value, out id))
            {
                MessageBox.Show("选中行没有有效数据");
                return Guid.Empty;
            }

            return id;
        }

        /// <summary>
        /// 主线程执行方法
        /// </summary>
        /// <param name="action"></param>
        private void FormInvoke(Action action)
        {
            this.Invoke(action);
        }

        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="folder"></param>
        private void OpenFolder(String folder)
        {
            if (folder.ExistsEx())
            {
                System.Diagnostics.Process.Start(folder);
            }
        }

        /// <summary>
        /// 组装文本
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private String BuildText(List<String> list)
        {
            return String.Join(",", list.ToArray());
        }

        #endregion
    }
}