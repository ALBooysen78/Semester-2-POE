using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    internal class Leader
    { 
        //create the getter and setter tile accessors
        public Leader(int X, int Y) : base(X, Y, 2, 20, 20, "L")
        {
            //swamp creature constructor
        }

        public Leader(int X, int Y, int DAMAGE, int HP, int MaxHP, string symbol) : base(X, Y, 2, HP, 20, "L")
        {

        }




        public override movement ReturnMove(movement enemyMovementLeader)
        {
            //add in tracking variables
            return enemyMovementLeader;
        }
    }
        
       
}
