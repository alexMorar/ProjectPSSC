using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProjectPSSC.Model
{
    public class Imprumut
    {
    List<carti> carti = new List<carti>();

        private string nume;
        private string nr_tel;
        private string cnp;
        private string adresa;
        private string data;
        private string titlu;


        public string Nume
        {
            get { return nume; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (Regex.IsMatch(value, "^[a-zA-Z]+$") == false)
                {
                    throw new NoGoodInputException();
                }
                nume = value;
            }
        }

        public string Nr_Telefon
        {
            get { return nr_tel; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                if (value.Length != 10)
                    throw new NoGoodInputException();

                if (Regex.IsMatch(value, "^[0-9]+$") == false)
                {
                    throw new NoGoodInputException();
                }
                
                nr_tel = value;
            }
        }


        public string CNP
        {
            get { return cnp; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                if (value.Length != 13)
                    throw new NoGoodInputException();

                if (Regex.IsMatch(value, "^[0-9]+$") == false)
                {
                    throw new NoGoodInputException();
                }
                cnp = value;
            }
        }

        public string Adresa
        {
            get { return adresa; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (Regex.IsMatch(value, "^[a-zA-Z]+$") == false)
                {
                    throw new NoGoodInputException();
                }
                adresa = value;
            }
        }

        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        public string Titlu
        {
            get { return titlu; }
            set{   titlu = value;}
        }

        public Imprumut(IBazeDate b, string nume, string nr_tel, string cnp, string adresa, string data, string titlu)
        {
            carti = b.getBookDataBase();
            Console.WriteLine("DataBase is uploaded!");
            Nume = nume;
            Nr_Telefon = nr_tel;
            CNP = cnp;
            Adresa = adresa;
            Data = Data;
            Titlu = titlu;

        }

        public void imprumutCarte()
        {
            int aux;
            try
            {
                foreach (carti carte in carti)
                {
                    if (carte.nume == titlu)
                    {
                        if (carte.nr_exemplare > 0)
                        {
                            Console.WriteLine("Cartea s-a imprumutat cu succes!");
                            aux = carte.nr_exemplare;
                            aux--;
                            Console.WriteLine(aux);
                            Console.WriteLine("nr carti:" + aux);
                        }
                        else throw new NotEnoughValueException();                
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Nu exista carti!");
                Console.WriteLine(e.Message);
            }
            
        }
       
    }

    public class NoGoodInputException : ApplicationException  
    {
    }
    public class NotEnoughValueException : ApplicationException
    {
    }
}
