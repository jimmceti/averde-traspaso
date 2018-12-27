using System;
using System.Collections.Generic;
using System.Text;

namespace Acosta.Domain
{
    public class UserMenuModel
    {
        public int IdMenu { get; set; }
        public int? IdMenuPadre { get; set; }
        public string Descripcion { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public bool Activo { get; set; }
        public long Orden { get; set; }
        public int Nivel { get; set; }
        public string Icono { get; set; }
        public string IdAplicacion { get; set; }
    }
}
