using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace Übung_6_Game_of_Live
{
    public partial class Form1 : Form
    {
        #region klappiklapp
        public const int width = 266; // Breite des Feldes
        public const int height = 190; // Höhe des Feldes

        public bool[,] AktuellesFrame = new bool[width, height];
        #endregion

        public void ZeichneFrame()
        {
            string dirName = Directory.GetCurrentDirectory();
            string backGroundPic = Directory.GetParent(dirName).Parent.Parent.FullName;
            var image = new Bitmap(backGroundPic + "\\starwars700.jpg");
            //image.SetResolution(width, height);
            

            int aliveCount = 0;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                { 
                    if (AktuellesFrame[x, y])
                    {
                        aliveCount++;
                        image.SetPixel(x, y,Color.White);
                    }                   
                }
            }   

            this.Text = "GameOfLife. Living Cells: " + aliveCount.ToString();

            pictureBox1.Image = image;
        }

        public void BerechneFrame()
        {
            var FolgeFrame = new bool[width, height]; 

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int Lebende_Nachbarzellen = Zähle_Lebend(x, y);

                    if (Lebende_Nachbarzellen < 2 || Lebende_Nachbarzellen > 3)
                    {
                        FolgeFrame[x, y] = false;
                    }

                    if (Lebende_Nachbarzellen == 2 && AktuellesFrame[x,y])
                    {
                        FolgeFrame[x, y] = true;
                    }

                    if (Lebende_Nachbarzellen == 3)
                    {
                        FolgeFrame[x,y] = true;
                    }
                }
            }

            AktuellesFrame = FolgeFrame;
        }

        public int Zähle_Lebend(int x,int y)
        {
            int Nachbarzahl = 0; // Für die Regeln

            // Links Oben
            if (AktuellesFrame[x - 1, y - 1])
            {
                Nachbarzahl++;
            }
            //Mitte Oben
            if (AktuellesFrame[x, y - 1])
            {
                Nachbarzahl++;
            }
            //Rechts Oben
            if (AktuellesFrame[x + 1, y - 1])
            {
                Nachbarzahl++;
            }
            //Links
            if (AktuellesFrame[x - 1, y])
            {
                Nachbarzahl++;
            }
            // Rechtes
            if (AktuellesFrame[x + 1, y])
            {
                Nachbarzahl++;
            }
            //Links Unten
            if (AktuellesFrame[x - 1, y + 1])
            {
                Nachbarzahl++;
            }
            //Mitte Unten
            if (AktuellesFrame[x, y + 1])
            {
                Nachbarzahl++;
            }
            //Rechts Unten
            if (AktuellesFrame[x + 1, y + 1])
            {
                Nachbarzahl++;
            }
            return Nachbarzahl;
        }


        public Form1()
        {
            InitializeComponent();

            //AktuellesFrame[100, 100] = true;
            //AktuellesFrame[101, 100] = true;
            //AktuellesFrame[100, 101] = true;
            //AktuellesFrame[99, 101] = true;
            //AktuellesFrame[100, 102] = true;

            //this.Width = width;
            //this.Height = height;

            var rnd = new System.Random();

            for (int y = 10; y < height - 10; y++)
            {
                for (int x = 10; x < width - 10; x++)
                {    
                    int nmbr = rnd.Next(2);

                    AktuellesFrame[x, y] = (nmbr == 1) ? true : false;
                }
            }
        }

        public void TimerIntervall_Tick(object sender, EventArgs e)
        {
            ZeichneFrame();
            BerechneFrame();
        }


        private void Star_Wars_Theme()
        {
            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(400, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(500, 150);//B
            Console.Beep(450, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(500, 150);//B
            Console.Beep(450, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(500, 150);//B
            Console.Beep(540, 150);//C
            Console.Beep(450, 1000);//A

            Thread.Sleep(1000);

            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(400, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(500, 150);//B
            Console.Beep(450, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(500, 150);//B
            Console.Beep(450, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(500, 150);//B
            Console.Beep(540, 150);//C
            Console.Beep(450, 1000);//A

            Thread.Sleep(500);

            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(350, 600);//E
            Console.Beep(350, 250);//E

            Console.Beep(700, 200);//C
            Console.Beep(600, 200);//B
            Console.Beep(500, 200);//A
            Console.Beep(400, 200);//G

            Console.Beep(400, 120);//G
            Console.Beep(500, 120);//A
            Console.Beep(600, 120);//B
            Console.Beep(500, 500);//A

            Console.Beep(350, 150);//E
            Console.Beep(400, 500);//F
            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D

            Console.Beep(350, 600);//E
            Console.Beep(350, 200);//E
            Console.Beep(700, 250);//C
            Console.Beep(600, 250);//B
            Console.Beep(500, 250);//A
            Console.Beep(400, 250);//G

            Console.Beep(800, 400);//D
            Console.Beep(200, 700);//A
            Thread.Sleep(200);
            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D






            Console.Beep(350, 600);//E
            Console.Beep(350, 250);//E

            Console.Beep(700, 200);//C
            Console.Beep(600, 200);//B
            Console.Beep(500, 200);//A
            Console.Beep(400, 200);//G

            Console.Beep(400, 120);//G
            Console.Beep(500, 120);//A
            Console.Beep(600, 120);//B
            Console.Beep(500, 500);//A

            Console.Beep(350, 150);//E
            Console.Beep(400, 700);//F
            Thread.Sleep(300);
            Console.Beep(600, 250);//D
            Console.Beep(600, 300);//D

            Console.Beep(800, 250);//G
            Console.Beep(700, 250);//F
            Console.Beep(600, 250);//E
            Console.Beep(500, 250);//D

            Console.Beep(400, 250);//C
            Console.Beep(300, 250);//B
            Console.Beep(200, 250);//A
            Console.Beep(100, 250);//G
            Thread.Sleep(300);

            Console.Beep(800, 1000);//D
            Thread.Sleep(1000);

            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(400, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(450, 150);//B
            Console.Beep(400, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(500, 150);//C
            Console.Beep(450, 150);//B
            Console.Beep(400, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(500, 160);//C
            Console.Beep(450, 160);//B
            Console.Beep(500, 160);//C
            Console.Beep(400, 1000);//A

            Thread.Sleep(1000);

            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(300, 150);//D
            Console.Beep(400, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(540, 150);//C
            Console.Beep(450, 150);//B
            Console.Beep(400, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(500, 150);//C
            Console.Beep(450, 150);//B
            Console.Beep(400, 150);//A
            Console.Beep(800, 900);//G
            Console.Beep(600, 900);//D

            Console.Beep(500, 160);//C
            Console.Beep(450, 160);//B
            Console.Beep(500, 160);//C
            Console.Beep(400, 1000);//A
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Star_Wars_Theme();
        }

        private void starte_Programm(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
