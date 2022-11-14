using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    class Shop
    {
        public Weapon[] WeaponArray;
        private Hero hero;
        private static Random rnd = new Random();

        public Shop(Hero hero)
        {
            WeaponArray = new Weapon[3];
            for (int i = 0; i < WeaponArray.Length; i++)
                WeaponArray[i] = weaponRand();
            this.hero = hero;

        }

        private Weapon weaponRand()
        {
            int weaponRandom = rnd.Next(0, 4);

            switch(weaponRandom)
            {
                case 0:
                    return new MeleeWeapon(MeleeWeapon.WeaponType.Dagger, 0, 0, "D ");

                case 1:
                    return new MeleeWeapon(MeleeWeapon.WeaponType.LongSword, 0, 0, "D ");

                case 2:
                    return new RangedWeapon(RangedWeapon.WeaponType.Rifle, 0, 0, "R ");

                default:
                    return new RangedWeapon(RangedWeapon.WeaponType.LongBow, 0, 0, "LB");

            }
        }

        public bool canBuy(int i)
        {
            return (hero.GoldPurse >= WeaponArray[i].WeaponCost);
        }

        public void Buy(int i)
        {
            hero.GoldPurse -= WeaponArray[i].WeaponCost;
            hero.Pickup(WeaponArray[i]);
            WeaponArray[i] = weaponRand();
        }
            
        public string DisplayWeapon(int i)
        {
            return $"Buy {WeaponArray[i].WeaponTypeString} ({WeaponArray[i].WeaponCost} Gold)";
        }
    }
}
