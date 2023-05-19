namespace kmfe.Editor
{
    public static class AppFormUtils
    {
        public static void InformationBox(string text, string caption = "提示")
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void WarningBox(string text, string caption = "警告")
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ErrorBox(string text, string caption = "错误")
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool QuestionBox(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }
    }
}
