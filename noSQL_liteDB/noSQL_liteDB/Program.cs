using LiteDB;
using System;

namespace noSQL_liteDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new LiteDatabase(@"db.db"))
            {
                var col = db.GetCollection<Auto>("Autos");

                foreach (var item in col.Query().ToList())
                {
                    Console.WriteLine(item.Hersteller);
                }
                col.Insert(new Auto() { Hersteller = "Baudi",Modell="B66" });


            }

            Console.ReadLine();

        }
    }
    class Auto
    {
        public int Id { get; set; }
        public string Hersteller { get; set; }
        public string Modell { get; set; }

    }
}
