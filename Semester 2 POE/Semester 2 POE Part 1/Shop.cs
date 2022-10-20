using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    class Shop
    {
        int[] WeaponArray = { 1, 2, 3 };


        public int weaponRand()
        {
            Random rnd = new Random();
            int weaponRandom = rnd.Next(0, 4);

            return weaponRandom;
        }

        /*public string buyer(int goldpurse, string target)
        {
            if(target == player)
            {
                // check if the player has enough money
                // subtract the money from the players purse if they do
            }

            return target;
        }*/




    }
}
