using System;
using System.Diagnostics;

namespace XOGame
{
    public class Turn
    {
        private char _whoseTurn = 'X';
        private int _turnsLeft = 9;

        /*
        * return a character representing which player is next to play 
        */
        public char WhoseTurn
        {
            get { return _whoseTurn; }
        }

        /*
         * how many turns remain in the game. (9 spots on the board) 
         */
        public int TurnsLeft
        {
            get { return _turnsLeft; }
        }

        // make a method to change player turns
        public void Flip()
        {   
            /* 
             * Guess
             * if (_whoseTurn == 'X'){
             *      _whoseTurn ='O';
             * }
             * else {
             *      _whoseTurn = 'X';
             * }
             */
            _whoseTurn = (_whoseTurn == 'X') ? 'O' : 'X';
            //decrenment turnsleft
            _turnsLeft--;
            // if the number of turns  gets lower than 0 throw an error
            if (_turnsLeft < 0)
                throw new ApplicationException("TurnsLeft cannot go lower than 0");
            OnFlipped();
        }


        public event EventHandler Flipped;

        private void OnFlipped()
        {
            EventHandler flipped = Flipped;
            if (flipped != null)
            {
                flipped(this, EventArgs.Empty);
            }
        }
    }
}