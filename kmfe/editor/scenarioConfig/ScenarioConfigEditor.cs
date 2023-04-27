using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.core.xmlHelper;
using kmfe.editor.scenarioConfig.helper;
using kmfe.editor.scenarioConfig.editDialog;
using System.Diagnostics;

namespace kmfe.editor.scenarioConfig
{
    internal enum EditType
    {
        None,
        City,
        Town,
        CityLikeDistance,
        Province,
        Region,
        Skill,
    }

    public partial class ScenarioConfigEditor : Form
    {
        EditType currentEditType = EditType.None;
        public readonly ScenarioData scenarioData = new();

        readonly CityLikeNeighborEdit cityLikeNeighborEdit;

        readonly Dictionary<EditType, BaseEditorHelper> editHelperDict;
        readonly Dictionary<EditType, BaseEditDialog> editDialogDict;

        public ScenarioConfigEditor()
        {
            InitializeComponent();

            CityEditHelper cityEditHelper = new(scenarioData);
            TownEditHelper townEditHelper = new(scenarioData);
            CityLikeNeighborHelper cityLikeNeighborHelper = new(scenarioData);
            ProvinceEditHelper provinceEditHelper = new(scenarioData);
            RegionEditHelper regionEditHelper = new(scenarioData);
            SkillEditHelper skillEditHelper = new(scenarioData);
            editHelperDict = new()
            {
                { EditType.City, cityEditHelper },
                { EditType.Town, townEditHelper },
                { EditType.CityLikeDistance, cityLikeNeighborHelper },
                { EditType.Province, provinceEditHelper },
                { EditType.Region, regionEditHelper },
                { EditType.Skill, skillEditHelper },
            };

            cityLikeNeighborEdit = new CityLikeNeighborEdit();
            cityLikeNeighborEdit.OnSave += CityLikeNeighborEdit_OnSave;
            editDialogDict = new()
            {
                { EditType.CityLikeDistance, cityLikeNeighborEdit },
            };
        }

        private void CityLikeNeighborEdit_OnSave(List<int>? updatedIdList)
        {
            if (updatedIdList == null)
                editHelperDict[EditType.CityLikeDistance].UpdateListView(listView);
            else
                editHelperDict[EditType.CityLikeDistance].UpdateRows(listView, updatedIdList);
        }

        void SetCurrentEditType(EditType editType)
        {
            if (currentEditType == editType) return;
            currentEditType = editType;
            InitListView(editType);
            UpdateListView(editType);
        }

        void InitListView(EditType editType)
        {
            if (editType == EditType.None) return;
            listView.Clear();
            listView.View = View.Details;
            editHelperDict[editType].InitListView(listView);
        }

        void UpdateListView(EditType editType)
        {
            if (editType == EditType.None) return;
            listView.BeginUpdate();
            listView.Items.Clear();
            editHelperDict[editType].UpdateListView(listView);
            listView.EndUpdate();
        }

        private void listViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            Stopwatch sw = new();
            sw.Start();
#endif
            ListView listViewCityPathData = (ListView)sender;
            ListViewItem? listViewItem = listViewCityPathData.GetItemAt(e.X, e.Y);
            if (listViewItem == null)
                return;
            switch (currentEditType)
            {
                case EditType.City:
                    break;
                case EditType.Town:
                    break;
                case EditType.CityLikeDistance:
                    CityLike cityLike = (CityLike)listViewItem.Tag;
                    cityLikeNeighborEdit.Init(scenarioData);
                    cityLikeNeighborEdit.Setup(cityLike);
                    cityLikeNeighborEdit.Show(this);
                    break;
                case EditType.Province:
                    break;
                case EditType.Region:
                    break;
                default:
                    break;
            }
#if DEBUG
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"<listViewMouseDoubleClick> {ts.TotalMilliseconds}ms.");
#endif
        }

        private void 载入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                scenarioData.LoadFromGlobalScenario("./PK/Media/scenario/scenario.s11");
                PathXmlHelper pathXmlHelper = new(scenarioData);
                pathXmlHelper.Load("./pk2.2/data/01 path.xml");
                SkillXmlHelper skillXmlHelper = new(scenarioData);
                skillXmlHelper.Load("./pk2.2/data/19 skill.xml");
                foreach (BaseEditDialog editDialog in editDialogDict.Values)
                {
                    editDialog.Initialized = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "发生错误");
                return;
            }
            statusLabel_currentType.Text = "载入成功";
            UpdateListView(currentEditType);
        }

        private void 保存修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                scenarioData.SaveToGlobalScenario("./PK/Media/scenario/scenario.s11");
                PathXmlHelper pathXmlHelper = new(scenarioData);
                pathXmlHelper.Save("./pk2.2/data/01 path.xml");
                SkillXmlHelper skillXmlHelper = new(scenarioData);
                skillXmlHelper.Save("./pk2.2/data/19 skill.xml");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "发生错误");
                return;
            }
            MessageBox.Show("保存完毕！", "保存完毕");
        }

        private void 城市ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentEditType(EditType.City);
            statusLabel_currentType.Text = "城市";
        }

        private void 港关ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentEditType(EditType.Town);
            statusLabel_currentType.Text = "港关";
        }

        private void 据点距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentEditType(EditType.CityLikeDistance);
            statusLabel_currentType.Text = "据点距离";
        }

        private void 州ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentEditType(EditType.Province);
            statusLabel_currentType.Text = "州";
        }

        private void 地区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentEditType(EditType.Region);
            statusLabel_currentType.Text = "地区";
        }

        private void 特技ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentEditType(EditType.Skill);
            statusLabel_currentType.Text = "特技";
        }
    }
}
