using kmfe.core;
using kmfe.core.types;
using Region = kmfe.core.types.Region;

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
                    Text = region.id.ToString()
                };
                item.SubItems.Add(region.name);
                listView.Items.Add(item);
            }
        }
        public override void UpdateListView(ListView listView, List<int> rows)
        {
            throw new NotImplementedException();
        }
    }
}
