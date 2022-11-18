using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Semester_2_POE_Part_1
{
    internal class GameEngine
    {
        private Map gameMap;    //delcarations
        public Map getMap() { return gameMap; }

        public Form1 Form1 { get; set; }

        public GameEngine()     //makes new map object
        {
            gameMap = new Map(10,20,10,15,8,8,6);
        }

        public bool MovePlayer(Character.movement move) //checks if the attapted movement is valid, and if so, moves the hero in that direction and updates vision array for hero and enemies
        {
            if (move == Character.movement.NoMovement) return false;

            Character.movement dir = gameMap.Heroprop.ReturnMove(move);
            if (dir == move)
            {
                
                gameMap.Mapprop[gameMap.Heroprop.X, gameMap.Heroprop.Y] = new EmptyTile(gameMap.Heroprop.X, gameMap.Heroprop.Y, " . ");    //replace the hero's current poition on the map with an empty tile
                gameMap.Heroprop.Move(move);    //move hero
                if(gameMap.Mapprop[gameMap.Heroprop.X, gameMap.Heroprop.Y] is Item) //allows the hero to pickup gold
                {
                    Item i = gameMap.GetItemAtPosition(gameMap.Heroprop.X, gameMap.Heroprop.Y);
                    gameMap.Heroprop.Pickup(i);
                    if (i is Weapon)
                    {
                        Form1.Changetext(gameMap.Heroprop.HasLootedWeapon());
                    }
                    else
                    {
                        Gold g = (Gold)i;
                        Form1.Changetext(gameMap.Heroprop.HaslootedGold(g.GoldAmount));
                    }
                    
                }
                gameMap.Mapprop[gameMap.Heroprop.X, gameMap.Heroprop.Y] = gameMap.Heroprop;    //replace the empty tile on the map with new hero position
                gameMap.UpdateVision(gameMap.Heroprop);


                for (int i = 0; i < gameMap.GetEnemies().Length; i++)   //updates enemy visions
                {
                    gameMap.UpdateVision(gameMap.GetEnemies()[i]);
                }
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public void MoveEnemies()   //method to move enemies
        {


            foreach (var enemy in gameMap.GetEnemies())
            {           
                Character.movement move = (Character.movement)enemy.ReturnMove(Character.movement.NoMovement);  //Since the ReturnMove method requires a parameter, no movement is passed in as a placeholder. This value is changed in the swamp creature class when a random movement is calculated
                           
                gameMap.Mapprop[enemy.X, enemy.Y] = new EmptyTile(enemy.X, enemy.Y, " . ");    //replace the enemy's current poition on the map with an empty tile
                enemy.Move(move);    //move enemy
                if (gameMap.Mapprop[enemy.X, enemy.Y] is Item)  
                {
                    Item i = gameMap.GetItemAtPosition(enemy.X, enemy.Y);
                    enemy.Pickup(i);
                    if (i is Weapon)
                    {
                        Form1.Changetext(enemy.HasLootedWeapon());

                    }
                    else
                    {
                        Gold g = (Gold)i;
                        Form1.Changetext(enemy.HaslootedGold(g.GoldAmount));
                    }

                }
                gameMap.Mapprop[enemy.X, enemy.Y] = enemy;    //replace the empty tile on the map with new enemy position
                gameMap.UpdateVision(gameMap.Heroprop);


                for (int i = 0; i < gameMap.GetEnemies().Length; i++)
                {
                    gameMap.UpdateVision(gameMap.GetEnemies()[i]);
                }
                    
                
                
            }
        }

        public void EnemyAttacks()  //method for enemy attacks
        { 
            foreach (Enemy enemy in gameMap.GetEnemies())
            {
                if (enemy.isDead() == true) //checks if the enemy is dead, so that they can't attack if so
                {
                    continue;
                }
                if (enemy is SwampCreature)     //attacks if enemy is a swampcreature
                {
                    
                    if (enemy.CheckRange(gameMap.Heroprop))    //attacks hero if he is close enough
                    {
                        enemy.Attack(gameMap.Heroprop);
                        Form1.Changetext($"You were dealt {enemy.Damage} damage by the {enemy.Symbol} at [{enemy.X},{enemy.Y}]\n");
                    }
                    
                }
                else if (enemy is Mage)     //attacks if enemy is a mage
                {
                    for (int i = 0; i < gameMap.GetEnemies().Length; i++)
                    {
                        if (enemy.CheckRange(gameMap.GetEnemies()[i]))      //mage attacks enemies ass well
                        {
                            enemy.Attack(gameMap.GetEnemies()[i]);
                            
                            if (gameMap.GetEnemies()[i].isDead() == true) // && gameMap.Mapprop[gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y] is Enemy
                            {
                                Form1.Changetext(Form1.HasDied(gameMap.GetEnemies()[i], enemy));
                                enemy.Loot(gameMap.GetEnemies()[i]);
                                gameMap.Mapprop[gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y] = new EmptyTile(gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, ". ");     //removes dead enemies from the map
                            }
                        }
                    }

                    if (enemy.CheckRange(gameMap.Heroprop))     //attacks hero
                    {
                        enemy.Attack(gameMap.Heroprop);
                        Form1.Changetext($"You were dealt {enemy.Damage} damage by the {enemy.Symbol} at [{enemy.X},{enemy.Y}]\n");
                    }
                }
                else if(enemy is Leader)
                {
                    if (enemy.CheckRange(gameMap.Heroprop))    //attacks hero if he is close enough
                    {
                        enemy.Attack(gameMap.Heroprop);
                        Form1.Changetext($"You were dealt {enemy.Damage} damage by the {enemy.Symbol} at [{enemy.X},{enemy.Y}]\n");
                        
                    }
                }
                gameMap.UpdateVision(gameMap.Heroprop);


                for (int i = 0; i < gameMap.GetEnemies().Length; i++)
                {
                    gameMap.UpdateVision(gameMap.GetEnemies()[i]);
                }
            }

            if (gameMap.Heroprop.HP <= 0)
            {
                MessageBox.Show("You died");
            }
        }

        public void SaveGame()
        {
            DataSet dataSet = new DataSet();                //make new dataset and datatable
            DataTable dataTable = new DataTable();

            dataSet.Tables.Add(dataTable);                  //add columns to the datatable which stores relevant information

            dataTable.Columns.Add(new DataColumn("ObjectType", typeof(string)));
            dataTable.Columns.Add(new DataColumn("X", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Y", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Health", typeof(int)));
            dataTable.Columns.Add(new DataColumn("MaxHealth", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Gold", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Weapon", typeof(string)));

            //add the dimensions of the map to the datatable
            dataTable.Rows.Add("MapDimensions", gameMap.GetMapHeight(), gameMap.GetMapWidth(), -1, -1, -1, " "); //since the map doesn't have all of the values, irrelevent ones are set to -1

            dataTable.Rows.Add("EnemyAmount", gameMap.GetEnemies().Length, -1, -1, -1, -1, " ");

            dataTable.Rows.Add("ItemAmount", gameMap.Items.Length, -1, -1, -1, -1, " ");
            //add the hero to the datatable
            if (gameMap.Heroprop.GetWeapon() != null)
            {
                dataTable.Rows.Add("Hero", gameMap.Heroprop.X, gameMap.Heroprop.Y, gameMap.Heroprop.HP, gameMap.Heroprop.MaxHp, gameMap.Heroprop.GoldPurse, gameMap.Heroprop.GetWeapon().WeaponTypeString);
            }
            else
            {
                dataTable.Rows.Add("Hero", gameMap.Heroprop.X, gameMap.Heroprop.Y, gameMap.Heroprop.HP, gameMap.Heroprop.MaxHp, gameMap.Heroprop.GoldPurse, " ");
            }
            //add the enemies to the datatable
            for (int i = 0; i < gameMap.GetEnemies().Length; i++)
            {
                if (gameMap.GetEnemies()[i] is SwampCreature)
                {
                    dataTable.Rows.Add("Swamp Creature", gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, gameMap.GetEnemies()[i].HP, gameMap.GetEnemies()[i].MaxHp, gameMap.GetEnemies()[i].GoldPurse, gameMap.GetEnemies()[i].GetWeapon().WeaponTypeString);
                }
                else if (gameMap.GetEnemies()[i] is Mage)
                {
                    dataTable.Rows.Add("Mage", gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, gameMap.GetEnemies()[i].HP, gameMap.GetEnemies()[i].MaxHp, gameMap.GetEnemies()[i].GoldPurse, " ");
                }
                else if (gameMap.GetEnemies()[i] is Leader)
                {
                    dataTable.Rows.Add("Leader", gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, gameMap.GetEnemies()[i].HP, gameMap.GetEnemies()[i].MaxHp, gameMap.GetEnemies()[i].GoldPurse, gameMap.GetEnemies()[i].GetWeapon().WeaponTypeString);
                }
            }
            //add the items to the datatable
            for (int i = 0; i < gameMap.Items.Length; i++)
            {
                if (gameMap.Items[i] is Gold)
                {
                    dataTable.Rows.Add("Gold", gameMap.Items[i].X, gameMap.Items[i].Y, -1, -1, ((Gold)gameMap.Items[i]).GoldAmount, " "); //since gold does not have all of the values, irrelevant ones are set to -1
                }
                else if (gameMap.Items[i] is Weapon)
                {
                    
                    dataTable.Rows.Add("Weapon", gameMap.Items[i].X, gameMap.Items[i].Y, -1, -1, -1, ((Weapon)gameMap.Items[i]).WeaponTypeString);
                }
            }
            //save dataset
            dataSet.WriteXml("Data.xml");
        }

        public void LoadGame()
        {
            DataSet loadSet = new DataSet();        //load dataset from saved file
            loadSet.ReadXml("Data.xml");

            foreach (DataRow row in loadSet.Tables[0].Rows)     //loop for each row in dataset
            {
                string objectType = (string)row["ObjectType"];      //set variables for each corresponding value in the dataset
                int xPos = Convert.ToInt32(row["X"]);
                int yPos = Convert.ToInt32(row["Y"]);
                int hp = Convert.ToInt32(row["Health"]);
                int maxHp = Convert.ToInt32(row["MaxHealth"]);
                int gold = Convert.ToInt32(row["Gold"]);
                string weapon = Convert.ToString(row["Weapon"]);

                switch (objectType)
                {
                    case "MapDimensions":
                        gameMap = new Map(xPos, xPos, yPos, yPos, gameMap.GetEnemies().Length, gameMap.Items.Length,5);   //makes a new map according to the dimensions given from the savefile
                        for (int x = 0; x < xPos; x++)      //creates obstacles on the edges of the map, as well as filling it with empty tiles
                        {
                            for (int y = 0; y < yPos; y++)
                            {
                                if (x == 0 || x == xPos - 1 || y == 0 || y == yPos - 1)
                                {
                                    gameMap.Mapprop[x, y] = new Obstacle(x, y, "X");
                                }
                                else
                                {
                                gameMap.Mapprop[x, y] = new EmptyTile(x, y, ". ");                                
                                }
                            }
                        }
                        break;
                    case "EnemyAmount":
                        Enemy[] tmp = new Enemy[xPos];
                        gameMap.SetEnemies(tmp);
                        break;
                    case "ItemAmount":
                        gameMap.Items = new Item[xPos];
                        break;
                    case "Hero":
                        Hero hero = new Hero(xPos, yPos,2, hp, maxHp, "H ") { GoldPurse = gold };   //makes a new hero from the savefile data
                        switch (weapon)
                        {
                            case "LongSword":
                                Weapon w = new MeleeWeapon(MeleeWeapon.WeaponType.LongSword, 0, 0, "LS");
                                hero.Pickup(w);
                                break;
                            case "Dagger":
                                Weapon x = new MeleeWeapon(MeleeWeapon.WeaponType.Dagger, 0, 0, "D ");
                                hero.Pickup(x);
                                break;
                            case "LongBow":
                                Weapon y = new RangedWeapon(RangedWeapon.WeaponType.LongBow, 0, 0, "LB");
                                hero.Pickup(y);
                                break;
                            case "Rifle":
                                Weapon z = new RangedWeapon(RangedWeapon.WeaponType.Rifle, 0, 0, "R ");
                                hero.Pickup(z);
                                break;
                            default:
                                break;
                        }
                        gameMap.Heroprop = hero;
                        gameMap.Mapprop[xPos, yPos] = hero;     //places new hero on the map
                        break;
                    case "Mage":
                        for (int i = 0; i < gameMap.GetEnemies().Length; i++)   //loops through enemies array and adds a new mage from the savefile data if there is an open space in the enemy array
                        {
                            if (gameMap.GetEnemies()[i] is null)    
                            {
                                Mage mage = new Mage(xPos, yPos,5, hp, 5, "M ") { GoldPurse = gold };
                                gameMap.GetEnemies()[i] = mage;
                                gameMap.Mapprop[xPos, yPos] = mage;     //places new mage on the map
                                break;
                            }
                        }
                        break;
                    case "Swamp Creature":
                        for (int i = 0; i < gameMap.GetEnemies().Length; i++)       //loops through enemies array and adds a swampcreature from the savefile data to an open space in the enemy array
                        {
                            if (gameMap.GetEnemies()[i] is null)
                            {
                                SwampCreature swampCreature = new SwampCreature(xPos, yPos, 1, hp, 10, "SC") {  GoldPurse = gold };
                                switch (weapon)
                                {
                                    case "LongSword":
                                        Weapon w = new MeleeWeapon(MeleeWeapon.WeaponType.LongSword, 0, 0, "LS");
                                        swampCreature.Pickup(w);
                                        break;
                                    case "Dagger":
                                        Weapon x = new MeleeWeapon(MeleeWeapon.WeaponType.Dagger, 0, 0, "D ");
                                        swampCreature.Pickup(x);
                                        break;
                                    case "LongBow":
                                        Weapon y = new RangedWeapon(RangedWeapon.WeaponType.LongBow, 0, 0, "LB");
                                        swampCreature.Pickup(y);
                                        break;
                                    case "Rifle":
                                        Weapon z = new RangedWeapon(RangedWeapon.WeaponType.Rifle, 0, 0, "R ");
                                        swampCreature.Pickup(z);
                                        break;
                                    default:
                                        break;
                                }
                                gameMap.GetEnemies()[i] = swampCreature;
                                gameMap.Mapprop[xPos, yPos] = swampCreature;    //places new swampcreature on the map
                                break;
                            }
                        }
                        break;
                    case "Leader":
                        for (int i = 0; i < gameMap.GetEnemies().Length; i++)       //loops through enemies array and adds a leader from the savefile data to an open space in the enemy array
                        {
                            if (gameMap.GetEnemies()[i] is null)
                            {
                                Leader leader = new Leader(xPos, yPos, 1, hp, 10, "L ") { GoldPurse = gold };
                                switch (weapon)
                                {
                                    case "LongSword":
                                        Weapon w = new MeleeWeapon(MeleeWeapon.WeaponType.LongSword, 0, 0, "LS");
                                        leader.Pickup(w);
                                        break;
                                    case "Dagger":
                                        Weapon x = new MeleeWeapon(MeleeWeapon.WeaponType.Dagger, 0, 0, "D ");
                                        leader.Pickup(x);
                                        break;
                                    case "LongBow":
                                        Weapon y = new RangedWeapon(RangedWeapon.WeaponType.LongBow, 0, 0, "LB");
                                        leader.Pickup(y);
                                        break;
                                    case "Rifle":
                                        Weapon z = new RangedWeapon(RangedWeapon.WeaponType.Rifle, 0, 0, "R ");
                                        leader.Pickup(z);
                                        break;
                                    default:
                                        break;
                                }
                                gameMap.GetEnemies()[i] = leader;
                                gameMap.Mapprop[xPos, yPos] = leader;    //places new leader on the map
                                break;
                            }
                        }
                        break;
                    case "Gold":        
                        Gold _gold = new Gold(xPos, yPos, "G ") { GoldAmount = gold };      //creates gold from the savefile data and adds it to an open space in the item array
                        for (int i = 0; i < gameMap.Items.Length; i++)
                        {
                            if (gameMap.Items[i] is null)
                            {
                                gameMap.Items[i] = _gold;
                                break;
                            }
                        }
                        gameMap.Mapprop[xPos, yPos] = _gold;    //places new gold on the map
                        break;
                    case "Weapon":
                        switch (weapon)
                        {
                            case "LongSword":
                                Weapon ls = new MeleeWeapon(MeleeWeapon.WeaponType.LongSword,xPos, yPos, "LS");
                                for (int i = 0; i < gameMap.Items.Length; i++)
                                {
                                    if (gameMap.Items[i] is null)
                                    {
                                        gameMap.Items[i] = ls;
                                        break;
                                    }
                                }
                                gameMap.Mapprop[xPos, yPos] = ls;
                                break;
                            case "Dagger":
                                Weapon d = new MeleeWeapon(MeleeWeapon.WeaponType.Dagger, xPos, yPos, "D ");
                                for (int i = 0; i < gameMap.Items.Length; i++)
                                {
                                    if (gameMap.Items[i] is null)
                                    {
                                        gameMap.Items[i] = d;
                                        break;
                                    }
                                }
                                gameMap.Mapprop[xPos, yPos] = d;
                                break;
                            case "LongBow":
                                Weapon lb = new RangedWeapon(RangedWeapon.WeaponType.LongBow, xPos, yPos, "LB");
                                for (int i = 0; i < gameMap.Items.Length; i++)
                                {
                                    if (gameMap.Items[i] is null)
                                    {
                                        gameMap.Items[i] = lb;
                                        break;
                                    }
                                }
                                gameMap.Mapprop[xPos, yPos] = lb;
                                break;
                            case "Rifle":
                                Weapon r = new RangedWeapon(RangedWeapon.WeaponType.Rifle, xPos, yPos, "R ");
                                for (int i = 0; i < gameMap.Items.Length; i++)
                                {
                                    if (gameMap.Items[i] is null)
                                    {
                                        gameMap.Items[i] = r;
                                        break;
                                    }
                                }
                                gameMap.Mapprop[xPos, yPos] = r;
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            /*for(int i = 0; i < gameMap.GetEnemies().Length; i++)    //loop to check if there are any null values in the enemies array 
            {
                if (gameMap.GetEnemies()[i] == null)        //if there is a null value, creates a new array that is sorter and sets the enemy array to the new one
                {
                    Enemy[] aliveEnemies = new Enemy[i];

                    for (int j = 0; j < aliveEnemies.Length; j++)
                    {
                        aliveEnemies[j] = gameMap.GetEnemies()[j];
                    }

                    gameMap.SetEnemies(aliveEnemies);

                    break;
                }
            }*/

            for (int i = 0; i < gameMap.GetEnemies().Length; i++)       //updates vision of all enemies
            {
                gameMap.UpdateVision(gameMap.GetEnemies()[i]);
            }

            gameMap.UpdateVision(gameMap.Heroprop);     //updates vision for hero
        }






    }//class
}
