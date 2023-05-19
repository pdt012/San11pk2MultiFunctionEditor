namespace kmfe.Editor.ScenarioConfig
{
    partial class InExportToExcelDialog
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
            checkedListBox = new CheckedListBox();
            btn_ok = new Button();
            text_edit_type = new TextBox();
            btn_choose_all = new Button();
            btn_cancel_all = new Button();
            SuspendLayout();
            // 
            // checkedListBox
            // 
            checkedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox.CheckOnClick = true;
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" });
            checkedListBox.Location = new Point(12, 80);
            checkedListBox.MultiColumn = true;
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(458, 136);
            checkedListBox.TabIndex = 1;
            // 
            // btn_ok
            // 
            btn_ok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_ok.Location = new Point(370, 12);
            btn_ok.Margin = new Padding(4, 5, 4, 5);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new Size(100, 38);
            btn_ok.TabIndex = 0;
            btn_ok.Text = "导入/导出";
            btn_ok.UseVisualStyleBackColor = true;
            btn_ok.Click += btn_ok_Click;
            // 
            // text_edit_type
            // 
            text_edit_type.BackColor = SystemColors.Control;
            text_edit_type.BorderStyle = BorderStyle.FixedSingle;
            text_edit_type.Enabled = false;
            text_edit_type.Location = new Point(12, 12);
            text_edit_type.Name = "text_edit_type";
            text_edit_type.ReadOnly = true;
            text_edit_type.Size = new Size(194, 27);
            text_edit_type.TabIndex = 4;
            text_edit_type.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_choose_all
            // 
            btn_choose_all.Location = new Point(12, 45);
            btn_choose_all.Name = "btn_choose_all";
            btn_choose_all.Size = new Size(94, 29);
            btn_choose_all.TabIndex = 2;
            btn_choose_all.Text = "全部选中";
            btn_choose_all.UseVisualStyleBackColor = true;
            btn_choose_all.Click += btn_choose_all_Click;
            // 
            // btn_cancel_all
            // 
            btn_cancel_all.Location = new Point(112, 45);
            btn_cancel_all.Name = "btn_cancel_all";
            btn_cancel_all.Size = new Size(94, 29);
            btn_cancel_all.TabIndex = 3;
            btn_cancel_all.Text = "全部取消";
            btn_cancel_all.UseVisualStyleBackColor = true;
            btn_cancel_all.Click += btn_cancel_all_Click;
            // 
            // InExportToExcelDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 233);
            Controls.Add(btn_cancel_all);
            Controls.Add(btn_choose_all);
            Controls.Add(text_edit_type);
            Controls.Add(btn_ok);
            Controls.Add(checkedListBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InExportToExcelDialog";
            Text = "Excel导入/导出";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckedListBox checkedListBox;
        private Button btn_ok;
        private TextBox text_edit_type;
        private Button btn_choose_all;
        private Button btn_cancel_all;
    }
}