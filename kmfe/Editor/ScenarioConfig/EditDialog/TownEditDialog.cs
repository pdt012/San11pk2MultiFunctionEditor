using kmfe.Core;
using kmfe.Core.GlobalTypes;
using kmfe.Editor.ScenarioConfig.EditDialog;

namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    public partial class TownEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        Town? town;

        public TownEditDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
        }

        public void Setup(Town town)
        {
            this.town = town;
            text_id.Text = town.Id.ToString();
            text_name.Text = town.name;
        }

        public override bool Apply()
        {
            if (town == null) return false;
            town.name = text_name.Text;

            OnApply?.Invoke(new List<int>() { town.Id - ScenarioData.cityCount });
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
