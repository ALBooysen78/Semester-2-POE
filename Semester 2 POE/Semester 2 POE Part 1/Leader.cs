using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    internal class Leader : Enemy
    { 
        //create the getter and setter tile accessors
        public Leader(int X, int Y) : base(X, Y, 2, 20, 20, "L ")
        {
            goldPurse = 2;
            //Leader constructor
        }

        public Leader(int X, int Y, int DAMAGE, int HP, int MaxHP, string symbol) : base(X, Y, 2, HP, 20, "L ")
        {

        }

        private Tile LeadersTarget;

        public Tile LEADERSTARGET { get { return LeadersTarget; } set { LeadersTarget = value; } }

        public override movement ReturnMove(movement enemyMovementLeader)
        {
            int differenceX = this.X - LeadersTarget.X;
            int differenceY = this.Y - LeadersTarget.Y;

            int differenceXPositive = Math.Abs(differenceX);
            int differenceYPositive = Math.Abs(differenceY);
            //add in tracking variables

            //determining weather the leader is closer on the x or y axis



            //movemnt depending on where the leader is further away 
            if (differenceXPositive > differenceYPositive)
            {
                if(differenceX > 0)
                {
                    //checking that there is a space to move into
                    //if there is not it will make a random movement
                    if (!(this.VISION[0] is Enemy) && !(this.VISION[0] is Hero) && !(this.VISION[0] is Obstacle))
                    {
                        //15 - 13 = 2 therefor movement is up
                        enemyMovementLeader = movement.up;
                    }
                    else
                    {
                        enemyMovementLeader = rndmovement(enemyMovementLeader);
                    }

                }
                else if(differenceX < 0)
                {
                    //checking that there is a space to move into
                    //if there is not it will make a random movement
                    if (!(this.VISION[1] is Enemy) && !(this.VISION[1] is Hero) && !(this.VISION[1] is Obstacle))
                    //13 - 15 = -2 2erefor movement is down
                    {
                        enemyMovementLeader = movement.down;
                    }
                    else
                    {
                        enemyMovementLeader = rndmovement(enemyMovementLeader);
                    }
                }
            }
            else 
            {
                if(differenceY > 0)
                {
                    //checking that there is a space to move into
                    //if there is not it will make a random movement
                    if (!(this.VISION[2] is Enemy) && !(this.VISION[2] is Hero) && !(this.VISION[2] is Obstacle))
                    //15-13 = 2 therefor movement is right
                    {
                        enemyMovementLeader = movement.left;
                    }
                    else
                    {
                        enemyMovementLeader = rndmovement(enemyMovementLeader);
                    }
                }
                else if (differenceY < 0)
                {
                    //checking that there is a space to move into
                    //if there is not it will make a random movement
                    if (!(this.VISION[3] is Enemy) && !(this.VISION[3] is Hero) && !(this.VISION[3] is Obstacle))
                    { 
                        enemyMovementLeader = movement.right; 
                    }
                    else
                    {
                        enemyMovementLeader = rndmovement(enemyMovementLeader);
                    }
                }
            }
            return enemyMovementLeader;


            



        }

        //Random movement method for the leader
        public movement rndmovement(movement enemyMovementLeader)
        {
            int i = 0;
            do
            {
                Random rndm = new Random();
                int randomVal;
                randomVal = rndm.Next(1, 5);
                enemyMovementLeader = (Character.movement)randomVal;

                if (enemyMovementLeader == movement.right)
                {
                    if (!(this.VISION[3] is Enemy) && !(this.VISION[3] is Hero) && !(this.VISION[3] is Obstacle))
                    {
                        enemyMovementLeader = movement.right;
                    }
                    else enemyMovementLeader = movement.NoMovement;
                }
                else if (enemyMovementLeader == movement.left)
                {
                    if (!(this.VISION[2] is Enemy) && !(this.VISION[2] is Hero) && !(this.VISION[2] is Obstacle))
                    {
                        enemyMovementLeader = movement.left;
                    }
                    else enemyMovementLeader = movement.NoMovement;

                }
                else if (enemyMovementLeader == movement.up)
                {
                    if (!(this.VISION[0] is Enemy) && !(this.VISION[0] is Hero) && !(this.VISION[0] is Obstacle))
                    {
                        enemyMovementLeader = movement.up;
                    }
                    else enemyMovementLeader = movement.NoMovement;

                }
                else if (enemyMovementLeader == movement.down)
                {
                    if (!(this.VISION[1] is Enemy) && !(this.VISION[1] is Hero) && !(this.VISION[1] is Obstacle))
                    {
                        enemyMovementLeader = movement.down;
                    }
                    else enemyMovementLeader = movement.NoMovement;

                }
                else if (enemyMovementLeader == movement.NoMovement)
                {
                    enemyMovementLeader = movement.NoMovement;
                }
                i++;

            } while (enemyMovementLeader == movement.NoMovement && i<100);

            return enemyMovementLeader;
        }
    }
        
       
}
