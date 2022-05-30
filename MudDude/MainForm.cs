namespace MudDude
{
    public partial class MainForm : Form
    {

        Core MainCore;

        public MainForm()
        {
            InitializeComponent();
            MainCore = new Core(this);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HideLabelButtons();
        }

        private void HideLabelButtons()
        {
            lblConnected.Visible = false;
            lblInGame.Visible = false;
            lblLoggedIn.Visible = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // TODO replace these magic numbers
            MainCore.ConnectToServer();
        }
    }
}