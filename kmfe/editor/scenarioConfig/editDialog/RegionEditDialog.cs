using Region = kmfe.core.globalTypes.Region;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public partial class RegionEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        Region? region;

        public RegionEditDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
        }

        public void Setup(Region region)
        {
            this.region = region;
            text_id.Text = region.Id.ToString();
            text_name.Text = region.name;
            text_read.Text = region.read;
        }

        public override bool Apply()
        {
            if (region == null) return false;
            region.name = text_name.Text;
            region.read = text_read.Text;

            OnApply?.Invoke(new List<int>() { region.Id });
            return true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
