namespace kmfe.forms
{
    partial class ChooseBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            chosen_list = new ListBox();
            panel1 = new Panel();
            label2 = new Label();
            close_btn = new Button();
            label1 = new Label();
            search_input = new TextBox();
            choice_list = new ListBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(chosen_list, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(search_input, 1, 1);
            tableLayoutPanel1.Controls.Add(choice_list, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(300, 249);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // chosen_list
            // 
            chosen_list.BorderStyle = BorderStyle.FixedSingle;
            chosen_list.Dock = DockStyle.Fill;
            chosen_list.FormattingEnabled = true;
            chosen_list.IntegralHeight = false;
            chosen_list.ItemHeight = 20;
            chosen_list.Location = new Point(0, 22);
            chosen_list.Margin = new Padding(0, 2, 3, 2);
            chosen_list.Name = "chosen_list";
            tableLayoutPanel1.SetRowSpan(chosen_list, 2);
            chosen_list.Size = new Size(147, 225);
            chosen_list.TabIndex = 6;
            chosen_list.MouseDoubleClick += chosen_list_MouseDoubleClick;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(close_btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(150, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 20);
            panel1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(0, 0);
            label2.MaximumSize = new Size(1000, 20);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 1;
            label2.Text = "选项↓";
            // 
            // close_btn
            // 
            close_btn.BackgroundImage = Properties.Resources.close;
            close_btn.BackgroundImageLayout = ImageLayout.Stretch;
            close_btn.Dock = DockStyle.Right;
            close_btn.Location = new Point(129, 0);
            close_btn.Margin = new Padding(0);
            close_btn.MaximumSize = new Size(21, 20);
            close_btn.MinimumSize = new Size(21, 20);
            close_btn.Name = "close_btn";
            close_btn.RightToLeft = RightToLeft.Yes;
            close_btn.Size = new Size(21, 20);
            close_btn.TabIndex = 3;
            close_btn.UseVisualStyleBackColor = true;
            close_btn.Click += close_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(3, 0);
            label1.MaximumSize = new Size(1000, 20);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 0;
            label1.Text = "已选择↓";
            // 
            // search_input
            // 
            search_input.BorderStyle = BorderStyle.FixedSingle;
            search_input.Dock = DockStyle.Fill;
            search_input.Location = new Point(153, 22);
            search_input.Margin = new Padding(3, 2, 0, 2);
            search_input.MaximumSize = new Size(10000, 24);
            search_input.MinimumSize = new Size(2, 24);
            search_input.Name = "search_input";
            search_input.PlaceholderText = "搜索...";
            search_input.Size = new Size(147, 24);
            search_input.TabIndex = 2;
            search_input.TextChanged += search_input_TextChanged;
            // 
            // choice_list
            // 
            choice_list.BorderStyle = BorderStyle.FixedSingle;
            choice_list.Dock = DockStyle.Fill;
            choice_list.FormattingEnabled = true;
            choice_list.IntegralHeight = false;
            choice_list.ItemHeight = 20;
            choice_list.Location = new Point(153, 50);
            choice_list.Margin = new Padding(3, 2, 0, 2);
            choice_list.Name = "choice_list";
            choice_list.Size = new Size(147, 197);
            choice_list.TabIndex = 7;
            choice_list.MouseDoubleClick += choice_list_MouseDoubleClick;
            // 
            // ChooseBox
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChooseBox";
            Size = new Size(300, 249);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Button close_btn;
        private TextBox search_input;
        private Panel panel1;
        private ListBox chosen_list;
        private ListBox choice_list;
    }
}
