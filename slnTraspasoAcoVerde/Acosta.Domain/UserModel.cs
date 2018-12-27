using System;
using System.Collections.Generic;

namespace Acosta.Domain
{
    public class UserModel
    {
        public long IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        public string Departamentos { get; set; }
        public string Plazas { get; set; }
        public bool Activo { get; set; }
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string IdGav { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public long IdUJefeDirecto { get; set; }
        public List<long> LstDepartamentos { get; set; }
        public List<long> LstPlazas { get; set; }
        public List<UserPermissionsModel> LstPermisos { get; set; }
        public List<UserMenuModel> LstMenu { get; set; }
    }
}
