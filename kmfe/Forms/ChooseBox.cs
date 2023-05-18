namespace kmfe.Forms
{
    public partial class ChooseBox : UserControl
    {
        List<IntString> allChoices = new();  // 所有选项
        bool isSearching = false;  // 是否正在搜索
        List<int> selected = new();  // 已选项列表
        List<int> unselected = new();  // 未选项列表
        List<int> foundUnselected = new();  // 搜索状态时的选项表

        public ChooseBox()
        {
            InitializeComponent();
        }

        public bool ShowCloseBtn
        {
            get { return close_btn.Visible; }
            set { close_btn.Visible = value; }
        }

        public int MaxSelections { set; get; } = -1;

        public List<IntString> Choices
        {
            set
            {
                allChoices = value;
                SetSelected(Array.Empty<int>());  // 初始化
            }
            get
            {
                return allChoices;
            }
        }

        public void SetSelected(int[] array)
        {
            selected = array.ToList(); ;
            UpdateSelected();
            unselected.Clear();
            foreach (IntString tag in allChoices)
            {
                if (selected.IndexOf(tag.Num) == -1)    // 已选中没有
                    unselected.Add(tag.Num);
            }
            UpdateUnselected();
        }

        public int[] GetSelected()
        {
            return selected.ToArray();
        }

        private void UpdateSelected()
        {
            chosen_list.BeginUpdate();
            chosen_list.Items.Clear();
            foreach (int id in selected)
            {
                int index = FindIndex(id);
                if (index >= 0)
                    chosen_list.Items.Add(allChoices[index].Str);
            }
            chosen_list.EndUpdate();
        }

        private void UpdateUnselected()
        {
            choice_list.BeginUpdate();
            choice_list.Items.Clear();
            if (isSearching)
            {
                foreach (int id in foundUnselected)
                {
                    int index = FindIndex(id);
                    if (index >= 0)
                        choice_list.Items.Add(allChoices[index].Str);
                }
            }
            else
            {
                foreach (int id in unselected)
                {
                    int index = FindIndex(id);
                    if (index >= 0)
                        choice_list.Items.Add(allChoices[index].Str);
                }
            }
            choice_list.EndUpdate();
        }

        /// <summary>
        /// 查找id对应的allChoices中的索引
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int FindIndex(int id)
        {
            for (int i = 0; i < allChoices.Count; i++)
            {
                if (allChoices[i].Num == id)
                    return i;
                else if (allChoices[i].Num > id)
                    break;
            }
            return -1;
        }

        private void Search(string word = "")
        {
            foundUnselected.Clear();
            if (word.Length > 0)
            {
                isSearching = true;
                choice_list.Items.Clear();
                foreach (int id in unselected)
                {
                    int index = FindIndex(id);
                    if (index >= 0 && allChoices[index].Str.IndexOf(word) >= 0)
                        foundUnselected.Add(id);
                }
            }
            else
                isSearching = false;
            UpdateUnselected();
        }

        private void SelectItem(int index)
        {
            if (selected.Count >= MaxSelections && MaxSelections >= 0)
                return;
            int id;
            if (isSearching)
            {
                id = foundUnselected[index];
                foundUnselected.RemoveAt(index);
                unselected.Remove(id);
            }
            else
            {
                id = unselected[index];
                unselected.RemoveAt(index);
            }
            // 找到正确位置插入
            bool inserted = false;
            for (int i = 0; i < selected.Count; i++)
            {
                if (selected[i] > id)
                {
                    selected.Insert(i, id);
                    inserted = true;
                    break;
                }
            }
            if (!inserted)
                selected.Add(id);
            UpdateSelected();
            UpdateUnselected();
        }

        private void UnselectItem(int index)
        {
            int id = selected[index];
            selected.RemoveAt(index);
            // 找到正确位置插入
            bool inserted = false;
            for (int i = 0; i < unselected.Count; i++)
            {
                if (unselected[i] > id)
                {
                    unselected.Insert(i, id);
                    inserted = true;
                    break;
                }
            }
            if (!inserted)
                unselected.Add(id);
            if (isSearching)
            {
                foundUnselected.Add(id);
                foundUnselected.Sort();
            }
            UpdateSelected();
            UpdateUnselected();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void search_input_TextChanged(object sender, EventArgs e)
        {
            Search(search_input.Text);
        }

        private void chosen_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            int index = chosen_list.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                UnselectItem(index);
            }
        }

        private void choice_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            int index = choice_list.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                SelectItem(index);
            }
        }
    }

    public record IntString(int Num, string Str);
}
