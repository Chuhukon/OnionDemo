using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Core;
using OnionDemo.Core.Base;
using OnionDemo.Core.Model;
using OnionDemo.Core.Services;

namespace OnionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start application
            IDependencyInitializer DI = CreateDependencyInitializer();
            DI.Start();

            //initialize 
            IAlbumRepository repository = ServiceLocator.Current.GetInstance<IAlbumRepository>();
            IValidationDictionary dictionary = ServiceLocator.Current.GetInstance<IValidationDictionary>();
            AlbumService albumService = new AlbumService(repository, dictionary);

            //Do some UI stuff

            ConsoleKeyInfo key;
            do
            {
                Console.Write("\nAlbum name  : ");
                var name = Console.ReadLine();
                Console.Write("Artist name : ");
                var artist = Console.ReadLine();

                albumService.CreateAlbum(new Album
                {
                    Name = name,
                    Artist = artist,
                    Genre = Genre.Pop //default value
                });

                Console.Write("(A)dd a new artist or (Q)uit. : ");
                key = Console.ReadKey();

            } while (key.KeyChar.Equals('A') || key.KeyChar.Equals('a'));

            Console.WriteLine("\nCurrently in the database: ");
            foreach (var item in repository.All)
                Console.WriteLine("{0} - {1}", item.Name, item.Artist);

            Console.ReadLine();
        }

        /// <summary>
        /// Factory function to create the DependencyInitializer..
        /// </summary>
        /// <returns></returns>
        public static IDependencyInitializer CreateDependencyInitializer()
        {
            //you can use the app.config to configure these items..
            var assembly = System.Reflection.Assembly.Load("OnionDemo.DependencyResolution");
            Type T = assembly.GetType("OnionDemo.DependencyResolution.Initializers.ConsoleInitializer", false, true);

            if (T != null) 
            {
                return (IDependencyInitializer)Activator.CreateInstance(T); 
            }

            throw new ApplicationException("There is no DependencyInitializer configured");
        }
    }

    public class Validation : IValidationDictionary
    {
        private bool isValid;

        public Validation()
        {
            isValid = true;
        }

        public void AddError(string key, string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", errorMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
            isValid = false;
        }

        public bool IsValid
        {
            get
            {
                return isValid;
            }
        }
    }

}
