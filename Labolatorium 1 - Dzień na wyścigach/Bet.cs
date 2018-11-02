using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labolatorium_1___Dzień_na_wyścigach
{
    public class Bet
    {
        public int amount; //ilosc obstawionych pieniedzy
        public int dog; // numer psa na ktory obstawiono
        public Guy bettor; //facet, ktory zawarl zaklad

        public string GetDescription()
        {
            //zwraca string, ktory okresla kto obstawil zaklad, jak duzo kasy postawil i na ktorego psa
            // gdy 0 to zaklad nie zostal zawarty
            if (amount >=5 && amount <=15)
            {
                return bettor.Name + " postawił " + amount + "zł na psa nr " + dog;
            }
            else
            return bettor.Name + " jeszcze nie obstawił ";
        }

        public int PayOut (int winner)
        {
            //parametr to zwyciezca, jezeli pies wygral, zwroc wartosc postawiona, w przeciwnym razie zwroc ze znakiem -
            if (winner == dog)
                return amount;
            else
                return -amount;
        }

    }
}
