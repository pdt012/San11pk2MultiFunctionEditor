using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.forms;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public partial class ProvinceEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        Province? province;

        public ProvinceEditDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            combo_region.Items.Clear();
            combo_region.Items.AddRange(AppEnvironment.scenarioData.GetAllRegionNames());
            choose_adjacent.MaxSelections = 5;
        }

        public void Setup(Province province)
        {
            this.province = province;
            text_id.Text = province.Id.ToString();
            text_name.Text = province.name;
            text_read.Text = province.read;
            text_desc.Text = province.desc;
            combo_region.SelectedIndex = province.regionId;
            choose_adjacent.Choices = GetEnabledProvinceNames(province);
            choose_adjacent.SetSelected(province.adjacentProvinceIdSet.ToArray());
        }

        public override bool Apply()
        {
            if (province == null) return false;
            province.name = text_name.Text;
            province.read = text_read.Text;
            province.desc = text_desc.Text;
            province.regionId = combo_region.SelectedIndex;
            province.adjacentProvinceIdSet = choose_adjacent.GetSelected().ToHashSet();

            OnApply?.Invoke(new List<int>() { province.Id });
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

        private List<IntString> GetEnabledProvinceNames(Province province)
        {
            List<IntString> names = new();
            foreach (Province province_ in AppEnvironment.scenarioData.provinceArray)
            {
                if (province_.Id != province.Id)  // 去除自己
                    names.Add(new IntString(province_.Id, string.Format("{0}-{1}", province_.Id, province_.name)));
            }
            return names;
        }
    }
}
