using kmfe.core;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public class BaseEditDialog : Form  /*不能定义为abstract类，会导致设计器出错*/
    {
        public delegate void ApplyHandle(List<int>? updatedRowList);
        protected ScenarioData? scenarioData;

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

        /// <summary>
        /// 初始化对话框，如果已经初始化过则自动跳过
        /// </summary>
        /// <param name="scenarioData"></param>
        public virtual void Init(ScenarioData scenarioData)
        {
            if (Initialized) return;
            this.scenarioData = scenarioData;
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
                Hide();
        }

        protected void Cancel()
        {
            Hide();
        }

        public void Show(Form? parent)
        {
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
