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

        public enum WeaponType { Rifle, LongBow }

        public override int WeaponRange { get => base.WeaponRange; set => base.WeaponRange = value; }

        public void RangeedWeaponSelecctor(WeaponType RangedWeapon)
        {
            switch (RangedWeapon)
            {
                case WeaponType.Rifle:
                    //string "Dagger";
                    //int Durability = 10;
                    //int Damage = 3;
                    //int Cost = 3;
                    break;

                case WeaponType.LongBow:
                    //string "LongSword";
                    //int Durability = 6;
                    //int Damage = 4;
                    //int Cost = 5;
                    break;
            }
        }


    }
}
