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

        /// <summary>
        /// 构造函数
        /// </summary>
        public Main()
        {
            InitializeComponent();
            InitControls();
            BindProjects();
        }

        /// <summary>
        /// 初始化控件状态
        /// </summary>
        private void InitControls()
        {
            //DataGridView
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

            //取消菜单左侧图标
            ((ToolStripDropDownMenu)tsmiSettings.DropDown).ShowImageMargin = false;
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
                Name = txtName.Text,
                UIFolder = cmbUIFolder.Text,
                ReleaseFolder = cmbReleaseFolder.Text,
                LastTime = DateTime.Now
            };

            if (CommonBLL.EditId != 0)
            {
                project.Id = CommonBLL.EditId;
            }

            ProjectDAL.SaveOrUpdate<Project>(project);

            BindProjects();

            //清空编辑框
            txtName.Text = cmbUIFolder.Text = cmbReleaseFolder.Text = "";

            CommonBLL.EditId = 0;
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
            Int32 id = SelectedRowId();
            if (id == -1) return;

            Project project = ProjectDAL.Get<Project>(id);

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
            Int32 id = SelectedRowId();
            if (id == -1) return;

            var project = ProjectDAL.Get<Project>(id);

            //删除数据
            ProjectDAL.Delete<Project>(project);

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
        #endregion

        #region 私有方法

        /// <summary>
        /// 绑定GridView
        /// </summary>
        private void BindProjects()
        {
            var projects = ProjectDAL.All<Project>().OrderBy(p => p.Id).ToList();

            //最后发布时间
            DateTime recentTime = projects.Count == 0 ? DateTime.MinValue : projects.Max(p => p.LastTime);

            //绑定DataGridView
            dgvProject.DataSource = projects;

            //绑定项目列表
            cmbProject.DisplayMember = "Name";
            cmbProject.DataSource = projects;
            cmbProject.SelectedIndex = projects.FindIndex(p => p.LastTime == recentTime);

            //绑定UIFolder
            cmbUIFolder.DataSource = RegeditBLL.GetRecentProjects();

            //绑定ReleaseFolder
            cmbReleaseFolder.DataSource = projects.Select(p => p.ReleaseFolder).Distinct().ToList();
        }

        /// <summary>
        /// 选中行Id
        /// </summary>
        /// <returns></returns>
        private Int32 SelectedRowId()
        {
            Int32 id;
            if (!ConvertUtil.TryParseToInt32(dgvProject.CurrentRow.Cells[0].Value, out id))
            {
                MessageBox.Show("选中行没有有效数据");
                return -1;
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

        #endregion
    }
}