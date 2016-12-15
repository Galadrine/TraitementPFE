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

        public PFE_StabilisationCockpit()
        {
            readfile();
            InitializeComponent();
            
        }

        private void Tout_Click(object sender, EventArgs e)
        {

        }


        public static void readfile()
        {
            var reader = new StreamReader(File.OpenRead(@".\sujets.csv"), Encoding.Default);
            bool read_title = false;
            int compteur = 0;
            while (!reader.EndOfStream)
            {

                sujet Sujet = new sujet(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0);
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
       
    }
}
