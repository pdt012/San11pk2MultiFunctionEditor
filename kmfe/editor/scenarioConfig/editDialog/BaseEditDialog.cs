using kmfe.core;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public abstract class BaseEditDialog : Form
    {
        public BaseEditDialog()
        {
            FormClosing += BaseEditDialog_FormClosing;
        }

        /// <summary>
        /// 是否已经初始化
        /// </summary>
        public bool Initialized { get; set; } = false;

        private void BaseEditDialog_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Cancel();
            }
        }

        public abstract void Init(ScenarioData scenarioData);

        public abstract void Save();

        protected void Confirm()
        {
            Save();
            Hide();
        }

        protected void Cancel()
        {
            Hide();
        }

        public void Show(Form parent)
        {
            if (!Visible)
            {
                StartPosition = FormStartPosition.Manual;
                Location = new Point(parent.Location.X + parent.Width / 2 - Width / 2,
                        parent.Location.Y + parent.Height / 2 - Height / 2);
                Show();
            }
            else
            {
                Activate();
            }
        }
    }
}
