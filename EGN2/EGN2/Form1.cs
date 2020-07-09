using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGN2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string egn = textBox1.Text;
            int[] egnInteger = new int[10];
            char[] egnArray = new char[10];

            float sbor;
            float lastNumber;



            if (egn.Length != 10)
            {
                MessageBox.Show("Wrong EGN length");
            } // proverka za 10 simvola

            else
            {
                try { egnArray = egn.ToCharArray(); } catch { MessageBox.Show("EGN must contain only numbers"); } // convertira string s egnto v char array
            }

            for (int i = 0; i < 10; i++)
            {
                egnInteger[i] = egnArray[i] - '0';
                //Console.WriteLine(egnInteger[i]);
            }

            sbor =
                egnInteger[0] * 2 +
                egnInteger[1] * 4 +
                egnInteger[2] * 8 +
                egnInteger[3] * 5 +
                egnInteger[4] * 10 +
                egnInteger[5] * 9 +
                egnInteger[6] * 7 +
                egnInteger[7] * 3 +
                egnInteger[8] * 6;

            lastNumber = sbor % 11;
            if (lastNumber == 10) { lastNumber = 0; };
            //Console.WriteLine(sbor);
            //Console.WriteLine(lastNumber);


            if (lastNumber == egnInteger[9])
            {
                textBox2.Text = ("This EGN exists.\n");

                izkarvaneNaData();
                namiraneNaMesec();
                namiraneNaGodina();
                namiraneNaOblast();
                namiraneNaPol();
            }

            else
            {
                textBox2.Text = ("No such EGN.");
            }

            void namiraneNaMesec()
            {
                string mesec;

                if (egnInteger[2] == 1)
                    switch (egnInteger[3])
                    {
                        case 0: mesec = "October"; textBox2.Text = textBox2.Text + mesec; break;
                        case 1: mesec = "November"; textBox2.Text = textBox2.Text + mesec; break;
                        case 2: mesec = "December"; textBox2.Text = textBox2.Text + mesec; break;

                    }
                else
                {
                    switch (egnInteger[3])
                    {
                        case 1: mesec = "January"; textBox2.Text = textBox2.Text + mesec; break;
                        case 2: mesec = "February"; textBox2.Text = textBox2.Text + mesec; break;
                        case 3: mesec = "March"; textBox2.Text = textBox2.Text + mesec; break;
                        case 4: mesec = "April"; textBox2.Text = textBox2.Text + mesec; break;
                        case 5: mesec = "May"; textBox2.Text = textBox2.Text + mesec; break;
                        case 6: mesec = "June"; textBox2.Text = textBox2.Text + mesec; break;
                        case 7: mesec = "July"; textBox2.Text = textBox2.Text + mesec; break;
                        case 8: mesec = "August"; textBox2.Text = textBox2.Text + mesec; break;
                        case 9: mesec = "September"; textBox2.Text = textBox2.Text + mesec; break;
                    }
                }



            }

            void izkarvaneNaData()
            {
                textBox2.Text = textBox2.Text + ($"\t{egnInteger[4]}{egnInteger[5]} ");
            }

            void namiraneNaGodina()
            {
                if (egnInteger[2] == 3 || egnInteger[2] == 4) // ako e predi 1900
                { textBox2.Text = textBox2.Text + ($" 18{egnInteger[0]}{egnInteger[1]}"); }

                else if (egnInteger[2] == 4 || egnInteger[2] == 5)
                { textBox2.Text = textBox2.Text + ($" 20{egnInteger[0]}{egnInteger[1]}"); } // ako e sled 2000

                else { textBox2.Text = textBox2.Text + ($" 19{egnInteger[0]}{egnInteger[1]}"); } // ako e mejdu 1900 i 2000
            }

            void namiraneNaOblast()
            {
                int oblastCheck = 0;

                for (int i = 6; i < 9; i++)
                {
                    oblastCheck = oblastCheck * 10;
                    oblastCheck += egnInteger[i];

                }
                textBox2.Text = textBox2.Text + "\t";

                if (oblastCheck <= 43) { textBox2.Text = textBox2.Text + "Благоевград"; }
                else if (oblastCheck >= 44 && oblastCheck <= 93) { textBox2.Text = textBox2.Text + "Бургас"; }
                else if (oblastCheck >= 94 && oblastCheck <= 139) { textBox2.Text = textBox2.Text + "Варна"; }
                else if (oblastCheck >= 140 && oblastCheck <= 169) { textBox2.Text = textBox2.Text + "Велико Търново"; }
                else if (oblastCheck >= 170 && oblastCheck <= 183) { textBox2.Text = textBox2.Text + "Видин"; }
                else if (oblastCheck >= 184 && oblastCheck <= 217) { textBox2.Text = textBox2.Text + "Враца"; }
                else if (oblastCheck >= 218 && oblastCheck <= 233) { textBox2.Text = textBox2.Text + "Габрово"; }
                else if (oblastCheck >= 234 && oblastCheck <= 281) { textBox2.Text = textBox2.Text + "Кърджали"; }
                else if (oblastCheck >= 282 && oblastCheck <= 301) { textBox2.Text = textBox2.Text + "Кюстендил"; }
                else if (oblastCheck >= 302 && oblastCheck <= 319) { textBox2.Text = textBox2.Text + "Ловеч"; }
                else if (oblastCheck >= 320 && oblastCheck <= 341) { textBox2.Text = textBox2.Text + "Монтана"; }
                else if (oblastCheck >= 342 && oblastCheck <= 377) { textBox2.Text = textBox2.Text + "Пазарджик"; }
                else if (oblastCheck >= 378 && oblastCheck <= 395) { textBox2.Text = textBox2.Text + "Перник"; }
                else if (oblastCheck >= 396 && oblastCheck <= 435) { textBox2.Text = textBox2.Text + "Плевен"; }
                else if (oblastCheck >= 436 && oblastCheck <= 501) { textBox2.Text = textBox2.Text + "Пловдив"; }
                else if (oblastCheck >= 502 && oblastCheck <= 527) { textBox2.Text = textBox2.Text + "Разград"; }
                else if (oblastCheck >= 528 && oblastCheck <= 555) { textBox2.Text = textBox2.Text + "Русе"; }
                else if (oblastCheck >= 556 && oblastCheck <= 575) { textBox2.Text = textBox2.Text + "Силистра"; }
                else if (oblastCheck >= 576 && oblastCheck <= 601) { textBox2.Text = textBox2.Text + "Сливен"; }
                else if (oblastCheck >= 602 && oblastCheck <= 623) { textBox2.Text = textBox2.Text + "Смолян"; }
                else if (oblastCheck >= 624 && oblastCheck <= 721) { textBox2.Text = textBox2.Text + "София - град"; }
                else if (oblastCheck >= 722 && oblastCheck <= 751) { textBox2.Text = textBox2.Text + "София - окръг"; }
                else if (oblastCheck >= 752 && oblastCheck <= 789) { textBox2.Text = textBox2.Text + "Стара Загора"; }
                else if (oblastCheck >= 790 && oblastCheck <= 821) { textBox2.Text = textBox2.Text + "Добрич"; }
                else if (oblastCheck >= 822 && oblastCheck <= 843) { textBox2.Text = textBox2.Text + "Търговище"; }
                else if (oblastCheck >= 844 && oblastCheck <= 871) { textBox2.Text = textBox2.Text + "Хасково"; }
                else if (oblastCheck >= 872 && oblastCheck <= 903) { textBox2.Text = textBox2.Text + "Шумен"; }
                else if (oblastCheck >= 904 && oblastCheck <= 925) { textBox2.Text = textBox2.Text + "Ямбол"; }
                else if (oblastCheck >= 926) { textBox2.Text = textBox2.Text + "Непозната област или друго"; }
                
            }

            void namiraneNaPol()
            {
                if(egnInteger[8] % 2 == 0) { textBox2.Text = textBox2.Text + "\tМъж"; }
                else { textBox2.Text = textBox2.Text + "\tЖена"; }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }


  }


