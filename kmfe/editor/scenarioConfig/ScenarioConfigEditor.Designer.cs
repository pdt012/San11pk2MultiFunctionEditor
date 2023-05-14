namespace kmfe.editor.scenarioConfig
{
    partial class ScenarioConfigEditor
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
            listView = new forms.DoubleBufferListView();
            menuStrip1 = new MenuStrip();
            菜单ToolStripMenuItem = new ToolStripMenuItem();
            载入ToolStripMenuItem = new ToolStripMenuItem();
            保存修改ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            全局修改ToolStripMenuItem = new ToolStripMenuItem();
            城市ToolStripMenuItem = new ToolStripMenuItem();
            港关ToolStripMenuItem = new ToolStripMenuItem();
            据点距离ToolStripMenuItem = new ToolStripMenuItem();
            州ToolStripMenuItem = new ToolStripMenuItem();
            地区ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            爵位ToolStripMenuItem = new ToolStripMenuItem();
            官职ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            特技ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            适性ToolStripMenuItem = new ToolStripMenuItem();
            地形ToolStripMenuItem = new ToolStripMenuItem();
            设施ToolStripMenuItem = new ToolStripMenuItem();
            兵器ToolStripMenuItem = new ToolStripMenuItem();
            战法ToolStripMenuItem = new ToolStripMenuItem();
            技术ToolStripMenuItem = new ToolStripMenuItem();
            能力ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            宝物ToolStripMenuItem = new ToolStripMenuItem();
            剧本修改ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabel_currentType = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView.FullRowSelect = true;
            listView.Location = new Point(15, 36);
            listView.Margin = new Padding(4);
            listView.Name = "listView";
            listView.Size = new Size(997, 529);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.MouseClick += listView_MouseClick;
            listView.MouseDoubleClick += listView_MouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 菜单ToolStripMenuItem, 全局修改ToolStripMenuItem, 剧本修改ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.Size = new Size(1029, 30);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            菜单ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 载入ToolStripMenuItem, 保存修改ToolStripMenuItem, toolStripSeparator5, 设置ToolStripMenuItem });
            菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            菜单ToolStripMenuItem.Size = new Size(53, 24);
            菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 载入ToolStripMenuItem
            // 
            载入ToolStripMenuItem.Name = "载入ToolStripMenuItem";
            载入ToolStripMenuItem.Size = new Size(224, 26);
            载入ToolStripMenuItem.Text = "载入";
            载入ToolStripMenuItem.Click += 载入ToolStripMenuItem_Click;
            // 
            // 保存修改ToolStripMenuItem
            // 
            保存修改ToolStripMenuItem.Name = "保存修改ToolStripMenuItem";
            保存修改ToolStripMenuItem.Size = new Size(224, 26);
            保存修改ToolStripMenuItem.Text = "保存修改";
            保存修改ToolStripMenuItem.Click += 保存修改ToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(221, 6);
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(224, 26);
            设置ToolStripMenuItem.Text = "设置";
            设置ToolStripMenuItem.Click += 设置ToolStripMenuItem_Click;
            // 
            // 全局修改ToolStripMenuItem
            // 
            全局修改ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 城市ToolStripMenuItem, 港关ToolStripMenuItem, 据点距离ToolStripMenuItem, 州ToolStripMenuItem, 地区ToolStripMenuItem, toolStripSeparator1, 爵位ToolStripMenuItem, 官职ToolStripMenuItem, toolStripSeparator2, 特技ToolStripMenuItem, toolStripSeparator3, 适性ToolStripMenuItem, 地形ToolStripMenuItem, 设施ToolStripMenuItem, 兵器ToolStripMenuItem, 战法ToolStripMenuItem, 技术ToolStripMenuItem, 能力ToolStripMenuItem, toolStripSeparator4, 宝物ToolStripMenuItem });
            全局修改ToolStripMenuItem.Name = "全局修改ToolStripMenuItem";
            全局修改ToolStripMenuItem.Size = new Size(83, 24);
            全局修改ToolStripMenuItem.Text = "全局修改";
            // 
            // 城市ToolStripMenuItem
            // 
            城市ToolStripMenuItem.Name = "城市ToolStripMenuItem";
            城市ToolStripMenuItem.Size = new Size(224, 26);
            城市ToolStripMenuItem.Text = "城市";
            // 
            // 港关ToolStripMenuItem
            // 
            港关ToolStripMenuItem.Name = "港关ToolStripMenuItem";
            港关ToolStripMenuItem.Size = new Size(224, 26);
            港关ToolStripMenuItem.Text = "港关";
            // 
            // 据点距离ToolStripMenuItem
            // 
            据点距离ToolStripMenuItem.Name = "据点距离ToolStripMenuItem";
            据点距离ToolStripMenuItem.Size = new Size(224, 26);
            据点距离ToolStripMenuItem.Text = "据点相邻";
            // 
            // 州ToolStripMenuItem
            // 
            州ToolStripMenuItem.Name = "州ToolStripMenuItem";
            州ToolStripMenuItem.Size = new Size(224, 26);
            州ToolStripMenuItem.Text = "州";
            // 
            // 地区ToolStripMenuItem
            // 
            地区ToolStripMenuItem.Name = "地区ToolStripMenuItem";
            地区ToolStripMenuItem.Size = new Size(224, 26);
            地区ToolStripMenuItem.Text = "地区";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // 爵位ToolStripMenuItem
            // 
            爵位ToolStripMenuItem.Name = "爵位ToolStripMenuItem";
            爵位ToolStripMenuItem.Size = new Size(224, 26);
            爵位ToolStripMenuItem.Text = "爵位";
            // 
            // 官职ToolStripMenuItem
            // 
            官职ToolStripMenuItem.Name = "官职ToolStripMenuItem";
            官职ToolStripMenuItem.Size = new Size(224, 26);
            官职ToolStripMenuItem.Text = "官职";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // 特技ToolStripMenuItem
            // 
            特技ToolStripMenuItem.Name = "特技ToolStripMenuItem";
            特技ToolStripMenuItem.Size = new Size(224, 26);
            特技ToolStripMenuItem.Text = "特技";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(221, 6);
            // 
            // 适性ToolStripMenuItem
            // 
            适性ToolStripMenuItem.Name = "适性ToolStripMenuItem";
            适性ToolStripMenuItem.Size = new Size(224, 26);
            适性ToolStripMenuItem.Text = "适性";
            // 
            // 地形ToolStripMenuItem
            // 
            地形ToolStripMenuItem.Name = "地形ToolStripMenuItem";
            地形ToolStripMenuItem.Size = new Size(224, 26);
            地形ToolStripMenuItem.Text = "地形";
            // 
            // 设施ToolStripMenuItem
            // 
            设施ToolStripMenuItem.Name = "设施ToolStripMenuItem";
            设施ToolStripMenuItem.Size = new Size(224, 26);
            设施ToolStripMenuItem.Text = "设施";
            // 
            // 兵器ToolStripMenuItem
            // 
            兵器ToolStripMenuItem.Name = "兵器ToolStripMenuItem";
            兵器ToolStripMenuItem.Size = new Size(224, 26);
            兵器ToolStripMenuItem.Text = "兵器";
            // 
            // 战法ToolStripMenuItem
            // 
            战法ToolStripMenuItem.Name = "战法ToolStripMenuItem";
            战法ToolStripMenuItem.Size = new Size(224, 26);
            战法ToolStripMenuItem.Text = "战法";
            // 
            // 技术ToolStripMenuItem
            // 
            技术ToolStripMenuItem.Name = "技术ToolStripMenuItem";
            技术ToolStripMenuItem.Size = new Size(224, 26);
            技术ToolStripMenuItem.Text = "技术";
            // 
            // 能力ToolStripMenuItem
            // 
            能力ToolStripMenuItem.Name = "能力ToolStripMenuItem";
            能力ToolStripMenuItem.Size = new Size(224, 26);
            能力ToolStripMenuItem.Text = "能力";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(221, 6);
            // 
            // 宝物ToolStripMenuItem
            // 
            宝物ToolStripMenuItem.Name = "宝物ToolStripMenuItem";
            宝物ToolStripMenuItem.Size = new Size(224, 26);
            宝物ToolStripMenuItem.Text = "宝物";
            // 
            // 剧本修改ToolStripMenuItem
            // 
            剧本修改ToolStripMenuItem.Name = "剧本修改ToolStripMenuItem";
            剧本修改ToolStripMenuItem.Size = new Size(83, 24);
            剧本修改ToolStripMenuItem.Text = "剧本修改";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel_currentType });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1029, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_currentType
            // 
            statusLabel_currentType.Name = "statusLabel_currentType";
            statusLabel_currentType.Size = new Size(39, 20);
            statusLabel_currentType.Text = "首页";
            // 
            // ScenarioConfigEditor
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 600);
            Controls.Add(statusStrip1);
            Controls.Add(listView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "ScenarioConfigEditor";
            Text = "剧本及全局配置修改器 - by 氕氘氚";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private forms.DoubleBufferListView listView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 菜单ToolStripMenuItem;
        private ToolStripMenuItem 载入ToolStripMenuItem;
        private ToolStripMenuItem 保存修改ToolStripMenuItem;
        private ToolStripMenuItem 全局修改ToolStripMenuItem;
        private ToolStripMenuItem 城市ToolStripMenuItem;
        private ToolStripMenuItem 港关ToolStripMenuItem;
        private ToolStripMenuItem 据点距离ToolStripMenuItem;
        private ToolStripMenuItem 州ToolStripMenuItem;
        private ToolStripMenuItem 地区ToolStripMenuItem;
        private ToolStripMenuItem 剧本修改ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel_currentType;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 特技ToolStripMenuItem;
        private ToolStripMenuItem 爵位ToolStripMenuItem;
        private ToolStripMenuItem 官职ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem 宝物ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem 适性ToolStripMenuItem;
        private ToolStripMenuItem 地形ToolStripMenuItem;
        private ToolStripMenuItem 设施ToolStripMenuItem;
        private ToolStripMenuItem 兵器ToolStripMenuItem;
        private ToolStripMenuItem 战法ToolStripMenuItem;
        private ToolStripMenuItem 技术ToolStripMenuItem;
        private ToolStripMenuItem 能力ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem 设置ToolStripMenuItem;
    }
}