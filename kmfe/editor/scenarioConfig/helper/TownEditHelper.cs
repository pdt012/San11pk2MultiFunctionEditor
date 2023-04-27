using kmfe.core;
using kmfe.core.globalTypes;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class TownEditHelper : BaseEditorHelper
    {
        public TownEditHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void InitListView(ListView listView)
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 80);
        }

        public override void UpdateListView(ListView listView)
        {
            foreach (Town town in scenarioData.townArray)
            {
                ListViewItem item = new()
                {
                    Tag = town,
                    Text = town.Id.ToString()
                };
                item.SubItems.Add(town.name);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            throw new NotImplementedException();
        }
    }
}
