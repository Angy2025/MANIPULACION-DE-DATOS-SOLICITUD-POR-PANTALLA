using System;
namespace ManipulaciondeobjetosSolicitudPorPantalla
{
    class Empleado
    {
        // campos privados que se van a encapsular con propiedades publicas 
        private string nombre;
        private decimal salario;

        // get y set se usa para manipular propiedades 
        public string Nombre
        {
            get { return nombre; } //Encapsular dentro de la propiedad publica el campo que esta privado arriba 
            //obten el elemento (campo) nombre y retornalo - el encapsulado es meter una propiedad dentro de otra 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    nombre = value;
                else
                    nombre = "Sin nombre";

            }
        }

        public decimal Salario
        {
            get { return salario; }

            set
            {
                if (value >= 0)
                    salario = value;

                else
                    salario = 0;
            }
        }

        // crear un metodo para ocultarlo ; metodo que puede ser ocultado 

        public void MostrarInformacion()
        {


            Console.WriteLine($"Empleado; {Nombre}, Salario; {Salario} ");
        }

        // Clase Hija para ocultar miembro con Comision

        class EmpleadoConComision : Empleado
        {
            public decimal Comision { get; set; }
            
            //Es una propiedad porque sera utilizada para almacenar los datos de la conexion 
            // Es de tipo publico porque la conexion DEBE ser publica ---- Ocultacion de miembros usando NEW 


            public new void MostrarInformacion()
            {
                //Solicitud de info. al usuario
                Console.WriteLine("\n _______Informacion del Empleado Con comision________");
                Console.WriteLine($"Nombre: {Nombre}");
                Console.WriteLine($"Salario: {Salario}");
                Console.WriteLine($"Comision: {Comision}");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {

                EmpleadoConComision emp = new EmpleadoConComision(); // <- usar la clase hija

                //Creacion de objetos para el empleado porque Elian no vino hoy y hay que dar todos los temas 

                Empleado emp1 = new Empleado();
                Console.WriteLine("Nombre del Empleado: ");
                emp.Nombre = Console.ReadLine();

                Console.WriteLine($"Ingrese el salario del empleado");
                decimal salario = Convert.ToDecimal(Console.ReadLine());
                emp.Salario = salario;


                Console.WriteLine("Ingrese el porcentaje de comision (20 = 20%): ");
                decimal porcentaje = Convert.ToDecimal(Console.ReadLine());
                emp.Comision = emp.Salario * (porcentaje / 100);

                //Mostrar la informacion obtenida y calculada:
                emp.MostrarInformacion();

                Console.ReadKey();
            }

        }

    }
}
