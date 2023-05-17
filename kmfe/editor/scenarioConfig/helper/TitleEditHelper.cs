using kmfe.core.globalTypes;
using kmfe.core;
using kmfe.editor.scenarioConfig.editDialog;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class TitleEditHelper : BaseEditorHelper
    {
        public readonly TitleEditDialog editDialog;

        public TitleEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
            baseEditDialog = editDialog;
        }

        public override int GetCount() => ScenarioData.titleCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 100);
            listView.Columns.Add("最大指挥", 100);
        }

        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (Title title in AppEnvironment.scenarioData.titleArray)
            {
                ListViewItem item = new()
                {
                    Tag = title,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Title title) return;
            item.SubItems.Clear();
            item.Tag = title;
            item.Text = title.Id.ToString();
            item.SubItems.Add(title.name);
            item.SubItems.Add(title.command.ToString());
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            if (item.Tag is not Title title) return;
            editDialog.Setup(title);
            editDialog.Execute(Form.ActiveForm);
        }
    }
}
