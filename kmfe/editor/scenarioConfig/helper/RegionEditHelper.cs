using kmfe.core;
using kmfe.core.globalTypes;
using Region = kmfe.core.globalTypes.Region;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class RegionEditHelper : BaseEditorHelper
    {
        public RegionEditHelper(ListView listView) : base(listView)
        {
        }

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
        }
        public override void UpdateListView()
        {
            foreach (Region region in AppEnvironment.scenarioData.regionArray)
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
