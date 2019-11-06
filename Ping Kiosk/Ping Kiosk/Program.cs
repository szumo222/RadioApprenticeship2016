using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;

namespace Ping_Kiosk
{
    class Program
    {
        static string s;
        static PingReply r;
        static Ping p = new Ping();
        static int i = 0;
        static int j = 0;
        static Process[] AllProcesses = Process.GetProcesses();

        static void pingg()
        {
            Thread.Sleep(1000);
            r = p.Send(s);
            if (r.Status == IPStatus.Success)
            {
                Console.WriteLine("Reply from " + s.ToString() + " " + r.Address.ToString() + " Successful Response delay = " + r.RoundtripTime.ToString() + " ms");
                j = j - 1;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Name:\t\t\tPing Kiosk\nAuthor:\t\t\tPatryk Szumielewicz\nE-mail:\t\t\tszumielewiczpatryk@gmail.com\nContact number:\t\t797578683\n");
            Thread.Sleep(1000);
            int counter = 0;
            string line;
            string[] tab = new string[12];
            string a;
            string b;
            string c;
            int height;
            int width;
            try {
                System.IO.StreamReader file = new System.IO.StreamReader(@"config.txt");
                while ((line = file.ReadLine()) != null)
                {
                    tab[counter] = line;
                    counter++;
                }
                a = tab[1];
                b = tab[3];
                c = tab[5];
                s = tab[11];
                height = int.Parse(tab[7]);
                width = int.Parse(tab[9]);
                Console.SetWindowSize(width, height);
                for (i = 0; i < 10; i++)
                {
                    try
                    {
                        pingg();
                        if (i == 9)
                        {
                            foreach (var process in Process.GetProcessesByName("iexplore"))
                            {
                                process.Kill();
                            }
                            Process.Start(a, b);
                        }
                    }
                    catch (PingException ex)
                    {
                        i = 0;
                        j++;
                        Console.WriteLine("No internet connection!");
                        if ((j == 9)) Process.Start(@"iexplore", c);

                    }
                    catch (System.InvalidOperationException ex)
                    {
                        Console.WriteLine("\nInvalid config file\nIn order to close application press any key...");
                        Console.ReadKey();
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Can't find config file!\nIn order to close application press any key...");
                Console.ReadKey();
            }
        }
    }
}