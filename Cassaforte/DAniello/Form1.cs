namespace DAniello
{
    public partial class win : Form
    {
        int nClick = 0;
        string password = "310864";

        bool state = false; // per disattivare i controlli dell'inserimento della combinazione

        int nAttempts = 0;

        private Bitmap image;

        //private string filename = "./Img/";

        public win()
        {
            InitializeComponent();
        }

        private void numBtnClicked(object sender, EventArgs e) {
            passDisp.Text += ((Button)sender).Text;
            nClick++;
            control();
            changePassword();
        }

        private void control()
        {
            if (nClick == 6 && !state)
            {
                if (passDisp.Text == password)
                {
                    numBtnEnableSystem();
                    addBtnPanel.Visible = true;
                    this.Text = "Cassaforte aperta";
                    imageBox.Size = new Size(500, 300);
                    loadImage(Image.FromFile("./Img/cassaforte_aperta.jpg"));
                }
                else
                {
                    passDisp.Text = "";
                    nClick = 0;
                    nAttempts++;
                }
            }
            if (nAttempts == 3)
            {
                alarmPanel.Visible = true;
            }
        }

        private void closeBtnClicked(object sender, EventArgs e)
        {
            numBtnEnableSystem();
            passDisp.Text = "";
            nClick = 0;
            addBtnPanel.Visible = false;
            nAttempts = 0;
            this.Text = "Cassaforte Chiusa";
            imageBox.Size = new Size(279, 300);
            loadImage(Image.FromFile("./Img/cassaforte_chiusa.jpg"));
        }

        private void numBtnEnableSystem()
        {
            button1.Enabled = !button1.Enabled;
            button2.Enabled = !button2.Enabled;
            button3.Enabled = !button3.Enabled;
            button4.Enabled = !button4.Enabled;
            button5.Enabled = !button5.Enabled;
            button6.Enabled = !button6.Enabled;
            button7.Enabled = !button7.Enabled;
            button8.Enabled = !button8.Enabled;
            button9.Enabled = !button9.Enabled;
            button10.Enabled = !button10.Enabled;
        }

        private void changePass(object sender, EventArgs e)
        {
            MessageBox.Show("Digita la nuova combinazione");
            numBtnEnableSystem();
            nClick = 0;
            state = true;
            closeBtn.Enabled = false;
            changePassBtn.Enabled = false;
            passDisp.Text = "";
            changePassword();
        }

        private void changePassword()
        {
            if (nClick == 6 && state)
            {
                password = passDisp.Text;
                state = false;
                closeBtn.Enabled = true;
                changePassBtn.Enabled = true;
                numBtnEnableSystem();
            }
        }

        private void loadImage(Image filePath)
        {
            if (image != null)
            {
                image.Dispose();
            }
            imageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(filePath);
            imageBox.ClientSize = new Size(imageBox.Width, imageBox.Height);
            imageBox.Image = (Image)image;

        }

        private void win_Load(object sender, EventArgs e)
        {
            // this.Size = new Size(1000, 1000);
            imageBox.Size = new Size(279, 300);
            loadImage(Image.FromFile("./Img/cassaforte_chiusa.jpg"));
        }
    }
}