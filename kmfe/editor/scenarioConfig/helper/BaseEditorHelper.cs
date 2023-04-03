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
        /// 更新表格内容
        /// </summary>
        /// <param name="listView"></param>
        public abstract void UpdateListView(ListView listView);

        /// <summary>
        /// 更新表格内容
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="rows">需要更新的行号</param>
        public abstract void UpdateListView(ListView listView, List<int> rows);

    }
}
