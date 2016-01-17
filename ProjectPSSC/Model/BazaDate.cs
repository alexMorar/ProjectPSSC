using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectPSSC.Model
{
    public struct carti
    {
        public string autor;
        public string nume;
        public string tip;
        public int nr_exemplare;
    }

    public class BazeDate : IBazeDate
    {

        List<carti> bookDB = new List<carti>();

        public BazeDate()
        {
            getDataBase();
        }

        void getDataBase()
        {
            string line;
            try
            {
                using (StreamReader reader = new StreamReader("BazaDate.txt"))
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        parseLine(line);
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not upload the Data Base:");
                Console.WriteLine(e.Message);
            }
        }

        void parseLine(string line)
        {
            string[] bookDetalis = line.Split('-');
            try
            {
                createDataBase(bookDetalis);
            }
            catch (Exception e)
            {
                Console.WriteLine("Stringul e cu eroare");
                Console.WriteLine(e.Message);
            }
        }

        void createDataBase(string[] detalis)
        {
            carti carti;
            carti.nume = detalis[0];
            carti.autor = detalis[1];
            carti.tip = detalis[2];
            carti.nr_exemplare = Convert.ToInt32(detalis[3]);
            bookDB.Add(carti);
        }

        public List<carti> getBookDataBase()
        {
            return bookDB;
        }

        public void decrement_exemplare(string carte, int value)
        {


        }


    }
}
