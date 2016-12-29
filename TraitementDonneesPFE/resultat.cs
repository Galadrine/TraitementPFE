using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraitementDonneesPFE
{
    class resultat
    {

        private List<List<double>> _positions;
        private int _numeroScenario;
        
        public int NumeroScenario
        {
            get { return _numeroScenario; }
            set { _numeroScenario = value; }
        }

        public List<List<double>> Positions
        {
            get { return _positions; }
            set { _positions = value; }
        }

        public resultat(int numScenario) {
            NumeroScenario = numScenario;
            Positions = new List<List<double>>();
        }

        public void ajoutCible(double numCible,double temps, double posX, double posY)
        {
            Positions.Add(new List<double> { numCible,temps, posX, posY });

        }


    }
}
