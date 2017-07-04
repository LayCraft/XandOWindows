using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XOGame;


namespace XOapp
{
    public partial class XOForm : Form
    {
        private Turn _turn;
        private char[,] grid = new char[3, 3];

        public XOForm()
        {
            InitializeComponent();
        }

        private void XOForm_Load(object sender, EventArgs e)
        {
            _turn = new Turn();
            _turn.Flipped += OnFlipped;
            OnFlipped(null, EventArgs.Empty);
        }

        private void CheckWin()
        {
            // check all winning conditions
            // horizontal
            CheckForWin(grid[0, 0], grid[0, 1], grid[0, 2]);
            CheckForWin(grid[1, 0], grid[1, 1], grid[1, 2]);
            CheckForWin(grid[2, 0], grid[2, 1], grid[2, 2]);
            // vertical
            CheckForWin(grid[0, 0], grid[1, 0], grid[2, 0]);
            CheckForWin(grid[0, 1], grid[1, 1], grid[2, 1]);
            CheckForWin(grid[0, 2], grid[1, 2], grid[2, 2]);
            // diagonal
            CheckForWin(grid[0, 0], grid[1, 1], grid[2, 2]);
            CheckForWin(grid[0, 2], grid[1, 1], grid[2, 0]);

        }

        private bool CheckForWin(char a, char b, char c)
        {
            if ((a == 'X' || a == 'O') && a == b && b == c)
            {
                MessageBox.Show(this, string.Format("{0} is the winner!", a), "X & O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                return true;
            }
            return false;
        }

        private void OnFlipped(object sender, EventArgs e)
        {
            _turnLabel.Text = string.Format("{0} Go!", _turn.WhoseTurn);
        }


        
        private void OnButtonClick(object sender, EventArgs e)
        {          
            // The code below gets the button that was clicked, and grabs a number from the Button's tag property
            Button button = sender as Button;
            // get tagnum as an int
            int tagNum;
            int.TryParse(button.Tag.ToString(), out tagNum);
            button.Text = _turn.WhoseTurn.ToString();

            switch (tagNum)
            {
                case 0: 
                    grid[0, 0] = _turn.WhoseTurn;                    
                    break;
                case 1:
                    grid[0, 1] = _turn.WhoseTurn;
                    
                    break;
                case 2:
                    grid[0, 2] = _turn.WhoseTurn;
                    break;
                case 3:
                    grid[1, 0] = _turn.WhoseTurn;
                    break;
                case 4:
                    grid[1, 1] = _turn.WhoseTurn;
                    break;
                case 5:
                    grid[1, 2] = _turn.WhoseTurn;
                    break;
                case 6:
                    grid[2, 0] = _turn.WhoseTurn;
                    break;
                case 7:
                    grid[2, 1] = _turn.WhoseTurn;
                    break;
                case 8:
                    grid[2, 2] = _turn.WhoseTurn;
                    break;
                default:
                    break;
            }
            CheckWin();
            _turn.Flip();
            button.Enabled = false;
        }
    }
}
