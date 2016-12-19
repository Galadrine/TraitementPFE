using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Reflection;

namespace TraitementDonneesPFE
{
    public partial class PFE_StabilisationCockpit : Form
    {
        private static List<sujet> mesSujets = new List<sujet>();
        private static List<int> L_sujetsChecked = new List<int>();
        private static List<int> L_ciblesChecked = new List<int>();
        private static List<CheckBox> L_checkBox_sujets = new List<CheckBox>();
        private static bool sexe=false;
        

        public PFE_StabilisationCockpit()
        {
            readfile();
            InitializeComponent();


        }
        /*
          #-----------------------------#
          # Fonction btn "tout" sujet---#
          #-----------------------------#
         */
        private void Tout_Click(object sender, EventArgs e)
        {
            int cpt1 = 0;
            int cpt2 = 0;
            Debug.WriteLine("nb checkbox" + " ");
            if (Tout.Text == "Tous")
            {

                foreach (CheckBox c in groupBox1.Controls)
                {
                    //Debug.WriteLine("nb foreach check tous : "+ " " + cpt1);
                    c.Checked = true;
                    cpt1++;
                    if (cpt1 == 27)
                    {
                        break;

                    }
                }
                Tout.Text = "Supprimer filtre";
            }
            else
            {
                foreach (CheckBox c in groupBox1.Controls)
                {
                    c.Checked = false;
                    cpt2++;
                    if (cpt2 == 27)
                    {
                        break;
                    }
                }
                Tout.Text = "Tous";
            }

        }

        /*
          #-----------------------------#
          # Fonction read file csv sujet#
          #-----------------------------#
         */
        public static void readfile()
        {
            var reader = new StreamReader(File.OpenRead(@".\sujets.csv"), Encoding.Default);
            bool read_title = false;
            int compteur = 0;
            List<resultat> L_vide = new List<resultat>();
            while (!reader.EndOfStream)
            {

                sujet Sujet = new sujet(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, L_vide);
                var line = reader.ReadLine();
                var values = line.Split(';');

                if (read_title)
                {
                    int id = int.Parse(values[0]);
                    int scenario = int.Parse(values[1]);
                    int sexe = int.Parse(values[2]);
                    int age = int.Parse(values[3]);
                    int main = int.Parse(values[4]);
                    int couleur = int.Parse(values[5]);
                    int accuite = int.Parse(values[6]);
                    int oeil_dir = int.Parse(values[7]);
                    int lunettes = int.Parse(values[8]);
                    int pb = int.Parse(values[9]);
                    int taille = int.Parse(values[10]);
                    int haut_corps = int.Parse(values[11]);
                    int poids = int.Parse(values[12]);


                    //On definit les attributs de l'equipier
                    Sujet.Id = id;
                    Sujet.Scenario = scenario;
                    Sujet.Sexe = sexe;
                    Sujet.Age = age;
                    Sujet.Main = main;
                    Sujet.Couleur = couleur;
                    Sujet.Accuite = accuite;
                    Sujet.Oeil_dir = oeil_dir;
                    Sujet.Lunettes = lunettes;
                    Sujet.Pb = pb;
                    Sujet.Taille = taille;
                    Sujet.Haut_corps = haut_corps;
                    Sujet.Poids = poids;

                    //On ajoute à la liste
                    mesSujets.Add(Sujet);

                }
                else
                {
                    read_title = true;
                }
                compteur++;

            }
        }

        #region selection checkbox sujets

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(1))
            {
                L_sujetsChecked.Remove(1);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(1);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(2))
            {
                L_sujetsChecked.Remove(2);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(2);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(23))
            {
                L_sujetsChecked.Remove(23);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(23);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(4))
            {
                L_sujetsChecked.Remove(4);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(4);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(5))
            {
                L_sujetsChecked.Remove(5);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(5);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(10))
            {
                L_sujetsChecked.Remove(10);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(10);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(24))
            {
                L_sujetsChecked.Remove(24);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(24);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(9))
            {
                L_sujetsChecked.Remove(9);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(9);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(3))
            {
                L_sujetsChecked.Remove(3);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(3);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(8))
            {
                L_sujetsChecked.Remove(8);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(8);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(7))
            {
                L_sujetsChecked.Remove(7);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(7);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(6))
            {
                L_sujetsChecked.Remove(6);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(6);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if( !sexe)
            {
                if (L_sujetsChecked.Contains(11))
                {
                    L_sujetsChecked.Remove(11);
                    Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
                }
                else
                {
                    L_sujetsChecked.Add(11);
                    Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
                }
            }
           
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(12))
            {
                L_sujetsChecked.Remove(12);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(12);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

            if (L_sujetsChecked.Contains(17))
            {
                L_sujetsChecked.Remove(17);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(17);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(16))
            {
                L_sujetsChecked.Remove(16);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(16);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(21))
            {
                L_sujetsChecked.Remove(21);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(21);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }

        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(26))
            {
                L_sujetsChecked.Remove(26);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(26);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(27))
            {
                L_sujetsChecked.Remove(27);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(27);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(22))
            {
                L_sujetsChecked.Remove(22);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(22);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(18))
            {
                L_sujetsChecked.Remove(18);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(18);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(19))
            {
                L_sujetsChecked.Remove(19);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(19);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(14))
            {
                L_sujetsChecked.Remove(14);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(14);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(15))
            {
                L_sujetsChecked.Remove(15);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(15);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(20))
            {
                L_sujetsChecked.Remove(20);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(20);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(25))
            {
                L_sujetsChecked.Remove(25);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(25);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(13))
            {
                L_sujetsChecked.Remove(13);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else
            {
                L_sujetsChecked.Add(13);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        #endregion

        /*
          #-----------------------------#
          # Fonction btn "toutes" cibles#
          #-----------------------------#
         */

        private void button1_Click(object sender, EventArgs e)
        {
            int cpt1 = 0;
            int cpt2 = 0;
            Debug.WriteLine("nb checkbox" + " ");
            if (button1.Text == "Toutes")
            {

                foreach (CheckBox c in groupBox2.Controls)
                {
                    //Debug.WriteLine("nb foreach check tous : "+ " " + cpt1);
                    c.Checked = true;
                    cpt1++;
                    if (cpt1 == 25)
                    {
                        break;
                    }
                }
                button1.Text = "Supprimer filtre";
            }
            else
            {
                foreach (CheckBox c in groupBox2.Controls)
                {
                    c.Checked = false;
                    cpt2++;
                    if (cpt2 == 25)
                    {
                        break;
                    }
                }
                button1.Text = "Toutes";
            }
        }


        #region checked cibles 
        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(25))
            {
                L_ciblesChecked.Remove(25);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(25);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox59_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(2))
            {
                L_ciblesChecked.Remove(2);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(2);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(3))
            {
                L_ciblesChecked.Remove(3);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(3);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(4))
            {
                L_ciblesChecked.Remove(4);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(4);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(5))
            {
                L_ciblesChecked.Remove(5);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(5);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(6))
            {
                L_ciblesChecked.Remove(6);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(6);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(7))
            {
                L_ciblesChecked.Remove(7);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(7);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(9))
            {
                L_ciblesChecked.Remove(9);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(9);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(8))
            {
                L_ciblesChecked.Remove(8);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(8);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(10))
            {
                L_ciblesChecked.Remove(10);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(10);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(11))
            {
                L_ciblesChecked.Remove(11);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(11);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(12))
            {
                L_ciblesChecked.Remove(12);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(12);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox60_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(1))
            {
                L_ciblesChecked.Remove(1);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(1);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(14))
            {
                L_ciblesChecked.Remove(14);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(14);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(15))
            {
                L_ciblesChecked.Remove(15);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(15);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(20))
            {
                L_ciblesChecked.Remove(20);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(20);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(19))
            {
                L_ciblesChecked.Remove(19);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(19);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(18))
            {
                L_ciblesChecked.Remove(18);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(18);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(17))
            {
                L_ciblesChecked.Remove(17);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(17);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(16))
            {
                L_ciblesChecked.Remove(16);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(16);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(21))
            {
                L_ciblesChecked.Remove(21);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(21);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {

            if (L_ciblesChecked.Contains(22))
            {
                L_ciblesChecked.Remove(22);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(22);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(23))
            {
                L_ciblesChecked.Remove(23);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(23);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(24))
            {
                L_ciblesChecked.Remove(24);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(24);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(25))
            {
                L_ciblesChecked.Remove(25);
                Debug.WriteLine("nb clibles checked : " + L_ciblesChecked.Count());
            }
            else
            {
                L_ciblesChecked.Add(25);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
            }
        }
        #endregion

        /*
          #-----------------------------#
          #Fonction selectionne tt homme#
          #-----------------------------#
         */

        private void checkBox_Sexe_Masc_CheckedChanged(object sender, EventArgs e)
        {
            int cpt = 0;

            sexe = true;
            //Supp List sujets selectionnes
            for (int num = 0; num < L_sujetsChecked.Count(); num++)
            {
                L_sujetsChecked.Remove(L_sujetsChecked[num]);
            }

           //Debug.WriteLine(checkBox_Sexe_Masc.Checked + " check sexe masc");

            if (checkBox_Sexe_Masc.Checked)
            {
                foreach (sujet suj in mesSujets)
                {
                     if(suj.Sexe==1)
                    {
                        L_sujetsChecked.Add(suj.Id);
                    }
                    //Debug.WriteLine("nb L_sujet Checkt count : sexe homme : " + L_sujetsChecked.Count());
                }

                //Debug.WriteLine("bool sexe : " + sexe);
                    for (int i = 0; i < L_sujetsChecked.Count(); i++)
                    {
                        cpt = 0;
                        foreach (CheckBox c in groupBox1.Controls)
                        {
                            cpt++;
                            if (c.Text == L_sujetsChecked[i].ToString())
                            {
                            int num2 = L_sujetsChecked[i];
                            c.Checked = true;
                                                        
                            }
                            else
                        {
                            c.Checked = false;
                        }
                            if (cpt == 27)
                            {
                                break;
                            }
                        }
                    }
                   
                
            }
            else
            {
               /* foreach (CheckBox c in groupBox1.Controls)
                {
                    cpt++;
                    if (c.Checked == true)
                    {
                        c.Checked = false;
                    }
                   
                    if (cpt == 27)
                    {
                        break;
                    }
                }
                */
            }
        }

        private void checkBox_Sexe_Femin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
