using kmfe.forms;

namespace kmfe.editor.scenarioConfig.editDialog
{
    partial class SkillEditDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillEditDialog));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            text_name = new TextBox();
            text_desc = new TextBox();
            text_type = new ComboBox();
            skill_binds = new ChooseBox();
            label6 = new Label();
            buttonCancel = new Button();
            buttonApply = new Button();
            value_level = new DecimalBox();
            text_id = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)value_level).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 16);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 16);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(242, 16);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "类型";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(358, 16);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "等级";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 49);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 4;
            label5.Text = "描述";
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(176, 14);
            text_name.Name = "text_name";
            text_name.Size = new Size(60, 27);
            text_name.TabIndex = 2;
            // 
            // text_desc
            // 
            text_desc.BorderStyle = BorderStyle.FixedSingle;
            text_desc.Location = new Point(65, 49);
            text_desc.Multiline = true;
            text_desc.Name = "text_desc";
            text_desc.Size = new Size(398, 48);
            text_desc.TabIndex = 5;
            // 
            // text_type
            // 
            text_type.FormattingEnabled = true;
            text_type.Location = new Point(287, 13);
            text_type.Name = "text_type";
            text_type.Size = new Size(65, 28);
            text_type.TabIndex = 3;
            // 
            // skill_binds
            // 
            skill_binds.Location = new Point(486, 40);
            skill_binds.Margin = new Padding(3, 4, 3, 4);
            skill_binds.MaxSelections = -1;
            skill_binds.Name = "skill_binds";
            skill_binds.ShowCloseBtn = false;
            skill_binds.Size = new Size(233, 187);
            skill_binds.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(486, 16);
            label6.Name = "label6";
            label6.Size = new Size(153, 20);
            label6.TabIndex = 11;
            label6.Text = "特技组合（最多8个）";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(623, 236);
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
            buttonApply.Location = new Point(519, 236);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 33);
            buttonApply.TabIndex = 1;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // value_level
            // 
            value_level.BorderStyle = BorderStyle.FixedSingle;
            value_level.Location = new Point(403, 14);
            value_level.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            value_level.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            value_level.Name = "value_level";
            value_level.Size = new Size(60, 27);
            value_level.TabIndex = 4;
            value_level.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // text_id
            // 
            text_id.AutoSize = true;
            text_id.BackColor = SystemColors.Control;
            text_id.BorderStyle = BorderStyle.FixedSingle;
            text_id.Location = new Point(65, 14);
            text_id.MinimumSize = new Size(60, 27);
            text_id.Name = "text_id";
            text_id.Size = new Size(60, 27);
            text_id.TabIndex = 27;
            text_id.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableLayoutPanel1.Controls.Add(checkBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(checkBox3, 0, 2);
            tableLayoutPanel1.Controls.Add(checkBox4, 0, 3);
            tableLayoutPanel1.Controls.Add(checkBox5, 0, 4);
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 3, 0);
            tableLayoutPanel1.Controls.Add(numericUpDown2, 3, 1);
            tableLayoutPanel1.Controls.Add(numericUpDown3, 3, 2);
            tableLayoutPanel1.Controls.Add(numericUpDown4, 3, 3);
            tableLayoutPanel1.Controls.Add(numericUpDown5, 3, 4);
            tableLayoutPanel1.Controls.Add(label8, 2, 1);
            tableLayoutPanel1.Controls.Add(label9, 2, 2);
            tableLayoutPanel1.Controls.Add(label10, 2, 3);
            tableLayoutPanel1.Controls.Add(label11, 2, 4);
            tableLayoutPanel1.Controls.Add(label7, 2, 0);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox3, 1, 2);
            tableLayoutPanel1.Controls.Add(textBox4, 1, 3);
            tableLayoutPanel1.Controls.Add(textBox5, 1, 4);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel1.Location = new Point(65, 103);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(398, 168);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Dock = DockStyle.Bottom;
            checkBox2.Location = new Point(3, 39);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(74, 24);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "参数 1";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Dock = DockStyle.Bottom;
            checkBox3.Location = new Point(3, 72);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(74, 24);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "参数 2";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Dock = DockStyle.Bottom;
            checkBox4.Location = new Point(3, 105);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(74, 24);
            checkBox4.TabIndex = 9;
            checkBox4.Text = "参数 3";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Dock = DockStyle.Bottom;
            checkBox5.Location = new Point(3, 138);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(74, 24);
            checkBox5.TabIndex = 12;
            checkBox5.Text = "参数 4";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Dock = DockStyle.Bottom;
            checkBox1.Location = new Point(3, 6);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(74, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "参数 0";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Bottom;
            numericUpDown1.Location = new Point(316, 3);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(79, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Dock = DockStyle.Bottom;
            numericUpDown2.Location = new Point(316, 36);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(79, 27);
            numericUpDown2.TabIndex = 5;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Dock = DockStyle.Bottom;
            numericUpDown3.Location = new Point(316, 69);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(79, 27);
            numericUpDown3.TabIndex = 8;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Dock = DockStyle.Bottom;
            numericUpDown4.Location = new Point(316, 102);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(79, 27);
            numericUpDown4.TabIndex = 11;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Dock = DockStyle.Bottom;
            numericUpDown5.Location = new Point(316, 135);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(79, 27);
            numericUpDown5.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Bottom;
            label8.Location = new Point(290, 38);
            label8.Margin = new Padding(3, 0, 3, 8);
            label8.Name = "label8";
            label8.Size = new Size(20, 20);
            label8.TabIndex = 30;
            label8.Text = "=";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Bottom;
            label9.Location = new Point(290, 71);
            label9.Margin = new Padding(3, 0, 3, 8);
            label9.Name = "label9";
            label9.Size = new Size(20, 20);
            label9.TabIndex = 31;
            label9.Text = "=";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Bottom;
            label10.Location = new Point(290, 104);
            label10.Margin = new Padding(3, 0, 3, 8);
            label10.Name = "label10";
            label10.Size = new Size(20, 20);
            label10.TabIndex = 32;
            label10.Text = "=";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Bottom;
            label11.Location = new Point(290, 137);
            label11.Margin = new Padding(3, 0, 3, 8);
            label11.Name = "label11";
            label11.Size = new Size(20, 20);
            label11.TabIndex = 33;
            label11.Text = "=";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Bottom;
            label7.Location = new Point(290, 5);
            label7.Margin = new Padding(3, 0, 3, 8);
            label7.Name = "label7";
            label7.Size = new Size(20, 20);
            label7.TabIndex = 29;
            label7.Text = "=";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Bottom;
            textBox2.Location = new Point(83, 36);
            textBox2.MaxLength = 12;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(201, 27);
            textBox2.TabIndex = 4;
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Bottom;
            textBox3.Location = new Point(83, 69);
            textBox3.MaxLength = 12;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(201, 27);
            textBox3.TabIndex = 7;
            textBox3.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Bottom;
            textBox4.Location = new Point(83, 102);
            textBox4.MaxLength = 12;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(201, 27);
            textBox4.TabIndex = 10;
            textBox4.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox5
            // 
            textBox5.Dock = DockStyle.Bottom;
            textBox5.Location = new Point(83, 135);
            textBox5.MaxLength = 12;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(201, 27);
            textBox5.TabIndex = 13;
            textBox5.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Location = new Point(83, 3);
            textBox1.MaxLength = 12;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 27);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // SkillEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 283);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(text_id);
            Controls.Add(value_level);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(label6);
            Controls.Add(skill_binds);
            Controls.Add(text_type);
            Controls.Add(text_desc);
            Controls.Add(text_name);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SkillEditDialog";
            Text = "特技编辑";
            ((System.ComponentModel.ISupportInitialize)value_level).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox text_name;
        private TextBox text_desc;
        private ComboBox text_type;
        private forms.ChooseBox skill_binds;
        private Label label6;
        private Button buttonCancel;
        private Button buttonApply;
        private DecimalBox value_level;
        private Label text_id;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label7;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox1;
    }
}