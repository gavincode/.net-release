using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileRelease.DAL;
using FileRelease.Model;

namespace FileRelease.UI
{
    public partial class FilterForm : Form
    {
        Project FilterProject;
        Boolean FilterChanged = false;
        Boolean BindOver = false;

        //默认筛选
        public static List<String> DefaultKeyWords = new List<String> { 
            "vshost","WebSite.dll.config"
        };
        public static List<String> DefaultFolders = new List<String> { 
            "Log","obj","Cache","Properties","System Volume Information"
        };
        public static List<String> DefaultTypes = new List<String> { 
            ".pdb",".cs",".csproj",".user",".suo",".InstallLog"
        };
        public static List<String> DefaultFiles = new List<String> { 
            "error.html","NPOI.OOXML.xml","NPOI.OpenXml4Net.xml","NPOI.xml","Util.xml"
        };

        //打包代码默认筛选
        public static List<String> DefaultCodeFolders = new List<String> { 
            "bin","obj"
        };
        public static List<String> DefaultCodeTypes = new List<String> { 
            ".pdb",".user",".suo",".InstallLog"
        };
        public FilterForm(Project project)
        {
            FilterProject = project;
            InitializeComponent();
            BindText();
        }

        private void BindText()
        {
            if (FilterProject.GetFilter() == null)
                FilterProject.SetFilter(FilterDAL.QueryOne(FilterProject));

            if (FilterProject.GetFilter() != null)
            {
                FilterProject.GetFilter().FileList().ForEach(p => txtFile.AppendText(p + Environment.NewLine));
                FilterProject.GetFilter().FolderList().ForEach(p => txtFolder.AppendText(p + Environment.NewLine));
                FilterProject.GetFilter().TypeList().ForEach(p => txtType.AppendText(p + Environment.NewLine));
                FilterProject.GetFilter().KeyWordList().ForEach(p => txtKeyWord.AppendText(p + Environment.NewLine));
            }

            BindOver = true;
        }

        private void BindDefaultText()
        {
            DefaultKeyWords.ForEach(p => txtKeyWord.AppendText(p + Environment.NewLine));
            DefaultFolders.ForEach(p => txtFolder.AppendText(p + Environment.NewLine));
            DefaultTypes.ForEach(p => txtType.AppendText(p + Environment.NewLine));
            DefaultFiles.ForEach(p => txtFile.AppendText(p + Environment.NewLine));
        }

        private void BindDefaultCodeText()
        {
            DefaultCodeFolders.ForEach(p => txtFolder.AppendText(p + Environment.NewLine));
            DefaultCodeTypes.ForEach(p => txtType.AppendText(p + Environment.NewLine));
        }

        private void ClearText()
        {
            txtKeyWord.Text = String.Empty;
            txtFolder.Text = String.Empty;
            txtType.Text = String.Empty;
            txtFile.Text = String.Empty;
        }

        private String BuildText(TextBox textBox)
        {
            textBox.Text = textBox.Text.Trim();
            return String.Join(",", textBox.Lines);
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            if (BindOver)
                FilterChanged = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FilterChanged)
            {
                Filter filter = FilterProject.GetFilter();
                if (filter == null)
                {
                    filter = new Filter();

                    //添加关系
                    FilterProject.SetFilter(filter);
                }

                filter.Files = BuildText(txtFile);
                filter.Folders = BuildText(txtFolder);
                filter.KeyWords = BuildText(txtKeyWord);
                filter.Types = BuildText(txtType);

                FilterDAL.SaveOrUpdate(filter);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkAddDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearText();
            BindDefaultText();
        }

        private void linkCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearText();
            BindDefaultCodeText();
        }
    }
}