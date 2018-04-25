using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SongCompetition1
{
    class Controller
    {
        private List<Competitor> competitors = new List<Competitor>();
        private int juryMembersNumber = 5;
        private int scoreLimit = 10;

        public void Start() {
            Input();

            Output("\nParticipants:\n");
            Competition();
            Output("\nResults:\n");

            Results();
            Search();

        }

        private void Input()
        {
            Competitor competitor;
            string name, departement;
            StreamReader streamReader = new StreamReader("competitors.txt");

            while (!streamReader.EndOfStream)
            {
                name = streamReader.ReadLine();
                departement = streamReader.ReadLine();

                competitor = new Competitor(name, departement);
                //Add the competitor object to the list of competitors
                competitors.Add(competitor);
            }
            streamReader.Close();
        }       

        private void Output(string title)
        {
            Console.WriteLine(title);
            foreach (Competitor competitor in competitors)
            {
                Console.WriteLine(competitor);
            }
        }

        private void Competition()
        {
            Random rand = new Random();
            int point;
            foreach (Competitor competitor in competitors)
            {
                //judges 'score
                for (int i = 1; i < juryMembersNumber; i++)
                {
                    point = rand.Next(scoreLimit);
                    competitor.Scoring(point);
                }
            }
        }

        private void Results()
        {
            Winner();
            Sorting();
        }
        private void Winner() {
            int max = competitors[0].Score;
            // tha maximum value
            foreach (Competitor singer in competitors)
            {
                if (singer.Score>max)
                {
                    max = singer.Score;
                }
            }
            //the winners
            Console.WriteLine("\nThe winners\n");
            foreach (Competitor competitor in competitors)
            {
                if (competitor.Score == max)
                {
                    Console.WriteLine(competitor);
                }
            }
        }
        private void Sorting()
        {
            // sorting
            Competitor temp;
            for (int i = 0; i < competitors.Count - 1; i++)
            {
                for (int j = i + 1; j < competitors.Count; j++)
                {
                    if (competitors[i].Score < competitors[j].Score)
                    {
                        temp = competitors[i];
                        competitors[i] = competitors[j];
                        competitors[j] = temp;
                    }
                }
            }
            Output("\nScoreboard\n");
        }
        private void Search()
        {
            Console.WriteLine("\nSearch for the competitors of a given departement\n");
            Console.Write("\nDo you look for someone? (y/n) ");

            char answer;
            while (!char.TryParse(Console.ReadLine(), out answer))
            {
                Console.Write("Only one character, please. ");
            }

            string departement;
            bool exists;

            while (answer == 'y' || answer == 'Y')
            {
                Console.Write("Departement: ");
                departement = Console.ReadLine();
                exists = false;

                foreach (Competitor competitor in competitors)
                {
                    if (competitor.Department == departement)
                    {
                        Console.WriteLine(competitor);
                        exists = true;
                    }
                }

                if (!exists)
                {
                    Console.WriteLine("There is no competitor from this departement.");
                }

                Console.Write("\nDo you look for another one? (y/n) ");
                answer = char.Parse(Console.ReadLine());
            }
        }

    }
}

