namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    public class BaseEditDialog : Form  /*不能定义为abstract类，会导致设计器出错*/
    {
        public delegate void ApplyHandle(List<int>? updatedRowList);

        public BaseEditDialog()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            KeyPress += BaseEditDialog_KeyPress;
            FormClosing += BaseEditDialog_FormClosing;
        }

        public bool ModalMode { get; set; } = false;

        private void BaseEditDialog_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Cancel();
            }
            else if (e.KeyChar == (char)Keys.Return)
            {
                Confirm();
            }
        }

        private void BaseEditDialog_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // 点击右上X时会触发两次，不知道为什么
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Cancel();
                Hide();  // 确保窗体被关闭
            }
        }

        /// <summary>
        /// 初始化对话框
        /// </summary>
        /// <param name="scenarioData"></param>
        public virtual void Init()
        {
        }

        /// <summary>
        /// 点击应用后的回调
        /// </summary>
        /// <returns>true=通过，false=驳回</returns>
        public virtual bool Apply()
        {
            return true;
        }

        protected void Confirm()
        {
            if (Apply())
            {
                if (ModalMode)
                    DialogResult = DialogResult.OK;
                else
                    Hide();
            }
        }

        protected void Cancel()
        {
            if (ModalMode)
                DialogResult = DialogResult.Cancel;
            else
                Hide();
        }

        public void Execute(Form? parent)
        {
            if (ModalMode)
            {
                Hide();  // 确保窗口已不可见（否则无法打开模态窗口）
                StartPosition = FormStartPosition.CenterParent;
                ShowDialog(parent);
            }
            else
            if (!Visible)
            {
                if (parent != null)  // 居中显示
                {
                    StartPosition = FormStartPosition.Manual;
                    Location = new Point(parent.Location.X + parent.Width / 2 - Width / 2,
                            parent.Location.Y + parent.Height / 2 - Height / 2);
                }
                Show();
            }
            else
            {
                Activate();
            }
        }
    }
}
