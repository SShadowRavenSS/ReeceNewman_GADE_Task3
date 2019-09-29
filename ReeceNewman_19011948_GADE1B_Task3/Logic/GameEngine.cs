using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class GameEngine
    {
        
        private Map map;
        int counter = 0;
        public Map Map { get => map; }
        

        public GameEngine(int numberOfUnits)
        {

            map = new Map(numberOfUnits, 20, 20, 6);
            map.newBattlefield();
            
        } 

        public void gameLogic(Unit[] unit, Buildings.Building[] bldings)
        {
            
            bool resetCounter = false;

            for (int i = 0; i < unit.Length; i++)
            {
                unit[i].death(); //Check for death and set relevant variable
                unit[i].IsAttacking = false; 

                if (unit[i].IsDead == false) //If unit is not dead
                {
                    Unit closest = unit[i].closestUnit(unit); //Determines the closest unit to this unit and stores that unit in 'closest'

                    if (unit[i].attackingRange(closest) == false || unit[i].Health / unit[i].MaxHealth * 100 < 25) //If the unit is below 25% hp or is not in range of the closest enemy 
                    {
                        unit[i].movement(closest, map.MapSizeX, map.MapSizeY); //Move

                        map.populateMap(); //Refresh Map
                    }
                    else if (unit[i].Faction != closest.Faction) //If the unit is not part of the same team
                    {
                        unit[i].combat(closest); //Do combat
                        map.populateMap(); //Refreh map
                    }

                }

                
            }

            for (int p = 0; p < bldings.Length; p++)
            {
                string type = bldings[p].GetType().ToString();
                string[] typeArr = type.Split('.');
                type = typeArr[typeArr.Length - 1];

                if (type == "ResourceBuilding")
                {
                    Buildings.ResourceBuilding rblding = (Buildings.ResourceBuilding)bldings[p];

                    rblding.GenerateResources();
                    
                }
                else
                {
                    Buildings.FactoryBuilding fblding = (Buildings.FactoryBuilding)bldings[p];
                    
                    if(fblding.ProductionSpeed <= counter)
                    {

                        Unit temp = fblding.SpawnUnits();
                        Array.Resize(ref map.units, map.Units.Length + 1);
                        map.Units[map.Units.Length - 1] = temp;
                        resetCounter = true;
                    }
                    else
                    {
                        resetCounter = false;
                    }
                    
                }
            }

            
            if(resetCounter == true)
            {
                resetCounter = false;
                counter = 0;
            }
            else
            {
                ++counter;
                
            }
            
        }

        public string getStats(Unit[] unit, Buildings.Building[] bldnings)
        {
            string stats = "";
            for (int i = 0; i < unit.Length; i++)
            {
                stats += unit[i].ToString();
            }
            for (int k = 0; k < bldnings.Length; k++)
            {
                stats += bldnings[k].ToString();
            }
            
            return stats;
        }
    }
}
