namespace kmfe.editor
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
            全局修改ToolStripMenuItem = new ToolStripMenuItem();
            城市ToolStripMenuItem = new ToolStripMenuItem();
            港关ToolStripMenuItem = new ToolStripMenuItem();
            据点距离ToolStripMenuItem = new ToolStripMenuItem();
            州ToolStripMenuItem = new ToolStripMenuItem();
            地区ToolStripMenuItem = new ToolStripMenuItem();
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
            listView.Location = new Point(12, 27);
            listView.Name = "listView";
            listView.Size = new Size(776, 398);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.MouseDoubleClick += listViewMouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 菜单ToolStripMenuItem, 全局修改ToolStripMenuItem, 剧本修改ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            菜单ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 载入ToolStripMenuItem, 保存修改ToolStripMenuItem });
            菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            菜单ToolStripMenuItem.Size = new Size(44, 20);
            菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 载入ToolStripMenuItem
            // 
            载入ToolStripMenuItem.Name = "载入ToolStripMenuItem";
            载入ToolStripMenuItem.Size = new Size(122, 22);
            载入ToolStripMenuItem.Text = "载入";
            载入ToolStripMenuItem.Click += 载入ToolStripMenuItem_Click;
            // 
            // 保存修改ToolStripMenuItem
            // 
            保存修改ToolStripMenuItem.Name = "保存修改ToolStripMenuItem";
            保存修改ToolStripMenuItem.Size = new Size(122, 22);
            保存修改ToolStripMenuItem.Text = "保存修改";
            保存修改ToolStripMenuItem.Click += 保存修改ToolStripMenuItem_Click;
            // 
            // 全局修改ToolStripMenuItem
            // 
            全局修改ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 城市ToolStripMenuItem, 港关ToolStripMenuItem, 据点距离ToolStripMenuItem, 州ToolStripMenuItem, 地区ToolStripMenuItem });
            全局修改ToolStripMenuItem.Name = "全局修改ToolStripMenuItem";
            全局修改ToolStripMenuItem.Size = new Size(67, 20);
            全局修改ToolStripMenuItem.Text = "全局修改";
            // 
            // 城市ToolStripMenuItem
            // 
            城市ToolStripMenuItem.Name = "城市ToolStripMenuItem";
            城市ToolStripMenuItem.Size = new Size(123, 22);
            城市ToolStripMenuItem.Text = "城市";
            城市ToolStripMenuItem.Click += 城市ToolStripMenuItem_Click;
            // 
            // 港关ToolStripMenuItem
            // 
            港关ToolStripMenuItem.Name = "港关ToolStripMenuItem";
            港关ToolStripMenuItem.Size = new Size(123, 22);
            港关ToolStripMenuItem.Text = "港关";
            港关ToolStripMenuItem.Click += 港关ToolStripMenuItem_Click;
            // 
            // 据点距离ToolStripMenuItem
            // 
            据点距离ToolStripMenuItem.Name = "据点距离ToolStripMenuItem";
            据点距离ToolStripMenuItem.Size = new Size(123, 22);
            据点距离ToolStripMenuItem.Text = "据点相邻";
            据点距离ToolStripMenuItem.Click += 据点距离ToolStripMenuItem_Click;
            // 
            // 州ToolStripMenuItem
            // 
            州ToolStripMenuItem.Name = "州ToolStripMenuItem";
            州ToolStripMenuItem.Size = new Size(123, 22);
            州ToolStripMenuItem.Text = "州";
            州ToolStripMenuItem.Click += 州ToolStripMenuItem_Click;
            // 
            // 地区ToolStripMenuItem
            // 
            地区ToolStripMenuItem.Name = "地区ToolStripMenuItem";
            地区ToolStripMenuItem.Size = new Size(123, 22);
            地区ToolStripMenuItem.Text = "地区";
            地区ToolStripMenuItem.Click += 地区ToolStripMenuItem_Click;
            // 
            // 剧本修改ToolStripMenuItem
            // 
            剧本修改ToolStripMenuItem.Name = "剧本修改ToolStripMenuItem";
            剧本修改ToolStripMenuItem.Size = new Size(68, 20);
            剧本修改ToolStripMenuItem.Text = "剧本修改";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel_currentType });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_currentType
            // 
            statusLabel_currentType.Name = "statusLabel_currentType";
            statusLabel_currentType.Size = new Size(32, 17);
            statusLabel_currentType.Text = "首页";
            // 
            // ScenarioConfigEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(listView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
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
    }
}