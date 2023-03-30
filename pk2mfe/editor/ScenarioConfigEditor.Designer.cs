using System.Drawing;
using System.Windows.Forms;

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
            this.listView = new kmfe.forms.DoubleBufferListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全局修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.城市ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.港关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.据点距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.州ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地区ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剧本修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_currentType = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 22);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(760, 415);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.全局修改ToolStripMenuItem,
            this.剧本修改ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.载入ToolStripMenuItem,
            this.保存修改ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 载入ToolStripMenuItem
            // 
            this.载入ToolStripMenuItem.Name = "载入ToolStripMenuItem";
            this.载入ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.载入ToolStripMenuItem.Text = "载入";
            this.载入ToolStripMenuItem.Click += new System.EventHandler(this.载入ToolStripMenuItem_Click);
            // 
            // 保存修改ToolStripMenuItem
            // 
            this.保存修改ToolStripMenuItem.Name = "保存修改ToolStripMenuItem";
            this.保存修改ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存修改ToolStripMenuItem.Text = "保存修改";
            this.保存修改ToolStripMenuItem.Click += new System.EventHandler(this.保存修改ToolStripMenuItem_Click);
            // 
            // 全局修改ToolStripMenuItem
            // 
            this.全局修改ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.城市ToolStripMenuItem,
            this.港关ToolStripMenuItem,
            this.据点距离ToolStripMenuItem,
            this.州ToolStripMenuItem,
            this.地区ToolStripMenuItem});
            this.全局修改ToolStripMenuItem.Name = "全局修改ToolStripMenuItem";
            this.全局修改ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.全局修改ToolStripMenuItem.Text = "全局修改";
            // 
            // 城市ToolStripMenuItem
            // 
            this.城市ToolStripMenuItem.Name = "城市ToolStripMenuItem";
            this.城市ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.城市ToolStripMenuItem.Text = "城市";
            this.城市ToolStripMenuItem.Click += new System.EventHandler(this.城市ToolStripMenuItem_Click);
            // 
            // 港关ToolStripMenuItem
            // 
            this.港关ToolStripMenuItem.Name = "港关ToolStripMenuItem";
            this.港关ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.港关ToolStripMenuItem.Text = "港关";
            this.港关ToolStripMenuItem.Click += new System.EventHandler(this.港关ToolStripMenuItem_Click);
            // 
            // 据点距离ToolStripMenuItem
            // 
            this.据点距离ToolStripMenuItem.Name = "据点距离ToolStripMenuItem";
            this.据点距离ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.据点距离ToolStripMenuItem.Text = "据点相邻";
            this.据点距离ToolStripMenuItem.Click += new System.EventHandler(this.据点距离ToolStripMenuItem_Click);
            // 
            // 州ToolStripMenuItem
            // 
            this.州ToolStripMenuItem.Name = "州ToolStripMenuItem";
            this.州ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.州ToolStripMenuItem.Text = "州";
            this.州ToolStripMenuItem.Click += new System.EventHandler(this.州ToolStripMenuItem_Click);
            // 
            // 地区ToolStripMenuItem
            // 
            this.地区ToolStripMenuItem.Name = "地区ToolStripMenuItem";
            this.地区ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.地区ToolStripMenuItem.Text = "地区";
            this.地区ToolStripMenuItem.Click += new System.EventHandler(this.地区ToolStripMenuItem_Click);
            // 
            // 剧本修改ToolStripMenuItem
            // 
            this.剧本修改ToolStripMenuItem.Name = "剧本修改ToolStripMenuItem";
            this.剧本修改ToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.剧本修改ToolStripMenuItem.Text = "剧本修改";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_currentType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_currentType
            // 
            this.statusLabel_currentType.Name = "statusLabel_currentType";
            this.statusLabel_currentType.Size = new System.Drawing.Size(32, 17);
            this.statusLabel_currentType.Text = "首页";
            // 
            // ScenarioConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ScenarioConfigEditor";
            this.Text = "剧本及全局配置修改器 - by 氕氘氚";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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