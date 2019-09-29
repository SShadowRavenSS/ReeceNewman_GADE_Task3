using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Unit
    {
        protected int faction;
        protected bool isDead;
        protected char symbol;
        protected bool isAttacking;
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected string name;



        private Random rng = new Random();



        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public int Health { get => health; set => health = value; }
        public int MaxHealth { get => maxHealth; }
        public int Speed { get => speed; set => speed = value; }
        public int Attack { get => attack; set => attack = value; }
        public int AttackRange { get => attackRange; set => attackRange = value; }
        public int Faction { get => faction; set => faction = value; }
        public char Symbol { get => symbol; set => symbol = value; }
        public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
        public bool IsDead { get => isDead;}
        public string Name { get => name; set => name = value; }

        public Unit(int xPos, int yPos, int health, int faction, int speed, int attack, int attackRange, char symbol, int maxHealth, string name)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.maxHealth = maxHealth;
            this.faction = faction;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.symbol = symbol;
            this.isDead = false;
            this.name = name;
        }

        public abstract void save();

        public bool attackingRange(Unit unit)
        {

            bool isInRange = false;
            if (Math.Abs(unit.XPos - this.XPos) > this.AttackRange && Math.Abs(unit.YPos - this.YPos) > this.AttackRange)
            {
                isInRange = false;
            }
            else
            {
                isInRange = true;
            }

            return isInRange;
        }

        public Unit closestUnit(Unit[] units)
        {
            int lowestDist = int.MaxValue;
            int closestUnit = int.MaxValue;
            int thisUnit = 0;

            for (int k = 0; k < units.Length; k++)
            {

                if (units[k].isDead == false)
                {

                    int dist = Math.Abs(units[k].XPos - this.XPos) + Math.Abs(units[k].YPos - this.YPos);

                    if (dist != 0)
                    {

                        if (dist < lowestDist && units[k].Faction != this.Faction)
                        {
                            lowestDist = dist;
                            closestUnit = k;
                        }

                    }
                    else
                    {
                        thisUnit = k;
                    }

                }

            }

            if (closestUnit != int.MaxValue)
            {
                return units[closestUnit];
            }
            else
            {
                return units[thisUnit];
            }

        }

        public void combat(Unit unitToAttack)
        {

            unitToAttack.Health -= this.Attack;
            this.IsAttacking = true;

        }

        public void death()
        {  

            if (this.Health >= 0)
            {
                isDead = false;
            }
            else
            {
                isDead = true;
            }

        }

        public void movement(Unit moveToUnit, int mapSizeX, int mapSizeY)
        {
            this.IsAttacking = false; //Since this unit is moving it is not attacking so set relevant boolean false
            double currentHealth = this.health;
            double maximumHealth = this.maxHealth;
            double percentageHealth = currentHealth / maximumHealth;

            if (percentageHealth < 0.25) //Checks if the unit is under 25% health
            {
                Console.WriteLine("My health is below 25% " + health);
                int randomDirection = rng.Next(0, 4); //Randoms a direction for the unit to move to
                switch (randomDirection)
                {

                    case 0:
                        {
                            if(this.yPos - 1 > 0)
                            {

                                this.yPos -= 1; //Moves unit
                                
                            }
                            break;
                        }
                    case 1:
                        {
                            if (this.yPos + 1 < mapSizeY)
                            {

                                this.YPos += 1; //Moves unit
                                
                            }
                            break;
                        }
                    case 2:
                        {
                            if (this.xPos - 1 > 0)
                            {

                                this.xPos -= 1; //Moves unit
                                
                            }
                            break;
                        }
                    case 3:
                        {
                            if (this.xPos + 1 < mapSizeX)
                            {

                                this.xPos += 1; //Moves unit

                            }
                            break;
                        }

                }

            }
            else
            {
                if (Math.Abs(moveToUnit.XPos - this.XPos) > Math.Abs(moveToUnit.YPos - this.YPos))
                {

                    if (moveToUnit.XPos - this.xPos > 0)
                    {

                        if (this.xPos + 1 < mapSizeX)
                        {

                            this.XPos += 1; //Moves unit

                        }

                    }
                    else if (moveToUnit.xPos - this.XPos < 0)
                    {

                        if (this.xPos - 1 > 0)
                        {

                            this.xPos -= 1; //Moves unit

                        }

                    }

                }
                else
                {

                    if (moveToUnit.yPos - this.yPos > 0)
                    {

                        if (this.yPos + 1 < mapSizeY)
                        {

                            this.yPos += 1; //Moves unit

                        }

                    }
                    else if (moveToUnit.yPos - this.yPos < 0)
                    {

                        if (this.yPos - 1 > 0)
                        {

                            this.yPos -= 1; //Moves unit

                        }

                    }

                }

            }
            
        }

        public override string ToString() //Ouputs all the unit's stats
        {
            string output;

            string unitType = this.GetType().ToString();
            string[] typeArr = unitType.Split('.');
            unitType = typeArr[typeArr.Length - 1];

            if(unitType == "MeleeUnit")
            {
                if (this.IsAttacking == false)
                {
                    output = "\n" + "_______________________________________" + "\n" + "This unit is a Melee Unit of type: " + name + "\n" + "This unit's x Position is: " + (this.XPos + 1) + "\n" + "This unit's y Position is: " + (this.YPos + 1) + "\n" + "This unit's Health is: " + this.Health + "\n" + "This unit's Speed is: " + this.Speed + "\n" + "This unit's Range is: " + this.AttackRange + "\n" + "This unit's Attack is: " + this.Attack + "\n" + "This unit's Team is: Team " + this.Faction + "\n" + "This unit is not Attacking";
                }
                else
                {
                    output = "\n" + "_______________________________________" + "\n" + "This unit is a Melee Unit of type: " + name + "\n" + "This unit's x Position is: " + (this.XPos + 1) + "\n" + "This unit's y Position is: " + (this.YPos + 1) + "\n" + "This unit's Health is: " + this.Health + "\n" + "This unit's Speed is: " + this.Speed + "\n" + "This unit's Range is: " + this.AttackRange + "\n" + "This unit's Attack is: " + this.Attack + "\n" + "This unit's Team is: Team " + this.Faction + "\n" + "This unit is Attacking";
                }
            }
            else
            {
                if (this.IsAttacking == false)
                {
                    output = "\n" + "_______________________________________" + "\n" + "This unit is a Ranged Unit of type: "+ name + "\n" + "This unit's x Position is: " + (this.XPos + 1) + "\n" + "This unit's y Position is: " + (this.YPos + 1) + "\n" + "This unit's Health is: " + this.Health + "\n" + "This unit's Speed is: " + this.Speed + "\n" + "This unit's Range is: " + this.AttackRange + "\n" + "This unit's Attack is: " + this.Attack + "\n" + "This unit's Team is: Team " + this.Faction + "\n" + "This unit is not Attacking";
                }
                else
                {
                    output = "\n" + "_______________________________________" + "\n" + "This unit is a Ranged Unit of type: " + name + "\n" + "This unit's x Position is: " + (this.XPos + 1) + "\n" + "This unit's y Position is: " + (this.YPos + 1) + "\n" + "This unit's Health is: " + this.Health + "\n" + "This unit's Speed is: " + this.Speed + "\n" + "This unit's Range is: " + this.AttackRange + "\n" + "This unit's Attack is: " + this.Attack + "\n" + "This unit's Team is: Team " + this.Faction + "\n" + "This unit is Attacking";
                }
            }

            return output;
        }
    
    }

}
