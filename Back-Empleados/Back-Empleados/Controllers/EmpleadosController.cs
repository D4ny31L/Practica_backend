using Back_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Back_Empleados.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods: "*")]
    public class EmpleadosController : ApiController
    {
        // GET: api/Empleados
        public IEnumerable<Empleados> Get()
        {
            GestorEmpleados gEmpleados = new GestorEmpleados();

            return gEmpleados.GetEmpleados();
        }

        // GET: api/Empleados/5
        public IEnumerable<Empleados> Get1(int id)
        {
            GestorEmpleados gEmpleados = new GestorEmpleados();

            return gEmpleados.GetOne(id);
        }

        // POST: api/Empleados
        public bool Post([FromBody]Empleados empleados)
        {
            GestorEmpleados gEmpleados = new GestorEmpleados();
            bool res = gEmpleados.Addempleado(empleados);

            return res;

        }

        // PUT: api/Empleados/5
        public bool Put(int id, [FromBody]Empleados empleados)
        {
            GestorEmpleados gEmpleados = new GestorEmpleados();
            bool res = gEmpleados.Updateempleado(id, empleados);

            return res;

        }

        // DELETE: api/Empleados/5
        public bool Delete(int id)
        {
            GestorEmpleados gEmpleados = new GestorEmpleados();
            bool res = gEmpleados.Deleteempleado(id);

            return res;
        }
    }
}
