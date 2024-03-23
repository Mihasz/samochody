using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();
            int licznik = 0;
            while (licznik == 0)
            {
                Console.WriteLine("Witaj na parkingu!");
                Console.WriteLine("1. Dodaj samochód do parkingu.");
                Console.WriteLine("5. Wyjdź.");
                Console.WriteLine("Wybierz co chcesz zrobić.");

                int numer = int.Parse(Console.ReadLine());

                while (numer != 1 && numer != 5)
                {
                    Console.WriteLine("Wprowadzono zły numer. Spróbuj ponownie.");
                    Console.WriteLine("Witaj na parkingu!");
                    Console.WriteLine("1. Dodaj samochód do parkingu.");
                    Console.WriteLine("5. Wyjdź");
                    Console.WriteLine("Wybierz co chcesz zrobić.");

                    numer = int.Parse(Console.ReadLine());

                }


                switch (numer)
                {
                    case 1:
                        parking.dodajSamochód();
                        licznik++;
                        break;
                    case 5:
                        Environment.Exit(0);

                        break;

                }


                while (licznik > 0)
                {
                    Console.WriteLine("Co chcesz robić dalej?");
                    Console.WriteLine("1. Dodaj samochód do parkingu.");
                    Console.WriteLine("2. Wypisz wszystkie samochody.");
                    Console.WriteLine("3. Usuń wybrany samochód.");
                    Console.WriteLine("4. Usuń ostatni samochód.");
                    Console.WriteLine("5. Wyjdź.");
                    numer = int.Parse(Console.ReadLine());
                    while (numer > 5)
                    {
                        Console.WriteLine("Wprowadzono zły numer. Spróbuj ponownie.");
                    }


                    switch (numer)
                    {
                        case 1:
                            parking.dodajSamochód();
                            break;
                        case 2:
                            parking.wypiszSamochody();
                            break;
                        case 3:
                            parking.usuńWybranysamochód();
                            break;
                        case 4:
                            parking.usuńOStatniSamochód();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }




                }

                Console.ReadKey();
            }
            }
        class Koło

        {
            public float średnica_felgi;
            public Koło()
            {

            }
            public Koło(float Średnica_felgi)
            {
                średnica_felgi = Średnica_felgi;
            }
        }
        class Silnik
        {

            public float pojemność;
            public string czyBenzyna;
            public Silnik()
            {

            }
            public Silnik(float Pojemność, string CzyBenzyna)
            {
                pojemność = Pojemność;
                czyBenzyna = CzyBenzyna;
            }
        }
        class Nadwozie
        {
            public string typNadwozia;
            public string kolor;
            public Nadwozie(string TypNadwozia, string Kolor)
            {
                typNadwozia = TypNadwozia;
                kolor = Kolor;
            }
            public Nadwozie()
            { }
        }
        class Samochód
        {
            Nadwozie Nadwozie = new Nadwozie();
            Silnik Silnik = new Silnik();
            Koło[] Koła = new Koło[4];
            public Samochód(Nadwozie nadwozie, Silnik silnik, Koło[] koła)
            {
                Nadwozie = nadwozie;
                Silnik = silnik;
                Koła = koła;
            }
            public override string ToString()
            {
                return $"Twoje samochody to:{Nadwozie.kolor}  {Nadwozie.typNadwozia} średnica felg to {Koła[0].średnica_felgi} cali";
            }
        }
        class Parking
        {
            
            
                List<Samochód> samochody = new List<Samochód>();
            public static int ileSamochodów;
            
                public void dodajSamochód()
                {
                    Console.WriteLine("Witaj!");
                    Console.WriteLine("Dodajmy twoje auto do parkingu.");
                    Console.WriteLine("Podaj nadwozie auta.");
                    string Nadwozie_auta = Console.ReadLine();
                    Console.WriteLine("Podaj średnice felgi auta w calach. (Zamiast '.' użyj ',' )");
                    float średnica_felgi_auta = float.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj kolor auta.");
                    string kolor_auta = Console.ReadLine();
                    Console.WriteLine("Podaj pojemność silnika w centymetrach sześciennych.");
                    float pojemność_silnika_auta = float.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj paliwo auta.");
                    string paliwo_auta = Console.ReadLine();

                    Koło koło1 = new Koło(średnica_felgi_auta);
                    Koło koło2 = new Koło(średnica_felgi_auta);
                    Koło koło3 = new Koło(średnica_felgi_auta);
                    Koło koło4 = new Koło(średnica_felgi_auta);
                    Koło[] koła = { koło1, koło2, koło3, koło4 };

                    Silnik silnik = new Silnik(pojemność_silnika_auta, paliwo_auta);
                    Nadwozie nadwozie = new Nadwozie(Nadwozie_auta, kolor_auta);
                     Samochód auto = new Samochód(nadwozie, silnik, koła);
                samochody.Add(auto);
                ileSamochodów++;

                }
                 public void wypiszSamochody()
                {   if (ileSamochodów == 0)
                    {
                        Console.WriteLine("Brak samochodów na parkingu.");
                    }
                    else
                    {
                    Console.WriteLine("Samochody na parkingu to:");
                    foreach (var i in samochody)
                    {
                        Console.WriteLine(i);
                    }
                    }
                }
            public void usuńOStatniSamochód()
                
            {
                if (ileSamochodów > 0)
                {
                    Console.WriteLine("Usunąłeś ostatni samochód.");
                    samochody.RemoveAt(ileSamochodów - 1);
                    ileSamochodów--;
                }
                else
                {
                    Console.WriteLine("Brak samochodów do usunięcia");
                }
                
                
            }
            public void usuńWybranysamochód()
            {
                Console.WriteLine("Który pojazd chcesz usunąć?");
                
                int dany_samochód = int.Parse(Console.ReadLine());

                if (dany_samochód > ileSamochodów)
                {
                    Console.WriteLine("Na parkingu nie ma tyle pojazdów");
                }
                else
                {
                    samochody.RemoveAt(dany_samochód - 1);
                    ileSamochodów--;
                }
            }
            
        }
    }

        
     

    
}
