using Acosta.Domain;
using System;
using System.Data;
using System.Linq;

namespace Acosta.Data
{
    public class Data_GeneralFunctions
    {
        DbFunctions func = new DbFunctions();

        public UserModel ConsultarMenuUsuario(string idGav)
        {

            try
            {
                string p10 = System.Web.Configuration.WebConfigurationManager.AppSettings["P10"];
                var datosparametos = new ParametersModel
                {
                    Accion = "26",
                    P10 = p10,
                    Pdec1 = idGav,
                    Idgav = idGav
                };
                var lstConsultaR = func.Ds_SPE_CONSULTAR(datosparametos);
                
                var datosUsuarioLogin = (from DataRow g in lstConsultaR.Tables[0].Rows
                                         select new UserModel
                                         {
                                             NombreCompleto = (g["NombreCompleto"].ToString()),
                                             Rol = (g["Rol"].ToString()),
                                             IdGav = idGav,
                                             IdUsuario = Convert.ToInt64(g["IdUsuario"].ToString()),
                                             IdTipoUsuario = Convert.ToInt32(g["IdTipoUsuario"].ToString()),
                                             LstMenu = (from DataRow d in lstConsultaR.Tables[1].Rows
                                                        select new UserMenuModel
                                                        {
                                                            Accion = (d["Accion"] == DBNull.Value ? "" : d["Accion"].ToString()),
                                                            Descripcion = d["Descripcion"].ToString(),
                                                            Icono = d["Icono"].ToString(),
                                                            IdAplicacion = (d["IdAplicacion"] == DBNull.Value ? "" : d["IdAplicacion"].ToString()),
                                                            Nivel = Convert.ToInt32(d["Nivel"].ToString()),
                                                            Orden = Convert.ToInt64(d["Orden"].ToString()),
                                                            IdMenu = Convert.ToInt32(d["IdMenu"].ToString()),
                                                            IdMenuPadre = (d["IdMenuPadre"] == DBNull.Value ? 0 : Convert.ToInt32(d["IdMenuPadre"].ToString())),
                                                            Controlador = d["Controlador"].ToString(),
                                                            Activo = Convert.ToBoolean(d["Activo"].ToString()),

                                                        }).ToList(),
                                             LstPermisos = (from DataRow f in lstConsultaR.Tables[1].Rows
                                                            select new UserPermissionsModel
                                                            {
                                                                Ver = Convert.ToBoolean(f["Ver"].ToString()),
                                                                Modificar = Convert.ToBoolean(f["Modificar"].ToString()),
                                                                Guardar = Convert.ToBoolean(f["Guardar"].ToString()),
                                                                Eliminar = Convert.ToBoolean(f["Eliminar"].ToString()),
                                                                Imprimir = Convert.ToBoolean(f["Imprimir"].ToString()),
                                                                IdMenu = Convert.ToInt32(f["IdMenu"].ToString()),
                                                                NombreMenu = f["Controlador"].ToString(),
                                                            }).ToList()
                                         }).FirstOrDefault();
                return datosUsuarioLogin;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string ConsultarIdAplicacion(string controlador, string idGav)
        {

            try
            {
                string p10 = System.Web.Configuration.WebConfigurationManager.AppSettings["P10"];
                var datosparametos = new ParametersModel
                {
                    Accion = "27",
                    P10 = p10,
                    Pstr1 = controlador,
                    Idgav = idGav
                };
                var datosConsultar = func.Ds_SPE_CONSULTAR(datosparametos).Tables[0];
                var idAPlicacion = "";
                if (datosConsultar.Rows[0][0] != DBNull.Value)
                    idAPlicacion = datosConsultar.Rows[0][0].ToString();

                return idAPlicacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ValidaAccesoSistema(string token, string idAplicaicon)
        {

            try
            {
                return func.Ds_SPE_CONSULTAR_PERMISO(token, idAplicaicon).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable Prueba_Conexion_porDLL(string cadenaConexion)
        {

            try
            {
                return func.Ds_SPPrueba_ConexionDLL(cadenaConexion).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
