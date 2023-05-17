namespace kmfe.editor.scenarioConfig.editDialog
{
    partial class ProvinceEditDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProvinceEditDialog));
            buttonCancel = new Button();
            buttonApply = new Button();
            text_id = new Label();
            label1 = new Label();
            text_name = new TextBox();
            label2 = new Label();
            label3 = new Label();
            text_read = new TextBox();
            choose_adjacent = new forms.ChooseBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            text_desc = new TextBox();
            combo_region = new ComboBox();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(293, 236);
            buttonCancel.Margin = new Padding(4, 5, 4, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 33);
            buttonCancel.TabIndex = 47;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.Location = new Point(189, 236);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 33);
            buttonApply.TabIndex = 48;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // text_id
            // 
            text_id.AutoSize = true;
            text_id.BackColor = SystemColors.Control;
            text_id.BorderStyle = BorderStyle.FixedSingle;
            text_id.Location = new Point(67, 12);
            text_id.Margin = new Padding(3);
            text_id.MinimumSize = new Size(60, 27);
            text_id.Name = "text_id";
            text_id.Size = new Size(60, 27);
            text_id.TabIndex = 46;
            text_id.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 14);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 45;
            label1.Text = "ID";
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(178, 12);
            text_name.Name = "text_name";
            text_name.Size = new Size(60, 27);
            text_name.TabIndex = 43;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 14);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 44;
            label2.Text = "名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(244, 14);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 49;
            label3.Text = "读音";
            // 
            // text_read
            // 
            text_read.BorderStyle = BorderStyle.FixedSingle;
            text_read.Location = new Point(289, 12);
            text_read.Name = "text_read";
            text_read.Size = new Size(100, 27);
            text_read.TabIndex = 50;
            // 
            // choose_adjacent
            // 
            choose_adjacent.Location = new Point(67, 79);
            choose_adjacent.Margin = new Padding(3, 4, 3, 4);
            choose_adjacent.MaxSelections = -1;
            choose_adjacent.Name = "choose_adjacent";
            choose_adjacent.ShowCloseBtn = false;
            choose_adjacent.Size = new Size(322, 147);
            choose_adjacent.TabIndex = 51;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 47);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 52;
            label4.Text = "\u007f介绍";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(244, 47);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 53;
            label5.Text = "地区";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 79);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 54;
            label6.Text = "相邻州";
            // 
            // text_desc
            // 
            text_desc.BorderStyle = BorderStyle.FixedSingle;
            text_desc.Location = new Point(67, 45);
            text_desc.Name = "text_desc";
            text_desc.Size = new Size(171, 27);
            text_desc.TabIndex = 55;
            // 
            // combo_region
            // 
            combo_region.FormattingEnabled = true;
            combo_region.Location = new Point(289, 45);
            combo_region.Name = "combo_region";
            combo_region.Size = new Size(100, 28);
            combo_region.TabIndex = 56;
            // 
            // ProvinceEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 283);
            Controls.Add(combo_region);
            Controls.Add(text_desc);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(choose_adjacent);
            Controls.Add(text_read);
            Controls.Add(label3);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(text_id);
            Controls.Add(label1);
            Controls.Add(text_name);
            Controls.Add(label2);
            Name = "ProvinceEditDialog";
            Text = "州编辑";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonApply;
        private Label text_id;
        private Label label1;
        private TextBox text_name;
        private Label label2;
        private Label label3;
        private TextBox text_read;
        private forms.ChooseBox choose_adjacent;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox text_desc;
        private ComboBox combo_region;
    }
}