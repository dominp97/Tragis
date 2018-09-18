using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traguis
{
    public partial class Form2 : Form
    {

        Bitmap img1 = new Bitmap(Properties.Resources.yeguaG);
        Bitmap img2 = new Bitmap(Properties.Resources.b2);
        Bitmap img3 = new Bitmap(Properties.Resources.b3);
        Bitmap img4 = new Bitmap(Properties.Resources.b4);
        Bitmap img5 = new Bitmap(Properties.Resources.b5);
        Bitmap img6 = new Bitmap(Properties.Resources.b6);
        Bitmap img7 = new Bitmap(Properties.Resources.b7);

        int monedas, bonos, partidaEspacial, dificultad;
        Boolean musica;
        public Form2(int monedas, int bonos)
        {
            InitializeComponent();
            this.monedas = monedas;
            this.bonos = bonos;
            partidaEspacial = 0;
            dificultad = 2;
            actualizarDatos();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            sonidico.Stop();
            Traguis formul = new Traguis(monedas, bonos);
            formul.Show();
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
                case 6: return img6;
                case 0: return img7;
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(bonos > 0 && monedas > 0)
            {
                monedas--;
                bonos--;
                button2.Enabled = false;
                try
                {
                    actualizarDatos();
                    CheckForIllegalCrossThreadCalls = false;
                    ThreadStart hiloCam = new ThreadStart(hiloCambiante);
                    Thread hilico5 = new Thread(hiloCam);
                    hilico5.IsBackground = true;
                    hilico5.Start();
                }
                catch (Exception) { }
            }
        }


        private void hiloCambiante()
        {
            for(int i = 0; i < 10; i++)
            {
                try
                {
                    cambiarImg();
                    duermete();
                }
                catch(Exception e) { }
                
            }

            compGanar();

            actualizarDatos();

            button2.Enabled = true;
        }

        private void duermete()
        {
            Thread.Sleep(50);
        }

        private void miniSiesta()
        {
            Thread.Sleep(5);
        }

        int n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15;
        Boolean continuar = true;

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            continuar = false;
            button6.Enabled = true;
            button2.Enabled = true;
            musica = false;
            sonidico.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button6.Enabled = false;
            button2.Enabled = false;
            musica = true;

            //musica 

            CheckForIllegalCrossThreadCalls = false;
            ThreadStart musiquilla = new ThreadStart(sonar);
            Thread hMusica = new Thread(musiquilla);
            hMusica.IsBackground = true;
            hMusica.Start();

            //hilo de repeticion

            continuar = true;
            CheckForIllegalCrossThreadCalls = false;
            ThreadStart hiloMotion = new ThreadStart(autoMotion);
            Thread hilico6 = new Thread(hiloMotion);
            hilico6.IsBackground = true;
            hilico6.Start();
        }

        private void autoMotion()
        {
            while (monedas > 0 && continuar == true && bonos > 0)
            {
                monedas--;
                bonos--;

                try
                {
                    actualizarDatos();
                    CheckForIllegalCrossThreadCalls = false;
                    ThreadStart hiloCam = new ThreadStart(hiloCambiante);
                    Thread hilico5 = new Thread(hiloCam);
                    hilico5.Start();
                }
                catch (Exception) { }

                Thread.Sleep(3000);
                
            }
            musica = false;
            sonidico.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dificultad <= 5)
            {
                dificultad++;
            }
            actualizarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dificultad >= 3){
                dificultad--;
            }

            actualizarDatos();
        }

        private void cambiarImg()
        {
            n1 = aleatorioInt();
            pictureBox1.Image = seleccionaCaso(n1);
            miniSiesta();
            
            n2 = aleatorioInt();
            pictureBox2.Image = seleccionaCaso(n2);
            miniSiesta();
            
            n3 = aleatorioInt();
            pictureBox3.Image = seleccionaCaso(n3);
            miniSiesta();
            
            n4 = aleatorioInt();
            pictureBox4.Image = seleccionaCaso(n4);
            miniSiesta();
            
            n5 = aleatorioInt();
            pictureBox5.Image = seleccionaCaso(n5);
            miniSiesta();
            
            n6 = aleatorioInt();
            pictureBox6.Image = seleccionaCaso(n6);
            miniSiesta();
            
            n7 = aleatorioInt();
            pictureBox7.Image = seleccionaCaso(n7);
            miniSiesta();
            n8 = aleatorioInt();
            pictureBox8.Image = seleccionaCaso(n8);
            miniSiesta();
            n9 = aleatorioInt();
            pictureBox9.Image = seleccionaCaso(n9);
            miniSiesta();
            n10 = aleatorioInt();
            pictureBox10.Image = seleccionaCaso(n10);
            miniSiesta();
            n11 = aleatorioInt();
            pictureBox11.Image = seleccionaCaso(n11);
            miniSiesta();
            n12 = aleatorioInt();
            pictureBox12.Image = seleccionaCaso(n12);
            miniSiesta();
            n13 = aleatorioInt();
            pictureBox13.Image = seleccionaCaso(n13);
            miniSiesta();
            n14 = aleatorioInt();
            pictureBox14.Image = seleccionaCaso(n14);
            miniSiesta();
            n15 = aleatorioInt();
            pictureBox15.Image = seleccionaCaso(n15);

           

        }

        private int aleatorioInt()
        {
            Random rand = new Random();
            return rand.Next(0, dificultad);
            
        }

        private void compGanar()
        {
            if(((n1 == n2)&&(n2 == n3)))
            {
                monedas = monedas + (15 * dificultad);
                
            }
            if (((n4 == n5) && (n5 == n6)))
            {

                monedas = monedas + (15 * dificultad);
            }

            if (((n7 == n8) && (n8 == n9)))
            {

                monedas = monedas + (15 * dificultad);
            }
            if (((n10 == n11) && (n11 == n12)))
            {

                monedas = monedas + (15 * dificultad);
            }
            if (((n13 == n14) && (n14 == n15)))
            {

                monedas = monedas + (15 * dificultad);
            }


            if(n1 == n4 && n4 == n7 && n7 == n10 && n10 == n13)
            {
                
                partidaEspacial++;
            }
            if (n2 == n5 && n5 == n8 && n8 == n11 && n11 == n14)
            {
                
                partidaEspacial++;
            }
            if (n3 == n6 && n6 == n9 && n9 == n12 && n12 == n15)
            {
                
                partidaEspacial++;
            }
            textBox2.Text = "Monedas : " + monedas.ToString();
            textBox3.Text = "Tirada especial : " + partidaEspacial;
        }

        private void actualizarDatos()
        {
            textBox1.Text = "Bonos : " + bonos.ToString();
            textBox2.Text = "Monedas : " + monedas.ToString();
            textBox3.Text = "Tirada especial : " + partidaEspacial.ToString();

            switch (dificultad)
            {
                case 2: pictureBox16.Show();
                    pictureBox17.Hide();
                    pictureBox18.Hide();
                    pictureBox19.Hide();
                    pictureBox20.Hide();
                    break;
                case 3:
                    pictureBox16.Show();
                    pictureBox17.Show();
                    pictureBox18.Hide();
                    pictureBox19.Hide();
                    pictureBox20.Hide();
                    break;
                case 4:
                    pictureBox16.Show();
                    pictureBox17.Show();
                    pictureBox18.Show();
                    pictureBox19.Hide();
                    pictureBox20.Hide();
                    break;
                case 5:
                    pictureBox16.Show();
                    pictureBox17.Show();
                    pictureBox18.Show();
                    pictureBox19.Show();
                    pictureBox20.Hide();
                    break;
                case 6:
                    pictureBox16.Show();
                    pictureBox17.Show();
                    pictureBox18.Show();
                    pictureBox19.Show();
                    pictureBox20.Show();
                    break;
            }
        }

        SoundPlayer sonidico = new SoundPlayer(Application.StartupPath + @"\son\yeguaGris.wav");

        private void sonar()
        {
            if (musica)
            {
                try
                {
                    
                    sonidico.PlayLooping();
                    
                }
                catch (System.IO.FileNotFoundException)
                {

                }
            }
            

        }


    }
}
