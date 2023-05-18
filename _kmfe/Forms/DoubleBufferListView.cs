namespace kmfe.Forms
{
    public partial class DoubleBufferListView : System.Windows.Forms.ListView
    {
        public DoubleBufferListView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
