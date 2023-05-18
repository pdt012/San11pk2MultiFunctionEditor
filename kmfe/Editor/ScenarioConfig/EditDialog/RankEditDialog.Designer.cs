namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    partial class RankEditDialog
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
            text_id = new Label();
            label1 = new Label();
            buttonCancel = new Button();
            buttonApply = new Button();
            value_command = new Forms.DecimalBox();
            label3 = new Label();
            text_name = new TextBox();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            combo_stat_type = new ComboBox();
            value_stat_increase = new Forms.DecimalBox();
            value_salary = new Forms.DecimalBox();
            label6 = new Label();
            value_rank_level = new Forms.DecimalBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)value_command).BeginInit();
            ((System.ComponentModel.ISupportInitialize)value_stat_increase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)value_salary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)value_rank_level).BeginInit();
            SuspendLayout();
            // 
            // text_id
            // 
            text_id.AutoSize = true;
            text_id.BackColor = SystemColors.Control;
            text_id.BorderStyle = BorderStyle.FixedSingle;
            text_id.Location = new Point(85, 12);
            text_id.Margin = new Padding(3);
            text_id.MinimumSize = new Size(60, 27);
            text_id.Name = "text_id";
            text_id.Size = new Size(60, 27);
            text_id.TabIndex = 36;
            text_id.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 14);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 35;
            label1.Text = "ID";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(223, 156);
            buttonCancel.Margin = new Padding(4, 5, 4, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 33);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.Location = new Point(119, 156);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 33);
            buttonApply.TabIndex = 1;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // value_command
            // 
            value_command.BorderStyle = BorderStyle.FixedSingle;
            value_command.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            value_command.Location = new Point(226, 45);
            value_command.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            value_command.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            value_command.Name = "value_command";
            value_command.Size = new Size(85, 27);
            value_command.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(151, 47);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 31;
            label3.Text = "最大指挥";
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(226, 12);
            text_name.Name = "text_name";
            text_name.Size = new Size(85, 27);
            text_name.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 14);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 29;
            label2.Text = "名称";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 81);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 37;
            label4.Text = "上升能力";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(166, 81);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 38;
            label5.Text = "上升值";
            // 
            // combo_stat_type
            // 
            combo_stat_type.FormattingEnabled = true;
            combo_stat_type.Location = new Point(85, 78);
            combo_stat_type.Name = "combo_stat_type";
            combo_stat_type.Size = new Size(60, 28);
            combo_stat_type.TabIndex = 5;
            // 
            // value_stat_increase
            // 
            value_stat_increase.BorderStyle = BorderStyle.FixedSingle;
            value_stat_increase.Location = new Point(226, 78);
            value_stat_increase.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            value_stat_increase.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            value_stat_increase.Name = "value_stat_increase";
            value_stat_increase.Size = new Size(60, 27);
            value_stat_increase.TabIndex = 6;
            // 
            // value_salary
            // 
            value_salary.BorderStyle = BorderStyle.FixedSingle;
            value_salary.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            value_salary.Location = new Point(226, 111);
            value_salary.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            value_salary.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            value_salary.Name = "value_salary";
            value_salary.Size = new Size(60, 27);
            value_salary.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(181, 113);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 41;
            label6.Text = "俸禄";
            // 
            // value_rank_level
            // 
            value_rank_level.BorderStyle = BorderStyle.FixedSingle;
            value_rank_level.Location = new Point(85, 45);
            value_rank_level.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            value_rank_level.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            value_rank_level.Name = "value_rank_level";
            value_rank_level.Size = new Size(60, 27);
            value_rank_level.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 47);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 43;
            label7.Text = "品阶";
            // 
            // RankEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 203);
            Controls.Add(value_rank_level);
            Controls.Add(label7);
            Controls.Add(value_salary);
            Controls.Add(label6);
            Controls.Add(value_stat_increase);
            Controls.Add(combo_stat_type);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(text_id);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(value_command);
            Controls.Add(label3);
            Controls.Add(text_name);
            Controls.Add(label2);
            Name = "RankEditDialog";
            Text = "官职编辑";
            ((System.ComponentModel.ISupportInitialize)value_command).EndInit();
            ((System.ComponentModel.ISupportInitialize)value_stat_increase).EndInit();
            ((System.ComponentModel.ISupportInitialize)value_salary).EndInit();
            ((System.ComponentModel.ISupportInitialize)value_rank_level).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label text_id;
        private Label label1;
        private Button buttonCancel;
        private Button buttonApply;
        private Forms.DecimalBox value_command;
        private Label label3;
        private TextBox text_name;
        private Label label2;
        private Label label4;
        private Label label5;
        private ComboBox combo_stat_type;
        private Forms.DecimalBox value_stat_increase;
        private Forms.DecimalBox value_salary;
        private Label label6;
        private Forms.DecimalBox value_rank_level;
        private Label label7;
    }
}