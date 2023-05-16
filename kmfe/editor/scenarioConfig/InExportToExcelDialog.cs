namespace kmfe.editor.scenarioConfig
{
    public partial class InExportToExcelDialog : Form
    {
        public InExportToExcelDialog()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public string OkButtonText
        {
            get
            {
                return btn_ok.Text;
            }
            set
            {
                btn_ok.Text = value;
            }
        }

        public string[] Headers
        {
            set
            {
                checkedListBox.Items.Clear();
                foreach (string header in value)
                {
                    checkedListBox.Items.Add(header);
                }
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, true);
                }
            }
            get
            {
                List<string> checkedHeaders = new();
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    string? header = checkedListBox.Items[i].ToString();
                    if (header != null)
                        checkedHeaders.Add(header);
                }
                return checkedHeaders.ToArray();
            }
        }

        public string EditTypeName
        {
            set
            {
                text_edit_type.Text = value;
            }
            get
            {
                return text_edit_type.Text;
            }
        }

        public string[] CheckedHeaders
        {
            get
            {
                List<string> checkedHeaders = new();
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (checkedListBox.GetItemChecked(i))
                    {
                        string? header = checkedListBox.Items[i].ToString();
                        if (header != null)
                            checkedHeaders.Add(header);
                    }
                }
                return checkedHeaders.ToArray();
            }
        }

        private void btn_choose_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
        }

        private void btn_cancel_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (CheckedHeaders.Contains("ID"))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("必须选择ID项！", "无法导出");
            }

        }
    }
}
