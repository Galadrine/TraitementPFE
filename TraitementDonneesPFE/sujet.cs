using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraitementDonneesPFE
{
    class sujet
    {

        #region Attributs

        public int _id;
        public int _scenario;
        public int _sexe;
        public int _age;
        public int _main;
        public int _couleur;
        public int _accuite;
        public int _oeil_dir;
        public int _lunettes;
        public int _pb;
        public int _taille;
        public int _haut_corps;
        public int _poids;
        public List<resultat> _resultats;

        #endregion

        #region Constructeur

        public sujet (int id, int scenario, int sexe, int age, int main, int couleur,int accuite, int oeil_dir, int lunettes, int pb, int taille, int haut_corps,int poids, List<resultat> resultats)
        {

            _id = id;
            _scenario = scenario;
            _sexe = sexe;
            _age = age;
            _main = main;
            _couleur = couleur;
            _accuite = accuite;
            _oeil_dir = oeil_dir;
            _lunettes = lunettes;
            _pb = pb;
            _taille = taille;
            _haut_corps = haut_corps;
            _poids = poids;
            _resultats = resultats;
                
        }

        #endregion


        #region Accesseurs

        public List<resultat> Resultats
        {
            get
            {
                return _resultats;
            }
            set
            {
                _resultats = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int Scenario
        {
            get
            {
                return _scenario;
            }
            set
            {
                _scenario = value;
            }
        }

        public int Sexe
        {
            get
            {
                return _sexe;
            }
            set
            {
                _sexe = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }

        public int Main
        {
            get
            {
                return _main;
            }

            set
            {
                _main = value;
            }
        }

        public int Couleur
        {
            get
            {
                 return _couleur;
            }

            set
            {
                _couleur = value;
            }
        }

        public int Accuite
        {
            get
            {
                return _accuite;
            }

            set
            {
                _accuite = value;
            }
        }

        public int Oeil_dir
        {
            get
            {
                return _oeil_dir;
            }
            set
            {
                _oeil_dir = value;
            }
        }
       
        public int Lunettes
        {
            get
            {
                return _lunettes;
            }
            set
            {
                _lunettes = value;
            }
        }


        public int Pb
        {
            get
            {
                return _pb;
            }
            set
            {
                _pb = value;

            }
        }


        public int Taille
        {
            get
            {
                return _taille;
            }

            set
            {
                _taille = value;
            }
        }


        public int  Haut_corps
        {
            get
            {
                return _haut_corps;
            }

            set
            {
                _haut_corps = value;
            }
        }

        public int Poids
        {
            get
            {
                return _poids;
            }
            set
            {
                _poids = value;
            }
        }

        #endregion




    }
}
