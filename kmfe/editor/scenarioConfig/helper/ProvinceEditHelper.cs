using kmfe.core;
using kmfe.core.globalTypes;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class ProvinceEditHelper : BaseEditorHelper
    {
        public ProvinceEditHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void InitListView(ListView listView)
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
            listView.Columns.Add("读音", 100);
            listView.Columns.Add("__12", 100);
            listView.Columns.Add("介绍", 100);
            listView.Columns.Add("地区", 60);
            listView.Columns.Add("相邻州", 300);
        }

        public override void UpdateListView(ListView listView)
        {
            foreach (Province province in scenarioData.provinceArray)
            {
                ListViewItem item = new()
                {
                    Tag = province,
                    Text = province.Id.ToString()
                };
                item.SubItems.Add(province.name);
                item.SubItems.Add(province.read);
                item.SubItems.Add(province.__12);
                item.SubItems.Add(province.desc);
                item.SubItems.Add(scenarioData.regionArray[province.regionId].name);
                List<string> adjacentProvinceNames = scenarioData.GetAdjacentProvinceNames(province);
                item.SubItems.Add(string.Join(", ", adjacentProvinceNames));
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            throw new NotImplementedException();
        }
    }
}
