using System.Globalization;
using System.Text.RegularExpressions;

namespace GetBirthdate
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(",--------------------------------------------------------,");
            Console.WriteLine("| Program pobierający datę urodzin w formacie dd.mm.rrrr |");
            Console.WriteLine("'--------------------------------------------------------'\n");
            // program pobiera prawidłowe daty począwszy od 01.01.1900 r.

            while (true)    
            {
                Console.Write("Podaj datę urodzin: ");
                /* wyrażenie regularne sprawdzające datę ze strony: https://regex101.com/r/hZ3nT4/1 */
                string pattern = @"(^(((0[1-9]|1[0-9]|2[0-8])[\.](0[1-9]|1[012]))|((29|30|31)[\.](0[13578]|1[02]))|((29|30)[\.](0[4,6,9]|11)))[\.](19|[2-9][0-9])\d\d$)|(^29[\.]02[\.](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)";
                string input = Console.ReadLine();
                if (input == "q") break;
                try
                {
                    var date = Regex.Matches(input, pattern)[0];
                    Console.WriteLine($"Podałeś prawidłową datę: {date}");
                    var cultureInfo = new CultureInfo("pl-PL");
                    string dateString = input;
                    var birthDate = DateTime.Parse(dateString, cultureInfo);
                    DateTime today = DateTime.Now;
                    TimeSpan age = today - birthDate;
                    int years = age.Days / 365;
                    Console.WriteLine($"Masz {years} lat.\n");
                    if (years >= 18)
                    {
                        Console.WriteLine("Jesteś pełnoletni/a.\n");
                    }
                }
                catch
                {
                    Console.WriteLine($"Podałeś złą datę: {input}\n");
                }
            }
        }
    }
}