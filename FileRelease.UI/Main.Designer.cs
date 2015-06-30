namespace FileRelease.UI
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.dataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataUIFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataReleaseFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataLastTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cbReleaseFolder = new System.Windows.Forms.CheckBox();
            this.link_ReleasePackageView = new System.Windows.Forms.LinkLabel();
            this.link_UIView = new System.Windows.Forms.LinkLabel();
            this.cmbUIFolder = new System.Windows.Forms.ComboBox();
            this.lblUIFolder = new System.Windows.Forms.Label();
            this.btnRelease = new System.Windows.Forms.Button();
            this.cbIncrease = new System.Windows.Forms.CheckBox();
            this.cmbReleaseFolder = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblProject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRAR = new System.Windows.Forms.CheckBox();
            this.ckbRAR = new System.Windows.Forms.CheckBox();
            this.lblChoice = new System.Windows.Forms.Label();
            this.ckbCode = new System.Windows.Forms.CheckBox();
            this.ckbRelease = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.cmsProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProject
            // 
            this.dgvProject.AllowUserToAddRows = false;
            this.dgvProject.AllowUserToDeleteRows = false;
            this.dgvProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProject.BackgroundColor = System.Drawing.Color.White;
            this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataId,
            this.dataName,
            this.dataUIFolder,
            this.dataReleaseFolder,
            this.dataLastTime});
            this.dgvProject.ContextMenuStrip = this.cmsProject;
            this.dgvProject.GridColor = System.Drawing.Color.Gray;
            this.dgvProject.Location = new System.Drawing.Point(0, 138);
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.ReadOnly = true;
            this.dgvProject.RowTemplate.Height = 23;
            this.dgvProject.Size = new System.Drawing.Size(939, 364);
            this.dgvProject.TabIndex = 20;
            this.dgvProject.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProject_CellDoubleClick);
            // 
            // dataId
            // 
            this.dataId.DataPropertyName = "Id";
            this.dataId.FillWeight = 25.38071F;
            this.dataId.HeaderText = "Id";
            this.dataId.Name = "dataId";
            this.dataId.ReadOnly = true;
            // 
            // dataName
            // 
            this.dataName.DataPropertyName = "Name";
            this.dataName.FillWeight = 110.3471F;
            this.dataName.HeaderText = "项目名称";
            this.dataName.Name = "dataName";
            this.dataName.ReadOnly = true;
            // 
            // dataUIFolder
            // 
            this.dataUIFolder.DataPropertyName = "UIFolder";
            this.dataUIFolder.FillWeight = 162.8866F;
            this.dataUIFolder.HeaderText = "项目路径";
            this.dataUIFolder.Name = "dataUIFolder";
            this.dataUIFolder.ReadOnly = true;
            // 
            // dataReleaseFolder
            // 
            this.dataReleaseFolder.DataPropertyName = "ReleaseFolder";
            this.dataReleaseFolder.FillWeight = 144.0542F;
            this.dataReleaseFolder.HeaderText = "发布路径";
            this.dataReleaseFolder.Name = "dataReleaseFolder";
            this.dataReleaseFolder.ReadOnly = true;
            // 
            // dataLastTime
            // 
            this.dataLastTime.DataPropertyName = "LastTime";
            this.dataLastTime.FillWeight = 57.33134F;
            this.dataLastTime.HeaderText = "最后发布时间";
            this.dataLastTime.Name = "dataLastTime";
            this.dataLastTime.ReadOnly = true;
            // 
            // cmsProject
            // 
            this.cmsProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.toolStripSeparator1,
            this.tsmiDelete});
            this.cmsProject.Name = "cmsProject";
            this.cmsProject.ShowImageMargin = false;
            this.cmsProject.Size = new System.Drawing.Size(108, 54);
            this.cmsProject.Opening += new System.ComponentModel.CancelEventHandler(this.cmsProject_Opening);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(107, 22);
            this.tsmiEdit.Text = "        编辑";
            this.tsmiEdit.ToolTipText = "编辑选中行";
            this.tsmiEdit.Click += new System.EventHandler(this.smiEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(107, 22);
            this.tsmiDelete.Text = "        删除";
            this.tsmiDelete.Click += new System.EventHandler(this.smiDelete_Click);
            // 
            // cbReleaseFolder
            // 
            this.cbReleaseFolder.AutoSize = true;
            this.cbReleaseFolder.Checked = true;
            this.cbReleaseFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReleaseFolder.Location = new System.Drawing.Point(611, 104);
            this.cbReleaseFolder.Name = "cbReleaseFolder";
            this.cbReleaseFolder.Size = new System.Drawing.Size(60, 16);
            this.cbReleaseFolder.TabIndex = 35;
            this.cbReleaseFolder.Text = "文件夹";
            this.cbReleaseFolder.UseVisualStyleBackColor = true;
            this.cbReleaseFolder.CheckedChanged += new System.EventHandler(this.cbReleaseFolder_CheckedChanged);
            // 
            // link_ReleasePackageView
            // 
            this.link_ReleasePackageView.AutoSize = true;
            this.link_ReleasePackageView.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.link_ReleasePackageView.Location = new System.Drawing.Point(724, 70);
            this.link_ReleasePackageView.Name = "link_ReleasePackageView";
            this.link_ReleasePackageView.Size = new System.Drawing.Size(53, 12);
            this.link_ReleasePackageView.TabIndex = 31;
            this.link_ReleasePackageView.TabStop = true;
            this.link_ReleasePackageView.Text = "发布文件";
            this.link_ReleasePackageView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_ReleasePackageView_LinkClicked);
            // 
            // link_UIView
            // 
            this.link_UIView.AutoSize = true;
            this.link_UIView.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.link_UIView.Location = new System.Drawing.Point(619, 70);
            this.link_UIView.Name = "link_UIView";
            this.link_UIView.Size = new System.Drawing.Size(53, 12);
            this.link_UIView.TabIndex = 30;
            this.link_UIView.TabStop = true;
            this.link_UIView.Text = "项目文件";
            this.link_UIView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_UIView_LinkClicked);
            // 
            // cmbUIFolder
            // 
            this.cmbUIFolder.FormattingEnabled = true;
            this.cmbUIFolder.Location = new System.Drawing.Point(129, 32);
            this.cmbUIFolder.Name = "cmbUIFolder";
            this.cmbUIFolder.Size = new System.Drawing.Size(374, 20);
            this.cmbUIFolder.TabIndex = 29;
            this.cmbUIFolder.SelectedIndexChanged += new System.EventHandler(this.cmbUIFolder_SelectedIndexChanged);
            this.cmbUIFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbUIFolder_MouseClick);
            // 
            // lblUIFolder
            // 
            this.lblUIFolder.AutoSize = true;
            this.lblUIFolder.ForeColor = System.Drawing.Color.Black;
            this.lblUIFolder.Location = new System.Drawing.Point(31, 37);
            this.lblUIFolder.Name = "lblUIFolder";
            this.lblUIFolder.Size = new System.Drawing.Size(59, 12);
            this.lblUIFolder.TabIndex = 28;
            this.lblUIFolder.Text = "项目路径:";
            // 
            // btnRelease
            // 
            this.btnRelease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRelease.ForeColor = System.Drawing.Color.Black;
            this.btnRelease.Location = new System.Drawing.Point(842, 29);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 59);
            this.btnRelease.TabIndex = 26;
            this.btnRelease.Text = "发布";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // cbIncrease
            // 
            this.cbIncrease.AutoSize = true;
            this.cbIncrease.Location = new System.Drawing.Point(684, 104);
            this.cbIncrease.Name = "cbIncrease";
            this.cbIncrease.Size = new System.Drawing.Size(48, 16);
            this.cbIncrease.TabIndex = 27;
            this.cbIncrease.Text = "增量";
            this.cbIncrease.UseVisualStyleBackColor = true;
            // 
            // cmbReleaseFolder
            // 
            this.cmbReleaseFolder.FormattingEnabled = true;
            this.cmbReleaseFolder.Location = new System.Drawing.Point(129, 68);
            this.cmbReleaseFolder.Name = "cmbReleaseFolder";
            this.cmbReleaseFolder.Size = new System.Drawing.Size(374, 20);
            this.cmbReleaseFolder.TabIndex = 37;
            this.cmbReleaseFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbReleaseFolder_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "发布路径:";
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(609, 30);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(183, 20);
            this.cmbProject.TabIndex = 38;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(31, 107);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 12);
            this.lblName.TabIndex = 39;
            this.lblName.Text = "项目命名:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(129, 104);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(282, 21);
            this.txtName.TabIndex = 40;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(436, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 28);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.ForeColor = System.Drawing.Color.Black;
            this.lblProject.Location = new System.Drawing.Point(531, 35);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(59, 12);
            this.lblProject.TabIndex = 42;
            this.lblProject.Text = "发布项目:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(531, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "打开文件:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(540, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "发布选项:";
            // 
            // cbRAR
            // 
            this.cbRAR.AutoSize = true;
            this.cbRAR.Location = new System.Drawing.Point(762, 100);
            this.cbRAR.Name = "cbRAR";
            this.cbRAR.Size = new System.Drawing.Size(42, 16);
            this.cbRAR.TabIndex = 45;
            this.cbRAR.Text = "RAR";
            this.cbRAR.UseVisualStyleBackColor = true;
            // 
            // ckbRAR
            // 
            this.ckbRAR.AutoSize = true;
            this.ckbRAR.Location = new System.Drawing.Point(748, 104);
            this.ckbRAR.Name = "ckbRAR";
            this.ckbRAR.Size = new System.Drawing.Size(42, 16);
            this.ckbRAR.TabIndex = 45;
            this.ckbRAR.Text = "RAR";
            this.ckbRAR.UseVisualStyleBackColor = true;
            // 
            // lblChoice
            // 
            this.lblChoice.AutoSize = true;
            this.lblChoice.ForeColor = System.Drawing.Color.Black;
            this.lblChoice.Location = new System.Drawing.Point(531, 107);
            this.lblChoice.Name = "lblChoice";
            this.lblChoice.Size = new System.Drawing.Size(59, 12);
            this.lblChoice.TabIndex = 46;
            this.lblChoice.Text = "发布选项:";
            // 
            // ckbCode
            // 
            this.ckbCode.AutoSize = true;
            this.ckbCode.Location = new System.Drawing.Point(804, 104);
            this.ckbCode.Name = "ckbCode";
            this.ckbCode.Size = new System.Drawing.Size(48, 16);
            this.ckbCode.TabIndex = 47;
            this.ckbCode.Text = "Code";
            this.ckbCode.UseVisualStyleBackColor = true;
            this.ckbCode.CheckedChanged += new System.EventHandler(this.ckbCode_CheckedChanged);
            // 
            // ckbRelease
            // 
            this.ckbRelease.AutoSize = true;
            this.ckbRelease.Location = new System.Drawing.Point(862, 104);
            this.ckbRelease.Name = "ckbRelease";
            this.ckbRelease.Size = new System.Drawing.Size(66, 16);
            this.ckbRelease.TabIndex = 48;
            this.ckbRelease.Text = "Release";
            this.ckbRelease.UseVisualStyleBackColor = true;
            this.ckbRelease.CheckedChanged += new System.EventHandler(this.ckbRelease_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 500);
            this.Controls.Add(this.ckbRelease);
            this.Controls.Add(this.ckbCode);
            this.Controls.Add(this.lblChoice);
            this.Controls.Add(this.ckbRAR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.cmbReleaseFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbReleaseFolder);
            this.Controls.Add(this.link_ReleasePackageView);
            this.Controls.Add(this.link_UIView);
            this.Controls.Add(this.cmbUIFolder);
            this.Controls.Add(this.lblUIFolder);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.cbIncrease);
            this.Controls.Add(this.dgvProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReleaseTool";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.cmsProject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.CheckBox cbReleaseFolder;
        private System.Windows.Forms.LinkLabel link_ReleasePackageView;
        private System.Windows.Forms.LinkLabel link_UIView;
        private System.Windows.Forms.ComboBox cmbUIFolder;
        private System.Windows.Forms.Label lblUIFolder;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.CheckBox cbIncrease;
        private System.Windows.Forms.ComboBox cmbReleaseFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataUIFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataReleaseFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataLastTime;
        private System.Windows.Forms.ContextMenuStrip cmsProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.CheckBox cbRAR;
        private System.Windows.Forms.CheckBox ckbRAR;
        private System.Windows.Forms.Label lblChoice;
        private System.Windows.Forms.CheckBox ckbCode;
        private System.Windows.Forms.CheckBox ckbRelease;
    }
}