using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.editor.scenarioConfig.editDialog;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class ArmyLevelEditHelper : BaseEditorHelper
    {
        public readonly ArmyLevelEditDialog editDialog;

        public ArmyLevelEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
        }

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
            listView.Columns.Add("可到达", 60);
            listView.Columns.Add("所需经验", 100);
            listView.Columns.Add("战法成功率", 100);
            listView.Columns.Add("能力倍率", 100);
        }

        public override void UpdateListView()
        {
            foreach (ArmyLevel armyLevel in AppEnvironment.scenarioData.armyLevelArray)
            {
                ListViewItem item = new()
                {
                    Tag = armyLevel,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not ArmyLevel armyLevel) return;

            item.SubItems.Clear();
            item.Tag = armyLevel;
            item.Text = armyLevel.Id.ToString();
            item.SubItems.Add(armyLevel.name);
            item.SubItems.Add(armyLevel.IsReachable() ? "o" : "x");
            item.SubItems.Add(armyLevel.IsReachable() ? armyLevel.exp.ToString() : "--");
            item.SubItems.Add(armyLevel.tacticsChanceBuff.ToString());
            item.SubItems.Add(armyLevel.unitStatRatio.ToString());
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            if (item.Tag is not ArmyLevel armyLevel) return;
            editDialog.Init();
            editDialog.Setup(armyLevel);
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
