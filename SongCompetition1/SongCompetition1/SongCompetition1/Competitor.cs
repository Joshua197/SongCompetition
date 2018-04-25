using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongCompetition1
{
    class Competitor
    {
        //static field
        private static int itemsNumber;

        //automatically implemented properties
        public int IdNumber { get; }
        public string Name { get; }
        public string Department { get;  }
        public int Score { get; private set; }

        //constructor
        public Competitor(string name, string department) {
            this.Name = name;
            this.Department = department;

            // unique id-number
            itemsNumber++;
            IdNumber = itemsNumber;
        }
        //methods
        public void Scoring(int point) {
            Score += point;
        }

        public override string ToString()
        {
            return IdNumber+"\t"+Name+"\t"+Department+"\t"+Score+" points";
        }
    }
}
