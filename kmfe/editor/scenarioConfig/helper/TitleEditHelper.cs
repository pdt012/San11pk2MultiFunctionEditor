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
        }

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 100);
            listView.Columns.Add("最大指挥", 100);
        }

        public override void UpdateListView()
        {
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
            editDialog.Init();
            editDialog.Setup(title);
            editDialog.Show(Form.ActiveForm);
        }

        public override void OnRightClicked(Form parentForm, ListViewItem item)
        {
            ;
        }

        public override void OnLoaded()
        {
            editDialog.Initialized = false;
        }

        public override void OnSaved()
        {
            ;
        }
    }
}
