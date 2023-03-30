using kmfe.core;
using kmfe.core.types;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Region = kmfe.core.types.Region;

namespace kmfe.editor
{
    internal enum EditType
    {
        None,
        City,
        GatePort,
        CityLikeDistance,
        Province,
        Region
    }

    public partial class ScenarioConfigEditor : Form
    {
        readonly ScenarioData scenarioData = new ScenarioData();
        EditType currentEditType = EditType.None;

        readonly CityLikeNeighborEdit cityLikeNeighborEdit;

        public ScenarioConfigEditor()
        {
            InitializeComponent();
            cityLikeNeighborEdit = new CityLikeNeighborEdit();
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
            listView.Clear();
            listView.View = View.Details;
            switch (editType)
            {
                case EditType.City:
                    listView.Columns.Add("ID", 40);
                    listView.Columns.Add("名称", 60);
                    listView.Columns.Add("相邻城市", 300);
                    break;
                case EditType.GatePort:
                    listView.Columns.Add("ID", 40);
                    listView.Columns.Add("名称", 80);
                    break;
                case EditType.CityLikeDistance:
                    listView.Columns.Add("ID", 40);
                    listView.Columns.Add("据点名", 80);
                    listView.Columns.Add("相邻据点", 300);
                    listView.Columns.Add("相邻城市", 300);
                    break;
                case EditType.Province:
                    listView.Columns.Add("ID", 40);
                    listView.Columns.Add("名称", 60);
                    listView.Columns.Add("读音", 100);
                    listView.Columns.Add("__12", 100);
                    listView.Columns.Add("介绍", 100);
                    listView.Columns.Add("地区", 60);
                    listView.Columns.Add("相邻州", 300);
                    break;
                case EditType.Region:
                    listView.Columns.Add("ID", 40);
                    listView.Columns.Add("名称", 60);
                    break;
                default:
                    break;
            }
        }

        void UpdateListView(EditType editType)
        {
            listView.BeginUpdate();
            listView.Items.Clear();
            switch (editType)
            {
                case EditType.City:
                    UpdateListView_city();
                    break;
                case EditType.GatePort:
                    UpdateListView_gatePort();
                    break;
                case EditType.CityLikeDistance:
                    UpdateListView_cityLikeDistance();
                    break;
                case EditType.Province:
                    UpdateListView_province();
                    break;
                case EditType.Region:
                    UpdateListView_region();
                    break;
                default:
                    break;
            }
            listView.EndUpdate();
        }

        void UpdateListView_city()
        {
            foreach (City city in scenarioData.cityArray)
            {
                ListViewItem item = new ListViewItem()
                {
                    Tag = city,
                    Text = city.id.ToString()
                };
                item.SubItems.Add(city.name);
                List<string> adjacentCityNames = scenarioData.GetAdjacentCityNames(city);
                item.SubItems.Add(string.Join(", ", adjacentCityNames));
                listView.Items.Add(item);
            }
        }

        void UpdateListView_gatePort()
        {
            foreach (GatePort gatePort in scenarioData.gatePortArray)
            {
                ListViewItem item = new ListViewItem()
                {
                    Tag = gatePort,
                    Text = (gatePort.id).ToString()
                };
                item.SubItems.Add(gatePort.name);
                listView.Items.Add(item);
            }
        }

        void UpdateListView_cityLikeDistance()
        {
            foreach (City city in scenarioData.cityArray)
            {
                ListViewItem item = new ListViewItem()
                {
                    Tag = city,
                    Text = city.id.ToString()
                };
                item.SubItems.Add(city.name);
                List<string> neighborNames = scenarioData.GetNeighborNames(city);
                item.SubItems.Add(string.Join(", ", neighborNames));
                List<string> adjacentCityNames = scenarioData.GetAdjacentCityNames(city);
                item.SubItems.Add(string.Join(", ", adjacentCityNames));
                listView.Items.Add(item);
            }
            foreach (GatePort gatePort in scenarioData.gatePortArray)
            {
                ListViewItem item = new ListViewItem()
                {
                    Tag = gatePort,
                    Text = (gatePort.id).ToString()
                };
                item.SubItems.Add(gatePort.name);
                List<string> neighborNames = scenarioData.GetNeighborNames(gatePort);
                item.SubItems.Add(string.Join(", ", neighborNames));
                listView.Items.Add(item);
            }
        }

        void UpdateListView_province()
        {
            foreach (Province province in scenarioData.provinceArray)
            {
                ListViewItem item = new ListViewItem()
                {
                    Tag = province,
                    Text = province.id.ToString()
                };
                item.SubItems.Add(province.name);
                item.SubItems.Add(province.read);
                item.SubItems.Add(province.__12);
                item.SubItems.Add(province.desc);
                item.SubItems.Add(scenarioData.regionArray[province.regionId].name);
                List<string> adjacentProvinceNames = scenarioData.GetAdjacentProvinceNames(province);
                item.SubItems.Add(string.Join(", ", adjacentProvinceNames));
                listView.Items.Add(item);
            }
        }

        void UpdateListView_region()
        {
            foreach (Region region in scenarioData.regionArray)
            {
                ListViewItem item = new ListViewItem()
                {
                    Tag = region,
                    Text = region.id.ToString()
                };
                item.SubItems.Add(region.name);
                listView.Items.Add(item);
            }
        }
        void DoubleClick_cityLikeDistance(ListViewItem listViewItem)
        {
            CityLike cityLike = (CityLike)listViewItem.Tag;
            cityLikeNeighborEdit.Setup(cityLike);
            cityLikeNeighborEdit.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = cityLikeNeighborEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                cityLikeNeighborEdit.Save(cityLike);
                UpdateListView(currentEditType);
            }
        }

        private void listViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listViewCityPathData = (ListView)sender;
            ListViewItem listViewItem = listViewCityPathData.GetItemAt(e.X, e.Y);
            if (listViewItem == null)
                return;
            switch (currentEditType)
            {
                case EditType.City:
                    break;
                case EditType.GatePort:
                    break;
                case EditType.CityLikeDistance:
                    DoubleClick_cityLikeDistance(listViewItem);
                    break;
                case EditType.Province:
                    break;
                case EditType.Region:
                    break;
                default:
                    break;
            }
        }

        private void 载入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                scenarioData.LoadFromGlobalScenario("./PK/Media/scenario/scenario.s11");
                PathXmlHelper pathXmlHelper = new PathXmlHelper(scenarioData);
                pathXmlHelper.Load("./pk2.2/data/01 path.xml");
                cityLikeNeighborEdit.Init(scenarioData);
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
                PathXmlHelper pathXmlHelper = new PathXmlHelper(scenarioData);
                pathXmlHelper.Save("./pk2.2/data/01 path.xml");
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
            SetCurrentEditType(EditType.GatePort);
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
    }
}
