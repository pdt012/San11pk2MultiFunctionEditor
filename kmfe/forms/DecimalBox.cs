namespace kmfe.forms
{
    /// <summary>
    /// 数值输入框
    /// <para>显示上下限提示</para>
    /// </summary>
    public partial class DecimalBox : NumericUpDown
    {
        readonly ToolTip toolTip;

        public DecimalBox()
        {
            InitializeComponent();
            toolTip = new()
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            toolTip.SetToolTip(this, GetToolTopText());
        }

        public new decimal Maximum
        {
            get
            {
                return base.Maximum;
            }
            set
            {
                base.Maximum = value;
                toolTip.SetToolTip(this, GetToolTopText());
            }
        }

        public new decimal Minimum
        {
            get
            {
                return base.Minimum;
            }
            set
            {
                base.Minimum = value;
                toolTip.SetToolTip(this, GetToolTopText());
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected string GetToolTopText()
        {
            string? numberFormat = DecimalPlaces > 0 ? $"f{DecimalPlaces}" : null;
            return string.Format("{0}~{1}", Minimum.ToString(numberFormat), Maximum.ToString(numberFormat));
        }
    }
}
