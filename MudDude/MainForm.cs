namespace MudDude
{
    public partial class MainForm : Form
    {

        Core MainCore;


        // Local UI vars
        private bool isConnected = false;
        private bool isLoggedIn = false;
        private bool isInGame = false;

        public MainForm()
        {
            InitializeComponent();
            MainCore = new Core(this);            
        }

        // Get/Set
        public bool GetIsConnected() { return isConnected; }
        public bool GetIsLoggedIn() { return isLoggedIn; }
        public bool GetIsInGame() { return isInGame; }

        public void SetIsConnected(bool _isConnected) { this.isConnected = _isConnected; }
        public void SetIsLoggedIn(bool _isLoggedIn) { this.isLoggedIn = _isLoggedIn; }
        public void SetIsInGame(bool _isInGame) { this.isInGame = _isInGame; }


        // Called when any changes are made for form vars
        public void UpdateForm()
        {
            UpdateConnectionLabels();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateForm();
            
        }

        private void UpdateConnectionLabels()
        {
            if (isConnected) 
                lblConnected.Visible = true;
            else
                lblConnected.Visible = false;
            if (isLoggedIn)
                lblLoggedIn.Visible = true;
            else
                lblLoggedIn.Visible = false;
            if (isInGame)
                lblInGame.Visible = true;
            else
                lblInGame.Visible = false;            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            MainCore.ConnectToServer();
        }

        public void ShowErrorMessage(string _ErrorMessge)
        {
            MessageBox.Show(_ErrorMessge);
        }

        private void editSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCore.OpenSettingsForm();
        }

        private void btnDebugWindow_Click(object sender, EventArgs e)
        {
            MainCore.OpenDebugWindows();
        }
    }
}