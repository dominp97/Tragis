using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Traguis
{
    public partial class Traguis : Form
    {
        
        Bitmap img1 = new Bitmap(Properties.Resources.t1);
        Bitmap img2 = new Bitmap(Properties.Resources.t2);
        Bitmap img3 = new Bitmap(Properties.Resources.t3);
        Bitmap img4 = new Bitmap(Properties.Resources.t4);
        Bitmap img5 = new Bitmap(Properties.Resources.t5);
        Bitmap img6 = new Bitmap(Properties.Resources.t6);

        Random rand = new Random();

        int apuesta;
        int bonos;

        public Traguis(int fichas, int bonos)
        {
            InitializeComponent();
            this.fichas = fichas;
            textBox2.Text = fichas.ToString();
            apuesta = 1;
            this.bonos = bonos;
            contarAvances = 0;
            button7.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
        }

        public Traguis()
        {
            InitializeComponent();
            fichas = 10;
            textBox2.Text = fichas.ToString();
            apuesta = 1;
            bonos = 0;
            button6.Enabled = false;
            contarAvances = 0;
            button7.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
        }

        int fichas;

        int contarAvances;
        private void button1_Click(object sender, EventArgs e)
        {
            contarAvances++;
            button1.Enabled = false;
            if ((fichas - apuesta) >= 0)
            {
                CheckForIllegalCrossThreadCalls = false;
                ThreadStart musiquilla = new ThreadStart(sonar);
                Thread hMusica = new Thread(musiquilla);
                hMusica.Start();

                try
                {
                    CheckForIllegalCrossThreadCalls = false;
                    ThreadStart opciones1 = new ThreadStart(cambiarImagenVector1);
                    Thread hilico1 = new Thread(opciones1);
                    hilico1.Start();
                }
                catch (Exception) { }
                
                try
                {
                    CheckForIllegalCrossThreadCalls = false;
                    ThreadStart opciones2 = new ThreadStart(cambiarImagenVector2);
                    Thread hilico2 = new Thread(opciones2);
                    hilico2.Start();
                }
                catch (Exception) { }
                
                try
                {
                    CheckForIllegalCrossThreadCalls = false;
                    ThreadStart opciones3 = new ThreadStart(cambiarImagenVector3);
                    Thread hilico3 = new Thread(opciones3);
                    hilico3.Start();
                }
                catch (Exception) { }

                try
                {
                    CheckForIllegalCrossThreadCalls = false;
                    ThreadStart compG = new ThreadStart(esperarComprobarGanar);
                    Thread hilico4 = new Thread(compG);
                    hilico4.Start();
                }
                catch (Exception) { }


                fichas -=apuesta;
                textBox2.Text = fichas.ToString();
                textBox6.Text = "Bonos : " + bonos;

                if(contarAvances == 5)
                {
                    try
                    {
                        CheckForIllegalCrossThreadCalls = false;
                        ThreadStart compA = new ThreadStart(avanzadin);
                        Thread hilicoAvanzado = new Thread(compA);
                        hilicoAvanzado.Start();
                    }
                    catch (Exception) { }

                }
                
            }
            else
            {
                textBox1.Text = "Mete mas dinero ";
            }

            

        }

        private void avanzadin()
        {
            contarAvances = rand.Next(0, 5);
            while (contarAvances >= 1)
            {
                
                textBox1.Text = "Tienes : " + contarAvances + " avances.";
                button7.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = false;
                //randomNumber--;
                //comprobarGanar(temp1, temp2, temp3);
            }
            contarAvances = 0;
            button7.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
        }

        private void esperarComprobarGanar()
        {
            Thread.Sleep(1000);
            comprobarGanar(res1, res2, res3);
            textBox1.Text = res1.ToString() + res2.ToString() + res3.ToString();
            Thread.Sleep(2000);
            button1.Enabled = true;

        }


        private void sonar()
        {
            try
            {
                SoundPlayer sonidico = new SoundPlayer(Application.StartupPath + @"\son\papapa.wav");
                sonidico.Play();
            }
            catch (System.IO.FileNotFoundException)
            {

            }
        }
        

       

        private void duermete()
        {
            Thread.Sleep(100);
        }
        
        private Bitmap seleccionaCaso(int num)
        {
            switch (num)
            {
                case 1: return img1;
                case 2: return img2;
                case 3: return img3;
                case 4: return img4;
                case 5: return img5;
                case 0: return img6;
            }
            return null;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            fichas += 10;
            textBox2.Text = fichas.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temp2++;
            temp2 = temp2 % 6;
            try
            {
                pictureBox2.Image = seleccionaCaso(temp2);
            }
            catch (Exception) { }
            contarAvances--;
            comprobarGanar(temp1, temp2, temp3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (apuesta < 3)
            {
                apuesta++;
                if(apuesta == 2)
                {
                    textBox5.ForeColor = System.Drawing.Color.Black;
                    textBox4.ForeColor = System.Drawing.Color.Lime;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    textBox5.ForeColor = System.Drawing.Color.Black;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                    textBox3.ForeColor = System.Drawing.Color.Lime;
                }
            }
            else
            {
                apuesta = 1;
                textBox5.ForeColor = System.Drawing.Color.Lime;
                textBox4.ForeColor = System.Drawing.Color.Black;
                textBox3.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temp3++;
            temp3 = temp3 % 6;
            try
            {
                pictureBox3.Image = seleccionaCaso(temp3);
            }
            catch (Exception) { }
            contarAvances--;
            comprobarGanar(temp1, temp2, temp3);
        }

        private void comprobarGanar(int num1, int num2, int num3)
        {
            if (num1.Equals(num2)&& num1.Equals(num3))
            {
                switch (num1)
                {
                    case 1: fichas += (100*apuesta);
                        textBox1.Text = "Has ganado 100 monedas";
                        break;
                    case 2: fichas += (200*apuesta);
                        textBox1.Text = "Has ganado 200 monedas";
                        break;
                    case 3: fichas += (300*apuesta);
                        textBox1.Text = "Has ganado 300 monedas";
                        break;
                    case 4: fichas += (400*apuesta);
                        textBox1.Text = "Has ganado 400 monedas";
                        break;
                    case 5: fichas += (500*apuesta);
                        textBox1.Text = "Has ganado 500 monedas";
                        break;
                    case 0: fichas += (600*apuesta);
                        textBox1.Text = "Has ganado 600 monedas";
                        break;
                }
                textBox2.Text = fichas.ToString();
            }
            if(num1 <= 0 || num2 <= 0 || num3 <= 0)
            {
                bonos += (2 * apuesta);
            }
            textBox6.Text = "Bonos : " + bonos;
            if (bonos > 0)
            {
                button6.Enabled = true;
            }
        }

        int res1 = 9, res2 = 9, res3 = 9;

        int temp1;
        private void cambiarImagenVector1()
        {
            int randomNumber = rand.Next(30, 40);
            if (res1 != 9 && res1 != 0)
            {
                res1 = rand.Next(1, 6);
                randomNumber = res1 * 6;
            }
            CheckForIllegalCrossThreadCalls = false;
            
            res1 = randomNumber % 6;
            int posVector = 0;
            for (int i = res1; i <= randomNumber; i++)
            {
                posVector++;
                posVector = i % 6;
                /*
                if (posVector >= imagenes.Length-1)
                {
                    posVector = 0;
                }
                */
                try
                {
                    pictureBox1.Image = seleccionaCaso(posVector);
                }
                catch (Exception) { }
                duermete();
            }
            temp1 = posVector;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 formul = new Form2(fichas, bonos);
            formul.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            temp1++;
            temp1 = temp1 % 6;
            try
            {
                pictureBox1.Image = seleccionaCaso(temp1);
            }
            catch (Exception) { }

            contarAvances--;
            comprobarGanar(temp1, temp2, temp3);
        }
        
        private void cambiarImagenVector2()
        {
            int randomNumber = rand.Next(40, 50);
            if (res2 != 9 && res2 != 0)
            {
                res2 = rand.Next(1, 6);
                randomNumber = res2 * 8;
            }
            
            int posVector = 0;
            res2 = randomNumber % 6;
            for (int i = res2; i <= randomNumber; i++)
            {
                posVector++;

                posVector = i % 6;
                /*
                if (posVector >= imagenes.Length-1)
                {
                    posVector = 0;
                }
                */

                try
                {
                    pictureBox2.Image = seleccionaCaso(posVector);
                }
                catch (Exception) { }
                duermete();
            }
            temp2 = posVector;
            
        }
        int temp2;

        private void cambiarImagenVector3()
        {
            int randomNumber = rand.Next(50, 60);
            if (res3 != 9 && res3 != 0)
            {
                res3 = rand.Next(1, 6);
                randomNumber = res3 * 10;
            }
            
            int posVector = 0;
            res3 = randomNumber % 6;
            for (int i = res3; i <= randomNumber; i++)
            {
                posVector++;

                posVector = i % 6;
                /*
                if (posVector >= imagenes.Length-1)
                {
                    posVector = 0;
                }
                */

                try
                {
                    pictureBox3.Image = seleccionaCaso(posVector);
                }
                catch (Exception) { }
                
                duermete();
            }
            temp3 = posVector;
           
        }
        int temp3;
    }
}
