using System;
using System.Collections.Generic;
namespace Zoologico.clases
{

    public class Persona
    {
        public string nombre { get; set; }
        
        
        public Persona(string nombre)
        {
            this.nombre = nombre;
        }
    }
    public class Cuidador : Persona
    {
        public int legajo {  get; set; }

        public Cuidador(): base("p")
        {
            legajo = 0;
             
        }
        public Cuidador(string n,int leg):base(n)
        {
            legajo = leg;
        }
        

        public void toString()
        {
            Console.WriteLine($"Nombre: {nombre}, Legajo: {legajo}");
        }
    }
}