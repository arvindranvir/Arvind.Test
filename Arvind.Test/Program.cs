using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using System.Text.RegularExpressions;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace Arvind.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //using MEF IOC
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            var _container = new CompositionContainer(catalog);

            var filter = _container.GetExportedValue<ISentenceFilter>();

            string sentence = string.Empty;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please Enter Q to quit, or enter your sentence");

                    sentence = Console.ReadLine();

                    if (string.Compare(sentence, "Q", true) == 0) return;

                    var KeyValue = filter.FindWordsAndCount(sentence);

                    foreach (var kv in KeyValue)
                    {
                        Console.WriteLine(kv.Key + "-" + kv.Value);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error has occured in the program, please try again to continue - error " + e.Message);
                }
            }
        }
    }
}
