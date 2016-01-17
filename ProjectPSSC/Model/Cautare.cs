using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPSSC.Model
{
    public class Cautare 
    {
        List<carti> books = new List<carti>();
        List<carti> CartiGasite;

      public Cautare(BazeDate b) 
        {
            books = b.getBookDataBase();
            CartiGasite = new List<carti>();
        }

        public void cautareCarte(string identificator, string nume)
        {

            if (identificator == "NumeCarte")
                {
                    cautaNume(nume);
                }
            else if (identificator == "Autor")
                {
                    cautaAutor(nume);
                }
            else if (identificator == "Tip")
                { 
                    cautaTip(nume);
                }
        }


        void cautaNume(string id)
        {
            
            foreach (carti book in books)
            {
                if (book.nume == id)
                {
                   CartiGasite.Add(book);
                }
            }
        }

        void cautaTip(string id)
        {
            foreach (carti book in books)
            {
                if (book.tip == id)
                {
                    CartiGasite.Add( book);
                }

            }
        }

        void cautaAutor(string id)
        {
            foreach (carti book in books)
            {
                if (book.autor == id)
                {
                    CartiGasite.Add(book);
                }
            }
        }

        public List<carti> getCartiGasite()
        {
            return CartiGasite;
        }
    }
}
