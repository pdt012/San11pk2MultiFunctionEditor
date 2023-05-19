using DocumentFormat.OpenXml.Office2010.CustomUI;
using kmfe.Core;
using kmfe.Core.GlobalTypes;
using kmfe.Editor.ScenarioConfig.EditDialog;
using kmfe.S11.S11Enums;

namespace kmfe.Editor.ScenarioConfig.EditHelper
{
    internal class TreasureEditHelper : BaseEditorHelper
    {
        public readonly TreasureEditDialog editDialog;
        readonly ContextMenuStrip contextMenu;
        readonly ToolStripMenuItem menuEditTreasure;
        readonly ToolStripMenuItem menuDelTreasure;
        readonly ToolStripMenuItem menuNewTreasure;

        Treasure? currentTreasure;
        int currentRow = -1;

        public TreasureEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
            baseEditDialog = editDialog;

            contextMenu = new();
            menuEditTreasure = new("编辑宝物", null, onClick_menuEditTreasure);
            menuDelTreasure = new("删除宝物", null, onClick_menuDelTreasure);
            menuNewTreasure = new("新增宝物", null, onClick_menuNewTreasure);
            contextMenu.Items.AddRange(new ToolStripItem[] { menuEditTreasure, menuDelTreasure, menuNewTreasure });
        }

        public override int GetCount() => ScenarioData.treasureCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 120);
            listView.Columns.Add("读音", 160);
            listView.Columns.Add("类型", 60);
            listView.Columns.Add("价值", 60);
            listView.Columns.Add("特技", 60);
            for (int i = 0; i < 5; i++)
            {
                listView.Columns.Add(Enum.GetName((StatType)i), 50);  // 能力加成
            }
            listView.Columns.Add("列传", 300);
            listView.Columns.Add("图片", 250);
        }

        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (Treasure treasure in AppEnvironment.scenarioData.treasureArray)
            {
                if (!treasure.IsValid()) continue;
                ListViewItem item = new()
                {
                    Tag = treasure,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Treasure treasure) return;

            item.SubItems.Clear();
            item.Text = treasure.Id.ToString();
            item.SubItems.Add(treasure.name);
            item.SubItems.Add(treasure.read);
            item.SubItems.Add(Enum.GetName(treasure.type));
            item.SubItems.Add(treasure.worth.ToString());
            string skillName = "";
            if (treasure.bindSkillId >= 0)
            {
                Skill skill = AppEnvironment.scenarioData.skillArray[treasure.bindSkillId];
                if (skill.IsValid())
                    skillName = skill.name;
                else
                    skillName = skill.Id.ToString();
            }
            item.SubItems.Add(skillName);
            for (int i = 0; i < 5; i++)
            {
                item.SubItems.Add(treasure.statBuff[i].ToString());
            }
            item.SubItems.Add(treasure.history);
            item.SubItems.Add(treasure.imagePath);
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            currentRow = listView.Items.IndexOf(item);
            currentTreasure = item.Tag as Treasure;
            if (currentTreasure is null) return;
            EditTreasure();
        }

        public override void OnRightClicked(Form parentForm, ListViewItem item)
        {
            currentRow = listView.Items.IndexOf(item);
            currentTreasure = item.Tag as Treasure;
            if (currentTreasure is null) return;
            menuDelTreasure.Enabled = currentTreasure.Id >= ScenarioData.skillCustomizeBegin;
            menuNewTreasure.Enabled = FindEmptySlot() != -1;
            contextMenu.Show(Control.MousePosition);
        }

        private void onClick_menuEditTreasure(object? sender, EventArgs e)
        {
            EditTreasure();
        }

        private void onClick_menuDelTreasure(object? sender, EventArgs e)
        {
            DelTreasure();
        }

        private void onClick_menuNewTreasure(object? sender, EventArgs e)
        {
            NewTreasure();
        }

        private void EditTreasure()
        {
            if (currentTreasure != null)
            {
                editDialog.Setup(currentTreasure, currentRow);
                editDialog.Execute(Form.ActiveForm);
            }
        }

        private void DelTreasure()
        {
            DialogResult result = MessageBox.Show("确认删除宝物？", "删除宝物", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                listView.Items.RemoveAt(currentRow);
                currentTreasure?.Reset();
            }
        }

        private void NewTreasure()
        {
            // 查找空缺的宝物id
            int treasureId = FindEmptySlot();
            if (treasureId >= 0)
            {
                currentRow = IdToRow(treasureId);
                currentTreasure = AppEnvironment.scenarioData.treasureArray[treasureId];
                ListViewItem newItem = new() { Tag = currentTreasure };
                listView.Items.Insert(currentRow, newItem);  // 新建一行
                // 打开宝物编辑窗口
                editDialog.Init();
                editDialog.Setup(currentTreasure, currentRow);
                // 强制以模态弹出
                bool modalMode = editDialog.ModalMode;
                editDialog.ModalMode = true;
                editDialog.Execute(Form.ActiveForm);
                editDialog.ModalMode = modalMode;
                if (editDialog.DialogResult != DialogResult.OK)
                {  // 如果没有保存则删除该行
                    listView.Items.RemoveAt(currentRow);
                }
            }
        }

        private int IdToRow(int id)
        {
            for (int row = 0; row < listView.Items.Count; row++)
            {
                ListViewItem item = listView.Items[row];
                Treasure? treasure = item.Tag as Treasure;
                if (treasure?.Id >= id)
                    return row;
            }
            return listView.Items.Count;
        }

        /// <summary>
        /// 查找空缺的宝物id
        /// </summary>
        /// <returns>没有空槽时返回-1</returns>
        private int FindEmptySlot()
        {
            for (int id = ScenarioData.treasureCustomizeBegin; id < ScenarioData.treasureCustomizeEnd; id++)
            {
                if (!AppEnvironment.scenarioData.treasureArray[id].IsValid())
                {
                    return id;
                }
            }
            return -1;
        }
    }
}
