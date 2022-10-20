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

            

            switch(weaponRandom)
            {
                case 0:
                    //dagger
                    break;

                case 1:
                    //longsword
                    break;

                case 2:
                    //rifle
                    break;

                case 3:
                    //longbow
                    break;

            }

            return weaponRandom;
        }


        //public string Buyer(Character buyer)
        //{

        //}




    }
}
