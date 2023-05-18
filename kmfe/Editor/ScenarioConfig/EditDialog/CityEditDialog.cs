using kmfe.Core.GlobalTypes;
using kmfe.Editor.ScenarioConfig.EditDialog;

namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    public partial class CityEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        City? city;

        public CityEditDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
        }

        public void Setup(City city)
        {
            this.city = city;
            text_id.Text = city.Id.ToString();
            text_name.Text = city.name;
        }

        public override bool Apply()
        {
            if (city == null) return false;
            city.name = text_name.Text;

            OnApply?.Invoke(new List<int>() { city.Id });
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
