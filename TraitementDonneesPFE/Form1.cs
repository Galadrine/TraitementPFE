﻿using System;
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
       private static List<CheckBox> L_checkBox_sujets = new List<CheckBox>();

        public PFE_StabilisationCockpit()
        {
            readfile();
            InitializeComponent();
            

    }

        private void Tout_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("nb checkbox" + " ");
            if (Tout.Text == "Tous")
            {
               
                foreach (CheckBox c in groupBox1.Controls)
                {
                    c.Checked = true;
                }
                Tout.Text = "Supprimer filtre";
            }
            else
            {
                foreach (CheckBox c in groupBox1.Controls)
                {
                    c.Checked = false;
                }
                Tout.Text = "Tous";
            }
            
        }


        public static void readfile()
        {
            var reader = new StreamReader(File.OpenRead(@".\sujets.csv"), Encoding.Default);
            bool read_title = false;
            int compteur = 0;
            List<resultat> L_vide = new List<resultat>();
            while (!reader.EndOfStream)
            {
                
                sujet Sujet = new sujet(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,L_vide);
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
           if(L_sujetsChecked.Contains(1))
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

    }
}
