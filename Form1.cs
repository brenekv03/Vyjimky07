using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vyjimky07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dnes = DateTime.Today;
            MessageBox.Show(dnes.ToString());
            try
            {
                using (StreamReader sr = new StreamReader("Osoby.txt"))
                {
                    while(!sr.EndOfStream)
                    {
                        string radek = sr.ReadLine();
                        try
                        {
                            DateTime datumNarozeni = DateTime.Parse(radek);
                            try
                            {
                                TimeSpan rozdil = dnes - datumNarozeni;
                                int pocetDnu = rozdil.Days;
                                MessageBox.Show(pocetDnu.ToString() + " " + datumNarozeni.ToString());
                            }
                            catch(FormatException)
                            {

                            }
                            catch(OverflowException)
                            {

                            }
                        }
                        catch(FormatException)
                        {
                            MessageBox.Show("Vadný zápis");
                        }
                    }
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Soubor nebyl nalezen");
            }
            catch (IOException)
            {
                MessageBox.Show("chyba při čtení souboru (soubor je poškozený)");
            }
        }
    }
}
