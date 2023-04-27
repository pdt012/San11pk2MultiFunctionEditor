using kmfe.core;
using kmfe.core.globalTypes;
using Region = kmfe.core.globalTypes.Region;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class RegionEditHelper : BaseEditorHelper
    {
        public RegionEditHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void InitListView(ListView listView)
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
        }
        public override void UpdateListView(ListView listView)
        {
            foreach (Region region in scenarioData.regionArray)
            {
                ListViewItem item = new()
                {
                    Tag = region,
                    Text = region.Id.ToString()
                };
                item.SubItems.Add(region.name);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            throw new NotImplementedException();
        }
    }
}
