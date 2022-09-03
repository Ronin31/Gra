using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Na_przyciskach
{

    public partial class Form1 : Form
    {
        int[] tablica = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int gracz1 = 1;
        int gracz2 = 2;
        int wysylacz = 9;
        int k = 0;
        int odbierz = 9;
        public Form1()
        {
            InitializeComponent();
        }


        void New()
        {
            tablica = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            button1.BackgroundImage = null;
            button2.BackgroundImage = null;
            button3.BackgroundImage = null;
            button4.BackgroundImage = null;
            button5.BackgroundImage = null;
            button6.BackgroundImage = null;
            button7.BackgroundImage = null;
            button8.BackgroundImage = null;
            button9.BackgroundImage = null;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

        }



        public int Sprawdzanie()
        {

            //button1.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            if ((tablica[0] == 1 && tablica[1] == 1 && tablica[2] == 1) || (tablica[5] == 1 && tablica[4] == 1 && tablica[3] == 1) || (tablica[8] == 1 && tablica[7] == 1 && tablica[6] == 1) || (tablica[0] == 1 && tablica[5] == 1 && tablica[8] == 1) || tablica[1] == 1 && tablica[4] == 1 && tablica[7] == 1 || (tablica[2] == 1 && tablica[3] == 1 && tablica[6] == 1) || (tablica[0] == 1 && tablica[4] == 1 && tablica[6] == 1) || (tablica[2] == 1 && tablica[4] == 1 && tablica[8] == 1))
            {
                int k;
                // Console.WriteLine("Wygral gracz 1");
                MessageBox.Show("Gracz 1", "Wygrałeś");
                var result = MessageBox.Show("Chcesz zaczać nową grę?",
                                             "Gracz 1",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    New();

                }

                if (result == DialogResult.No)
                {
                    //System.Environment.Exit(1);
                    k = 5;
                    return k;
                }



            }


            if ((tablica[0] == 2 && tablica[1] == 2 && tablica[2] == 2) || (tablica[5] == 2 && tablica[4] == 2 && tablica[3] == 2) || (tablica[8] == 2 && tablica[7] == 2 && tablica[6] == 2) || (tablica[0] == 2 && tablica[5] == 2 && tablica[8] == 2) || tablica[1] == 2 && tablica[4] == 2 && tablica[7] == 2 || (tablica[2] == 2 && tablica[3] == 2 && tablica[6] == 2) || (tablica[0] == 2 && tablica[4] == 2 && tablica[6] == 2) || (tablica[2] == 2 && tablica[4] == 2 && tablica[8] == 2))
            {
                int k;
                //Console.WriteLine("Wygral gracz 2");
                MessageBox.Show("Gracz 1", "Przegrałeś");
                var result = MessageBox.Show("Chcesz zaczać nową grę?",
                                             "Gracz 1",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    New();
                }
                if (result == DialogResult.No)
                {
                    //System.Environment.Exit(1);
                    k = 5;
                    return k;
                }

            }

            else
                 if ((tablica[0] == 1 || tablica[0] == 2) && (tablica[1] == 1 || tablica[1] == 2) && (tablica[2] == 1 || tablica[2] == 2) && (tablica[3] == 1 || tablica[3] == 2) && (tablica[4] == 1 || tablica[4] == 2) && (tablica[5] == 1 || tablica[5] == 2) && (tablica[6] == 1 || tablica[6] == 2) && (tablica[7] == 1 || tablica[7] == 2) && (tablica[8] == 1 || tablica[8] == 2))
            {
                MessageBox.Show("Remis! ");
                var result1 = MessageBox.Show("Chcesz zaczać nową grę?",
                                                             "Gracz 1",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    New();

                }

                if (result1 == DialogResult.No)
                {
                    //System.Environment.Exit(1);
                    k = 5;
                    return k;

                }
            }
            return 0;

        }



        public void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button1.Enabled = false;
            tablica[0] = gracz1;

            label1.Hide();
            Console.WriteLine(Convert.ToString(tablica[0]));
            wysylacz = 0;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
           {
                System.Environment.Exit(1);
            }
            
            
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }

        }

        public void button2_Click(object sender, EventArgs e)
        {
            button2.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button2.Enabled = false;
            tablica[1] = gracz1;
            Console.WriteLine(Convert.ToString(tablica[0]) + Convert.ToString(tablica[1] ));
            wysylacz = 1;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button3.Enabled = false;
            tablica[2] = gracz1;
            wysylacz = 2;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
           
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button6.Enabled = false;
            tablica[5] = gracz1;
            wysylacz = 5;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button4.Enabled = false;
            tablica[3] = gracz1;
            wysylacz = 3;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            
            odbierz = odbieranie();

            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button5.Enabled = false;
            tablica[4] = gracz1;
            wysylacz = 4;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
           
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button7.Enabled = false;
            tablica[6] = gracz1;
            wysylacz = 6;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button8.Enabled = false;
            tablica[7] = gracz1;
            wysylacz = 7;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.BackgroundImage = Na_przyciskach.Properties.Resources.Krzyzyk;
            button9.Enabled = false;
            tablica[8] = gracz1;
            wysylacz = 8;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            
            odbierz = odbieranie();
            F();
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
        }
      public void F()
        {
            label1.Show();
                if (odbierz == 0)
                {
                    button1.Enabled = false;
                    tablica[0] = gracz2;
                button1.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            }
                else
            if (odbierz == 1)
            {
                button2.Enabled = false;
                tablica[1] = gracz2;
                button2.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            } else
            if (odbierz == 2)
            {
                button3.Enabled = false;
                tablica[2] = gracz2;
                button3.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            } else
            if (odbierz == 3)
            {
                button4.Enabled = false;
                tablica[3] = gracz2;
                button4.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            } else
            if (odbierz == 4)
            {
                button5.Enabled = false;
                tablica[4] = gracz2;
                button5.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            } else
            if (odbierz == 5)
            {
                button6.Enabled = false;
                tablica[5] = gracz2;
                button6.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            } else
            if (odbierz == 6)
            {
                button7.Enabled = false;
                tablica[6] = gracz2;
                button7.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            } else
            if (odbierz == 7)
            {
                button8.Enabled = false;
                tablica[7] = gracz2;
                button8.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            }
            else
            if (odbierz == 8)
            {
                button9.Enabled = false;
                tablica[8] = gracz2;
                button9.BackgroundImage = Na_przyciskach.Properties.Resources.Kolko;
            }
        }
        public void nadawanie(int wysylacz)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1200);
            Console.WriteLine("[Try to connect to server...]");
            NetworkStream n = client.GetStream();
            Console.WriteLine("[Connected]");
            string ch = Convert.ToString(wysylacz);
            byte[] message = Encoding.Unicode.GetBytes(ch);
            n.Write(message, 0, message.Length);
            Console.WriteLine("-----Sent-----");
            client.Close();
        }

        public int odbieranie()
        {
            TcpListener listen = new TcpListener(IPAddress.Any, 1201);
            Console.WriteLine("[Listenning...]");
            listen.Start();
            TcpClient client1 = listen.AcceptTcpClient();
            Console.WriteLine("[Client connected]");
            NetworkStream steam = client1.GetStream();
            byte[] buffer = new byte[client1.ReceiveBufferSize];
            int data = steam.Read(buffer, 0, client1.ReceiveBufferSize);
            string ch1 = Encoding.Unicode.GetString(buffer, 0, data);
            Console.WriteLine("Message recivied:" + ch1);

                listen.Stop();

            odbierz=Convert.ToInt32(ch1);
            return odbierz;
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            
                odbierz = odbieranie();

                F();

        }
        

    }
}
