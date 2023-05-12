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
            ((System.ComponentModel.ISupportInitialize)value_level).BeginInit();
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
            label2.Location = new Point(20, 51);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(131, 51);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "类型";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(247, 51);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "等级";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 84);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 4;
            label5.Text = "描述";
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(65, 48);
            text_name.Name = "text_name";
            text_name.Size = new Size(60, 27);
            text_name.TabIndex = 2;
            // 
            // text_desc
            // 
            text_desc.BorderStyle = BorderStyle.FixedSingle;
            text_desc.Location = new Point(65, 81);
            text_desc.Multiline = true;
            text_desc.Name = "text_desc";
            text_desc.Size = new Size(287, 48);
            text_desc.TabIndex = 5;
            // 
            // text_type
            // 
            text_type.FormattingEnabled = true;
            text_type.Location = new Point(176, 48);
            text_type.Name = "text_type";
            text_type.Size = new Size(65, 28);
            text_type.TabIndex = 3;
            // 
            // skill_binds
            // 
            skill_binds.Location = new Point(119, 136);
            skill_binds.Margin = new Padding(3, 4, 3, 4);
            skill_binds.MaxSelections = -1;
            skill_binds.Name = "skill_binds";
            skill_binds.ShowCloseBtn = false;
            skill_binds.Size = new Size(233, 141);
            skill_binds.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 142);
            label6.Name = "label6";
            label6.Size = new Size(93, 40);
            label6.TabIndex = 11;
            label6.Text = "特技组合\r\n（最多8个）";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(293, 286);
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
            buttonApply.Location = new Point(189, 286);
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
            value_level.Location = new Point(292, 48);
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
            // SkillEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 333);
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
    }
}