using System;
using System.IO;
using System.Text;
using TeachMeSkills.DotNet.ApiApplicationCore.Interfaces;
using TeachMeSkills.DotNet.ApiApplicationCore.Services;

namespace TeachMeSkills.DotNet.ApiApplicationUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter cocktail name: ");
            var userInput = Console.ReadLine();
            IRequestService requestService = new RequestService();
            
            var response = requestService.SearchAsync(userInput).GetAwaiter().GetResult();
            if (response.drinks is null)
            {
                Console.WriteLine("Nothing found.. :(");
                Console.ReadKey();
                return;
            }

            var writePath = $"thecocktaildb_{Guid.NewGuid()}.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                foreach (var item in response.drinks)
                {
                    sw.WriteLine(item.strDrink);
                    sw.WriteLine(item.strInstructions);
                    sw.WriteLine("---");
                }
            }

            Console.ReadKey();
        }
    }
}
