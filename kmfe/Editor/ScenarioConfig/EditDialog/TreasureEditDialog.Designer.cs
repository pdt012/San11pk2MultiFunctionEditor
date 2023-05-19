namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    partial class TreasureEditDialog
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
            value_worth = new Forms.DecimalBox();
            combo_type = new ComboBox();
            text_name = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonCancel = new Button();
            buttonApply = new Button();
            label5 = new Label();
            label6 = new Label();
            text_read = new TextBox();
            label7 = new Label();
            text_history = new TextBox();
            text_image = new TextBox();
            combo_skill = new ComboBox();
            label8 = new Label();
            picture_image = new PictureBox();
            decimalBox1 = new Forms.DecimalBox();
            label9 = new Label();
            decimalBox2 = new Forms.DecimalBox();
            label10 = new Label();
            decimalBox3 = new Forms.DecimalBox();
            label11 = new Label();
            decimalBox4 = new Forms.DecimalBox();
            label12 = new Label();
            decimalBox5 = new Forms.DecimalBox();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)value_worth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_image).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox5).BeginInit();
            SuspendLayout();
            // 
            // text_id
            // 
            text_id.AutoSize = true;
            text_id.BackColor = SystemColors.Control;
            text_id.BorderStyle = BorderStyle.FixedSingle;
            text_id.Location = new Point(57, 12);
            text_id.Margin = new Padding(3);
            text_id.MinimumSize = new Size(60, 27);
            text_id.Name = "text_id";
            text_id.Size = new Size(60, 27);
            text_id.TabIndex = 35;
            text_id.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // value_worth
            // 
            value_worth.BorderStyle = BorderStyle.FixedSingle;
            value_worth.Location = new Point(168, 79);
            value_worth.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            value_worth.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            value_worth.Name = "value_worth";
            value_worth.Size = new Size(60, 27);
            value_worth.TabIndex = 5;
            value_worth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // combo_type
            // 
            combo_type.FormattingEnabled = true;
            combo_type.Location = new Point(57, 78);
            combo_type.Name = "combo_type";
            combo_type.Size = new Size(65, 28);
            combo_type.TabIndex = 4;
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(57, 45);
            text_name.Name = "text_name";
            text_name.Size = new Size(120, 27);
            text_name.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(128, 81);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 33;
            label4.Text = "价值";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 31;
            label3.Text = "类型";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 29;
            label2.Text = "名称";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 14);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 28;
            label1.Text = "ID";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(463, 266);
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
            buttonApply.Location = new Point(359, 266);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 33);
            buttonApply.TabIndex = 1;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(183, 47);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 38;
            label5.Text = "读音";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 120);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 39;
            label6.Text = "列传";
            // 
            // text_read
            // 
            text_read.BorderStyle = BorderStyle.FixedSingle;
            text_read.Location = new Point(228, 45);
            text_read.Name = "text_read";
            text_read.Size = new Size(221, 27);
            text_read.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(123, 14);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 41;
            label7.Text = "图片";
            // 
            // text_history
            // 
            text_history.BorderStyle = BorderStyle.FixedSingle;
            text_history.Location = new Point(57, 118);
            text_history.Multiline = true;
            text_history.Name = "text_history";
            text_history.Size = new Size(504, 105);
            text_history.TabIndex = 7;
            // 
            // text_image
            // 
            text_image.BorderStyle = BorderStyle.FixedSingle;
            text_image.Location = new Point(168, 12);
            text_image.Name = "text_image";
            text_image.ReadOnly = true;
            text_image.Size = new Size(281, 27);
            text_image.TabIndex = 43;
            // 
            // combo_skill
            // 
            combo_skill.FormattingEnabled = true;
            combo_skill.Location = new Point(279, 78);
            combo_skill.Name = "combo_skill";
            combo_skill.Size = new Size(100, 28);
            combo_skill.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(234, 81);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 45;
            label8.Text = "特技";
            // 
            // picture_image
            // 
            picture_image.BorderStyle = BorderStyle.Fixed3D;
            picture_image.Location = new Point(460, 12);
            picture_image.Name = "picture_image";
            picture_image.Size = new Size(100, 100);
            picture_image.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_image.TabIndex = 46;
            picture_image.TabStop = false;
            picture_image.Click += picture_image_Click;
            // 
            // decimalBox1
            // 
            decimalBox1.BorderStyle = BorderStyle.FixedSingle;
            decimalBox1.Location = new Point(57, 229);
            decimalBox1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            decimalBox1.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            decimalBox1.Name = "decimalBox1";
            decimalBox1.Size = new Size(60, 27);
            decimalBox1.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 232);
            label9.Name = "label9";
            label9.Size = new Size(39, 20);
            label9.TabIndex = 47;
            label9.Text = "统率";
            // 
            // decimalBox2
            // 
            decimalBox2.BorderStyle = BorderStyle.FixedSingle;
            decimalBox2.Location = new Point(168, 229);
            decimalBox2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            decimalBox2.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            decimalBox2.Name = "decimalBox2";
            decimalBox2.Size = new Size(60, 27);
            decimalBox2.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(123, 232);
            label10.Name = "label10";
            label10.Size = new Size(39, 20);
            label10.TabIndex = 49;
            label10.Text = "武力";
            // 
            // decimalBox3
            // 
            decimalBox3.BorderStyle = BorderStyle.FixedSingle;
            decimalBox3.Location = new Point(279, 229);
            decimalBox3.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            decimalBox3.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            decimalBox3.Name = "decimalBox3";
            decimalBox3.Size = new Size(60, 27);
            decimalBox3.TabIndex = 10;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(234, 232);
            label11.Name = "label11";
            label11.Size = new Size(39, 20);
            label11.TabIndex = 51;
            label11.Text = "智力";
            // 
            // decimalBox4
            // 
            decimalBox4.BorderStyle = BorderStyle.FixedSingle;
            decimalBox4.Location = new Point(390, 229);
            decimalBox4.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            decimalBox4.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            decimalBox4.Name = "decimalBox4";
            decimalBox4.Size = new Size(60, 27);
            decimalBox4.TabIndex = 11;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(345, 232);
            label12.Name = "label12";
            label12.Size = new Size(39, 20);
            label12.TabIndex = 53;
            label12.Text = "政治";
            // 
            // decimalBox5
            // 
            decimalBox5.BorderStyle = BorderStyle.FixedSingle;
            decimalBox5.Location = new Point(501, 229);
            decimalBox5.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            decimalBox5.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            decimalBox5.Name = "decimalBox5";
            decimalBox5.Size = new Size(60, 27);
            decimalBox5.TabIndex = 12;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(456, 232);
            label13.Name = "label13";
            label13.Size = new Size(39, 20);
            label13.TabIndex = 55;
            label13.Text = "魅力";
            // 
            // TreasureEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 313);
            Controls.Add(decimalBox5);
            Controls.Add(label13);
            Controls.Add(decimalBox4);
            Controls.Add(label12);
            Controls.Add(decimalBox3);
            Controls.Add(label11);
            Controls.Add(decimalBox2);
            Controls.Add(label10);
            Controls.Add(decimalBox1);
            Controls.Add(label9);
            Controls.Add(picture_image);
            Controls.Add(label8);
            Controls.Add(combo_skill);
            Controls.Add(text_image);
            Controls.Add(text_history);
            Controls.Add(label7);
            Controls.Add(text_read);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(text_id);
            Controls.Add(value_worth);
            Controls.Add(combo_type);
            Controls.Add(text_name);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TreasureEditDialog";
            Text = "宝物编辑";
            ((System.ComponentModel.ISupportInitialize)value_worth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_image).EndInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)decimalBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label text_id;
        private Forms.DecimalBox value_worth;
        private ComboBox combo_type;
        private TextBox text_name;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button buttonCancel;
        private Button buttonApply;
        private Label label5;
        private Label label6;
        private TextBox text_read;
        private Label label7;
        private TextBox text_history;
        private TextBox text_image;
        private ComboBox combo_skill;
        private Label label8;
        private PictureBox picture_image;
        private Forms.DecimalBox decimalBox1;
        private Label label9;
        private Forms.DecimalBox decimalBox2;
        private Label label10;
        private Forms.DecimalBox decimalBox3;
        private Label label11;
        private Forms.DecimalBox decimalBox4;
        private Label label12;
        private Forms.DecimalBox decimalBox5;
        private Label label13;
    }
}