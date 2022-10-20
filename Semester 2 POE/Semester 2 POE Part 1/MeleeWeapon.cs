using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    abstract class MeleeWeapon : Weapon
    {
        public MeleeWeapon(int X, int Y, string symbol) : base(X, Y, symbol)
        {
            //Weapon  constructor
        }

        public MeleeWeapon(MeleeWeapon.WeaponType weaponType, int X, int Y, string symbol) : base(X, Y, symbol) 
        {
            switch (weaponType)
            {
                case WeaponType.Dagger:

                    WeaponTypeString = "Dagger";
                    WeaponDurability = 10;
                    WeaponDamage = 3;
                    WeaponCost = 3;
                    //string "Dagger";
                    //int Durability = 10;
                    //int Damage = 3;
                    //int Cost = 3;
                    break;

                case WeaponType.LongSword:
                    WeaponTypeString = "LongSword";
                    WeaponDurability = 6;
                    WeaponDamage = 4;
                    WeaponCost = 5;
                    //string "LongSword";
                    //int Durability = 6;
                    //int Damage = 4;
                    //int Cost = 5;
                    break;
            }

        }

        public enum WeaponType { Dagger, LongSword }


    public override int WeaponRange { get { return 1; } }






    }//class
}
