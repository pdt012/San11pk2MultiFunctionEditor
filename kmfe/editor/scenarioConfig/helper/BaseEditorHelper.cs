using kmfe.core;

namespace kmfe.editor.scenarioConfig.helper
{
    internal abstract class BaseEditorHelper
    {
        protected ScenarioData scenarioData;

        public BaseEditorHelper(ScenarioData scenarioData)
        {
            this.scenarioData = scenarioData;
        }

        /// <summary>
        /// 表格初始化（创建表头）
        /// </summary>
        /// <param name="listView"></param>
        public abstract void InitListView(ListView listView);

        /// <summary>
        /// 生成表格内容
        /// </summary>
        /// <param name="listView"></param>
        public abstract void UpdateListView(ListView listView);

        /// <summary>
        /// 更新表格一行内容
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="item">需要更新的行对象</param>
        public abstract void UpdateRow(ListViewItem item);

        /// <summary>
        /// 更新表格一行内容
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="row">需要更新的行号</param>
        public void UpdateRow(ListView listView, int row)
        {
            ListViewItem item = listView.Items[row];
            UpdateRow(item);
        }

        /// <summary>
        /// 更新表格多行内容
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="rows">需要更新的行号</param>
        public void UpdateRows(ListView listView, List<int> rows)
        {
            foreach (int row in rows)
            {
                UpdateRow(listView, row);
            }
        }

    }
}
