using Engine;
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
    public partial class frmAdventureGame : Form
    {
        //adding variable to store player
        private Player myPlayer;

        public frmAdventureGame()
        {
            InitializeComponent();

            myPlayer = new Player(10, 10, 20, 0, 1);

            lblHitPoints.Text = myPlayer.currentHitPoints.ToString();
            lblGold.Text = myPlayer.gold.ToString();
            lblExperience.Text = myPlayer.experiencePoints.ToString();
            lblLevel.Text = myPlayer.level.ToString();

            Location location = new Location(1, "Home", "This is your house.");
            

        }





        private void frmAdventureGame_Load(object sender, EventArgs e)
        {

        }
    }
}
