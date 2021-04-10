using EfCore.Data;
using EfCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EFContext context = new EFContext("data source = DESKTOP-VGPBEL0; initial catalog = Study; user id = sa; password = jym0927*SqlServer");
            var alumnos = context.Alumnos.ToList();
            Alumno newAlumno = new Alumno()
            {
                Name = "Prueba",
                SurName = "Prueba"
            };
            context.Alumnos.Add(newAlumno);
            context.SaveChanges();

            var alumno = context.Alumnos.FirstOrDefault();
            alumno.SurName = "CAMBIANDO";
            context.Update(alumno);
            context.SaveChanges();
        }
    }
}
