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
        List<String> DefaultKeyWords = new List<String> { 
            "vshost","WebSite.dll.config"
        };
        List<String> DefaultFolders = new List<String> { 
            "Log","obj","Cache","Properties","System Volume Information"
        };
        List<String> DefaultTypes = new List<String> { 
            ".pdb",".cs",".csproj",".user",".suo",".InstallLog"
        };
        List<String> DefaultFiles = new List<String> { 
            "error.html","NPOI.OOXML.xml","NPOI.OpenXml4Net.xml","NPOI.xml","Util.xml"
        };

        public FilterForm(Project project)
        {
            FilterProject = project;
            InitializeComponent();
            BindText();
        }

        private void BindText()
        {
            if (FilterProject.Filter != null)
            {
                FilterProject.Filter.FileList.ForEach(p => txtFile.AppendText(p + Environment.NewLine));
                FilterProject.Filter.FolderList.ForEach(p => txtFolder.AppendText(p + Environment.NewLine));
                FilterProject.Filter.TypeList.ForEach(p => txtType.AppendText(p + Environment.NewLine));
                FilterProject.Filter.KeyWordList.ForEach(p => txtKeyWord.AppendText(p + Environment.NewLine));
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
                Filter filter = FilterProject.Filter;
                if (filter == null)
                {
                    filter = new Filter();

                    //添加关系
                    FilterProject.AddFilter(filter);
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
            BindDefaultText();
        }
    }
}