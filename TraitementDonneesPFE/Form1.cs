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

        #region -- Attributs --

        private static List<Sujet> mesSujets = new List<Sujet>();
        private static List<int> L_sujetsChecked = new List<int>();
        private static List<int> L_ciblesChecked = new List<int>();
        private static List<CheckBox> L_checkBox_sujets = new List<CheckBox>();
        private List<List<int>> L_positionsET = new List<List<int>>();
        private List<List<double>> L_positionsET2 = new List<List<double>>();
        private int acuiteSelectionne =0, correctionSelectionne = 0, couleurYeuxSelectionne = 0, mainSelectionne = 0,
            oeilSelectionne = 0, ordreScenarioSelectionne = 0, sexeSelectionne = 0, scenarioSelectionne = 0;
        private string poidsSelectionne = "", tailleSelectionne = "", tailleHautSelectionne = "";
        bool[] activerSujets = new bool[28];
        private double counterTime = 0f;

        #endregion

        public PFE_StabilisationCockpit()
        {
            readfile();
            InitializeComponent();
            comboBoxAcuite.SelectedIndex = 0;
            comboBoxCorrection.SelectedIndex = 0;
            comboBoxCouleurYeux.SelectedIndex = 0;
            comboBoxMain.SelectedIndex = 0;
            comboBoxOeil.SelectedIndex = 0;
            comboBoxOrdreScenario.SelectedIndex = 0;
            comboBoxPoids.SelectedIndex = 0;
            comboBoxScenario.SelectedIndex = 0;
            comboBoxTaille.SelectedIndex = 0;
            comboBoxTailleHaut.SelectedIndex = 0;
            comboBoxSexe.SelectedIndex = 0;

            Image i = pictureBoxDraw.Image;
            using (Graphics g = Graphics.FromImage(i))
            {
                g.FillEllipse(Brushes.Red, new Rectangle((int)(72 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(480 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(960 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1440 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1848 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle((int)(72 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(480 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(960 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1440 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1848 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle((int)(72 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(480 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(960 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1440 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1848 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle((int)(72 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(480 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(960 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1440 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1848 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle((int)(72 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(480 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(960 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1440 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle((int)(1848 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));

                pictureBoxDraw.Refresh();
            }

            comboBoxSujetTemps.SelectedIndex = 0;
            comboBoxCibleTemps.SelectedIndex = 0;
            comboBoxScenarioTemps.SelectedIndex = 0;

            foreach (Control c in groupBox5.Controls)
            {
                c.Enabled = false;
            }
            foreach (Control c in groupBox8.Controls)
            {
                c.Enabled = false;
            }
            foreach (Control c in groupBox7.Controls)
            {
                c.Enabled = false;
            }
            textBoxTime.Enabled = false;

        }

        #region -- Fonctions Evenements --

        #region selection checkbox sujets

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(1) && !checkBox1.Checked)
            {
                L_sujetsChecked.Remove(1);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox1.Checked)
            {
                L_sujetsChecked.Add(1);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(2) && !checkBox2.Checked)
            {
                L_sujetsChecked.Remove(2);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox2.Checked)
            {
                L_sujetsChecked.Add(2);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(23) && !checkBox23.Checked)
            {
                L_sujetsChecked.Remove(23);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox23.Checked)
            {
                L_sujetsChecked.Add(23);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(4) && !checkBox4.Checked)
            {
                L_sujetsChecked.Remove(4);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox4.Checked)
            {
                L_sujetsChecked.Add(4);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(5) && !checkBox5.Checked)
            {
                L_sujetsChecked.Remove(5);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox5.Checked)
            {
                L_sujetsChecked.Add(5);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(10) && !checkBox10.Checked)
            {
                L_sujetsChecked.Remove(10);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox10.Checked)
            {
                L_sujetsChecked.Add(10);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(24) && !checkBox24.Checked)
            {
                L_sujetsChecked.Remove(24);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox24.Checked)
            {
                L_sujetsChecked.Add(24);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(9) && !checkBox9.Checked)
            {
                L_sujetsChecked.Remove(9);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox9.Checked)
            {
                L_sujetsChecked.Add(9);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(3) && !checkBox3.Checked)
            {
                L_sujetsChecked.Remove(3);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox3.Checked)
            {
                L_sujetsChecked.Add(3);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(8) && !checkBox8.Checked)
            {
                L_sujetsChecked.Remove(8);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox8.Checked)
            {
                L_sujetsChecked.Add(8);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(7) && !checkBox7.Checked)
            {
                L_sujetsChecked.Remove(7);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox7.Checked)
            {
                L_sujetsChecked.Add(7);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(6) && !checkBox6.Checked)
            {
                L_sujetsChecked.Remove(6);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox6.Checked)
            {
                L_sujetsChecked.Add(6);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

            if (L_sujetsChecked.Contains(11) && !checkBox11.Checked)
            {
                L_sujetsChecked.Remove(11);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox11.Checked)
            {
                L_sujetsChecked.Add(11);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }


        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(12) && !checkBox12.Checked)
            {
                L_sujetsChecked.Remove(12);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox12.Checked)
            {
                L_sujetsChecked.Add(12);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

            if (L_sujetsChecked.Contains(17) && !checkBox17.Checked)
            {
                L_sujetsChecked.Remove(17);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox17.Checked)
            {
                L_sujetsChecked.Add(17);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(16) && !checkBox16.Checked)
            {
                L_sujetsChecked.Remove(16);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox16.Checked)
            {
                L_sujetsChecked.Add(16);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(21) && !checkBox21.Checked)
            {
                L_sujetsChecked.Remove(21);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox21.Checked)
            {
                L_sujetsChecked.Add(21);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }

        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(26) && !checkBox26.Checked)
            {
                L_sujetsChecked.Remove(26);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox26.Checked)
            {
                L_sujetsChecked.Add(26);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(22) && !checkBox22.Checked)
            {
                L_sujetsChecked.Remove(22);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox22.Checked)
            {
                L_sujetsChecked.Add(22);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(18) && !checkBox18.Checked)
            {
                L_sujetsChecked.Remove(18);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox18.Checked)
            {
                L_sujetsChecked.Add(18);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(19) && !checkBox19.Checked)
            {
                L_sujetsChecked.Remove(19);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox19.Checked)
            {
                L_sujetsChecked.Add(19);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(14) && !checkBox14.Checked)
            {
                L_sujetsChecked.Remove(14);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox14.Checked)
            {
                L_sujetsChecked.Add(14);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(15) && !checkBox15.Checked)
            {
                L_sujetsChecked.Remove(15);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox15.Checked)
            {
                L_sujetsChecked.Add(15);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(20) && !checkBox20.Checked)
            {
                L_sujetsChecked.Remove(20);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox20.Checked)
            {
                L_sujetsChecked.Add(20);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(25) && !checkBox25.Checked)
            {
                L_sujetsChecked.Remove(25);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if (checkBox25.Checked)
            {
                L_sujetsChecked.Add(25);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (L_sujetsChecked.Contains(13) && !checkBox13.Checked)
            {
                L_sujetsChecked.Remove(13);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
            else if(checkBox13.Checked)
            {
                L_sujetsChecked.Add(13);
                Debug.WriteLine("nb sujets checked : " + L_sujetsChecked.Count());
            }
        }

        #endregion

        #region checked cibles

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(25) && !checkBox32.Checked)
            {
                L_ciblesChecked.Remove(25);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox32.Checked)
            {
                L_ciblesChecked.Add(25);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox59_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(2) && !checkBox59.Checked)
            {
                L_ciblesChecked.Remove(2);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox59.Checked)
            {
                L_ciblesChecked.Add(2);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(3) && !checkBox48.Checked)
            {
                L_ciblesChecked.Remove(3);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox48.Checked)
            {
                L_ciblesChecked.Add(3);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(4) && !checkBox42.Checked)
            {
                L_ciblesChecked.Remove(4);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox42.Checked)
            {
                L_ciblesChecked.Add(4);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(5) && !checkBox36.Checked)
            {
                L_ciblesChecked.Remove(5);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox36.Checked)
            {
                L_ciblesChecked.Add(5);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(6) && !checkBox58.Checked)
            {
                L_ciblesChecked.Remove(6);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox58.Checked)
            {
                L_ciblesChecked.Add(6);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(7) && !checkBox57.Checked)
            {
                L_ciblesChecked.Remove(7);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox57.Checked)
            {
                L_ciblesChecked.Add(7);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(9) && !checkBox41.Checked)
            {
                L_ciblesChecked.Remove(9);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox41.Checked)
            {
                L_ciblesChecked.Add(9);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(8) && !checkBox47.Checked)
            {
                L_ciblesChecked.Remove(8);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox47.Checked)
            {
                L_ciblesChecked.Add(8);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                

            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(10) && !checkBox35.Checked)
            {
                L_ciblesChecked.Remove(10);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox35.Checked)
            {
                L_ciblesChecked.Add(10);
                Debug.WriteLine("nb sujets cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(11) && !checkBox56.Checked)
            {
                L_ciblesChecked.Remove(11);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox56.Checked)
            {
                L_ciblesChecked.Add(11);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(12) &&!checkBox55.Checked)
            {
                L_ciblesChecked.Remove(12);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox55.Checked)
            {
                L_ciblesChecked.Add(12);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox60_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(1) && !checkBox60.Checked)
            {
                L_ciblesChecked.Remove(1);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox60.Checked)
            {
                L_ciblesChecked.Add(1);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
                
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(14) && !checkBox40.Checked)
            {
                L_ciblesChecked.Remove(14);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox40.Checked)
            {
                L_ciblesChecked.Add(14);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(15) && !checkBox34.Checked)
            {
                L_ciblesChecked.Remove(15);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox34.Checked)
            {
                L_ciblesChecked.Add(15);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(20) && !checkBox33.Checked)
            {
                L_ciblesChecked.Remove(20);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if (checkBox33.Checked)
            {
                L_ciblesChecked.Add(20);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(19) && !checkBox39.Checked)
            {
                L_ciblesChecked.Remove(19);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox39.Checked)
            {
                L_ciblesChecked.Add(19);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(18) && !checkBox45.Checked)
            {
                L_ciblesChecked.Remove(18);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox45.Checked)
            {
                L_ciblesChecked.Add(18);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(17) && !checkBox53.Checked)
            {
                L_ciblesChecked.Remove(17);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox53.Checked)
            {
                L_ciblesChecked.Add(17);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(16) && !checkBox54.Checked)
            {
                L_ciblesChecked.Remove(16);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox54.Checked)
            {
                L_ciblesChecked.Add(16);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(21) && !checkBox52.Checked)
            {
                L_ciblesChecked.Remove(21);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox52.Checked)
            {
                L_ciblesChecked.Add(21);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {

            if (L_ciblesChecked.Contains(22) && !checkBox51.Checked)
            {
                L_ciblesChecked.Remove(22);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox51.Checked)
            {
                L_ciblesChecked.Add(22);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(23) && !checkBox44.Checked)
            {
                L_ciblesChecked.Remove(23);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox44.Checked)
            {
                L_ciblesChecked.Add(23);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(24) && !checkBox38.Checked)
            {
                L_ciblesChecked.Remove(24);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox38.Checked)
            {
                L_ciblesChecked.Add(24);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (L_ciblesChecked.Contains(13) && !checkBox46.Checked)
            {
                L_ciblesChecked.Remove(13);
                Debug.WriteLine("nb cibles checked : " + L_ciblesChecked.Count());
            }
            else if(checkBox46.Checked)
            {
                L_ciblesChecked.Add(13);
                Debug.WriteLine("nb cibles cibles : " + L_ciblesChecked.Count());
                
            }
        }

        #endregion

        private void TousSujets_Click(object sender, EventArgs e)
        {
            int cpt1 = 0;
            int cpt2 = 0;
            Debug.WriteLine("nb checkbox" + " ");
            if (Tout.Text == "Tous")
            {

                foreach (Control c in groupBox1.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        if (cb.Enabled == true)
                        {
                            //Debug.WriteLine("nb foreach check tous : "+ " " + cpt1);
                            if (cb.Checked == false)
                            {
                                cb.Checked = true;
                            }
                            cpt1++;
                        }
                        if (cpt1 == 27)
                        {
                            break;

                        }
                    }
                }
                Tout.Text = "Supprimer filtre";
            }
            else
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        cb.Checked = false;
                        cpt2++;
                        if (cpt2 == 27)
                        {
                            break;
                        }
                    }
                    Tout.Text = "Tous";

                }
            }


        }

        private void ToutesCibles_Click(object sender, EventArgs e)
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

        #region Selection Filtres

        private void ChangementScenario(object sender, EventArgs e)
        {
            int val = comboBoxScenario.SelectedIndex;
            switch (val)
            {
                case 0: // Sans mouvements
                    scenarioSelectionne = 1;
                    break;
                case 1: // Mouvement avant/arrière
                    scenarioSelectionne = 2;
                    break;
                case 2: // Mouvements rotations
                    scenarioSelectionne = 3;
                    break;
                default:
                    break;
            }

        }

        private void ChangementOrdreScenario(object sender, EventArgs e)
        {
            int val = comboBoxOrdreScenario.SelectedIndex;
            switch (val)
            {
                /*
                Tous
                123
                132
                213
                231
                312
                321
                */
                case 0: //
                    ordreScenarioSelectionne = 0;
                    break;
                case 1: // 
                    ordreScenarioSelectionne = 123;
                    break;
                case 2: // 
                    ordreScenarioSelectionne = 132;
                    break;
                case 3: // 
                    ordreScenarioSelectionne = 213;
                    break;
                case 4: // 
                    ordreScenarioSelectionne = 231;
                    break;
                case 5: // 
                    ordreScenarioSelectionne = 312;
                    break;
                case 6: // 
                    ordreScenarioSelectionne = 321;
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementMainDirectrice(object sender, EventArgs e)
        {
            int val = comboBoxMain.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    mainSelectionne = 0;
                    break;
                case 1: // 
                    mainSelectionne = 1;
                    break;
                case 2: // 
                    mainSelectionne = 2;
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementOeilDirecteur(object sender, EventArgs e)
        {
            int val = comboBoxOeil.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    oeilSelectionne = 0;
                    break;
                case 1: // 
                    oeilSelectionne = 1;
                    break;
                case 2: // 
                    oeilSelectionne = 2;
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementCouleurYeux(object sender, EventArgs e)
        {
            int val = comboBoxCouleurYeux.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    couleurYeuxSelectionne = 0;
                    break;
                case 1: // 
                    couleurYeuxSelectionne = 1;
                    break;
                case 2: // 
                    couleurYeuxSelectionne = 2;
                    break;
                case 3: // 
                    couleurYeuxSelectionne = 3;
                    break;
                case 4: // 
                    couleurYeuxSelectionne = 4;
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementSexe(object sender, EventArgs e)
        {
            int val = comboBoxSexe.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    sexeSelectionne = 0;
                    break;
                case 1: // 
                    sexeSelectionne = 1;
                    break;
                case 2: // 
                    sexeSelectionne = 2;
                    break;
                default:
                    break;
            }
            ApplyFilters();

        }

        private void ChangementAcuite(object sender, EventArgs e)
        {
            int val = comboBoxAcuite.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    acuiteSelectionne = 0;
                    break;
                case 1: // 
                    acuiteSelectionne = 10;
                    break;
                case 2: // 
                    acuiteSelectionne = 9;
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementCorrection(object sender, EventArgs e)
        {
            int val = comboBoxCorrection.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    correctionSelectionne = 0;
                    break;
                case 1: // 
                    correctionSelectionne = 1;
                    break;
                case 2: // 
                    correctionSelectionne = 2;
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementPoids(object sender, EventArgs e)
        {
            int val = comboBoxPoids.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    poidsSelectionne = "";
                    break;
                case 1: // 
                    poidsSelectionne = comboBoxPoids.SelectedItem.ToString();
                    break;
                case 2: // 
                    poidsSelectionne = comboBoxPoids.SelectedItem.ToString();
                    break;
                case 3: // 
                    poidsSelectionne = comboBoxPoids.SelectedItem.ToString();
                    break;
                case 4: // 
                    poidsSelectionne = comboBoxPoids.SelectedItem.ToString();
                    break;
                case 5: // 
                    poidsSelectionne = comboBoxPoids.SelectedItem.ToString();
                    break;
                case 6: // 
                    poidsSelectionne = comboBoxPoids.SelectedItem.ToString();
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementTaille(object sender, EventArgs e)
        {
            int val = comboBoxTaille.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    tailleSelectionne = "";
                    break;
                case 1: // 
                    tailleSelectionne = comboBoxTaille.SelectedItem.ToString();
                    break;
                case 2: // 
                    tailleSelectionne = comboBoxTaille.SelectedItem.ToString();
                    break;
                case 3: // 
                    tailleSelectionne = comboBoxTaille.SelectedItem.ToString();
                    break;
                case 4: // 
                    tailleSelectionne = comboBoxTaille.SelectedItem.ToString();
                    break;
                case 5: // 
                    tailleSelectionne = comboBoxTaille.SelectedItem.ToString();
                    break;
                default:
                    break;
            }
            ApplyFilters();
        }

        private void ChangementTailleHaut(object sender, EventArgs e)
        {
            int val = comboBoxTailleHaut.SelectedIndex;
            switch (val)
            {
                case 0: // 
                    tailleHautSelectionne = "";
                    break;
                case 1: // 
                    tailleHautSelectionne = comboBoxTailleHaut.SelectedItem.ToString();
                    break;
                case 2: // 
                    tailleHautSelectionne = comboBoxTailleHaut.SelectedItem.ToString();
                    break;
                case 3: // 
                    tailleHautSelectionne = comboBoxTailleHaut.SelectedItem.ToString();
                    break;
                case 4: // 
                    tailleHautSelectionne = comboBoxTailleHaut.SelectedItem.ToString();
                    break;
                default:
                    break;
            }
            ApplyFilters();

        }

        #endregion

        private void dessinerTousLesCercles(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                int nbAffichage = 0;
                L_positionsET.Clear();

                foreach (Sujet suj in mesSujets)
                {
                    if (L_sujetsChecked.Contains(suj.Id))
                    {
                        foreach (resultat resu in suj.Resultats)
                        {
                            if (resu.NumeroScenario == (scenarioSelectionne))
                            {
                                foreach (List<double> ldoub in resu.Positions)
                                {

                                    if (L_ciblesChecked.Contains((int)ldoub[0]))
                                    {
                                        List<int> toAdd = new List<int> { ((int)(ldoub[2] * 0.5625) + 110), ((int)(ldoub[3] * 0.5625) + 61) };
                                        L_positionsET.Add(toAdd);
                                        nbAffichage++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (L_positionsET != null)
                {
                    dessinerCercle(L_positionsET,2);
                }
                Debug.WriteLine("Nb positions affichées :" + nbAffichage);
            }
            else if (radioButton2.Checked == true)
            {
                timerCount.Stop();
                timerCount.Start();
                counterTime = 0;
                L_positionsET2.Clear();
                textBoxTime.Enabled = true;

                Debug.WriteLine("sujet : " +comboBoxSujetTemps.SelectedItem);

                double aEnlever = 0;

                foreach (Sujet suj in mesSujets)
                {
                    if (suj.Id == int.Parse(comboBoxSujetTemps.SelectedItem.ToString()))
                    {
                        foreach (resultat res in suj.Resultats)
                        {
                            if (res.NumeroScenario == int.Parse((comboBoxScenarioTemps.SelectedIndex + 1).ToString()))
                            {
                                foreach (List<double> dou in res.Positions)
                                {
                                    //numCible,temps, posX, posY
                                    if (dou[0]== int.Parse(comboBoxCibleTemps.SelectedItem.ToString()))
                                    {
                                        if (aEnlever == 0)
                                        {
                                            aEnlever = Math.Floor(dou[1]);
                                        }
                                        List<double> toAdd = new List<double> { dou[1] - aEnlever, dou[2] * 0.5625f + 110f, dou[3] * 0.5625f + 61f };
                                        L_positionsET2.Add(toAdd);
                                    }
                                }
                            }
                        }
                    }
                }



            }

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            timerCount.Stop();
            counterTime = 0;
            textBoxTime.Text = "";
            foreach (Control c in groupBox1.Controls)
            {
                c.Enabled = true;
            }
            foreach (Control c in groupBox2.Controls)
            {
                c.Enabled = true;
            }
            foreach (Control c in groupBox5.Controls)
            {
                c.Enabled = false;
            }
            foreach (Control c in groupBox7.Controls)
            {
                c.Enabled = false;
            }
            foreach (Control c in groupBox8.Controls)
            {
                c.Enabled = false;
            }
            textBoxTime.Enabled = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {

            foreach (Control c in groupBox1.Controls)
            {
                c.Enabled = false;
            }
            foreach (Control c in groupBox2.Controls)
            {
                c.Enabled = false;
            }
            foreach (Control c in groupBox5.Controls)
            {
                c.Enabled = true;
            }
            foreach (Control c in groupBox7.Controls)
            {
                c.Enabled = true;
            }
            foreach (Control c in groupBox8.Controls)
            {
                c.Enabled = true;
            }

        }

        private void timerCount_Tick(object sender, EventArgs e)
        {
            if (L_positionsET2.Count()>1)
            {
                counterTime = counterTime + 0.1f;
                textBoxTime.Text = (counterTime / 10).ToString();

                double toCompare = Math.Round(counterTime / 10, 2);
                double toCompare2 = Math.Round(L_positionsET2[0][0], 2);
                if (toCompare2 == toCompare)
                {
                    List<List<int>> aze = new List<List<int>>();
                    List<int> toAdd = new List<int> { (int)(L_positionsET2[0][1]), (int)(L_positionsET2[0][2]) };
                    aze.Add(toAdd);
                    dessinerCercle(aze,10);
                    L_positionsET2.RemoveAt(0);
                }
            }

        }


        #endregion

        #region -- Fonctions --

        private void readfile()
        {
            List<List<resultat>> aAjouter = new List<List<resultat>>();
            List<resultat> res = new List<resultat>();
            var directories = Directory.GetDirectories(".\\EyeTracker");

            foreach (string dossier in directories)
            {

                var reader2 = new StreamReader(File.OpenRead(@dossier + "\\1.txt"), Encoding.Default);
                int compteur2 = 0;

                resultat tempoRes = new resultat(1);
                double tempoCible = 0;
                while (!reader2.EndOfStream)
                {
                    var line2 = reader2.ReadLine();
                    if (line2.StartsWith("E"))
                    {
                        compteur2++;
                        break;
                    }
                    if (line2.StartsWith("T"))
                    {
                        tempoCible = double.Parse(line2.Substring(1, 2));
                        if (tempoCible == 25)
                        {
                            int azazeazeaze = 0;
                        }
                    }
                    else
                    {
                        var values = line2.Split(':');
                        var values2 = values[1].Split(',');
                        tempoRes.ajoutCible(tempoCible, double.Parse(values[0].Replace('.', ',')), double.Parse(values2[0]), double.Parse(values2[1].Split(';')[0]));
                    }
                    compteur2++;
                }


                var reader3 = new StreamReader(File.OpenRead(@dossier + "\\2.txt"), Encoding.Default);
                int compteur3 = 0;

                resultat tempoRes2 = new resultat(2);
                double tempoCible2 = 0;
                while (!reader3.EndOfStream)
                {
                    var line3 = reader3.ReadLine();
                    if (line3.StartsWith("E"))
                    {
                        compteur3++;
                        break;
                    }
                    if (line3.StartsWith("T"))
                    {
                        tempoCible2 = double.Parse(line3.Substring(1, 2));
                    }
                    else
                    {
                        var values = line3.Split(':');
                        var values2 = values[1].Split(',');
                        tempoRes2.ajoutCible(tempoCible2, double.Parse(values[0].Replace('.', ',')), double.Parse(values2[0]), double.Parse(values2[1].Split(';')[0]));
                    }
                    compteur3++;
                }


                var reader4 = new StreamReader(File.OpenRead(@dossier + "\\3.txt"), Encoding.Default);
                int compteur4 = 0;

                resultat tempoRes3 = new resultat(3);
                double tempoCible3 = 0;
                while (!reader4.EndOfStream)
                {
                    var line2 = reader4.ReadLine();
                    if (line2.StartsWith("E"))
                    {
                        compteur4++;
                        break;
                    }
                    if (line2.StartsWith("T"))
                    {
                        tempoCible3 = double.Parse(line2.Substring(1, 2));
                    }
                    else
                    {
                        var values = line2.Split(':');
                        var values2 = values[1].Split(',');
                        tempoRes3.ajoutCible(tempoCible3, double.Parse(values[0].Replace('.', ',')), double.Parse(values2[0]), double.Parse(values2[1].Split(';')[0]));
                    }
                    compteur4++;
                }
                aAjouter.Add(new List<resultat> { tempoRes, tempoRes2, tempoRes3 });
            } // Fin parcourt dossiers EyeTracker

            var reader = new StreamReader(File.OpenRead(@".\sujets.csv"), Encoding.Default);
            bool read_title = false;
            int compteur = 0;
            while (!reader.EndOfStream)
            {

                Sujet Sujet = new Sujet(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, aAjouter[compteur]);
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
                    Sujet.Resultats = aAjouter[compteur];

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

        private void ApplyFilters()
        {
            //Enable all others checkbox
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Enabled = true;
                }
            }

            List<int> L_num_suj_fem = new List<int>();

            //Supp List sujets selectionnes 
            L_sujetsChecked.Clear();

            //Uncheck all checkbox
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == true)
                    {
                        cb.Checked = false;
                    }
                }
            }


            int cpt = 0;

            foreach (Sujet suj in mesSujets)
            {
                #region Verification des sujets à activer

                if (sexeSelectionne == 0 || sexeSelectionne == suj.Sexe)
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (acuiteSelectionne == 0 || acuiteSelectionne == suj.Accuite)
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (correctionSelectionne == 0 || correctionSelectionne == suj.Lunettes)
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (couleurYeuxSelectionne == 0 || couleurYeuxSelectionne == suj.Couleur)
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (mainSelectionne == 0 || mainSelectionne == suj.Main)
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (oeilSelectionne == 0 || oeilSelectionne == suj.Oeil_dir)
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (ordreScenarioSelectionne == 0 || ordreScenarioSelectionne == suj.Scenario)
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }
                string[] valuesPoids = new string[2], valuesTaille = new string[2], valuesTailleHaut = new string[2];
                if (poidsSelectionne!="")
                {
                    valuesPoids = poidsSelectionne.Split('-');
                }
                if (poidsSelectionne == "" || Between(suj.Poids, int.Parse(valuesPoids[0]), int.Parse(valuesPoids[1])))
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (tailleSelectionne != "")
                {
                    valuesTaille = tailleSelectionne.Split('-');
                }
                if (tailleSelectionne == "" || Between(suj.Taille, int.Parse(valuesTaille[0]), int.Parse(valuesTaille[1])))
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }

                if (tailleHautSelectionne != "")
                {
                    valuesTailleHaut = tailleHautSelectionne.Split('-');
                }
                if (tailleHautSelectionne == "" || Between(suj.Haut_corps, int.Parse(valuesTailleHaut[0]), int.Parse(valuesTailleHaut[1])))
                {
                    activerSujets[cpt+1] = true;
                }
                else
                {
                    activerSujets[cpt+1] = false;
                    cpt++;
                    continue;
                }
                cpt++;
                #endregion
            }

            //Enable checkboxes 
            for (int s = 1; s < activerSujets.Length; s++)
            {

                foreach (Control c in groupBox1.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;

                        if (cb.Text == s.ToString() && activerSujets[s] == true)
                        {
                            cb.Checked = true;
                        }
                        /*
                        if (cpt == 27)
                        {
                            break;
                        }
                        */
                    }
                }
            }

            //Disable all others checkbox
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == false)
                    {
                        cb.Enabled = false;
                    }
                }
            }

            

        }

        private bool Between(int num, int lower, int upper)
        {
            if (lower <= num && num <= upper)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void dessinerCercle(List<List<int>> L, int taille)
        {
            pictureBoxDraw.Image = Image.FromFile("1300x731-Center1080x608.jpg");
            Image i = pictureBoxDraw.Image;
            using (Graphics g = Graphics.FromImage(i))
            {
                foreach (List<int> item in L)
                {
                    g.FillEllipse(Brushes.White, new Rectangle(item[0], item[1], taille, taille));
                    
                }

                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(72 * 0.5625 + 110), (int)(72 * 0.5625 + 61) , 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(480 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(960 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1440 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1848 * 0.5625 + 110), (int)(72 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(72 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(480 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(960 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1440 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1848 * 0.5625 + 110), (int)(310 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(72 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(480 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(960 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1440 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1848 * 0.5625 + 110), (int)(773 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(72 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(480 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(960 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1440 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1848 * 0.5625 + 110), (int)(1008 * 0.5625 + 61), 8, 8));

                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(72 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(480 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(960 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1440 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));
                g.FillEllipse(Brushes.Red, new Rectangle(  (int)(1848 * 0.5625 + 110), (int)(540 * 0.5625 + 61), 8, 8));



                pictureBoxDraw.Refresh();
            }
        }

        #endregion


    }
}
