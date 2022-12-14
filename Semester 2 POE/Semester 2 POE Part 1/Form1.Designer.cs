namespace Semester_2_POE_Part_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.upButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.mapDisplayTextBox = new System.Windows.Forms.TextBox();
            this.playerStatsLabel = new System.Windows.Forms.Label();
            this.EnemyStatsTextbox = new System.Windows.Forms.RichTextBox();
            this.SelectEnemyDropDownList = new System.Windows.Forms.ComboBox();
            this.attackEnemyButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.backlogTextBox = new System.Windows.Forms.RichTextBox();
            this.shopLabel = new System.Windows.Forms.Label();
            this.item1Button = new System.Windows.Forms.Button();
            this.item2Button = new System.Windows.Forms.Button();
            this.item3Button = new System.Windows.Forms.Button();
            this.mapLabel = new System.Windows.Forms.Label();
            this.enemyBoxLabel = new System.Windows.Forms.Label();
            this.backlogLabel = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // upButton
            // 
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.upButton.Location = new System.Drawing.Point(411, 271);
            this.upButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(67, 75);
            this.upButton.TabIndex = 0;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.leftButton.Location = new System.Drawing.Point(331, 365);
            this.leftButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(67, 75);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // downButton
            // 
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.downButton.Location = new System.Drawing.Point(411, 365);
            this.downButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(67, 75);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rightButton.Location = new System.Drawing.Point(492, 365);
            this.rightButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(67, 75);
            this.rightButton.TabIndex = 3;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // mapDisplayTextBox
            // 
            this.mapDisplayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapDisplayTextBox.Font = new System.Drawing.Font("Monospac821 BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapDisplayTextBox.Location = new System.Drawing.Point(69, 76);
            this.mapDisplayTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mapDisplayTextBox.Multiline = true;
            this.mapDisplayTextBox.Name = "mapDisplayTextBox";
            this.mapDisplayTextBox.ReadOnly = true;
            this.mapDisplayTextBox.Size = new System.Drawing.Size(240, 361);
            this.mapDisplayTextBox.TabIndex = 4;
            // 
            // playerStatsLabel
            // 
            this.playerStatsLabel.AutoSize = true;
            this.playerStatsLabel.Location = new System.Drawing.Point(357, 76);
            this.playerStatsLabel.Name = "playerStatsLabel";
            this.playerStatsLabel.Size = new System.Drawing.Size(146, 17);
            this.playerStatsLabel.TabIndex = 5;
            this.playerStatsLabel.Text = "Player stats comes here";
            // 
            // EnemyStatsTextbox
            // 
            this.EnemyStatsTextbox.Location = new System.Drawing.Point(562, 76);
            this.EnemyStatsTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyStatsTextbox.Name = "EnemyStatsTextbox";
            this.EnemyStatsTextbox.ReadOnly = true;
            this.EnemyStatsTextbox.Size = new System.Drawing.Size(138, 204);
            this.EnemyStatsTextbox.TabIndex = 6;
            this.EnemyStatsTextbox.Text = "";
            this.EnemyStatsTextbox.TextChanged += new System.EventHandler(this.EnemyStatsTextbox_TextChanged);
            // 
            // SelectEnemyDropDownList
            // 
            this.SelectEnemyDropDownList.FormattingEnabled = true;
            this.SelectEnemyDropDownList.Location = new System.Drawing.Point(570, 297);
            this.SelectEnemyDropDownList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectEnemyDropDownList.Name = "SelectEnemyDropDownList";
            this.SelectEnemyDropDownList.Size = new System.Drawing.Size(106, 25);
            this.SelectEnemyDropDownList.TabIndex = 7;
            this.SelectEnemyDropDownList.SelectedIndexChanged += new System.EventHandler(this.SelectEnemy_SelectedIndexChanged);
            // 
            // attackEnemyButton
            // 
            this.attackEnemyButton.Location = new System.Drawing.Point(591, 344);
            this.attackEnemyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.attackEnemyButton.Name = "attackEnemyButton";
            this.attackEnemyButton.Size = new System.Drawing.Size(66, 25);
            this.attackEnemyButton.TabIndex = 8;
            this.attackEnemyButton.Text = "Attack";
            this.attackEnemyButton.UseVisualStyleBackColor = true;
            this.attackEnemyButton.Click += new System.EventHandler(this.attackEnemyButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(591, 390);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(66, 25);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(591, 419);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(66, 25);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // backlogTextBox
            // 
            this.backlogTextBox.Location = new System.Drawing.Point(726, 76);
            this.backlogTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backlogTextBox.Name = "backlogTextBox";
            this.backlogTextBox.ReadOnly = true;
            this.backlogTextBox.Size = new System.Drawing.Size(146, 203);
            this.backlogTextBox.TabIndex = 11;
            this.backlogTextBox.Text = "";
            this.backlogTextBox.TextChanged += new System.EventHandler(this.backlogTextBox_TextChanged);
            // 
            // shopLabel
            // 
            this.shopLabel.AutoSize = true;
            this.shopLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopLabel.Location = new System.Drawing.Point(722, 296);
            this.shopLabel.Name = "shopLabel";
            this.shopLabel.Size = new System.Drawing.Size(56, 23);
            this.shopLabel.TabIndex = 12;
            this.shopLabel.Text = "Shop:";
            // 
            // item1Button
            // 
            this.item1Button.Enabled = false;
            this.item1Button.Location = new System.Drawing.Point(726, 343);
            this.item1Button.Name = "item1Button";
            this.item1Button.Size = new System.Drawing.Size(146, 25);
            this.item1Button.TabIndex = 13;
            this.item1Button.Text = "Shopbutton1";
            this.item1Button.UseVisualStyleBackColor = true;
            this.item1Button.Click += new System.EventHandler(this.item1Button_Click);
            // 
            // item2Button
            // 
            this.item2Button.Enabled = false;
            this.item2Button.Location = new System.Drawing.Point(726, 374);
            this.item2Button.Name = "item2Button";
            this.item2Button.Size = new System.Drawing.Size(146, 25);
            this.item2Button.TabIndex = 14;
            this.item2Button.Text = "Shopbutton2";
            this.item2Button.UseVisualStyleBackColor = true;
            this.item2Button.Click += new System.EventHandler(this.item2Button_Click);
            // 
            // item3Button
            // 
            this.item3Button.Enabled = false;
            this.item3Button.Location = new System.Drawing.Point(726, 405);
            this.item3Button.Name = "item3Button";
            this.item3Button.Size = new System.Drawing.Size(146, 25);
            this.item3Button.TabIndex = 15;
            this.item3Button.Text = "Shopbutton3";
            this.item3Button.UseVisualStyleBackColor = true;
            this.item3Button.Click += new System.EventHandler(this.item3Button_Click);
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapLabel.Location = new System.Drawing.Point(65, 51);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(46, 23);
            this.mapLabel.TabIndex = 16;
            this.mapLabel.Text = "Map";
            // 
            // enemyBoxLabel
            // 
            this.enemyBoxLabel.AutoSize = true;
            this.enemyBoxLabel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyBoxLabel.Location = new System.Drawing.Point(558, 51);
            this.enemyBoxLabel.Name = "enemyBoxLabel";
            this.enemyBoxLabel.Size = new System.Drawing.Size(142, 17);
            this.enemyBoxLabel.TabIndex = 17;
            this.enemyBoxLabel.Text = "Selected Enemy Stats:";
            // 
            // backlogLabel
            // 
            this.backlogLabel.AutoSize = true;
            this.backlogLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backlogLabel.Location = new System.Drawing.Point(722, 47);
            this.backlogLabel.Name = "backlogLabel";
            this.backlogLabel.Size = new System.Drawing.Size(143, 23);
            this.backlogLabel.TabIndex = 18;
            this.backlogLabel.Text = "Backlog Display:";
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.Location = new System.Drawing.Point(356, 47);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(99, 23);
            this.playerLabel.TabIndex = 19;
            this.playerLabel.Text = "Hero Stats:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 527);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.backlogLabel);
            this.Controls.Add(this.enemyBoxLabel);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.item3Button);
            this.Controls.Add(this.item2Button);
            this.Controls.Add(this.item1Button);
            this.Controls.Add(this.shopLabel);
            this.Controls.Add(this.backlogTextBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.attackEnemyButton);
            this.Controls.Add(this.SelectEnemyDropDownList);
            this.Controls.Add(this.EnemyStatsTextbox);
            this.Controls.Add(this.playerStatsLabel);
            this.Controls.Add(this.mapDisplayTextBox);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.upButton);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.TextBox mapDisplayTextBox;
        private System.Windows.Forms.Label playerStatsLabel;
        private System.Windows.Forms.RichTextBox EnemyStatsTextbox;
        private System.Windows.Forms.ComboBox SelectEnemyDropDownList;
        private System.Windows.Forms.Button attackEnemyButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.RichTextBox backlogTextBox;
        private System.Windows.Forms.Label shopLabel;
        private System.Windows.Forms.Button item1Button;
        private System.Windows.Forms.Button item2Button;
        private System.Windows.Forms.Button item3Button;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.Label enemyBoxLabel;
        private System.Windows.Forms.Label backlogLabel;
        private System.Windows.Forms.Label playerLabel;
    }
}

