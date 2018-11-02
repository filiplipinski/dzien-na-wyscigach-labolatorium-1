using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labolatorium_1___Dzień_na_wyścigach
{
    public partial class Form1 : Form
    {

        Chart[] chart = new Chart[4]; //4 obiekty psow
        Guy[] guy = new Guy[3];
        public Random randomMain = new Random();
        

        public void InitializeDogs()
        {
            for (int index = 0; index < 4; index++)
            {
                chart[index] = new Chart();

                chart[index].startingPosition = chart0.Left;
                chart[index].raceTrackLength = pictureBox1.Width - chart0.Width + chart0.Left ; //+ dodac ten margines po lewej
                chart[index].myRandom = randomMain; 
            }

            chart[0].myPictureBox = chart0;
            chart[1].myPictureBox = chart1;
            chart[2].myPictureBox = chart2;
            chart[3].myPictureBox = chart3;
        }

        public void InitializeGuys()
        {

            guy[0] = new Guy() { Cash = 50, Name = "Janek", MyRadioButton = janekRadioButton, MyLabel = janekLabel };
            guy[0].UpdateLabels();
            guy[1] = new Guy() { Cash = 75, Name = "Bartek", MyRadioButton = bartekRadioButton, MyLabel = bartekLabel };
            guy[1].UpdateLabels();
            guy[2] = new Guy() { Cash = 45, Name = "Arek", MyRadioButton = arekRadioButton, MyLabel = arekLabel };
            guy[2].UpdateLabels();
        }

        public Form1()
        {
            InitializeComponent();
            InitializeDogs();
            InitializeGuys();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
                timer1.Start();
                panel1.Enabled = false;
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if(janekRadioButton.Checked)
            {
                guy[0].PlaceBet((int)howBigBet.Value, (int)whichChart.Value);
            }
            else if (bartekRadioButton.Checked)
            {
                guy[1].PlaceBet((int)howBigBet.Value, (int)whichChart.Value);
            }
            else if (arekRadioButton.Checked)
            {
                guy[2].PlaceBet((int)howBigBet.Value, (int)whichChart.Value);
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                    if (chart[i].Run() == true)
                    {
                        timer1.Stop();
                        panel1.Enabled = true;
                        MessageBox.Show("Zwycięzca to chart z numerem " + (i + 1), "Gratulacje !");

                        for (int j = 0; j <= 3; j++)
                            chart[j].TakeStartingPosition();
                        for (int k = 0; k < 3; k++ )
                        {
                        guy[k].Collect(i+1);
                        guy[k].ClearBet();
                        guy[k].UpdateLabels();
                        }
                    }                   
            }
        }

        private void janekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            whoBet.Text = "Janek";
        }

        private void bartekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            whoBet.Text = "Bartek";
        }


        private void arekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            whoBet.Text = "Arek";
        }
    }
}
