using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester_2_POE_Part_1
{
    public partial class Form1 : Form
    {
        GameEngine engine;  //declarations
        Shop shop;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //creates game engine object, displays the map
        {
            engine = new GameEngine(); 
            engine.Form1 = this;

            DisplayMap();

            engine.getMap().GetEnemies();

            string[] entires = new string[engine.getMap().GetEnemies().Length]; //getting string array of eneimes on form load
            
            for (int i = 0; i < entires.Length; i++) //drop down menu entries
            {
                entires[i] = engine.getMap().GetEnemies()[i].ToString();
                SelectEnemyDropDownList.Items.Add(entires[i]); //adding entires to drop down menu on form load
            }

            shop = new Shop(engine.getMap().Heroprop);

            item1Button.Text = shop.DisplayWeapon(0);
            item2Button.Text = shop.DisplayWeapon(1);
            item3Button.Text = shop.DisplayWeapon(2);
            

        }

        private void EnemyStatsTextbox_TextChanged(object sender, EventArgs e)
        {
            
            //EnemyStatsTextbox.Text += "/n";
            //EnemyStatsTextbox.Text += engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].ToString();
            
        }

        private void attackEnemyButton_Click(object sender, EventArgs e)
        {
            if(SelectEnemyDropDownList.SelectedIndex == -1)
            {
                return; // to catch any errors if nothing in entered
            }
            try
            {
                if (engine.getMap().Heroprop.CheckRange(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex]) == true)
                {   //to attack an enemy if one is selected and in range
                    engine.getMap().Heroprop.Attack(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex]);
                    backlogTextBox.Text += $"Your attack was successfull!\n";

                    EnemyStatsTextbox.Text = engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].ToString();
                    if(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].isDead()== true)     //removes dead enemy symbols from the map and updates the map display
                    {
                        engine.getMap().Mapprop[engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].X, engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].Y] = new EmptyTile(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].X, engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].Y, ". ");
                        DisplayMap();
                        engine.getMap().UpdateVision(engine.getMap().Heroprop);
                        EnemyStatsTextbox.Text += "\nEnemy was killed, please select another enemy to attack";
                        backlogTextBox.Text += HasDied(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex], engine.getMap().Heroprop);

                        if (engine.getMap().Heroprop.Loot(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex]))
                        {
                            backlogTextBox.Text += engine.getMap().Heroprop.HasLootedWeapon();
                        }

                        
                    }

                }
                else
                {   // if no enemy is in range
                    backlogTextBox.Text += "Attack Failed, enemy not in range\n";
                }
            }
            catch(IndexOutOfRangeException)
            {   //if trying to attack an enemy thats dead
                EnemyStatsTextbox.Text = "Enemy is unalived";
            }
            

            RemoveEnemies();    //remove dead enemies from enemy array
            engine.EnemyAttacks();      //enies attack after player does
            RemoveEnemies();      
            EnemyDropdown();
            DisplayMap();
            CheckGold();

            if(engine.getMap().GetEnemies().Length == 0)
            {
                MessageBox.Show("You are victorious!\nYou have slain all the enemies");
            }

        }

        private void SelectEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnemyStatsTextbox.Text = engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].ToString();    //sets the enemy stats textbox to display the selected enemy's stats when they are clicked in the dropdown
        }



        private void DisplayMap()   //method to display map with symbols in a textbox
        {
            mapDisplayTextBox.Clear();
            for (int i = 0; i < engine.getMap().GetMapHeight(); i++)
            {
                for (int j = 0; j < engine.getMap().GetMapWidth(); j++)
                {
                    mapDisplayTextBox.Text += engine.getMap().GetSymbol(i, j);
                }
                mapDisplayTextBox.Text += Environment.NewLine;
            }

            playerStatsLabel.Text = engine.getMap().Heroprop.ToString();
        }

        private void upButton_Click(object sender, EventArgs e) //moves hero up 
        {
            engine.MovePlayer(Character.movement.up);
            engine.MoveEnemies();   //move enemies after hero
            engine.EnemyAttacks();    //enemies attack after moving
            RemoveEnemies();     //remove dead enemies from enemy array
            DisplayMap();
            EnemyDropdown();
            CheckGold();
        }

        private void downButton_Click(object sender, EventArgs e)   //moves hero down
        {
            engine.MovePlayer(Character.movement.down);
            engine.MoveEnemies();   //move enemies after hero
            engine.EnemyAttacks();    //enemies attack after moving
            RemoveEnemies();     //remove dead enemies from enemy array 
            DisplayMap();
            EnemyDropdown();
            CheckGold();
        }

        private void rightButton_Click(object sender, EventArgs e)  //moves hero right
        {
            engine.MovePlayer(Character.movement.right);
            engine.MoveEnemies();   //move enemies after hero
            engine.EnemyAttacks();    //enemies attack after moving
            RemoveEnemies();     //remove dead enemies from enemy array
            DisplayMap();
            EnemyDropdown();
            CheckGold();
        }
        private void leftButton_Click(object sender, EventArgs e)   //moves hero left
        {
            engine.MovePlayer(Character.movement.left);
            engine.MoveEnemies();   //move enemies after hero
            engine.EnemyAttacks();    //enemies attack after moving
            RemoveEnemies();     //remove dead enemies from enemy array
            DisplayMap();
            EnemyDropdown();
            CheckGold();
        }

        private void EnemyDropdown() //renames enemy texts in the dropdown list to update their changing coordinates when they move
        {
           
            for (int i = 0; i < SelectEnemyDropDownList.Items.Count; i++) //drop down menu entries
            {
                SelectEnemyDropDownList.Items[i] = engine.getMap().GetEnemies()[i].ToString();
            }

        }

        public void RemoveEnemies()                        //check if enemies are dead, if they are dead create a new array without the dead ones
                                                            //set enemies method to overwrite the eneimes array + update combobox
        {
            int tmp = 0;

            for (int i = 0; i < engine.getMap().GetEnemies().Length; i++)
            {
                if (engine.getMap().GetEnemies()[i].isDead() == true)
                {
                    tmp++;
                }
            }

            if (tmp != 0)
            {
               
                Enemy[] noDeadEnemies = new Enemy[engine.getMap().GetEnemies().Length - tmp];
                int j = 0;
                for (int i = 0; i < engine.getMap().GetEnemies().Length; i++)
                {
                    //add all elements into new array except the dead one
                    if(engine.getMap().GetEnemies()[i].isDead() == false)
                    {
                        noDeadEnemies[j] = engine.getMap().GetEnemies()[i];
                        j++;
                    }
                }

                engine.getMap().SetEnemies(noDeadEnemies); //update the array to be the living enemies

                string[] entires = new string[engine.getMap().GetEnemies().Length]; //drop down menu entries

                SelectEnemyDropDownList.Items.Clear();

                for (int i = 0; i < entires.Length; i++)
                {
                    entires[i] = engine.getMap().GetEnemies()[i].ToString();
                    SelectEnemyDropDownList.Items.Add(entires[i]);
                }

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to save your current progress? Only one game can be saved at a time.", "Save Game?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                engine.SaveGame();
            }
            
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to load a previous saved game? All current progress will be lost.", "Load Game?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                engine.LoadGame();
                DisplayMap();   //display map after loading
                SelectEnemyDropDownList.Items.Clear();  //clear dropdown list

                string[] entires = new string[engine.getMap().GetEnemies().Length];

                for (int i = 0; i < entires.Length; i++) //drop down menu entries
                {
                    entires[i] = engine.getMap().GetEnemies()[i].ToString();
                    SelectEnemyDropDownList.Items.Add(entires[i]); //adding entires to drop down menu
                }
            
            }
        }

        private void backlogTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void Changetext(string s)
        {
            backlogTextBox.Text += s;
        }

        public string HasDied(Character target, Character attacker)
        {
            return $"The {target.Symbol} at [{target.X},{target.Y}] has been killed by the {attacker.Symbol} at [{attacker.X},{attacker.Y}]\n";
        }

        private void item1Button_Click(object sender, EventArgs e)
        {
            shop.Buy(0);
            Changetext($"You have bought a {engine.getMap().Heroprop.GetWeapon().WeaponTypeString}");
            item1Button.Text = shop.DisplayWeapon(0);
            CheckGold();
            playerStatsLabel.Text = engine.getMap().Heroprop.ToString();
        }

        private void CheckGold()
        {
            item1Button.Enabled = shop.canBuy(0);
            item2Button.Enabled = shop.canBuy(1);
            item3Button.Enabled = shop.canBuy(2);
        }

        private void item2Button_Click(object sender, EventArgs e)
        {
            shop.Buy(1);
            Changetext($"You have bought a {engine.getMap().Heroprop.GetWeapon().WeaponTypeString}");
            item2Button.Text = shop.DisplayWeapon(1);
            CheckGold();
            playerStatsLabel.Text = engine.getMap().Heroprop.ToString();
        }

        private void item3Button_Click(object sender, EventArgs e)
        {
            shop.Buy(2);
            Changetext($"You have bought a {engine.getMap().Heroprop.GetWeapon().WeaponTypeString}");
            item3Button.Text = shop.DisplayWeapon(2);
            CheckGold();
            playerStatsLabel.Text = engine.getMap().Heroprop.ToString();
        }
    }
}
