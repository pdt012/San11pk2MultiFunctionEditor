namespace kmfe.editor.scenarioConfig.editDialog
{
    partial class TitleEditDialog
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
            label3 = new Label();
            text_name = new TextBox();
            label2 = new Label();
            value_command = new forms.DecimalBox();
            buttonCancel = new Button();
            buttonApply = new Button();
            text_id = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)value_command).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 44);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 16;
            label3.Text = "最大指挥";
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(59, 42);
            text_name.Name = "text_name";
            text_name.Size = new Size(85, 27);
            text_name.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 44);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 14;
            label2.Text = "名称";
            // 
            // value_command
            // 
            value_command.BorderStyle = BorderStyle.FixedSingle;
            value_command.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            value_command.Location = new Point(225, 42);
            value_command.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            value_command.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            value_command.Name = "value_command";
            value_command.Size = new Size(85, 27);
            value_command.TabIndex = 3;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(223, 86);
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
            buttonApply.Location = new Point(119, 86);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 33);
            buttonApply.TabIndex = 1;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // text_id
            // 
            text_id.AutoSize = true;
            text_id.BackColor = SystemColors.Control;
            text_id.BorderStyle = BorderStyle.FixedSingle;
            text_id.Location = new Point(59, 9);
            text_id.Margin = new Padding(3);
            text_id.MinimumSize = new Size(60, 27);
            text_id.Name = "text_id";
            text_id.Size = new Size(60, 27);
            text_id.TabIndex = 28;
            text_id.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 11);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 27;
            label1.Text = "ID";
            // 
            // TitleEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 133);
            Controls.Add(text_id);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(value_command);
            Controls.Add(label3);
            Controls.Add(text_name);
            Controls.Add(label2);
            Name = "TitleEditDialog";
            Text = "爵位编辑";
            ((System.ComponentModel.ISupportInitialize)value_command).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox text_name;
        private Label label2;
        private forms.DecimalBox value_command;
        private Button buttonCancel;
        private Button buttonApply;
        private Label text_id;
        private Label label1;
    }
}