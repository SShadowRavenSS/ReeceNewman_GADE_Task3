using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Units
{
    public class MeleeUnit : Unit
    {

        public MeleeUnit(int xPos, int yPos, int health, int speed, int range, char symbol, int attack, int faction, int maxHealth, string name ) : base(xPos, yPos, health, faction, speed, attack, range, symbol, maxHealth, name)
        {

        }

        public override void save()
        {
            FileStream fs = new FileStream("saves/units/saves.game", FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(saveFormatter());

            sw.Close();
            fs.Close();
        }

        private string saveFormatter()
        {
            string output = "";

            output = XPos + "," + YPos + "," + Health + "," + Speed + "," + AttackRange + "," + Symbol + "," + Attack + "," + Faction + "," + MaxHealth + "," + Name;

            return output;
        }
    }
}
