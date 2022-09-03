// Z uwagi na to, że oba programy działają na tej samej zasadzie - naprzemiennego wysyłania danych, opisany zostanie tylko jeden program. Początkowo zdefiniowane zostały biblioteki wykorzystane w programie.
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

namespace serwer_przyciski
{
    public partial class Form1 : Form
    {
        
        int[] tablica = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // Tworzymy tablicę o wymiarze 9, wypełnioną zerami. Do tej tablicy beda zapisywane wartości, jeśli ktoś posawił znak na danym polu
        int gracz2 = 1; // Dla gracza 2 mamy liczbę 1, a dla gracza 1 mamy liczbę 2. Dodatkowo deklarujemy zmienne przydatne w dalszej części kodu
        int gracz1 = 2;
        int wysylacz = 9; //wartość którą wysyłamy do drugioego gracza. Na jej podstawie u drugiego gracza zapisyuwane jest gdzie przeciwnik posawil swój znak 
        int k = 0;

        int odbierz = 9; //wartość odebrana od drugiego gracza. Początkowo wynosi 9 bo nic nie odebraliśmy 
        public Form1()
        {
            InitializeComponent(); // Inicjalizujemy komponenty

        }


        void New() 
        {
            // Funkcja do resetu gry. Ustawiamy wszystkie wartości w tablicy na 0. Usuwamy ponadto obrazki i odblokowujemy wszystkie przyciski. 
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

        public int  Sprawdzanie()
        {
            // Funkcja sprawdzenie sprawdza czy gracz wygrał po wszystkich kombinacjach w tablicy (gracz 2 = 1, gracz 1 = 2). W momencie wygranej wypisuje wiadomość "wygrałeś" lub w przypadku przegranej - "przegrałeś.
            // Dodatkowo pyta nas czy chcemy zacząć grę od nowa. Jeżeli nie - przekazujemy wartość zmiennej do zamknięcia, jeżeli tak, wywołujemy funkcję New().
            
            if ((tablica[0] == 1 && tablica[1] == 1 && tablica[2] == 1) || (tablica[5] == 1 && tablica[4] == 1 && tablica[3] == 1) || (tablica[8] == 1 && tablica[7] == 1 && tablica[6] == 1) || (tablica[0] == 1 && tablica[5] == 1 && tablica[8] == 1) || tablica[1] == 1 && tablica[4] == 1 && tablica[7] == 1 || (tablica[2] == 1 && tablica[3] == 1 && tablica[6] == 1) || (tablica[0] == 1 && tablica[4] == 1 && tablica[6] == 1) || (tablica[2] == 1 && tablica[4] == 1 && tablica[8] == 1))
            {
                int k;
                // Console.WriteLine("Wygral gracz 1");
                MessageBox.Show("Gracz 2", "Przegrałeś");
                var result = MessageBox.Show("Chcesz zaczać nową grę?",
                                             "Gracz 2",
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



                return 0;
            }
           

            if ((tablica[0] == 2 && tablica[1] == 2 && tablica[2] == 2) || (tablica[5] == 2 && tablica[4] == 2 && tablica[3] == 2) || (tablica[8] == 2 && tablica[7] == 2 && tablica[6] == 2) || (tablica[0] == 2 && tablica[5] == 2 && tablica[8] == 2) || tablica[1] == 2 && tablica[4] == 2 && tablica[7] == 2 || (tablica[2] == 2 && tablica[3] == 2 && tablica[6] == 2) || (tablica[0] == 2 && tablica[4] == 2 && tablica[6] == 2) || (tablica[2] == 2 && tablica[4] == 2 && tablica[8] == 2))
            {
                int k;
                //Console.WriteLine("Wygral gracz 2");
                MessageBox.Show("Gracz 2", "Wygrałeś");
                var result = MessageBox.Show("Chcesz zaczać nową grę?",
                                             "Gracz 2",
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

            if ((tablica[0] == 1 || tablica[0] == 2) && (tablica[1] == 1 || tablica[1] == 2) && (tablica[2] == 1 || tablica[2] == 2) && (tablica[3] == 1 || tablica[3] == 2) && (tablica[4] == 1 || tablica[4] == 2) && (tablica[5] == 1 || tablica[5] == 2) && (tablica[6] == 1 || tablica[6] == 2) && (tablica[7] == 1 || tablica[7] == 2) && (tablica[8] == 1 || tablica[8] == 2))
            {
                // W momencie wystąpienia remisu wyświetla się komunikat o remisie i pytaniu czy chcemy zacząć nową grę. Jeżeli tak, wywoływana jest funkcja New().
                MessageBox.Show("Remis! ");
                var result1 = MessageBox.Show("Chcesz zaczać nową grę?",
                                                             "Gracz 2",
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



        

        // Z uwagi na identyczne działanie każdej funkcji związanej z przyciskiem, opiszemy tylko jedną.
        // W momencie wykrycia kliknięcia wstawiamy zdjęcie (w tym przypadku kółko), uniemożliwiamy ponownie kliknięcie w dany punkt, ukrywamy napis "Twój ruch", nadajemy wiadomość do drugiego użytkownika,
        // sprawdzamy czy należy zrestartować grę (wartość k=5 z funkcji). Następnie odbieramy  wartość od drugiego gracza i znowu sprawdzamy czy ktoś wygrał. Jeżeli tak, to wyświetlamy odpowiedni komunikat.
        public void button1_Click(object sender, EventArgs e)
            {
            
                
                button1.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
                int k=0;
            button1.Enabled = false;
                tablica[0] = gracz1;
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
            button2.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;

                button2.Enabled = false;
                tablica[1] = gracz1;
                
                wysylacz = 1;
            label1.Hide();
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            //nadawanie(wysylacz);
            
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
            button3.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
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
            button6.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
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
            button4.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
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
            button5.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
            button5.Enabled = false;
                tablica[4] = gracz1;
            label1.Hide();
            wysylacz = 4;
            nadawanie(wysylacz);
            k = Sprawdzanie();
            
            if (k == 5)
            {
                System.Environment.Exit(1);
            }
            ;
            
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
            button7.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
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
            button8.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
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
            button9.BackgroundImage = serwer_przyciski.Properties.Resources.Kolko;
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
        // Funkcja F() służy do interpretacji wartości od drugiego gracza. W danym polu dodajemy obrazek "Krzyżyk", a także uniemożliwiamy kliknięcie w to miejsce i zmieniamy wartość tablicy. 
            public void F()
            {
                label1.Show();
                if (odbierz == 0)
                {
                    button1.Enabled = false;
                    tablica[0] = gracz2;
                    button1.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
                    
            }
                else
            if (odbierz == 1)
                {
                    button2.Enabled = false;
                    tablica[1] = gracz2;
                    button2.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            } else
                if (odbierz == 2)
                {
                    button3.Enabled = false;
                    tablica[2] = gracz2;
                    button3.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            }
                else
                if (odbierz == 3)
                {
                    button4.Enabled = false;
                    tablica[3] = gracz2;
                    button4.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            }
                else
                if (odbierz == 4)
                {
                    button5.Enabled = false;
                    tablica[4] = gracz2;
                    button5.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            }
                else
                if (odbierz == 5)
                {
                    button6.Enabled = false;
                    tablica[5] = gracz2;
                    button6.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            }
                else
                if (odbierz == 6)
                {
                    button7.Enabled = false;
                    tablica[6] = gracz2;
                    button7.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            }
                else
                if (odbierz == 7)
                {
                    button8.Enabled = false;
                    tablica[7] = gracz2;
                    button8.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            }
                else
                if (odbierz == 8)
                {
                    button9.Enabled = false;
                    tablica[8] = gracz2;
                    button9.BackgroundImage = serwer_przyciski.Properties.Resources.Krzyzyk;
            }
            }
        // Funkcja nadawanie służy do nawiązania połączenia z drugim użytkownikiem, a następnie wysłania krótkiej zmiennej, która poinformuje o tym, które pole kliknął drugi gracz.
        // Na potrzeby wysłania potrzebna była konwersja wiadomości na inny format. Użyliśmy do tego funkcji Convert.To...
            public void nadawanie(int wysylacz)
            {
                TcpClient client = new TcpClient("127.0.0.1", 1201);
                Console.WriteLine("[Try to connect to server...]");
                NetworkStream n = client.GetStream();
                Console.WriteLine("[Connected]");
                string ch = Convert.ToString(wysylacz);
                byte[] message = Encoding.Unicode.GetBytes(ch);
                n.Write(message, 0, message.Length);
                Console.WriteLine("-----Sent-----");
                client.Close();

            }
            // Funkcja odebranie służy do nawiązania połączenia na danym porcie z drugim komputerem. Nasłuchujemy, aż drugi użytkownik wyśle nam odpowiednią wartość, którą jest zmienna omówiona powyżej.
            // Na początku musimy rozpocząć nasłuchiwanie, a na końcu musimy zakończyć połączenie "listen.Stop()", aby drugi użytkownik mógł się połączyć.
            public int odbieranie()
            {
                TcpListener listen = new TcpListener(IPAddress.Any, 1200);
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

                odbierz = Convert.ToInt32(ch1);
                return odbierz;
            }

            private void Form1_Load(object sender, EventArgs e)
            {


                if (wysylacz > -1 && wysylacz < 9)
                {
                    odbierz = odbieranie();

                    F();
                }



            }


    }
}
