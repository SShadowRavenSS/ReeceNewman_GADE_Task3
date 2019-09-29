using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Units
{
    public partial class frmBattleSim : Form
    {
        
        GameEngine gameEngine;

        public frmBattleSim()
        {
            InitializeComponent();
        }

        private void frmBattleSim_Load(object sender, EventArgs e)
        {

            gameEngine = new GameEngine(5);
            lblMap.Text = gameEngine.Map.convertMap();
            
            rtxUnitInfo.Text = gameEngine.getStats(gameEngine.Map.Units,gameEngine.Map.Buildings);
            
        }

        

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrOnly.Enabled = true;
            tmrOnly.Start();
        }

        private void playGame(object sender, EventArgs e)
        {
            gameEngine.gameLogic(gameEngine.Map.Units, gameEngine.Map.Buildings);
            lblMap.Text = gameEngine.Map.convertMap();
            lblTimer.Text = Convert.ToString(Convert.ToInt32(lblTimer.Text) + 1);
            rtxUnitInfo.Text = gameEngine.getStats(gameEngine.Map.Units, gameEngine.Map.Buildings);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            tmrOnly.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           // if (!Directory.Exists("saves"))
            //{
              //  Directory.CreateDirectory("saves");

                //if (!Directory.Exists("saves/units"))
                //{
                  //  Directory.CreateDirectory("saves/units");
                //}

            //}
            Directory.CreateDirectory("saves");
            Directory.CreateDirectory("saves/units");
            Directory.CreateDirectory("saves/buildings");


            FileStream fs = new FileStream("saves/units/saves.game", FileMode.Create, FileAccess.Write); //opens a new filestream and creates and overrides file if it does not exist 
            fs.Close(); // closes filestream
            FileStream fs1 = new FileStream("saves/buildings/saves.game", FileMode.Create, FileAccess.Write); //opens a new filestream and creates and overrides file if it does not exist 
            fs1.Close(); // closes filestream

            for (int i = 0; i < gameEngine.Map.units.Length; i++)
            {
                gameEngine.Map.units[i].save();
            }

            for (int k = 0; k < gameEngine.Map.Buildings.Length; k++)
            {
                gameEngine.Map.Buildings[k].save();
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            gameEngine.Map.read();
            tmrOnly.Enabled = true;
            tmrOnly.Start();
        }
    }
}
