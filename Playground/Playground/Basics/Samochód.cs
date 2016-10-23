using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Basics
{
    class Samochód
    {
        public Samochód(string kolor)
        {
            Kolor = kolor;
        }

        public string Kolor { get; }

        private int prędkość = 0;

        public void Jedź() {
            Console.WriteLine("jedziemy");
        }

        public void Skrencaj() {
        }

        public int Przyśpiesz()
        {
            Console.WriteLine("przyśpieszamy");
            prędkość = prędkość + 2;
            return prędkość;
        }

        public override string ToString()
        {
            return "Kolor " + Kolor;
        }
    }


    [TestFixture]
    class SamochódTest {

        [Test]
        public void JedźDoPrzodu() {
            Samochód mercedes = new Samochód("niebieski");
            
            mercedes.Jedź();

            var ford = new Samochód("czerwony");
            ford.Jedź();
            
            var prędkośćForda = ford.Przyśpiesz();

            Console.WriteLine("prędkość forda " + prędkośćForda);
            Console.WriteLine("prędkość forda " + ford.Przyśpiesz());
            Console.WriteLine("prędkość forda " + new Samochód("czarny"));

        }
    }
}
