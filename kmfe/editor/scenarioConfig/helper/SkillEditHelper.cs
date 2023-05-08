using kmfe.core.globalTypes;
using kmfe.core;
using kmfe.common;
using kmfe.editor.scenarioConfig.editDialog;
using System.Windows.Forms;

namespace kmfe.editor.scenarioConfig.helper
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

        public SkillEditHelper(ScenarioData scenarioData, ListView listView) : base(scenarioData, listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;

            contextMenu = new();
            menuEditSkill = new("编辑特技", null, onClick_menuEditSkill);
            menuDelSkill = new("删除特技", null, onClick_menuDelSkill);
            menuNewSkill = new("新增特技", null, onClick_menuDelSkill);
            contextMenu.Items.AddRange(new ToolStripItem[] { menuEditSkill, menuDelSkill, menuNewSkill });
        }

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 80);
            listView.Columns.Add("描述", 500);
            listView.Columns.Add("类型", 60);
            listView.Columns.Add("等级", 60);
            listView.Columns.Add("组合特技", 200);
        }

        public override void UpdateListView()
        {
            foreach (Skill skill in scenarioData.skillArray)
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
            item.SubItems.Add(skill.desc);
            item.SubItems.Add(Enum.GetName(skill.type));
            item.SubItems.Add(skill.level.ToString());
            item.SubItems.Add(GetBindSkillsNameString(skill));
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
            menuDelSkill.Enabled = currentSkill.Id >= Constants.SKILL_CUSTOMIZE_BEGIN;
            menuNewSkill.Enabled = FindEmptySlot() != -1;
            contextMenu.Show(Control.MousePosition);
        }

        public override void OnLoaded()
        {
            editDialog.Initialized = false;
        }

        public override void OnSaved()
        {
            ;
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
                editDialog.Init(scenarioData);
                editDialog.Setup(currentSkill);
                editDialog.Show(Form.ActiveForm);
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
                currentSkill = scenarioData.skillArray[skillId];
                // 打开特技编辑窗口
                editDialog.Init(scenarioData);
                editDialog.Setup(currentSkill);
                editDialog.Show(listView);
                /*if (editOneSkillInfo(this->skills->at(skill_id)))
                {  // 只有确认了才新建
                    this->insertRow(this->selected_row);
                    this->UpdateOneSkillInfo(this->skills->at(skill_id), this->selected_row);
                }*/
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
            for (int id = Constants.SKILL_CUSTOMIZE_BEGIN; id < Constants.SKILL_CUSTOMIZE_END; id++)
            {
                if (!scenarioData.skillArray[id].IsValid())
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
                nameList.Add(scenarioData.skillArray[skillId].name);
            }
            return string.Join(", ", nameList);
        }
    }
}
