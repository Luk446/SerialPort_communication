using BlueMystic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortExample
{
    public partial class HomeScreen : Form

    {
        private DarkModeCS DM = null;

        public HomeScreen()
        {
            InitializeComponent();
            DM = new DarkModeCS(this);
            this.ActiveControl = null;
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmallHome sHome = new SmallHome();
            sHome.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MediumMain med = new MediumMain();
            med.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LargeMain lar = new LargeMain();
            lar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Diagnostics diagnostics = new Diagnostics();
            diagnostics.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            About bout = new About();
            bout.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
