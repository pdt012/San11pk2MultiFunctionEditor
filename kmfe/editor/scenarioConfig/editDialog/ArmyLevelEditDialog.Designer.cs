using kmfe.forms;

namespace kmfe.editor.scenarioConfig.editDialog
{
    partial class ArmyLevelEditDialog
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
            text_name = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            value_exp = new DecimalBox();
            value_tactic_chance = new DecimalBox();
            value_stat_ratio = new DecimalBox();
            buttonCancel = new Button();
            buttonApply = new Button();
            label6 = new Label();
            check_reachable = new CheckBox();
            text_id = new Label();
            ((System.ComponentModel.ISupportInitialize)value_exp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)value_tactic_chance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)value_stat_ratio).BeginInit();
            SuspendLayout();
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(57, 42);
            text_name.Name = "text_name";
            text_name.Size = new Size(60, 27);
            text_name.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 8;
            label2.Text = "名称";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 11);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 7;
            label1.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 77);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 11;
            label3.Text = "所需经验";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 11);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 12;
            label4.Text = "战法成功率加成";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(168, 44);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 13;
            label5.Text = "能力倍率";
            // 
            // value_exp
            // 
            value_exp.BorderStyle = BorderStyle.FixedSingle;
            value_exp.Location = new Point(243, 75);
            value_exp.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            value_exp.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            value_exp.Name = "value_exp";
            value_exp.Size = new Size(60, 27);
            value_exp.TabIndex = 14;
            value_exp.ValueChanged += value_exp_ValueChanged;
            // 
            // value_tactic_chance
            // 
            value_tactic_chance.BorderStyle = BorderStyle.FixedSingle;
            value_tactic_chance.Location = new Point(243, 9);
            value_tactic_chance.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            value_tactic_chance.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            value_tactic_chance.Name = "value_tactic_chance";
            value_tactic_chance.Size = new Size(60, 27);
            value_tactic_chance.TabIndex = 15;
            // 
            // value_stat_ratio
            // 
            value_stat_ratio.BorderStyle = BorderStyle.FixedSingle;
            value_stat_ratio.DecimalPlaces = 2;
            value_stat_ratio.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            value_stat_ratio.Location = new Point(243, 42);
            value_stat_ratio.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            value_stat_ratio.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            value_stat_ratio.Name = "value_stat_ratio";
            value_stat_ratio.Size = new Size(60, 27);
            value_stat_ratio.TabIndex = 16;
            value_stat_ratio.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(233, 116);
            buttonCancel.Margin = new Padding(4, 5, 4, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 33);
            buttonCancel.TabIndex = 22;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(129, 116);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 33);
            buttonApply.TabIndex = 21;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(306, 11);
            label6.Margin = new Padding(0, 0, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 23;
            label6.Text = "%";
            // 
            // check_reachable
            // 
            check_reachable.AutoSize = true;
            check_reachable.CheckAlign = ContentAlignment.MiddleRight;
            check_reachable.Location = new Point(86, 76);
            check_reachable.Name = "check_reachable";
            check_reachable.Size = new Size(76, 24);
            check_reachable.TabIndex = 25;
            check_reachable.Text = "可达到";
            check_reachable.UseVisualStyleBackColor = true;
            check_reachable.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // text_id
            // 
            text_id.AutoSize = true;
            text_id.BackColor = SystemColors.Control;
            text_id.BorderStyle = BorderStyle.FixedSingle;
            text_id.Location = new Point(57, 9);
            text_id.Margin = new Padding(3);
            text_id.MinimumSize = new Size(60, 27);
            text_id.Name = "text_id";
            text_id.Size = new Size(60, 27);
            text_id.TabIndex = 26;
            text_id.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ArmyLevelEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 163);
            Controls.Add(text_id);
            Controls.Add(check_reachable);
            Controls.Add(label6);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(value_stat_ratio);
            Controls.Add(value_tactic_chance);
            Controls.Add(value_exp);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(text_name);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ArmyLevelEditDialog";
            Text = "适性编辑";
            ((System.ComponentModel.ISupportInitialize)value_exp).EndInit();
            ((System.ComponentModel.ISupportInitialize)value_tactic_chance).EndInit();
            ((System.ComponentModel.ISupportInitialize)value_stat_ratio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text_name;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private DecimalBox value_exp;
        private DecimalBox value_tactic_chance;
        private DecimalBox value_stat_ratio;
        private Button buttonCancel;
        private Button buttonApply;
        private Label label6;
        private CheckBox check_reachable;
        private Label text_id;
    }
}