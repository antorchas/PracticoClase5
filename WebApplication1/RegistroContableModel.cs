using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class RegistroContableModel
    {
        public int id {  get; set; }    
        public int idCuenta { get; set; }   
        public int tipo { get; set; }   
        public double monto { get; set; }
    }
}