using System;

namespace Zoologico.clases
{
    interface IAnimal
    {
        void comer();
        void presentarAnimal();
        
        
    }

    public class Animal : IAnimal
    {
        public string comida { get; set; }
        public string especie { get; set; }
        public string nombre { get; set; }
        public Cuidador cuidador { get; set; }

        public Animal()
        {
            comida = "a";
            especie = "a";
            nombre = "a";
            cuidador = new Cuidador("p", 4);
        }
        public Animal(string c, string e, string n)
        {
            comida = c;
            especie = e;
            nombre = n;
            cuidador = new Cuidador("p",4);
           
        }

        public void comer()
        {
            Console.WriteLine($"{nombre} ({especie}) con {comida}");
        }

        public void presentarAnimal()
        {
            Console.WriteLine($"Nombre: {nombre}, Especie: {especie}, Comida: {comida})");
        }
        
    }

    public class Ave : Animal
    {
        public Ave(string c, string e, string n) : base(c, e, n) { }

        public void volar()
        {
            Console.WriteLine($"{nombre} está volando");
        }
       
    }

    public class Mamifero : Animal
    {
        public Mamifero(string c, string e, string n) : base(c, e, n) { }

        public void amamantar()
        {
            Console.WriteLine($"{nombre} está amamantando");
        }
        
    }

    public class Pez : Animal
    {
        public Pez(string c, string e, string n) : base(c, e, n) { }

        public void nadar()
        {
            Console.WriteLine($"{nombre} está nadando");
        }
        
    }

    public class Planta: Animal
    {
        public Planta(string c,string e,string n) : base(c,e,n) { }
    }
}