using kmfe.core;
using kmfe.editor.scenarioConfig.editDialog;

namespace kmfe.editor.scenarioConfig.helper
{
    internal abstract class BaseEditorHelper
    {
        protected ScenarioData scenarioData;
        protected ListView listView;

        public BaseEditorHelper(ScenarioData scenarioData, ListView listView)
        {
            this.scenarioData = scenarioData;
            this.listView = listView;
        }

        protected void OnItemsApplyCallback(List<int>? updatedRowList)
        {
            if (updatedRowList == null)  // 更新整个表格
            {
                listView.Items.Clear();
                UpdateListView();
            }
            else
            {
                UpdateRows(updatedRowList);
            }
        }

        /// <summary>
        /// 表格初始化（创建表头）
        /// </summary>
        /// <param name="listView"></param>
        public abstract void InitListView();

        /// <summary>
        /// 生成表格内容
        /// </summary>
        /// <param name="listView"></param>
        public abstract void UpdateListView();

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
        public void UpdateRow(int row)
        {
            ListViewItem item = listView.Items[row];
            UpdateRow(item);
        }

        /// <summary>
        /// 更新表格多行内容
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="rows">需要更新的行号</param>
        public void UpdateRows(List<int> rows)
        {
            foreach (int row in rows)
            {
                UpdateRow(row);
            }
        }

        /// <summary>
        /// 左键双击时回调
        /// </summary>
        /// <param name="parentForm">父窗口</param>
        /// <param name="item">点击的行对象</param>
        public abstract void OnDoubleClicked(Form parentForm, ListViewItem item);

        /// <summary>
        /// 右键单击时回调
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="item"></param>
        public abstract void OnRightClicked(Form parentForm, ListViewItem item);

        /// <summary>
        /// 载入时回调
        /// </summary>
        public abstract void OnLoaded();

        /// <summary>
        /// 保存时回调
        /// </summary>
        public abstract void OnSaved();

    }
}
