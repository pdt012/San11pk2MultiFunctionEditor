namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    partial class RegionEditDialog
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
            text_read = new TextBox();
            label3 = new Label();
            text_id = new Label();
            label1 = new Label();
            text_name = new TextBox();
            label2 = new Label();
            buttonCancel = new Button();
            buttonApply = new Button();
            SuspendLayout();
            // 
            // text_read
            // 
            text_read.BorderStyle = BorderStyle.FixedSingle;
            text_read.Location = new Point(263, 12);
            text_read.Name = "text_read";
            text_read.Size = new Size(100, 27);
            text_read.TabIndex = 56;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 14);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 55;
            label3.Text = "读音";
            // 
            // text_id
            // 
            text_id.AutoSize = true;
            text_id.BackColor = SystemColors.Control;
            text_id.BorderStyle = BorderStyle.FixedSingle;
            text_id.Location = new Point(41, 12);
            text_id.Margin = new Padding(3);
            text_id.MinimumSize = new Size(60, 27);
            text_id.Name = "text_id";
            text_id.Size = new Size(60, 27);
            text_id.TabIndex = 54;
            text_id.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 14);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 53;
            label1.Text = "ID";
            // 
            // text_name
            // 
            text_name.BorderStyle = BorderStyle.FixedSingle;
            text_name.Location = new Point(152, 12);
            text_name.Name = "text_name";
            text_name.Size = new Size(60, 27);
            text_name.TabIndex = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 14);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 52;
            label2.Text = "名称";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(263, 56);
            buttonCancel.Margin = new Padding(4, 5, 4, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 33);
            buttonCancel.TabIndex = 57;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.Location = new Point(159, 56);
            buttonApply.Margin = new Padding(4, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 33);
            buttonApply.TabIndex = 58;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // RegionEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 103);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(text_read);
            Controls.Add(label3);
            Controls.Add(text_id);
            Controls.Add(label1);
            Controls.Add(text_name);
            Controls.Add(label2);
            Name = "RegionEditDialog";
            Text = "地区编辑";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text_read;
        private Label label3;
        private Label text_id;
        private Label label1;
        private TextBox text_name;
        private Label label2;
        private Button buttonCancel;
        private Button buttonApply;
    }
}