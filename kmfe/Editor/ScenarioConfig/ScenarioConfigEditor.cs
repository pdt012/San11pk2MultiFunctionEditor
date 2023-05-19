using ClosedXML.Excel;
using kmfe.Core;
using kmfe.Core.ExcelHelper;
using kmfe.Editor.ScenarioConfig.EditHelper;
using System.Diagnostics;

namespace kmfe.Editor.ScenarioConfig
{
    record EditTypeRecord(string Name, BaseEditorHelper EditorHelper, ToolStripMenuItem MenuBtn, BaseExcelHelper? ExcelHelper);

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
        Treasure,
        ArmyLevel,
    }

    public partial class ScenarioConfigEditor : Form
    {
        EditType currentEditType = EditType.None;

        readonly Dictionary<EditType, EditTypeRecord> editTypeRecordDict;
        readonly List<DataXmlName> usingDataXmlList;
        readonly List<ToolStripMenuItem> unusedMenuBtnList;

        public ScenarioConfigEditor()
        {
            InitializeComponent();
            保存修改ToolStripMenuItem.Enabled = false;
            全局修改ToolStripMenuItem.Enabled = false;
            剧本修改ToolStripMenuItem.Enabled = false;
            导出ToolStripMenuItem.Enabled = false;
            导入ToolStripMenuItem.Enabled = false;

            editTypeRecordDict = new()
            {
                { EditType.City,
                    new ("城市", new CityEditHelper(listView), 城市ToolStripMenuItem, null) },
                { EditType.Town,
                    new ("港关", new TownEditHelper(listView) ,港关ToolStripMenuItem, null) },
                { EditType.CityLikeDistance,
                    new ("据点距离", new NeighborEditHelper(listView), 据点距离ToolStripMenuItem, null) },
                { EditType.Province,
                    new ("州", new ProvinceEditHelper(listView), 州ToolStripMenuItem, null) },
                { EditType.Region,
                    new ("地区", new RegionEditHelper(listView), 地区ToolStripMenuItem, null) },
                { EditType.Title,
                    new ("爵位", new TitleEditHelper(listView), 爵位ToolStripMenuItem, new TitleExcelHelper()) },
                { EditType.Rank,
                    new ("官职", new RankEditHelper(listView), 官职ToolStripMenuItem, new RankExcelHelper()) },
                { EditType.Skill,
                    new ("特技", new SkillEditHelper(listView), 特技ToolStripMenuItem, new SkillExcelHelper()) },
                { EditType.Treasure,
                    new ("宝物", new TreasureEditHelper(listView), 宝物ToolStripMenuItem, new TreasureExcelHelper()) },
                { EditType.ArmyLevel,
                    new ("适性", new ArmyLevelEditHelper(listView), 适性ToolStripMenuItem, new ArmyLevelExcelHelper()) },
            };

            // 使用到的xml配置文件
            usingDataXmlList = new()
            {
                DataXmlName.path,
                DataXmlName.armyLevel,
                DataXmlName.title,
                DataXmlName.rank,
                DataXmlName.skill,
                DataXmlName.treasure,
                DataXmlName.treasureModel,
            };

            // 绑定菜单回调
            foreach (KeyValuePair<EditType, EditTypeRecord> pair in editTypeRecordDict)
            {
                EditType editType = pair.Key;
                EditTypeRecord record = pair.Value;
                ToolStripMenuItem toolStripMenuItem = record.MenuBtn;
                toolStripMenuItem.Click += (object? sender, EventArgs e) =>
                {
                    SetCurrentEditType(editType);
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
            };
            // 未完成功能禁用菜单
            foreach (ToolStripMenuItem toolStripMenuItem in unusedMenuBtnList)
            {
                toolStripMenuItem.Enabled = false;
            }
        }

        void SetCurrentEditType(EditType newEditType)
        {
            if (currentEditType == newEditType) return;
            if (editTypeRecordDict.TryGetValue(currentEditType, out EditTypeRecord? currentEditTypeRecord))
            {
                currentEditTypeRecord?.EditorHelper.OnLeave();
            }
            currentEditType = newEditType;
            EditTypeRecord newEditTypeRecord = editTypeRecordDict[newEditType];
            newEditTypeRecord.EditorHelper.OnEnter();
            statusLabel_currentType.Text = newEditTypeRecord.Name;
            InitListView(newEditType);
            UpdateListView(newEditType);
        }

        void InitListView(EditType editType)
        {
            if (editType == EditType.None) return;
            listView.Clear();
            listView.View = View.Details;
            editTypeRecordDict[editType].EditorHelper.InitListView();
        }

        void UpdateListView(EditType editType)
        {
            if (editType == EditType.None) return;
            listView.BeginUpdate();
            editTypeRecordDict[editType].EditorHelper.UpdateListView();
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
            editTypeRecordDict[currentEditType].EditorHelper.OnDoubleClicked(this, listViewItem);
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
            editTypeRecordDict[currentEditType].EditorHelper.OnRightClicked(this, listViewItem);
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

                foreach (EditTypeRecord editTypeRecord in editTypeRecordDict.Values)
                {
                    editTypeRecord.EditorHelper.OnLoaded();
                }
            }
            catch (Exception exc)
            {
                AppFormUtils.ErrorBox(exc.ToString(), "发生错误");
                return;
            }
            statusLabel_currentType.Text = "载入成功";
            UpdateListView(currentEditType);
            保存修改ToolStripMenuItem.Enabled = true;
            全局修改ToolStripMenuItem.Enabled = true;
            导出ToolStripMenuItem.Enabled = true;
            导入ToolStripMenuItem.Enabled = true;
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

                foreach (EditTypeRecord editTypeRecord in editTypeRecordDict.Values)
                {
                    editTypeRecord.EditorHelper.OnSaved();
                }
            }
            catch (Exception exc)
            {
                AppFormUtils.ErrorBox(exc.ToString(), "发生错误");
                return;
            }
            AppFormUtils.InformationBox("保存完毕！", "保存完毕");
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settingsDialog = SettingsDialog.GetInstance();
            settingsDialog.Setup();
            settingsDialog.ShowDialog();
        }

        private void 导出到Excel此页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EditTypeRecord editTypeRecord = editTypeRecordDict[currentEditType];
                if (editTypeRecord == null) return;
                BaseExcelHelper? excelHelper = editTypeRecord.ExcelHelper ?? throw new("此项目不支持Excel导出");
                InExportToExcelDialog inExportToExcelDialog = new()
                {
                    Text = "导出到Excel",
                    OkButtonText = "导出",
                    Headers = excelHelper.ExcelHeaders,
                    EditTypeName = editTypeRecord.Name
                };
                if (inExportToExcelDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFileDialog saveFileDialog = new()
                    {
                        Title = "选择导出到的Excel文件",
                        Filter = "Excel文件|*.xlsx",
                        InitialDirectory = "."
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 打开Excel文档
                        XLWorkbook workbook = new();
                        if (excelHelper != null)
                        {
                            IXLWorksheet worksheet = workbook.Worksheets.Add(editTypeRecord.Name);
                            excelHelper.WriteExcelSheet(worksheet, inExportToExcelDialog.CheckedHeaders, editTypeRecord.EditorHelper.GetCount());
                        }
                        workbook.SaveAs(saveFileDialog.FileName);
                        AppFormUtils.InformationBox("导出成功！", "导出成功");
                    }
                }
            }
            catch (Exception exc)
            {
                AppFormUtils.ErrorBox(exc.ToString(), "发生错误");
                return;
            }
        }

        private void 导出到Excel全局配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppFormUtils.QuestionBox("此操作将全部全局配置导出到Excel文件，可能需要较长时间，是否继续？", "全部全局配置导出到Excel"))
                    return;
                SaveFileDialog saveFileDialog = new()
                {
                    Title = "选择导出到的Excel文件",
                    Filter = "Excel文件|*.xlsx",
                    InitialDirectory = "."
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 打开Excel文档
                    XLWorkbook workbook = new();
                    foreach (EditTypeRecord editTypeRecord in editTypeRecordDict.Values)
                    {
                        BaseExcelHelper? excelHelper = editTypeRecord.ExcelHelper;
                        if (excelHelper != null)
                        {
                            IXLWorksheet worksheet = workbook.Worksheets.Add(editTypeRecord.Name);
                            excelHelper.WriteExcelSheet(worksheet, excelHelper.ExcelHeaders, editTypeRecord.EditorHelper.GetCount());
                        }
                    }
                    workbook.SaveAs(saveFileDialog.FileName);
                    AppFormUtils.InformationBox("导出成功！", "导出成功");
                }
            }
            catch (Exception exc)
            {
                AppFormUtils.ErrorBox(exc.ToString(), "发生错误");
                return;
            }
        }

        private void 从Excel导入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new()
                {
                    Title = "选择导入的Excel文件",
                    Filter = "Excel文件|*.xlsx",
                    InitialDirectory = "."
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EditTypeRecord editTypeRecord = editTypeRecordDict[currentEditType];
                    if (editTypeRecord == null) return;
                    BaseExcelHelper? excelHelper = editTypeRecord.ExcelHelper ?? throw new("此项目不支持Excel导入");
                    // 读取Excel文件
                    XLWorkbook workbook = new(openFileDialog.FileName);
                    if (!workbook.TryGetWorksheet(editTypeRecord.Name, out IXLWorksheet worksheet))
                        throw new($"找不到对应的Excel表({editTypeRecord.Name})");
                    // 读取表头
                    string[] headers = excelHelper.ReadExcelSheetHeaders(worksheet);
                    if (!headers.Contains("ID"))
                        throw new($"Excel表({editTypeRecord.Name})中缺少ID列");
                    InExportToExcelDialog inExportToExcelDialog = new()
                    {
                        Text = "从Excel导入",
                        OkButtonText = "导入",
                        Headers = headers,
                        EditTypeName = editTypeRecord.Name
                    };
                    if (inExportToExcelDialog.ShowDialog() == DialogResult.OK)
                    {
                        excelHelper.ReadExcelSheet(worksheet, inExportToExcelDialog.CheckedHeaders);
                        AppFormUtils.InformationBox("导入成功！", "导入成功");
                        // 刷新表格
                        editTypeRecord.EditorHelper.UpdateListView();
                    }
                }
            }
            catch (Exception exc)
            {
                AppFormUtils.ErrorBox(exc.ToString(), "发生错误");
                return;
            }
        }
    }
}
