using kmfe.Core;
using kmfe.Core.GlobalTypes;
using kmfe.Editor.ScenarioConfig.EditDialog;

namespace kmfe.Editor.ScenarioConfig.EditHelper
{
    internal class ProvinceEditHelper : BaseEditorHelper
    {
        public readonly ProvinceEditDialog editDialog;

        public ProvinceEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
            baseEditDialog = editDialog;
        }

        public override int GetCount() => ScenarioData.provinceCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
            listView.Columns.Add("读音", 100);
            listView.Columns.Add("__12", 100);
            listView.Columns.Add("介绍", 100);
            listView.Columns.Add("地区", 60);
            listView.Columns.Add("相邻州", 300);
        }

        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (Province province in AppEnvironment.scenarioData.provinceArray)
            {
                ListViewItem item = new()
                {
                    Tag = province,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Province province) return;

            item.SubItems.Clear();
            item.Text = province.Id.ToString();
            item.SubItems.Add(province.name);
            item.SubItems.Add(province.read);
            item.SubItems.Add(province.__12);
            item.SubItems.Add(province.desc);
            item.SubItems.Add(AppEnvironment.scenarioData.regionArray[province.regionId].name);
            List<string> adjacentProvinceNames = AppEnvironment.scenarioData.GetAdjacentProvinceNames(province);
            item.SubItems.Add(string.Join(", ", adjacentProvinceNames));
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            if (item.Tag is not Province province) return;
            editDialog.Setup(province);
            editDialog.Execute(Form.ActiveForm);
        }
    }
}
