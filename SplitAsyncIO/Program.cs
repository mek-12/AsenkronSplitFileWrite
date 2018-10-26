using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAsyncIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watcher = new Stopwatch();
            watcher.Start();
            var gameZone = GameCreator.CreateRandomElements(10000000);
            Console.WriteLine("Islem Basladi. Devam ediyor...");

            
            var r = Write10File(gameZone);
            r.Wait();
            watcher.Stop();

            Console.WriteLine("Ana Program bitti. Ana program için geçen süre : {0}", watcher.ElapsedMilliseconds.ToString());


            
        }

        public static async Task Write10File(List<GameElement> elements)
        {
            Stopwatch watcher = new Stopwatch();

            for (int i = 1; i<=10;i++)
            {
                watcher.Start();
                var list = elements.Skip((i - 1) * 1000000).Take(1000000).ToList();
                Console.WriteLine("{0}.nci dosya yazma işlemi başladı...",i);
                await WriteFileAsync(list, Path.Combine(Environment.CurrentDirectory, "GameZone_" + i.ToString()));
                watcher.Stop();
                Console.WriteLine("{0}.nci dosya yazma işlemi için {1} milisaniye geçti",i,watcher.ElapsedMilliseconds.ToString());
            }
        }


        public static async Task WriteFileAsync(List<GameElement> elements, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in elements)
                {
                    await writer.WriteLineAsync(item.ToString());
                }
            }
        }
    }
}
