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
    public partial class SmallHome : Form
    {
        public SmallHome()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Small1 small1 = new Small1();
            small1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Small2 small2 = new Small2();
            small2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Small3 small3 = new Small3();
            small3.Show();
            this.Hide();
        }
    }
}
