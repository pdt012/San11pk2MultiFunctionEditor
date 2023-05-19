using kmfe.Common;

namespace kmfe.Editor
{
    public partial class SettingsDialog : Form
    {
        private static SettingsDialog? instance;

        public static SettingsDialog GetInstance()
        {
            instance ??= new SettingsDialog();
            return instance;
        }

        private SettingsDialog()
        {
            InitializeComponent();
        }

        public void Init()
        {

        }

        public void Setup()
        {
            text_pk2path.Text = Settings.Pk2Path;
        }


        private void btn_set_pk2path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new()
            {
                Description = "请选择pk2.2文件夹",
                SelectedPath = Settings.Pk2Path.Length > 0 ? Settings.Pk2Path : Path.GetFullPath("."),
                ShowNewFolderButton = false,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.SelectedPath.EndsWith("pk2.2"))
                {
                    string? gameRootPath = Path.GetDirectoryName(dialog.SelectedPath);
                    if (gameRootPath != null)
                    {
                        Settings.Pk2Path = dialog.SelectedPath;
                        Settings.PkPath = Path.Combine(gameRootPath, "PK");
                    }
                    else
                    {
                        AppFormUtils.WarningBox("当前路径找不到PK文件夹！", "路径选择错误");
                    }
                }
                else
                {
                    AppFormUtils.WarningBox("请选择pk2.2文件夹！", "路径选择错误");
                }
            }
            text_pk2path.Text = Settings.Pk2Path;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Settings.Save();
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
