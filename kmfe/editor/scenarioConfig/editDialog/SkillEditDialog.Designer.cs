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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            skillName = new TextBox();
            skillDesc = new TextBox();
            skillType = new ComboBox();
            skillBinds = new forms.ChooseBox();
            label6 = new Label();
            buttonCancel = new Button();
            buttonApply = new Button();
            skillLevel = new NumericUpDown();
            skillId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)skillLevel).BeginInit();
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
            // skillName
            // 
            skillName.BorderStyle = BorderStyle.FixedSingle;
            skillName.Location = new Point(65, 48);
            skillName.Name = "skillName";
            skillName.Size = new Size(60, 27);
            skillName.TabIndex = 6;
            // 
            // skillDesc
            // 
            skillDesc.BorderStyle = BorderStyle.FixedSingle;
            skillDesc.Location = new Point(65, 81);
            skillDesc.Multiline = true;
            skillDesc.Name = "skillDesc";
            skillDesc.Size = new Size(287, 48);
            skillDesc.TabIndex = 8;
            // 
            // skillType
            // 
            skillType.FormattingEnabled = true;
            skillType.Location = new Point(176, 48);
            skillType.Name = "skillType";
            skillType.Size = new Size(65, 28);
            skillType.TabIndex = 9;
            // 
            // skillBinds
            // 
            skillBinds.Location = new Point(65, 155);
            skillBinds.Margin = new Padding(3, 4, 3, 4);
            skillBinds.Name = "skillBinds";
            skillBinds.ShowCloseBtn = false;
            skillBinds.Size = new Size(287, 141);
            skillBinds.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(65, 132);
            label6.Name = "label6";
            label6.Size = new Size(153, 20);
            label6.TabIndex = 11;
            label6.Text = "特技组合（最多8个）";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(256, 305);
            buttonCancel.Margin = new Padding(4, 5, 4, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 39);
            buttonCancel.TabIndex = 20;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(65, 305);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 39);
            buttonApply.TabIndex = 19;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // skillLevel
            // 
            skillLevel.BorderStyle = BorderStyle.FixedSingle;
            skillLevel.Location = new Point(292, 48);
            skillLevel.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            skillLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            skillLevel.Name = "skillLevel";
            skillLevel.Size = new Size(60, 27);
            skillLevel.TabIndex = 22;
            skillLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // skillId
            // 
            skillId.BorderStyle = BorderStyle.FixedSingle;
            skillId.Enabled = false;
            skillId.Location = new Point(65, 14);
            skillId.Name = "skillId";
            skillId.Size = new Size(60, 27);
            skillId.TabIndex = 5;
            // 
            // SkillEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 353);
            Controls.Add(skillLevel);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(label6);
            Controls.Add(skillBinds);
            Controls.Add(skillType);
            Controls.Add(skillDesc);
            Controls.Add(skillName);
            Controls.Add(skillId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SkillEditDialog";
            Text = "特技编辑";
            ((System.ComponentModel.ISupportInitialize)skillLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox skillName;
        private TextBox skillDesc;
        private ComboBox skillType;
        private forms.ChooseBox skillBinds;
        private Label label6;
        private Button buttonCancel;
        private Button buttonApply;
        private NumericUpDown skillLevel;
        private TextBox skillId;
    }
}