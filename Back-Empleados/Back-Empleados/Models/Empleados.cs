using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Back_Empleados.Models
{
    public class Empleados
    {
        public int ID_empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string Nacimiento { get; set; }


        public Empleados() { }

        public Empleados(int ID, string nombre, string apellidop, string apellidom, string telefono, string sexo, string nacimiento)
        {
            ID_empleado = ID;
            Nombre = nombre;
            Apellidop = apellidop;
            Apellidom = apellidom;
            Telefono = telefono;
            Sexo = sexo;
            Nacimiento = nacimiento;
            
        }

        public Empleados(string nombre, string apellidop, string apellidom, string telefono, string sexo, string nacimiento)
        {
            Nombre = nombre;
            Apellidop = apellidop;
            Apellidom = apellidom;
            Telefono = telefono;
            Sexo = sexo;
            Nacimiento = nacimiento;
        }
    }
}