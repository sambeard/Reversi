﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Form1 : Form
    {
        GameClass Game;

        public Form1()
        {
            InitializeComponent();
            this.Game = new GameClass(this, this.Game_panel.Size, 6, this.checkBoxB.Checked, this.checkBoxR.Checked);

        }

        private void Game_panel_Paint(object sender, PaintEventArgs e)
        {
            Game.drawHandler(e.Graphics);

        }
        public void checkLabels()
        {
            switch (this.Game.Current.Player)
            {
                case -1: break;
                case 1:
                    {
                        this.TurnLabel.Text = "BLUE";
                        this.TurnLabel.ForeColor = Color.Blue;
                        break;
                    }
                case 2:
                    {
                        this.TurnLabel.Text = "RED";
                        this.TurnLabel.ForeColor = Color.Red;
                        break;
                    }
            }
            this.Score_Blue.Text = this.Game.getBlueScore.ToString();
            this.Score_Red.Text = this.Game.getRedScore.ToString();
            if (this.Game.GameOver)
            {
                this.L_GameOver.Size = new Size(Game_panel.Size.Width, Game_panel.Size.Height);
                this.L_GameOver.Location = new Point(0, 0);
                if (this.Game.getBlueScore > this.Game.getRedScore)
                {
                    this.L_GameOver.Text = "BLUE WINS";
                    this.L_GameOver.ForeColor = Color.Blue;
                }
                else if (this.Game.getBlueScore == this.Game.getRedScore)
                {
                    this.L_GameOver.Text = "DRAW";
                    this.L_GameOver.ForeColor = Color.FromArgb(85, 85, 85);
                }
                else
                {
                    this.L_GameOver.Text = "RED WINS";
                    this.L_GameOver.ForeColor = Color.Red;
                }
            }
            else
            {
                this.L_GameOver.Text = "";
                this.L_GameOver.Location = new Point(-2000, -2000);
            }
        }

        private void Game_panel_MouseClick(object sender, MouseEventArgs e)
        {
            Game.mouseEvent(e.Location);
            this.checkLabels();
            //this.backButton.Enabled = (this.Game.MovesMade.Count != 0);
            Game_panel.Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (combo_GameMode.SelectedIndex)
            {
                case -1: this.Game = new GameClass(this, Game_panel.Size, 6, this.checkBoxB.Checked, this.checkBoxR.Checked); ; break;
                case 0: this.Game = new GameClass(this, Game_panel.Size, 6, this.checkBoxB.Checked, this.checkBoxR.Checked); ; break;
                case 1: this.Game = new GameClass(this, Game_panel.Size, 8, this.checkBoxB.Checked, this.checkBoxR.Checked); ; break;
                case 2: this.Game = new GameClass(this, Game_panel.Size, 10, this.checkBoxB.Checked, this.checkBoxR.Checked); ; break;
                case 3: this.Game = new GameClass(this, Game_panel.Size, 12, this.checkBoxB.Checked, this.checkBoxR.Checked); ; break;
                case 4: this.Game = new GameClass(this, Game_panel.Size, 14, this.checkBoxB.Checked, this.checkBoxR.Checked); ; break;
                case 5: this.Game = new GameClass(this, Game_panel.Size, 16, this.checkBoxB.Checked, this.checkBoxR.Checked); ; break;
            }
            this.checkLabels();
            if (this.checkBoxB.Checked == true && this.checkBoxR.Checked == true) Game.computerMove();
            this.backButton.Enabled = false;
            this.Refresh();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            this.Game_panel.Size = (c.Size.Width <= c.Size.Height) ? new Size(c.Size.Width - 150, c.Size.Width - 150) : new Size(c.Size.Height - 150, c.Size.Height - 150);
            this.L_GameOver.Size = new Size(Game_panel.Size.Width, Game_panel.Size.Height);
            this.Game.Screen = this.Game_panel.Size;
            this.Refresh();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //this.Game.popMove();
            this.Refresh();
        }

        private void pause()
        {
            // Pause App
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'K') pause();
        }
    }
}
