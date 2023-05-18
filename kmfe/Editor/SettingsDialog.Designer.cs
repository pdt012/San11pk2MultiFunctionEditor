namespace kmfe.Editor
{
    partial class SettingsDialog
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
            label2 = new Label();
            text_pk2path = new TextBox();
            btn_set_pk2path = new Button();
            buttonCancel = new Button();
            buttonApply = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 31);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "pk2.2路径";
            // 
            // text_pk2path
            // 
            text_pk2path.Location = new Point(97, 28);
            text_pk2path.Name = "text_pk2path";
            text_pk2path.ReadOnly = true;
            text_pk2path.Size = new Size(319, 27);
            text_pk2path.TabIndex = 2;
            // 
            // btn_set_pk2path
            // 
            btn_set_pk2path.Location = new Point(422, 28);
            btn_set_pk2path.Name = "btn_set_pk2path";
            btn_set_pk2path.Size = new Size(48, 27);
            btn_set_pk2path.TabIndex = 3;
            btn_set_pk2path.Text = "浏览";
            btn_set_pk2path.UseVisualStyleBackColor = true;
            btn_set_pk2path.Click += btn_set_pk2path_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(277, 108);
            buttonCancel.Margin = new Padding(4, 5, 100, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 31);
            buttonCancel.TabIndex = 22;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonApply.Location = new Point(109, 108);
            buttonApply.Margin = new Padding(100, 5, 4, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(96, 31);
            buttonApply.TabIndex = 21;
            buttonApply.Text = "保存";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // SettingsDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 153);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(label2);
            Controls.Add(btn_set_pk2path);
            Controls.Add(text_pk2path);
            Name = "SettingsDialog";
            Text = "设置";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox text_pk2path;
        private Button btn_set_pk2path;
        private Button buttonCancel;
        private Button buttonApply;
    }
}