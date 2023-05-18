﻿using kmfe.Editor.ScenarioConfig.EditDialog;

namespace kmfe.Editor.ScenarioConfig.EditHelper
{
    internal abstract class BaseEditorHelper
    {
        protected ListView listView;
        protected BaseEditDialog? baseEditDialog;

        public BaseEditorHelper(ListView listView)
        {
            this.listView = listView;
        }

        protected void OnItemsApplyCallback(List<int>? updatedRowList)
        {
            if (updatedRowList == null)  // 更新整个表格
            {
                UpdateListView();
            }
            else
            {
                UpdateRows(updatedRowList);
            }
        }

        /// <summary>
        /// 获取数据行数
        /// </summary>
        /// <returns></returns>
        public abstract int GetCount();

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
        public virtual void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
        }

        /// <summary>
        /// 右键单击时回调
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="item"></param>
        public virtual void OnRightClicked(Form parentForm, ListViewItem item)
        {
        }

        /// <summary>
        /// 进入该项目修改时
        /// </summary>
        public virtual void OnEnter()
        {
            baseEditDialog?.Init();
        }

        /// <summary>
        /// 退出该项目修改时
        /// </summary>
        public virtual void OnLeave()
        {
            baseEditDialog?.Hide();
        }

        /// <summary>
        /// 载入时回调
        /// </summary>
        public virtual void OnLoaded()
        {
        }

        /// <summary>
        /// 保存时回调
        /// </summary>
        public virtual void OnSaved()
        {
        }

    }
}