using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{ // character class 
    public abstract class Character : Tile
    {
        protected int hp;
        protected int maxHp;                    //protected variables followed by public variables
        protected int damage;
        protected int goldPurse;

        protected Weapon weapon;

        public Weapon GetWeapon()
        {
            return weapon;
        }

        public int HP { get { return hp; } set { hp = value; } }
        public int MaxHp { get { return maxHp; } set { maxHp = value; } }

        public int Damage { get { return damage; } set { damage = value; } }

        public int GoldPurse { get { return goldPurse; } set { goldPurse = value; } }

        protected Tile[] vision = new Tile[4];          //creating the vision variables contructors
        protected tileType tile;                        //tiletype variables and contructors

        public Tile[] VISION { get { return vision; } set { vision = value; } }     //vision [ 0 , 1 , 2 , 3 ] = { up, down, left, right }

        //private List<Tile> Vision{ get { return vision; }set { vision = value; }}
        public tileType Tile { get { return tile; } set { tile = value; } }


        private movement Movement;                  //creating the movement variables, getters + setters
        public movement MOVEMENT { get { return Movement; } set { Movement = value; } }
        public enum movement { NoMovement, up, down, left, right } //movement enum
        public void Move(movement move) //switch case for the moment enum
        {
            switch (move)
            {
                case movement.NoMovement:
                    this.X = X;
                    this.Y = Y;
                    break;

                case movement.up:
                    X--;
                    break;

                case movement.down:
                    X++;
                    break;

                case movement.right:
                    Y++;
                    break;

                case movement.left:
                    Y--;
                    break;
            }
        }

        public abstract movement ReturnMove(movement move = 0); //return move method

        public virtual void Attack(Character target)
        {
            target.HP -= Damage; //attack method
        }

        public bool isDead()
        {
            if (HP <= 0)
            {
                return true;        //isdead method
            }
            return false;
        }

        public virtual bool CheckRange(Character target)
        {
            //needs to return true or false
            //checks range of the character
            if (this.weapon == null)
            {
                if (DistanceTo(target) > 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            if(DistanceTo(target) > this.weapon.WeaponRange)
            {
                return false;
            }
            else 
            {
                return true;
            }

        }

        private int DistanceTo(Character Target)
        {   //calculations for distance to 
            int distX;
            int distY;

            distX = Math.Abs(Target.X - this.X);
            distY = Math.Abs(Target.Y - this.Y);

            return distX + distY;
        }

        public abstract override string ToString(); //overridding to string for hero and enemy

        public Character(int X, int Y, int DAMAGE, int HP, int MaxHP, string symbol)
        {
            this.x = X;
            this.y = Y;
            this.damage = DAMAGE;
            this.hp = HP;                   //character contructors
            this.maxHp = MaxHP;
            this.symbol = symbol;
            //This method is to denote whether or not the character is alive or dead. nested to not perma loop it.
           
        }

        public void Pickup(Item i)  //method for picking up gold
        {
            if (i is Gold)
            {
                Gold g = (Gold)i;
                GoldPurse += g.GetGoldAmount();
                return;
            }
            if (i is Weapon)
            {
                Equip((Weapon)i);
            }
        }

        private void Equip(Weapon w)
        {
            weapon = w;
            this.damage = weapon.WeaponDamage;
        }

        public bool Loot(Character c)
        {
            this.goldPurse += c.GoldPurse;

            if (this is Mage)
            {
                return false;
            }

            if (c.GetWeapon() != null)
            {
                if (this.GetWeapon() == null)
                {
                    this.Pickup(c.GetWeapon());
                    return true;
                }
            }
            return false;
        }

        public string HasLootedWeapon()
        {
            
            return $"The {this.symbol} at [{X.ToString()},{Y.ToString()}] has looted a {this.GetWeapon().WeaponTypeString}\n";
        }

        public string HaslootedGold(int i)
        {
            return $"The {this.symbol} at [{X.ToString()},{Y.ToString()}] has looted {i} gold\n";
        }
    }
}
