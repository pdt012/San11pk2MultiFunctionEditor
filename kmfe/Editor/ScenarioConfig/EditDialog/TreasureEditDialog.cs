using kmfe.Common;
using kmfe.Core;
using kmfe.Core.GlobalTypes;
using kmfe.Forms;
using kmfe.Properties;
using kmfe.S11.S11Enums;
using System.Drawing;

namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    public partial class TreasureEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        Treasure? treasure;
        int row = -1;
        readonly DecimalBox[] valueStatBuffs;

        public TreasureEditDialog()
        {
            InitializeComponent();
            valueStatBuffs = new DecimalBox[5] { decimalBox1, decimalBox2, decimalBox3, decimalBox4, decimalBox5 };
        }

        public override void Init()
        {
            combo_type.Items.Clear();
            combo_type.Items.AddRange(Enum.GetNames<TreasureType>());
            List<Skill> skills = new();
            foreach (Skill skill in AppEnvironment.scenarioData.skillArray)
            {
                if (skill.IsValid())
                    skills.Add(skill);
            }
            combo_skill.Items.Clear();
            combo_skill.Items.Add("--无--");
            combo_skill.Items.AddRange(skills.ToArray());
        }

        public void Setup(Treasure treasure, int row)
        {
            this.treasure = treasure;
            this.row = row;
            text_id.Text = treasure.Id.ToString();
            text_name.Text = treasure.name;
            text_read.Text = treasure.read;
            text_history.Text = treasure.history;
            combo_type.SelectedIndex = (int)treasure.type;
            value_worth.Value = treasure.worth;
            // 特技
            combo_skill.SelectedItem = null;
            if (treasure.bindSkillId >= 0)
                combo_skill.SelectedItem = AppEnvironment.scenarioData.skillArray[treasure.bindSkillId];
            combo_skill.SelectedItem ??= "--无--";
            // 能力加成
            for (int i = 0; i < 5; i++)
            {
                valueStatBuffs[i].Value = treasure.statBuff[i];
            }
            // 图片
            text_image.Text = treasure.imagePath;
            ShowImage(treasure.imagePath);
        }

        public override bool Apply()
        {
            if (treasure == null) return false;
            if (text_name.Text.Length == 0)
            {
                MessageBox.Show("名称不可以为空.");
                return false;
            }
            treasure.name = text_name.Text;
            treasure.read = text_read.Text;
            treasure.history = text_history.Text;
            treasure.type = (TreasureType)combo_type.SelectedIndex;
            treasure.worth = (int)value_worth.Value;
            // 特技
            if (combo_skill.SelectedItem is Skill skill)
                treasure.bindSkillId = skill.Id;
            else
                treasure.bindSkillId = -1;
            // 能力加成
            for (int i = 0; i < 5; i++)
            {
                treasure.statBuff[i] = (int)valueStatBuffs[i].Value;
            }
            // 图片
            treasure.imagePath = text_image.Text;

            OnApply?.Invoke(new List<int>() { row });
            return true;
        }

        private void picture_image_Click(object sender, EventArgs e)
        {
            if (treasure == null) return;
            string path = Path.Combine(AppEnvironment.GetDataPath(), treasure.imagePath);
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "选择宝物图片",
                Filter = "bmp文件|*.bmp"
            };
            if (File.Exists(path))
                openFileDialog.InitialDirectory = path;
            else
                openFileDialog.InitialDirectory = AppEnvironment.GetDataPath();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.FileName.StartsWith(AppEnvironment.GetDataPath())) { 
                    MessageBox.Show("请选择data目录下的图片文件！", "非法图片路径");
                    return;
            }
                string relativePath = openFileDialog.FileName.Replace(AppEnvironment.GetDataPath(), "");
                relativePath = relativePath.Trim('/').Trim('\\');
                text_image.Text = relativePath;
                ShowImage(relativePath);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void ShowImage(string imageRelativePath)
        {
            try
            {
                Bitmap bitmap = new Bitmap(Path.Combine(AppEnvironment.GetDataPath(), imageRelativePath).Replace("/", "\\"));
                picture_image.Image = bitmap;
            }
            catch (ArgumentException)
            {
                picture_image.Image = Resources.close;
            }
        }
    }
}
