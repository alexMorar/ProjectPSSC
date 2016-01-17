using GalaSoft.MvvmLight.Command;
using ProjectPSSC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;

namespace ProjectPSSC.ViewModel
{
  public  class MainWindowViewModel : ObservableObject
    {
      private string _nameSearch;
      private string _listSearch;
      private string _books;
        public string NameSearch { get {return _nameSearch;} set{ Set(ref _nameSearch, value);} }
        public string ListSearch { get { return _listSearch; } set { Set(ref _listSearch, value); } }


        private string _nameImprumut;
        private string _nrTelefon;
        private string _cnp;
        private string _adresa;
        private DateTime _data;
        private string _titlu;

        public string NameImprumut { get { return _nameImprumut; } set { Set(ref _nameImprumut, value); } }
        public string NrTelefon { get { return _nrTelefon; } set { Set(ref _nrTelefon, value); } }
        public string CNP { get { return _cnp; } set { Set(ref _cnp, value); } }
        public string Adresa { get { return _adresa; } set { Set(ref _adresa, value); } }
        public DateTime Data { get { return _data; } set { Set(ref _data, value); } }
        public string Titlu { get { return _titlu; } set { Set(ref _titlu, value); } }

      public List<carti> books;
      BazeDate bd;
      public string Books { get { return _books; } set { Set(ref _books, value); } }

      public MainWindowViewModel()
      {
          bd = new BazeDate();
          books = new List<carti>();
          books = bd.getBookDataBase();
          printBooks(books);
      }
    
      private RelayCommand _searchBooksFromDb;
      
      public RelayCommand SearchBooksFromDb
      {
          get
          {
              return _searchBooksFromDb ?? (_searchBooksFromDb = new RelayCommand(() =>
              {
                  Books="";
                  Cautare cauta = new Cautare(bd);
                  List<carti> cartiGasite = new List<carti>();
                  cauta.cautareCarte(NameSearch, ListSearch);
                  cartiGasite = cauta.getCartiGasite();
                  printBooks(cartiGasite);
              }));
          }
      }

      void printBooks(List<carti> book)
      {
          foreach (carti carte in book)
          {
              Books+=(carte.nume + " " + carte.autor + " " + carte.tip + " " + carte.nr_exemplare.ToString() + "\n");
              Books+=("---------------------------------------------------------------------------------------------\n");
          }

      }


      private RelayCommand _afiseazaBooks;

      public RelayCommand AfiseazaBooks
      {
          get
          {
              return _afiseazaBooks ?? (_afiseazaBooks = new RelayCommand(() =>
              {
                  Books = "";
                  bd = new BazeDate();
                  books = new List<carti>();
                  books = bd.getBookDataBase();
                  printBooks(books);
              }));
          }
      }



      private RelayCommand _imprumutaCarte;

      public RelayCommand ImprumutaCarte
      {

          get
          {
              return _imprumutaCarte ?? (_imprumutaCarte = new RelayCommand(() =>
                  {
                      bd = new BazeDate();
                      Imprumut borrow = new Imprumut(bd, NameImprumut, NrTelefon, CNP, Adresa, Data.ToString(), Titlu);
                      borrow.imprumutCarte();
                  }));
          }
      }

    }
}
