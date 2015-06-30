namespace FileRelease.UI
{
    partial class FilterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.lblFolderFilter = new System.Windows.Forms.Label();
            this.lblFileFilter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKeyWord = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.linkAddDefault = new System.Windows.Forms.LinkLabel();
            this.linkCode = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblFolderFilter
            // 
            this.lblFolderFilter.AutoSize = true;
            this.lblFolderFilter.Location = new System.Drawing.Point(313, 22);
            this.lblFolderFilter.Name = "lblFolderFilter";
            this.lblFolderFilter.Size = new System.Drawing.Size(41, 12);
            this.lblFolderFilter.TabIndex = 1;
            this.lblFolderFilter.Text = "文件夹";
            // 
            // lblFileFilter
            // 
            this.lblFileFilter.AutoSize = true;
            this.lblFileFilter.Location = new System.Drawing.Point(187, 22);
            this.lblFileFilter.Name = "lblFileFilter";
            this.lblFileFilter.Size = new System.Drawing.Size(29, 12);
            this.lblFileFilter.TabIndex = 3;
            this.lblFileFilter.Text = "文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "类型";
            // 
            // lblKeyWord
            // 
            this.lblKeyWord.AutoSize = true;
            this.lblKeyWord.Location = new System.Drawing.Point(452, 22);
            this.lblKeyWord.Name = "lblKeyWord";
            this.lblKeyWord.Size = new System.Drawing.Size(41, 12);
            this.lblKeyWord.TabIndex = 7;
            this.lblKeyWord.Text = "关键字";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(13, 43);
            this.txtType.Multiline = true;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(116, 179);
            this.txtType.TabIndex = 8;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(280, 43);
            this.txtFolder.Multiline = true;
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(116, 179);
            this.txtFolder.TabIndex = 9;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(145, 43);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(116, 179);
            this.txtFile.TabIndex = 10;
            this.txtFile.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(416, 43);
            this.txtKeyWord.Multiline = true;
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(116, 179);
            this.txtKeyWord.TabIndex = 11;
            this.txtKeyWord.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(186, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // linkAddDefault
            // 
            this.linkAddDefault.AutoSize = true;
            this.linkAddDefault.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkAddDefault.Location = new System.Drawing.Point(12, 247);
            this.linkAddDefault.Name = "linkAddDefault";
            this.linkAddDefault.Size = new System.Drawing.Size(47, 12);
            this.linkAddDefault.TabIndex = 14;
            this.linkAddDefault.TabStop = true;
            this.linkAddDefault.Text = "Release";
            this.linkAddDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddDefault_LinkClicked);
            // 
            // linkCode
            // 
            this.linkCode.AutoSize = true;
            this.linkCode.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkCode.Location = new System.Drawing.Point(82, 247);
            this.linkCode.Name = "linkCode";
            this.linkCode.Size = new System.Drawing.Size(29, 12);
            this.linkCode.TabIndex = 15;
            this.linkCode.TabStop = true;
            this.linkCode.Text = "Code";
            this.linkCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCode_LinkClicked);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 277);
            this.Controls.Add(this.linkCode);
            this.Controls.Add(this.linkAddDefault);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtKeyWord);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblKeyWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFileFilter);
            this.Controls.Add(this.lblFolderFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "过滤";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolderFilter;
        private System.Windows.Forms.Label lblFileFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKeyWord;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel linkAddDefault;
        private System.Windows.Forms.LinkLabel linkCode;
    }
}