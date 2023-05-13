using kmfe.core;
using kmfe.core.globalTypes;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public partial class TitleEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        Title? title;

        public TitleEditDialog()
        {
            InitializeComponent();
        }

        public override void Init(ScenarioData scenarioData)
        {
            base.Init(scenarioData);
        }

        public void Setup(Title title)
        {
            this.title = title;
            text_id.Text = title.Id.ToString();
            text_name.Text = title.name;
            value_command.Value = title.command;
        }

        public override bool Apply()
        {
            if (title == null) return false;
            title.name = text_name.Text;
            title.command = (int)value_command.Value;

            OnApply?.Invoke(new List<int>() { title.Id });
            return true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
