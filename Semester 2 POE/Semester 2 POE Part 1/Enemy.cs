using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
     internal class Enemy : Character
    {
        public override movement ReturnMove(movement enemyMovement)
        {   //return movement override without anything in it incase each seperate enemy has a different movement
            throw new NotImplementedException();
        }

        protected Random random = new Random();
        protected Enemy(int X, int Y, int DAMAGE, int HP, int MaxHP, string symbol) : base(X,Y, DAMAGE, HP, MaxHP, symbol)
        {
            //enemy constructor
        }

        public override string ToString()
        {       //enemy too string overide
            //EnemyClassName at[X, Y] (Amount DMG)
            string enemyInfo = "The " + symbol; //need to add enemy name
            enemyInfo += $" at [{X.ToString()}, {Y.ToString()}]";
            enemyInfo += " is at " + hp.ToString() + "HP\n";
            if (this.weapon == null)
            {
                enemyInfo += $"Is barehanded and deals {this.damage} damage";
            }
            else
            {
                enemyInfo += weapon.ToString();
                enemyInfo += $"\nDamage: {this.damage}";
            }

            return enemyInfo;
        }

    }
     





























}
