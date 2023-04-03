using kmfe.core;
using kmfe.core.types;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class GatePortEditHelper : BaseEditorHelper
    {
        public GatePortEditHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void InitListView(ListView listView)
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 80);
        }

        public override void UpdateListView(ListView listView)
        {
            foreach (GatePort gatePort in scenarioData.gatePortArray)
            {
                ListViewItem item = new()
                {
                    Tag = gatePort,
                    Text = (gatePort.id).ToString()
                };
                item.SubItems.Add(gatePort.name);
                listView.Items.Add(item);
            }
        }

        public override void UpdateListView(ListView listView, List<int> rows)
        {
            throw new NotImplementedException();
        }
    }
}
