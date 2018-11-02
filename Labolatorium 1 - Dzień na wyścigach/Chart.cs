using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labolatorium_1___Dzień_na_wyścigach
{
    public class Chart
    {
        public int startingPosition; // pozycja startowa       
        public PictureBox myPictureBox = null;
        public int raceTrackLength; //dlugosc trasy
        public int Location = 0; //polozenie na torze
        public Random myRandom;
        

        public bool Run()
        {
            //przesun sie losow o 1,2,3 lub 4 punkty
            //zaaktualizuj polozenie pciture box
            //true jesli wygra wyscig

            if (Location < raceTrackLength)
            {
                myPictureBox.Left += myRandom.Next(1,10);
                Location = myPictureBox.Left;
                return false;
            }                    
            else
            return true;
        }

        public void TakeStartingPosition()
        {

            Location = startingPosition;
            myPictureBox.Left = startingPosition;
            // wyzeruj polozenie i ustaw na lini poczatkowej

        }
    }
}
