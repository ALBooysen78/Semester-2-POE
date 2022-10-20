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

        public enum WeaponType { Dagger, LongSword }

        public override int WeaponRange { get => base.WeaponRange; set => base.WeaponRange = value; }

        public void MeleeWeaponSelecctor(WeaponType MeleeWeapon)
        {
            switch (MeleeWeapon)
            {
                case WeaponType.Dagger:
                    //string "Dagger";
                    //int Durability = 10;
                    //int Damage = 3;
                    //int Cost = 3;
                    break;

                case WeaponType.LongSword:
                    //string "LongSword";
                    //int Durability = 6;
                    //int Damage = 4;
                    //int Cost = 5;
                    break;
            }
        }




    }//class
}
