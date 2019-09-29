using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buildings;
using System.IO;

namespace Units
{
    public class Map
    {
        private char[,] map;
        private int mapSizeX, mapSizeY;
        Random rng = new Random();
        public Unit[] units;
        private Buildings.Building[] buildings;
        

        public char[,] MapDisplay { get => map; set => map = value; }
        public int MapSizeX { get => mapSizeX; }
        public int MapSizeY { get => mapSizeY; }
        public Random Rng { get => rng; }
        public Unit[] Units { get => units; set => units = value; }
        public Building[] Buildings { get => buildings; }

        public Map(int numOfUnits, int mapSizeX, int mapsizeY, int numOfBuildings)
        {

            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapsizeY;
            MapDisplay = new char[MapSizeX, MapSizeY];
            units = new Unit[numOfUnits];
            buildings = new Building[numOfBuildings];
             
            
        }

        

        public void newBattlefield()
        {
            int xPos, yPos, type, faction;
            

            for (int l = 0; l < Units.Length; l++)
            {
                xPos = Rng.Next(0, mapSizeX);
                yPos = Rng.Next(0, mapSizeY);
                type = Rng.Next(0, 2);
                faction = Rng.Next(0, 2);
                

                if (type == 0 && faction == 0)
                {
                    MeleeUnit unit = new MeleeUnit(xPos,yPos,120,1,1,'M',10,faction,120, "Knight");
                    Units[l] = unit;
                }
                else if(type == 1 && faction == 0)
                {
                    RangedUnit unit = new RangedUnit(xPos,yPos,100,1,2,'R',5,faction,100, "Knight");
                    Units[l] = unit;
                }
                else if(type == 0 && faction == 1)
                {
                    MeleeUnit unit = new MeleeUnit(xPos, yPos, 120, 1, 1, 'm', 10, faction,120, "Archer");
                    Units[l] = unit;
                }
                else if(type == 1 && faction == 1)
                {
                    RangedUnit unit = new RangedUnit(xPos, yPos, 100, 1, 2, 'r', 5, faction,100, "Archer");
                    Units[l] = unit;
                }
            }

            for (int k = 0; k < buildings.Length; k++)
            {
                xPos = Rng.Next(0, mapSizeX);
                yPos = Rng.Next(0, mapSizeY);
                type = Rng.Next(0, 2);
                faction = Rng.Next(0, 2);
                int bldingType = rng.Next(0, 2);

                if (bldingType == 0 && type == 0 && faction == 0)
                {
                    if(map.Length -1 == yPos)
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'F', "RangedUnit",true);
                        buildings[k] = blding;
                    }
                    else
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'F', "RangedUnit", false);
                        buildings[k] = blding;
                    }
                    
                }
                else if (bldingType == 0 && type == 1 && faction == 0)
                {
                    if(map.Length-1 == yPos)
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'F', "MeleeUnit", true);
                        buildings[k] = blding;
                    }
                    else
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'F', "MeleeUnit", false);
                        buildings[k] = blding;
                    }
                    
                }
                else if (bldingType == 0 && type == 0 && faction == 1)
                {
                    if(map.Length -1 == yPos)
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'f', "RangedUnit", true);
                        buildings[k] = blding;
                    }
                    else
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'f', "RangedUnit", false);
                        buildings[k] = blding;
                    }
                    
                }
                else if (bldingType == 0 && type == 1 && faction == 1)
                {
                    if(map.Length -1 == yPos)
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'f', "MeleeUnit", true);
                        buildings[k] = blding;
                    }
                    else
                    {
                        FactoryBuilding blding = new FactoryBuilding(xPos, yPos, 100, faction, 'f', "MeleeUnit", false);
                        buildings[k] = blding;
                    }
                    
                }
                else if (bldingType == 1 && faction == 0)
                {
                    ResourceBuilding blding = new ResourceBuilding(xPos, yPos, 100,faction,'W',1000,50);
                    buildings[k] = blding;
                }
                else if (bldingType == 1 && faction == 1)
                {
                    ResourceBuilding blding = new ResourceBuilding(xPos, yPos, 100, faction, 'w', 1000, 50);
                    buildings[k] = blding;
                }
            }

            populateMap();
                       
        }

        public string convertMap()
        {
            string mapOutput = "";

            for (int i = 0; i < mapSizeY; i++)
            {
                for (int k = 0; k < mapSizeX; k++)
                {
                    mapOutput += Convert.ToString(MapDisplay[i, k]);
                }
                mapOutput += "\n";
            }

            return mapOutput;
        }

        public void populateMap()
        {
            
            for (int i = 0; i < MapSizeY; i++)
            { 

                for (int k = 0; k < MapSizeX; k++)
                {
                    MapDisplay[i, k] = '.';
                }
                
            }

            for (int m = 0; m < Units.Length; m++)
            {              
                insertUnits(Units[m]);               
            }

            for (int o = 0; o < buildings.Length; o++)
            {
                insertBuildings(buildings[o]);
            }
            
        }

        private void insertUnits(Unit unit)
        {

            if(unit.IsDead == false)
            {
                MapDisplay[unit.YPos, unit.XPos] = unit.Symbol;
            }
            
        }

        private void insertBuildings(Building blding)
        {
            string type = blding.GetType().ToString();
            string[] typeArr = type.Split('.');
            type = typeArr[typeArr.Length - 1];

            if(type == "ResourceBuilding")
            {
                ResourceBuilding rblding = (ResourceBuilding)blding;
                MapDisplay[rblding.YPos, rblding.XPos] = rblding.Symbol;
            }
            else
            {
                FactoryBuilding fblding = (FactoryBuilding)blding;
                MapDisplay[fblding.YPos, fblding.XPos] = fblding.Symbol;
            }
        }

        public void read()
        {
            FileStream fs = new FileStream("saves/units/saves.game", FileMode.Open, FileAccess.Read); //opens file to be read
            StreamReader reader = new StreamReader(fs); //starts reading


            string line = reader.ReadLine(); //Saves the read line into usable vairiable
            units = new Unit[0];

            while (line != null)
            {
                Array.Resize(ref units, units.Length + 1);

                string[] lineArr = line.Split(','); //Splits the read line at ',' and saves it into array
                char symbol = Convert.ToChar(lineArr[5]); //adds each read number into temp variable
                int xPos = Convert.ToInt32(lineArr[0]);
                int yPos = Convert.ToInt32(lineArr[1]);
                int health = Convert.ToInt32(lineArr[2]);
                int speed = Convert.ToInt32(lineArr[3]);
                int attackRange = Convert.ToInt32(lineArr[4]);
                int attack = Convert.ToInt32(lineArr[6]);
                int faction = Convert.ToInt32(lineArr[7]);
                int maxHealth = Convert.ToInt32(lineArr[8]);
                string name = lineArr[9];

                if (symbol == 'r' || symbol == 'R')
                {

                    RangedUnit tempUnit = new RangedUnit(xPos, yPos, health, speed, attackRange, symbol, attack, faction, maxHealth, name);
                    units[units.Length - 1] = tempUnit;

                }
                else
                {

                    MeleeUnit tempUnit = new MeleeUnit(xPos, yPos, health, speed, attackRange, symbol, attack, faction, maxHealth, name);
                    units[units.Length - 1] = tempUnit;

                }

                line = reader.ReadLine(); //Reads the next line

            }

            fs.Close(); //Closes the filestream

            //Buildings
            FileStream fsBuild = new FileStream("saves/buildings/saves.game", FileMode.Open, FileAccess.Read); //opens file to be read
            StreamReader readerBuild = new StreamReader(fsBuild); //starts reading


            string linebuild = readerBuild.ReadLine(); //Saves the read line into usable vairiable
            buildings = new Building[0];

            while (linebuild != null)
            {
                Array.Resize(ref buildings, buildings.Length + 1);

                string[] lineArr = linebuild.Split(','); //Splits the read line at ',' and saves it into array
                char symbol = Convert.ToChar(lineArr[4]); //adds each read number into temp variable
                

                if (symbol == 'f' || symbol == 'F')
                {
                    int xPos = Convert.ToInt32(lineArr[0]);
                    int yPos = Convert.ToInt32(lineArr[1]);
                    int health = Convert.ToInt32(lineArr[2]);
                    string unitType = lineArr[3];
                    int faction = Convert.ToInt32(lineArr[5]);
                    int maxHealth = Convert.ToInt32(lineArr[6]);

                    FactoryBuilding tempUnit = new FactoryBuilding(xPos, yPos, health, faction,symbol,unitType,false, maxHealth);
                    buildings[buildings.Length-1] = tempUnit;

                }
                else
                {
                    int xPos = Convert.ToInt32(lineArr[0]);
                    int yPos = Convert.ToInt32(lineArr[1]);
                    int health = Convert.ToInt32(lineArr[2]);
                    string type = lineArr[3];
                    int faction = Convert.ToInt32(lineArr[5]);
                    int maxHealth = Convert.ToInt32(lineArr[6]);
                    int resourcesPerRound = Convert.ToInt32(lineArr[7]);
                    int generatedResources = Convert.ToInt32(lineArr[9]);
                    int resourcePoolRemaining = Convert.ToInt32(lineArr[8]);
                    int maxPool = Convert.ToInt32(lineArr[10]);

                    ResourceBuilding tempUnit = new ResourceBuilding(xPos, yPos, health, faction,symbol,maxPool,resourcesPerRound, maxHealth);
                    buildings[buildings.Length-1] = tempUnit;

                }

                linebuild = readerBuild.ReadLine(); //Reads the next line

            }

            fsBuild.Close(); //Closes the filestream
            populateMap();
        }

        
    }
}
