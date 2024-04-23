using System;


namespace Zoologico.clases
{
    public class Zoologico
    {
        public List<Animal> lAnimal;
        public List<Cuidador> lCuidadores;

        public Zoologico()
        {
            lAnimal = new List<Animal>();
            lCuidadores = new List<Cuidador>();
        }

        //Metodos para administrar cuidadores
        public void agregarCuidador(Cuidador cuidador)
        {
            lCuidadores.Add(cuidador);

        }
        public void mostrarCuidadores()
        {
            foreach (Cuidador cuidador in lCuidadores)
            {
                cuidador.toString();
            }
            Console.WriteLine("Presione una tecla para continuar.");Console.ReadLine(); Console.Clear();
        }



        // Métodos para administrar animales
        public void agregarAnimal(Animal animal)
        {
            lAnimal.Add(animal);
        }

        public void mostrarAnimales()
        {
            foreach (Animal animal in lAnimal)
            {
                animal.presentarAnimal();
            }
            Console.WriteLine("Presione una tecla para continuar."); 
            Console.ReadLine(); 
            Console.Clear();
        }

        //------------------------------------------------------------------------------------
        public void abrirMenu()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("¡Bienvenido al Zoologico!");
                Console.WriteLine("Elija entre las siguientes opciones segun su situacion:");
                Console.WriteLine("1-Si es nuevo, cree una cuenta.");
                Console.WriteLine("2-Si ya tiene una cuenta, ingrese a su cuenta.");
                int opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1: crearCuenta(); break;
                    case 2: ingresarCuenta(); break;
                    default: continuar = false; break;
                }
            } while (continuar);
        }

        public void crearCuenta()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Bienvenido al menu de crear cuentas:");
            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese su numero de legajo: ");
            int legajo = int.Parse(Console.ReadLine());

            Cuidador cuid = new Cuidador(nombre, legajo);
            agregarCuidador(cuid);
            Console.WriteLine("Cuenta creada con exito.\nPresione cualquier tecla para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void ingresarCuenta()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Bienvenido al menu de ingresar cuentas:");
            Console.Write("Ingrese su legajo:");
            int leg = int.Parse(Console.ReadLine());

            if (lCuidadores.Count > 0)
            {
                foreach (var i in lCuidadores)
                {
                    if (i.legajo == leg)
                    {
                        Console.WriteLine("Cuenta ingresada con exito.\nPresione cualquier tecla para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine($"Bienvenido {i.nombre}, elija entre las siguientes opciones.");
                            Console.WriteLine("1-Agregar animales.\n2-Alimentar animales.\n3-Mostrar animales.\n4-Mostrar lista de cuidadores.\n5-Asignar cuidadores a los animales.\n6-Salir.");
                            int opc = int.Parse(Console.ReadLine());
                            switch (opc)
                            {
                                case 1: crearAnimal(); break;
                                case 2: alimentarAnimales(i); break;
                                case 3: mostrarAnimales(); break;
                                case 4: mostrarCuidadores(); break;
                                case 5: asignarCuidador(i); break;
                                case 6: return;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("OPCION INCORRECTA, INGRESE NUEVAMENTE LAS OPCIONES. PRESIONE UNA TECLA PARA CONTINUAR.");
                                    Console.ReadLine();
                                    Console.ResetColor();
                                    Console.Clear();break;
                            }
                        } while (true);

                    }
                }
            }
        }

        public void crearAnimal()
        {
            Console.Clear();
            Console.Write("Ingrese nombre del animal: ");
            string nombreAnimal = Console.ReadLine();
            Console.Write("Ingrese especie del animal: ");
            string especieAnimal = Console.ReadLine();
            Console.Write("Ingrese alimento principal del animal: ");
            string comidaDelAnimal = Console.ReadLine();

            Console.WriteLine("Ingrese que tipo de animal es:" +
                "\n1-Ave." +
                "\n2-Mamifero." +
                "\n3-Pez." +
                "\n4-Planta carnivora.");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Ave ave = new Ave(comidaDelAnimal, especieAnimal, nombreAnimal);
                    agregarAnimal(ave); break;
                case 2:
                    Mamifero mamifero = new Mamifero(comidaDelAnimal, especieAnimal, nombreAnimal);
                    agregarAnimal(mamifero); break;
                case 3:
                    Pez pez = new Pez(comidaDelAnimal, especieAnimal, nombreAnimal);
                    agregarAnimal(pez); break;
                case 4:
                    Planta planta = new Planta(comidaDelAnimal, especieAnimal, nombreAnimal);
                    agregarAnimal(planta); break;
                default: Console.WriteLine("Opcion invalida"); Console.Clear(); return;
            }
            Console.WriteLine("Animal creado con exito.Presione cualquier tecla para continuar.");
            Console.ReadLine();
            Console.Clear();
        }


        public void alimentarAnimales(Cuidador c)
        {
            Console.Clear();
            Console.WriteLine("Animales a los que puede alimentar: ");
            if (lAnimal.Count > 0)
            {
                mostrarAnimales();
                Console.Write("Ingrese el nombre del animal que quiera alimentar: ");
                string nombreAnimal = Console.ReadLine();
                foreach (Animal o in lAnimal)
                {
                    if (o.nombre == nombreAnimal)
                    {
                        Console.WriteLine($"El cuidador {c.nombre} esta alimentando a: ");
                        o.comer();
                        o.cuidador = c;
                        Console.WriteLine("Presione cualquier tecla para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay animales para alimentar.");
            }


        }
        public void asignarCuidador(Cuidador c)
        {
            Console.Clear();
            Console.WriteLine("La lista de los animales es la siguiente:");
            mostrarAnimales();
            Console.Write("Ingrese el nombre del animal al que desea asignar un cuidador: ");
            string nombreAnimal = Console.ReadLine();

            
            foreach (Animal animal in lAnimal)
            {
                if (animal.nombre == nombreAnimal)
                {
                    animal.cuidador = c;
                    Console.WriteLine($"Cuidador {c.nombre} asignado correctamente a {animal.nombre} ({animal.especie}).");
                    
                    break; // Salir del bucle después de encontrar y asignar el cuidador
                }
            }

           

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadLine();
            Console.Clear();
        }





    }
}

