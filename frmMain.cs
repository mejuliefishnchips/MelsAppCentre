using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MelsAppCentre
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            frmPaint myPaint = new frmPaint();
            myPaint.ShowDialog();
        }

        private void btnAdventureGame_Click(object sender, EventArgs e)
        {
            frmAdventureGame myGame = new frmAdventureGame();
            myGame.ShowDialog();
        }
    }
}
