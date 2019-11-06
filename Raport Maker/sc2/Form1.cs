using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace sc2
{
    public partial class Form1 : Form
    {
        string[] FileList;
        string[] FileMonthNumber;
        string[] CorrectFileList;
        string name;
        string tt;
        int[] numery;
        int dlugosc;
        int a;
        int b;
        bool czynadpisac;
        bool fdocelowy = false;
        bool fzplikami = false;

        public Form1()
        {
            InitializeComponent();
        }

        //Button - ścieżka do odczytu plików
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                fzplikami = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przycisku!\n" + ex, "Raport Maker");
            }
        }

        //Button - ścieżka do zapisania pliku
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog2.ShowDialog();
                textBox2.Text = folderBrowserDialog2.SelectedPath;
                fdocelowy = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przycisku!\n" + ex, "Raport Maker");
            }
        }

        //Button - wykonanie raportu
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((fzplikami == false) || (fdocelowy == false)) MessageBox.Show("Wybierz katalog z plikami", "Raport Maker");
                else if((fzplikami == true) && (fdocelowy == true))
                {
                    radiobuttoncheck();
                    if (tt == null) MessageBox.Show("Wybierz miesiąc!", "Raport Maker");
                    else if (tt != null)
                    {
                        a = 0;
                        dlugosc = 0;
                        czynadpisac = false;
                        FileList = Directory.GetFiles(textBox1.Text, "*.txt").ToArray();
                        FileMonthNumber = new string[FileList.Length];
                        for (int i = 0; i < FileMonthNumber.Length; i++)
                        {
                            FileMonthNumber[i] = Path.GetFileNameWithoutExtension(FileList[i]);
                            FileMonthNumber[i] = FileMonthNumber[i].Remove(6);
                            FileMonthNumber[i] = FileMonthNumber[i].Remove(0, 4);
                        }
                        for (int i = 0; i < FileList.Length; i++)
                        {
                            if (FileMonthNumber[i] == tt) dlugosc++;
                        }
                        if ((dlugosc == 0)) MessageBox.Show("Brak plików!", "Raport Maker");
                        else if ((dlugosc != b) && (dlugosc != b + 1)) MessageBox.Show("Za mało plików z wybranego miesiąca\nIlość plików: " + dlugosc, "Raport Maker");
                        else if ((dlugosc == b) || (dlugosc == b + 1))
                        {
                            CorrectFileList = new string[dlugosc];
                            numery = new int[dlugosc];
                            for (int i = 0; i < FileMonthNumber.Length; i++)
                            {
                                if (FileMonthNumber[i] == tt)
                                {
                                    numery[a] = i;
                                    a++;
                                }
                            }
                            for (int i = 0; i < dlugosc; i++)
                            {
                                CorrectFileList[i] = FileList[numery[i]];
                            }
                            name = textBox2.Text + @"\raport " + tt + ".txt";
                            if (File.Exists(name))
                            {
                                DialogResult dr = MessageBox.Show("Raport już istnieje\nCzy chcesz go nadpisać?", "Raport Maker", MessageBoxButtons.YesNo);
                                switch (dr)
                                {
                                    case DialogResult.Yes:
                                        File.Delete(name);
                                        czynadpisac = true;
                                        break;
                                    case DialogResult.No:
                                        czynadpisac = false;
                                        break;
                                }
                            }
                            else if (!File.Exists(name)) czynadpisac = true;

                            if (czynadpisac == true)
                            {
                                scalanie();
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Wybierz katalog docelowy", "Raport Maker");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Wybierz katalog z plikami!", "Raport Maker");
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("W katalogu nie ma plików txt", "Raport Maker");
            }
            catch (Exception ex)
           {
                MessageBox.Show("Wystąpił błąd!!\n" + ex);
            }
        }

        //Szukanie znaku < i usuwanie wierszy
        private void szukanie(string word, int i)
        {
            //Wyświetlanie procentowego postępu progress bar
            progressBar1.Value = i;
            int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
            progressBar1.CreateGraphics().DrawString("Postęp: " + percent.ToString() + "%", new System.Drawing.Font("Arial", (float)8.25, System.Drawing.FontStyle.Regular), System.Drawing.Brushes.Black, new System.Drawing.PointF(progressBar1.Width / 2 - 30, progressBar1.Height / 2 - 7));

            //Analizowanie scalonego pliku w celu usuwania wierszy
            TextReader tr = new StreamReader(name);
            string poczytane = tr.ReadToEnd();
            tr.Close();
            TextWriter tw1 = new StreamWriter(name);

            if (poczytane.Contains(word))
            {
                int a = poczytane.IndexOf(word);
                string nowy;
                if (a == 0) nowy = poczytane.Remove(a, 41);
                else nowy = poczytane.Remove(a - 1, 42 + 123);
                tw1.Write(nowy);
            }
            tw1.Close();
            progressBar1.Refresh();
        }

        //Ustawianie miesiąca
        private void radiobuttoncheck()
        {
            if (radioButton1.Checked == true)
            {
                tt = "01";
                b = 31;
            }
            else if (radioButton2.Checked == true)
            {
                tt = "02";
                b = 28;
            }
            else if (radioButton3.Checked == true)
            {
                tt = "03";
                b = 31;
            }
            else if (radioButton4.Checked == true)
            {
                tt = "04";
                b = 30;
            }
            else if (radioButton5.Checked == true)
            {
                tt = "05";
                b = 31;
            }
            else if (radioButton6.Checked == true)
            {
                tt = "06";
                b = 30;
            }
            else if (radioButton7.Checked == true)
            {
                tt = "07";
                b = 31;
            }
            else if (radioButton8.Checked == true)
            {
                tt = "08";
                b = 31;
            }
            else if (radioButton9.Checked == true)
            {
                tt = "09";
                b = 30;
            }
            else if (radioButton10.Checked == true)
            {
                tt = "10";
                b = 31;
            }
            else if (radioButton11.Checked == true)
            {
                tt = "11";
                b = 30;
            }
            else if (radioButton12.Checked == true)
            {
                tt = "12";
                b = 31;
            }
        }

        //Scalanie plików w jeden plik
        private void scalanie()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int nCount = 0; nCount < CorrectFileList.Length; nCount++)
            {
                sb.AppendLine(System.IO.File.ReadAllText(CorrectFileList[nCount]));
            }
            string output = sb.ToString();
            File.WriteAllText(name, output);
            string word = "<";
            progressBar1.Minimum = 0;
            progressBar1.Maximum = CorrectFileList.Length - 1;
            //Szukanie znaku < i usuwanie wierszy
            for (int i = 0; i < CorrectFileList.Length; i++)
            {
                szukanie(word, i);
            }
            MessageBox.Show("Utworzono plik " + name);
            progressBar1.Value = 0;
            czynadpisac = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor:\tPatryk Szumielewicz\nNumer:\t797578683\nE-mail:\tszumielewiczpatryk@gmail.com\nWersja:\t" + Application.ProductVersion, "Raport Maker");
        }
    }
}