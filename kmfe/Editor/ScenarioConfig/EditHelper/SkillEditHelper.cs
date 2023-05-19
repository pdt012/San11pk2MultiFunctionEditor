using kmfe.Editor.ScenarioConfig.EditDialog;
using kmfe.Core.GlobalTypes;
using kmfe.Core;

namespace kmfe.Editor.ScenarioConfig.EditHelper
{
    internal class SkillEditHelper : BaseEditorHelper
    {
        public readonly SkillEditDialog editDialog;
        readonly ContextMenuStrip contextMenu;
        readonly ToolStripMenuItem menuEditSkill;
        readonly ToolStripMenuItem menuDelSkill;
        readonly ToolStripMenuItem menuNewSkill;

        Skill? currentSkill;
        int currentRow = -1;

        public SkillEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
            baseEditDialog = editDialog;

            contextMenu = new();
            menuEditSkill = new("编辑特技", null, onClick_menuEditSkill);
            menuDelSkill = new("删除特技", null, onClick_menuDelSkill);
            menuNewSkill = new("新增特技", null, onClick_menuNewSkill);
            contextMenu.Items.AddRange(new ToolStripItem[] { menuEditSkill, menuDelSkill, menuNewSkill });
        }

        public override int GetCount() => ScenarioData.skillCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 50);
            listView.Columns.Add("名称", 50);
            listView.Columns.Add("描述", 400);
            listView.Columns.Add("类型", 50);
            listView.Columns.Add("等级", 50);
            listView.Columns.Add("组合特技", 200);
            listView.Columns.Add("参数0", 150);
            listView.Columns.Add("参数1", 150);
            listView.Columns.Add("参数2", 150);
            listView.Columns.Add("参数3", 150);
            listView.Columns.Add("参数4", 150);
        }

        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (Skill skill in AppEnvironment.scenarioData.skillArray)
            {
                if (!skill.IsValid()) continue;
                ListViewItem item = new()
                {
                    Tag = skill,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Skill skill) return;

            item.SubItems.Clear();
            item.Tag = skill;
            item.Text = skill.Id.ToString();
            item.SubItems.Add(skill.name);
            item.SubItems.Add(skill.GetFormattedDesc());
            item.SubItems.Add(Enum.GetName(skill.type));
            item.SubItems.Add(skill.level.ToString());
            item.SubItems.Add(GetBindSkillsNameString(skill));
            foreach (SkillConstant constant in skill.constantArray)
            {
                if (constant.available)
                    item.SubItems.Add($"{constant.desc} = {constant.value}");
                else
                    item.SubItems.Add("");
            }
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            currentRow = listView.Items.IndexOf(item);
            currentSkill = item.Tag as Skill;
            if (currentSkill is null) return;
            EditSkill();
        }

        public override void OnRightClicked(Form parentForm, ListViewItem item)
        {
            currentRow = listView.Items.IndexOf(item);
            currentSkill = item.Tag as Skill;
            if (currentSkill is null) return;
            menuDelSkill.Enabled = currentSkill.Id >= ScenarioData.skillCustomizeBegin;
            menuNewSkill.Enabled = FindEmptySlot() != -1;
            contextMenu.Show(Control.MousePosition);
        }

        private void onClick_menuEditSkill(object? sender, EventArgs e)
        {
            EditSkill();
        }

        private void onClick_menuDelSkill(object? sender, EventArgs e)
        {
            DelSkill();
        }

        private void onClick_menuNewSkill(object? sender, EventArgs e)
        {
            NewSkill();
        }

        private void EditSkill()
        {
            if (currentSkill != null)
            {
                editDialog.Setup(currentSkill, currentRow);
                editDialog.Execute(Form.ActiveForm);
            }
        }

        private void DelSkill()
        {
            DialogResult result = MessageBox.Show("确认删除特技？", "删除特技", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                listView.Items.RemoveAt(currentRow);
                currentSkill?.Reset();
            }
        }

        private void NewSkill()
        {
            // 查找空缺的特技id
            int skillId = FindEmptySlot();
            if (skillId >= 0)
            {
                currentRow = IdToRow(skillId);
                currentSkill = AppEnvironment.scenarioData.skillArray[skillId];
                ListViewItem newItem = new() { Tag = currentSkill };
                listView.Items.Insert(currentRow, newItem);  // 新建一行
                // 打开特技编辑窗口
                editDialog.Init();
                editDialog.Setup(currentSkill, currentRow);
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
                Skill? skill = item.Tag as Skill;
                if (skill?.Id >= id)
                    return row;
            }
            return listView.Items.Count;
        }

        /// <summary>
        /// 查找空缺的特技id
        /// </summary>
        /// <returns>没有空槽时返回-1</returns>
        private int FindEmptySlot()
        {
            for (int id = ScenarioData.skillCustomizeBegin; id < ScenarioData.skillCustomizeEnd; id++)
            {
                if (!AppEnvironment.scenarioData.skillArray[id].IsValid())
                {
                    return id;
                }
            }
            return -1;
        }

        private string GetBindSkillsNameString(Skill skill)
        {
            List<string> nameList = new();
            foreach (int skillId in skill.bindSkillList)
            {
                nameList.Add(AppEnvironment.scenarioData.skillArray[skillId].name);
            }
            return string.Join(", ", nameList);
        }
    }
}
