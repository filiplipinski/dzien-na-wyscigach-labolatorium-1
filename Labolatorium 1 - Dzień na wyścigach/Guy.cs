using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labolatorium_1___Dzień_na_wyścigach
{
    public class Guy 
    {
        public string Name; // imie faceta
        public Bet MyBet = new Bet();
        public int Cash; // ile kasy posiada

        public RadioButton MyRadioButton; //moje pole wyboru
        public Label MyLabel; //moja etykieta

        public Guy()
        {
            //moimi slowami:
            //to tak jakby konstruktor ktory daje przy wywowałaniu rowniez BET
            //ale z powodu ze to klasa, to bettor jest przekazywany, sam siebie wiec this
            MyBet.bettor = this; 
        }

        public void UpdateLabels()
        {
            //ustaw moje pole tekstowe na opis zakladu, a napis obok pola wyboru tak, aby pokazywal ilosc kasy ("janek ma 43zl)
            MyRadioButton.Text = Name + " ma " + Cash + "zł";
            MyLabel.Text = MyBet.GetDescription();
        }  
        public void ClearBet()
        {
            //czysczenie zakladu
            MyBet.amount = 0;
            MyBet.dog = 0;
        }
        public bool PlaceBet( int amount, int DogToWin)
        {
            //ustaw nowy zaklad i przechowaj go w poly MyBet
            //zwraca true, jezeli facet ma wsytarczajaca ilosc pieniedzy aby obstawic
            if (amount <= Cash)
            {
                MyBet.amount = amount;
                MyBet.dog = DogToWin;
                UpdateLabels();
                return true;
            }
            else
            {
                MessageBox.Show(Name + " nie ma wystarczająco pieniędzy, aby obstawić", "Brak środków");
                return false;
            }
        }

        public void Collect (int winner)
        {
            //poprosc o wyplate zakladu i zaaktualizuj etykiety

            Cash += MyBet.PayOut(winner);
            UpdateLabels();
        }
    }
}
