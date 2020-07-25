using System;
using System.Collections.Generic;
using System.Text;

namespace Tiendita.models
{
    class Usuario
    {
        public uint Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }

        public override string ToString()
        {
            return $"{Id}) Nombre: {Nombre} Contraseña: {Contrasenia}";
        }
    }
}
