using kmfe.core;
using kmfe.editor.scenarioConfig.helper;
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
        Title,
        Rank,
        Skill,
        ArmyLevel,
    }

    public partial class ScenarioConfigEditor : Form
    {
        EditType currentEditType = EditType.None;

        readonly Dictionary<EditType, BaseEditorHelper> editHelperDict;
        readonly List<DataXmlName> usingDataXmlList;
        readonly Dictionary<EditType, ToolStripMenuItem> menuBtnDict;
        readonly List<ToolStripMenuItem> unusedMenuBtnList;

        public ScenarioConfigEditor()
        {
            InitializeComponent();
            保存修改ToolStripMenuItem.Enabled = false;
            全局修改ToolStripMenuItem.Enabled = false;
            剧本修改ToolStripMenuItem.Enabled = false;

            editHelperDict = new()
            {
                { EditType.City, new CityEditHelper(listView) },
                { EditType.Town, new TownEditHelper(listView) },
                { EditType.CityLikeDistance, new NeighborEditHelper(listView) },
                { EditType.Province, new ProvinceEditHelper(listView) },
                { EditType.Region, new RegionEditHelper(listView) },
                { EditType.Title, new TitleEditHelper(listView) },
                { EditType.Rank, new RankEditHelper(listView) },
                { EditType.Skill, new SkillEditHelper(listView) },
                { EditType.ArmyLevel, new ArmyLevelEditHelper(listView) },
            };
            // 功能对应的菜单按钮
            menuBtnDict = new()
            {
                { EditType.City, 城市ToolStripMenuItem },
                { EditType.Town, 港关ToolStripMenuItem },
                { EditType.CityLikeDistance, 据点距离ToolStripMenuItem },
                { EditType.Province, 州ToolStripMenuItem },
                { EditType.Region, 地区ToolStripMenuItem },
                { EditType.Title, 爵位ToolStripMenuItem },
                { EditType.Rank, 官职ToolStripMenuItem },
                { EditType.Skill, 特技ToolStripMenuItem },
                { EditType.ArmyLevel, 适性ToolStripMenuItem },
            };

            // 使用到的xml配置文件
            usingDataXmlList = new()
            {
                DataXmlName.path,
                DataXmlName.armyLevel,
                DataXmlName.title,
                DataXmlName.rank,
                DataXmlName.skill,
            };

            // 绑定菜单回调
            foreach (KeyValuePair<EditType, ToolStripMenuItem> pair in menuBtnDict)
            {
                EditType editType = pair.Key;
                ToolStripMenuItem toolStripMenuItem = pair.Value;
                toolStripMenuItem.Click += (object? sender, EventArgs e) =>
                {
                    SetCurrentEditType(editType);
                    statusLabel_currentType.Text = toolStripMenuItem.Text;
                };
            }

            // 未完成功能的菜单按钮
            unusedMenuBtnList = new()
            {
                地形ToolStripMenuItem,
                设施ToolStripMenuItem,
                兵器ToolStripMenuItem,
                战法ToolStripMenuItem,
                技术ToolStripMenuItem,
                能力ToolStripMenuItem,
                宝物ToolStripMenuItem,
            };
            // 未完成功能禁用菜单
            foreach (ToolStripMenuItem toolStripMenuItem in unusedMenuBtnList)
            {
                toolStripMenuItem.Enabled = false;
            }
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
            editHelperDict[editType].InitListView();
        }

        void UpdateListView(EditType editType)
        {
            if (editType == EditType.None) return;
            listView.BeginUpdate();
            listView.Items.Clear();
            editHelperDict[editType].UpdateListView();
            listView.EndUpdate();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            Stopwatch sw = new();
            sw.Start();
#endif
            if (e.Button != MouseButtons.Left)
                return;
            ListView listViewCityPathData = (ListView)sender;
            ListViewItem? listViewItem = listViewCityPathData.GetItemAt(e.X, e.Y);
            if (listViewItem == null)
                return;
            editHelperDict[currentEditType].OnDoubleClicked(this, listViewItem);
#if DEBUG
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"<listViewMouseDoubleClick> {ts.TotalMilliseconds}ms.");
#endif
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            ListView listViewCityPathData = (ListView)sender;
            ListViewItem? listViewItem = listViewCityPathData.GetItemAt(e.X, e.Y);
            if (listViewItem == null)
                return;
            editHelperDict[currentEditType].OnRightClicked(this, listViewItem);
        }

        private void 载入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ScenarioData scenarioData = AppEnvironment.scenarioData;
                scenarioData.LoadFromGlobalScenario(AppEnvironment.GetGlobalScenarioPath());

                foreach (DataXmlName dataXmlName in usingDataXmlList)
                {
                    try
                    {
                        AppEnvironment.xmlHelperDict[dataXmlName].Load(AppEnvironment.GetDataXmlPath(dataXmlName));
                    }
                    catch (KeyNotFoundException)
                    {
                        continue;
                    }
                }

                foreach (BaseEditorHelper editorHelper in editHelperDict.Values)
                {
                    editorHelper.OnLoaded();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "发生错误");
                return;
            }
            statusLabel_currentType.Text = "载入成功";
            UpdateListView(currentEditType);
            保存修改ToolStripMenuItem.Enabled = true;
            全局修改ToolStripMenuItem.Enabled = true;
        }

        private void 保存修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ScenarioData scenarioData = AppEnvironment.scenarioData;
                scenarioData.SaveToGlobalScenario(AppEnvironment.GetGlobalScenarioPath());

                foreach (DataXmlName dataXmlName in usingDataXmlList)
                {
                    try
                    {
                        AppEnvironment.xmlHelperDict[dataXmlName].Save(AppEnvironment.GetDataXmlPath(dataXmlName));
                    }
                    catch (KeyNotFoundException)
                    {
                        continue;
                    }
                }

                foreach (BaseEditorHelper editorHelper in editHelperDict.Values)
                {
                    editorHelper.OnSaved();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "发生错误");
                return;
            }
            MessageBox.Show("保存完毕！", "保存完毕");
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settingsDialog = SettingsDialog.GetInstance();
            settingsDialog.Setup();
            settingsDialog.ShowDialog();
        }
    }
}
