using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Entidades
{
    public class Persona
    {
        private string Documento;
        private string Apellido;
        private string Nombre;
        public Persona(string Documento, string Apellido, string Nombre)

        {
            Documento = Documento;
            Nombre = Nombre;
            Apellido = Apellido;

        }

        public string DocumentoPersona
        {
            get => Documento;
            set => Documento = value;
        }

        public string ApellidoPersona
        {
            get => Apellido;
            set => Apellido = value;
        }
        public string NombrePersona
        {
            get => Nombre;
            set => Nombre = value;

        }

    }
}
