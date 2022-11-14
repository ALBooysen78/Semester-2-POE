using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    public abstract class Weapon : Item
    {

        public Weapon(int X, int Y, string symbol) : base(X, Y, symbol)
        {
            //Weapon  constructor
        }

        private int weaponDamage;
        private int weaponRange;
        private int weaponDurability;
        private int weaponCost;
        private string weaponTypeString;


        public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
        public virtual int WeaponRange { get { return weaponRange; } set { weaponRange = value; } }
        public int WeaponDurability { get { return weaponDurability; } set { weaponDurability = value; } }
        public int WeaponCost { get { return weaponCost; } set { weaponDurability = value; } }
        public string WeaponTypeString { get { return weaponTypeString; } set { weaponTypeString = value; } }

    }
}
