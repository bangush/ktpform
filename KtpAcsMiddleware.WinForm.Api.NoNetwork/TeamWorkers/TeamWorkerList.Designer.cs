namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    partial class TeamWorkerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamWorkerList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TeamsLb = new System.Windows.Forms.ListBox();
            this.TeamsCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TeamReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamWorkerAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.con_tems_add = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_tems = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSyn_ktp = new CCWin.SkinControl.SkinButton();
            this.SearchButton = new CCWin.SkinControl.SkinButton();
            this.WorkersGridPager = new KtpAcsMiddleware.WinForm.Api.UserControls.KtpGridPager();
            this.WorkerAuthenticationStatesCb = new System.Windows.Forms.ComboBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthenticationStateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ktpMag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerSeeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerSetForemanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_project_id = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TeamsCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.WorkerCms.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(8, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TeamsLb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSyn_ktp);
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGridPager);
            this.splitContainer1.Panel2.Controls.Add(this.WorkerAuthenticationStatesCb);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1337, 651);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 0;
            // 
            // TeamsLb
            // 
            this.TeamsLb.ContextMenuStrip = this.TeamsCms;
            this.TeamsLb.Font = new System.Drawing.Font("宋体", 12F);
            this.TeamsLb.FormattingEnabled = true;
            this.TeamsLb.ItemHeight = 16;
            this.TeamsLb.Location = new System.Drawing.Point(0, 0);
            this.TeamsLb.Name = "TeamsLb";
            this.TeamsLb.Size = new System.Drawing.Size(222, 644);
            this.TeamsLb.TabIndex = 0;
            this.TeamsLb.SelectedIndexChanged += new System.EventHandler(this.TeamsLb_SelectedIndexChanged);
            // 
            // TeamsCms
            // 
            this.TeamsCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TeamReloadMenuItem,
            this.TeamWorkerAddMenuItem,
            this.con_tems_add,
            this.exit_tems});
            this.TeamsCms.Name = "TeamsCms";
            this.TeamsCms.Size = new System.Drawing.Size(125, 92);
            this.TeamsCms.Opening += new System.ComponentModel.CancelEventHandler(this.TeamsCms_Opening);
            // 
            // TeamReloadMenuItem
            // 
            this.TeamReloadMenuItem.Name = "TeamReloadMenuItem";
            this.TeamReloadMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamReloadMenuItem.Text = "刷新";
            this.TeamReloadMenuItem.Click += new System.EventHandler(this.TeamReloadMenuItem_Click);
            // 
            // TeamWorkerAddMenuItem
            // 
            this.TeamWorkerAddMenuItem.Name = "TeamWorkerAddMenuItem";
            this.TeamWorkerAddMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamWorkerAddMenuItem.Text = "添加工人";
            this.TeamWorkerAddMenuItem.Click += new System.EventHandler(this.TeamWorkerAddMenuItem_Click);
            // 
            // con_tems_add
            // 
            this.con_tems_add.Name = "con_tems_add";
            this.con_tems_add.Size = new System.Drawing.Size(124, 22);
            this.con_tems_add.Text = "添加班组";
            this.con_tems_add.Click += new System.EventHandler(this.add_team_con);
            // 
            // exit_tems
            // 
            this.exit_tems.Name = "exit_tems";
            this.exit_tems.Size = new System.Drawing.Size(124, 22);
            this.exit_tems.Text = "编辑班组";
            this.exit_tems.Click += new System.EventHandler(this.exit_tems_Click);
            // 
            // btnSyn_ktp
            // 
            this.btnSyn_ktp.BackColor = System.Drawing.Color.DarkGray;
            this.btnSyn_ktp.BaseColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSyn_ktp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSyn_ktp.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSyn_ktp.DownBack = null;
            this.btnSyn_ktp.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSyn_ktp.Location = new System.Drawing.Point(941, 621);
            this.btnSyn_ktp.MouseBack = null;
            this.btnSyn_ktp.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSyn_ktp.Name = "btnSyn_ktp";
            this.btnSyn_ktp.NormlBack = null;
            this.btnSyn_ktp.Size = new System.Drawing.Size(162, 29);
            this.btnSyn_ktp.TabIndex = 26;
            this.btnSyn_ktp.Text = "一 键 同 步 云 端";
            this.btnSyn_ktp.UseVisualStyleBackColor = false;
            this.btnSyn_ktp.Visible = false;
            this.btnSyn_ktp.Click += new System.EventHandler(this.btnSyn_ktp_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.BaseColor = System.Drawing.SystemColors.ControlDark;
            this.SearchButton.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.SearchButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.SearchButton.DownBack = null;
            this.SearchButton.Location = new System.Drawing.Point(903, 5);
            this.SearchButton.MouseBack = null;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.NormlBack = null;
            this.SearchButton.Size = new System.Drawing.Size(136, 26);
            this.SearchButton.TabIndex = 25;
            this.SearchButton.Text = "搜 索";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // WorkersGridPager
            // 
            this.WorkersGridPager.Location = new System.Drawing.Point(4, 619);
            this.WorkersGridPager.Margin = new System.Windows.Forms.Padding(4);
            this.WorkersGridPager.Name = "WorkersGridPager";
            this.WorkersGridPager.PageCount = 0;
            this.WorkersGridPager.PageIndex = 1;
            this.WorkersGridPager.PageSize = 15;
            this.WorkersGridPager.PagingHandler = null;
            this.WorkersGridPager.Size = new System.Drawing.Size(295, 25);
            this.WorkersGridPager.TabIndex = 19;
            // 
            // WorkerAuthenticationStatesCb
            // 
            this.WorkerAuthenticationStatesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkerAuthenticationStatesCb.FormattingEnabled = true;
            this.WorkerAuthenticationStatesCb.Location = new System.Drawing.Point(720, 5);
            this.WorkerAuthenticationStatesCb.Name = "WorkerAuthenticationStatesCb";
            this.WorkerAuthenticationStatesCb.Size = new System.Drawing.Size(151, 24);
            this.WorkerAuthenticationStatesCb.TabIndex = 18;
            this.WorkerAuthenticationStatesCb.SelectedValueChanged += new System.EventHandler(this.WorkerAuthenticationStatesCb_SelectedValueChanged);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(4, 5);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(700, 26);
            this.SearchText.TabIndex = 16;
            this.SearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchText_KeyDown);
            // 
            // WorkersGrid
            // 
            this.WorkersGrid.AllowUserToAddRows = false;
            this.WorkersGrid.AllowUserToDeleteRows = false;
            this.WorkersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WorkersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WorkersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.teamId,
            this.WorkerName,
            this.IdentityCode,
            this.Mobile,
            this.SexText,
            this.Nation,
            this.AddressNow,
            this.AuthenticationStateText,
            this.TeamName,
            this.recordId,
            this.ktpMag});
            this.WorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.WorkersGrid.Location = new System.Drawing.Point(0, 37);
            this.WorkersGrid.MultiSelect = false;
            this.WorkersGrid.Name = "WorkersGrid";
            this.WorkersGrid.ReadOnly = true;
            this.WorkersGrid.RowHeadersVisible = false;
            this.WorkersGrid.RowHeadersWidth = 20;
            this.WorkersGrid.RowTemplate.Height = 23;
            this.WorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkersGrid.Size = new System.Drawing.Size(1103, 575);
            this.WorkersGrid.TabIndex = 0;
            this.WorkersGrid.SelectionChanged += new System.EventHandler(this.WorkersGrid_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "userId";
            this.id.HeaderText = "userId";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // teamId
            // 
            this.teamId.DataPropertyName = "teamId";
            this.teamId.HeaderText = "班组id";
            this.teamId.Name = "teamId";
            this.teamId.ReadOnly = true;
            this.teamId.Visible = false;
            // 
            // WorkerName
            // 
            this.WorkerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkerName.DataPropertyName = "userName";
            this.WorkerName.FillWeight = 6.369752F;
            this.WorkerName.HeaderText = "姓名";
            this.WorkerName.MinimumWidth = 100;
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
            // 
            // IdentityCode
            // 
            this.IdentityCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentityCode.DataPropertyName = "identityNum";
            this.IdentityCode.FillWeight = 10.1916F;
            this.IdentityCode.HeaderText = "证件号";
            this.IdentityCode.MinimumWidth = 100;
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "phoneNum";
            this.Mobile.FillWeight = 8.917653F;
            this.Mobile.HeaderText = "手机号";
            this.Mobile.MinimumWidth = 100;
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // SexText
            // 
            this.SexText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SexText.DataPropertyName = "sex";
            this.SexText.FillWeight = 5.095802F;
            this.SexText.HeaderText = "性别";
            this.SexText.MinimumWidth = 100;
            this.SexText.Name = "SexText";
            this.SexText.ReadOnly = true;
            // 
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nation.DataPropertyName = "nation";
            this.Nation.FillWeight = 8.917653F;
            this.Nation.HeaderText = "民族";
            this.Nation.MinimumWidth = 100;
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            // 
            // AddressNow
            // 
            this.AddressNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddressNow.DataPropertyName = "address";
            this.AddressNow.FillWeight = 25.47901F;
            this.AddressNow.HeaderText = "地址";
            this.AddressNow.MinimumWidth = 172;
            this.AddressNow.Name = "AddressNow";
            this.AddressNow.ReadOnly = true;
            // 
            // AuthenticationStateText
            // 
            this.AuthenticationStateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthenticationStateText.DataPropertyName = "certificationStatus";
            this.AuthenticationStateText.FillWeight = 5.095802F;
            this.AuthenticationStateText.HeaderText = "状态";
            this.AuthenticationStateText.MinimumWidth = 100;
            this.AuthenticationStateText.Name = "AuthenticationStateText";
            this.AuthenticationStateText.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "teamName";
            this.TeamName.FillWeight = 10.1916F;
            this.TeamName.HeaderText = "班组";
            this.TeamName.MinimumWidth = 100;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // recordId
            // 
            this.recordId.DataPropertyName = "recordId";
            this.recordId.HeaderText = "recordId";
            this.recordId.Name = "recordId";
            this.recordId.ReadOnly = true;
            this.recordId.Visible = false;
            // 
            // ktpMag
            // 
            this.ktpMag.DataPropertyName = "ktpMag";
            this.ktpMag.FillWeight = 82.74112F;
            this.ktpMag.HeaderText = "同步信息";
            this.ktpMag.MinimumWidth = 100;
            this.ktpMag.Name = "ktpMag";
            this.ktpMag.ReadOnly = true;
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerSeeMenuItem,
            this.WorkerEditMenuItem,
            this.WorkerDelMenuItem,
            this.WorkerSetForemanMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(137, 92);
            // 
            // WorkerSeeMenuItem
            // 
            this.WorkerSeeMenuItem.Name = "WorkerSeeMenuItem";
            this.WorkerSeeMenuItem.Size = new System.Drawing.Size(136, 22);
            this.WorkerSeeMenuItem.Text = "查看";
            this.WorkerSeeMenuItem.Click += new System.EventHandler(this.WorkerSeeMenuItem_Click);
            // 
            // WorkerEditMenuItem
            // 
            this.WorkerEditMenuItem.Name = "WorkerEditMenuItem";
            this.WorkerEditMenuItem.Size = new System.Drawing.Size(136, 22);
            this.WorkerEditMenuItem.Text = "编辑";
            this.WorkerEditMenuItem.Click += new System.EventHandler(this.WorkerEditMenuItem_Click);
            // 
            // WorkerDelMenuItem
            // 
            this.WorkerDelMenuItem.Name = "WorkerDelMenuItem";
            this.WorkerDelMenuItem.Size = new System.Drawing.Size(136, 22);
            this.WorkerDelMenuItem.Text = "删除";
            this.WorkerDelMenuItem.Click += new System.EventHandler(this.WorkerDelMenuItem_Click);
            // 
            // WorkerSetForemanMenuItem
            // 
            this.WorkerSetForemanMenuItem.Name = "WorkerSetForemanMenuItem";
            this.WorkerSetForemanMenuItem.Size = new System.Drawing.Size(136, 22);
            this.WorkerSetForemanMenuItem.Text = "设备班组长";
            this.WorkerSetForemanMenuItem.Click += new System.EventHandler(this.WorkerSetForemanMenuItem_Click);
            // 
            // btn_project_id
            // 
            this.btn_project_id.BackColor = System.Drawing.Color.Transparent;
            this.btn_project_id.BaseColor = System.Drawing.SystemColors.ControlDark;
            this.btn_project_id.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_project_id.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_project_id.DownBack = null;
            this.btn_project_id.Location = new System.Drawing.Point(372, 10);
            this.btn_project_id.MouseBack = null;
            this.btn_project_id.Name = "btn_project_id";
            this.btn_project_id.NormlBack = null;
            this.btn_project_id.Size = new System.Drawing.Size(75, 23);
            this.btn_project_id.TabIndex = 2;
            this.btn_project_id.Text = "查询项目";
            this.btn_project_id.UseVisualStyleBackColor = false;
            this.btn_project_id.Visible = false;
            this.btn_project_id.Click += new System.EventHandler(this.btn_project_id_Click);
            // 
            // TeamWorkerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 698);
            this.Controls.Add(this.btn_project_id);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeamWorkerList";
            this.Text = "班组工人";
            this.Load += new System.EventHandler(this.TeamWorkerList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TeamsCms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).EndInit();
            this.WorkerCms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox TeamsLb;
        private System.Windows.Forms.ContextMenuStrip TeamsCms;
        private System.Windows.Forms.ToolStripMenuItem TeamWorkerAddMenuItem;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.ToolStripMenuItem WorkerEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerDelMenuItem;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ComboBox WorkerAuthenticationStatesCb;
        private UserControls.KtpGridPager WorkersGridPager;
        private System.Windows.Forms.ToolStripMenuItem TeamReloadMenuItem;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.ToolStripMenuItem WorkerSeeMenuItem;
        private CCWin.SkinControl.SkinButton SearchButton;
        private System.Windows.Forms.ToolStripMenuItem con_tems_add;
        private System.Windows.Forms.ToolStripMenuItem exit_tems;
        private System.Windows.Forms.ToolStripMenuItem WorkerSetForemanMenuItem;
        private CCWin.SkinControl.SkinButton btnSyn_ktp;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthenticationStateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ktpMag;
        private CCWin.SkinControl.SkinButton btn_project_id;
    }
}