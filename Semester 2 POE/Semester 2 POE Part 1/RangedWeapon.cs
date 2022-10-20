using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    abstract class RangedWeapon : Weapon
    {
        public RangedWeapon(int X, int Y, string symbol) : base(X, Y, symbol)
        {
            //Weapon  constructor
        }

        public RangedWeapon(RangedWeapon.WeaponType weaponType, int X, int Y, string symbol) : base(X, Y, symbol)
        {
            switch (weaponType)
            {
                case WeaponType.Rifle:

                    WeaponTypeString = "Rifle";
                    WeaponDurability = 3;
                    WeaponRange = 3;
                    WeaponDamage = 5;
                    WeaponCost = 7;

                    break;

                case WeaponType.LongBow:

                    WeaponTypeString = "LongBow";
                    WeaponDurability = 4;
                    WeaponRange = 2;
                    WeaponDamage = 4;
                    WeaponCost = 6;

                    break;
            }

        }

        public enum WeaponType { Rifle, LongBow }

        public override int WeaponRange { get => base.WeaponRange; set => base.WeaponRange = value; }



    }
}
