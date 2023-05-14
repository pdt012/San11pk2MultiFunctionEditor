using kmfe.core;
using kmfe.core.globalTypes;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class TownEditHelper : BaseEditorHelper
    {
        public TownEditHelper(ListView listView) : base(listView)
        {
        }

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 80);
        }

        public override void UpdateListView()
        {
            foreach (Town town in AppEnvironment.scenarioData.townArray)
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

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            ;
        }

        public override void OnRightClicked(Form parentForm, ListViewItem item)
        {
            ;
        }

        public override void OnLoaded()
        {
            ;
        }

        public override void OnSaved()
        {
            ;
        }
    }
}
