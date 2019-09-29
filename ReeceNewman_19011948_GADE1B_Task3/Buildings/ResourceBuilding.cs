using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Buildings
{
    public class ResourceBuilding : Building
    {
        private string type;
        private int resourcePoolRemaining, generatedResources, resourcesPerRound, maxPool;

        public int XPos { get => base.xPos; set => base.xPos = value; }
        public int YPos { get => base.yPos; set => base.yPos = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth; }
        public int Faction { get => base.faction; }
        public char Symbol { get => base.symbol; }


        public ResourceBuilding(int xPos, int yPos, int health, int faction, char symbol, int maxPool, int production) : base(xPos, yPos, health, faction, symbol)
        {
            this.resourcePoolRemaining = maxPool;
            this.maxPool = maxPool;
            generatedResources = 0;
            this.resourcesPerRound = production;
            type = "Wood";
        }

        public ResourceBuilding(int xPos, int yPos, int health, int faction, char symbol, int maxPool, int production, int maxHp) : base(xPos, yPos, health, faction, symbol)
        {
            this.maxHealth = maxHp;
            this.resourcePoolRemaining = maxPool;
            this.maxPool = maxPool;
            generatedResources = 0;
            this.resourcesPerRound = production;
            type = "Wood";
        }

        public override bool Death()
        {
            bool isDead = false;

            if(this.Health > 0)
            {
                isDead = false;
            }
            else
            {
                isDead = true;
            }
            return isDead;
        }

        public override string ToString()
        {
            string output = "\n" + "_______________________________________" + "\n" + "This unit is a ResourceBuilding of type: " + type + "\n" + "This Building's x Position is: " + (this.XPos + 1) + "\n" + "This Building's y Position is: " + (this.YPos + 1) + "\n" + "This Building's Health is: " + this.Health + "\n" + "This Building's Production is: " + this.resourcesPerRound + "\n" + "This Building has generated " + this.generatedResources + " " + type + "\n" + "This Building's Team is: Team " + this.Faction + "\n" + "This Building has a Remaining Resource Pool of: " + resourcePoolRemaining;


            return output;
        }

        public void GenerateResources()
        {
            
            if(resourcePoolRemaining != 0)
            {
                
                if (resourcePoolRemaining - resourcesPerRound < 0)
                {
                    generatedResources += resourcePoolRemaining;
                    resourcePoolRemaining = 0;                  
                }
                else
                {
                    generatedResources += resourcesPerRound;
                    resourcePoolRemaining -= resourcesPerRound;
                }
            }
        }

        public override void save()
        {
            FileStream fs = new FileStream("saves/buildings/saves.game", FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(saveFormatter());

            sw.Close();
            fs.Close();
        }

        private string saveFormatter()
        {
            string output = "";

            output = XPos + "," + YPos + "," + Health + "," + type + "," + Symbol + "," + Faction + "," + MaxHealth + "," + resourcesPerRound + "," + resourcePoolRemaining + "," + generatedResources + "," + maxPool;

            return output;
        }
    }
}
