using Acosta.Data;
using Acosta.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TraspasoAcoVerde.AuxClasses
{
    public static class GeneralFunctions
    {
        /// <summary>
        /// Metodo para validar los permisos de usuario
        /// </summary>
        /// <param name="motivo"></param>
        /// <returns></returns>
        public static bool ValidaPermisosUsuario(ref string motivo)
        {
            try
            {
                var datoCokie = GetCookie("TRSis");
                Data_GeneralFunctions data_GeneralFunctions = new Data_GeneralFunctions();


                var usuario = new UserModel();
                if (!string.IsNullOrEmpty(datoCokie))                  
                {
                    DataTable t_resultado = new DataTable();
                    t_resultado = data_GeneralFunctions.ValidaAccesoSistema(datoCokie, GetIdAplicacion()); 
                                                                                                
                    if (t_resultado.Rows.Count > 0)
                    {
                        usuario.IdGav = t_resultado.Rows[0][0].ToString();

                        var datosUsuario = data_GeneralFunctions.ConsultarMenuUsuario(usuario.IdGav);
                        if (datosUsuario == null)
                        {
                            motivo = "Datos del usuario no encontrados cookie " + datoCokie + " idapli " + GetIdAplicacion();
                            return false;

                        }
                        HttpContext.Current.Session["Usuario" + HttpContext.Current.Session.SessionID] = datosUsuario;
                        HttpContext.Current.Session["Username"] = datosUsuario.NombreCompleto;
                        HttpContext.Current.Session["Rol"] = datosUsuario.Rol;
                        if (!ValidaPermisos(0))
                        {
                            motivo = " PErmiso del usaurio no enocntrados idusuario " + GetIdGav() + " idapli " + GetIdAplicacion();
                            return false;

                        }

                        return true;
                    }
                    else
                    {
                        motivo = "no tiene permisos o no se encutra en la otra bd idaplicacion " + GetIdAplicacion() + " cockie" + GetCookie("TRSis");

                        //Si el usuario no cuenta con Permisos se re-direcciona a la pantalla de Login
                        return false;
                    }
                }
                else
                {
                    motivo = "no hay cookie";
                    return false;
                }

            }
            catch (Exception ex)
            {
                motivo = "otro error" + ex.Message;
                throw ex;

            }
        }

        public static string GetCookie(string key)
        {
            string value = "";
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key))
            {
                value = HttpContext.Current.Request.Cookies[key].Value;
            }
            return value;
        }

        public static string GetIdAplicacion()
        {
            string controlador = ((string)HttpContext.Current.Session["Controlador" + HttpContext.Current.Session.SessionID]);
            Data_GeneralFunctions data_GeneralFunctions = new Data_GeneralFunctions();
            var idAplicacion = data_GeneralFunctions.ConsultarIdAplicacion(controlador, "1006");
            return idAplicacion;


        }

        public static string GetIdGav()
        {
            var datosLogin = (UserModel)HttpContext.Current.Session["Usuario" + HttpContext.Current.Session.SessionID];
            return datosLogin.IdGav;

        }

        public static bool ValidaPermisos(int Permiso)
        {
            try
            {
                bool Autorizado;

                UserPermissionsModel permisos = new UserPermissionsModel();
                Data_GeneralFunctions validacion = new Data_GeneralFunctions(); //Variable para llamar las funciones de validacion de permisos de usuario.

                var mySession = HttpContext.Current.Session;
                var lstPermisos = validacion.ConsultarMenuUsuario(GetIdGav()).LstPermisos;
                string Controlador = ((String)mySession["Controlador" + mySession.SessionID]);

                permisos = lstPermisos.Where(d => d.NombreMenu == Controlador).FirstOrDefault();
                
                //1.- Guardar
                //2.- Editar
                //3.- Imprimir
                //4.- Eliminar

                switch (Permiso)
                {
                    case 0:
                        Autorizado = (permisos == null ? false : permisos.Ver);
                        break;
                    case 1:
                        Autorizado = (permisos == null ? false : permisos.Guardar);
                        break;
                    case 2:
                        Autorizado = (permisos == null ? false : permisos.Modificar);
                        break;
                    case 3:
                        Autorizado = (permisos == null ? false : permisos.Imprimir);
                        break;
                    case 4:
                        Autorizado = (permisos == null ? false : permisos.Eliminar);
                        break;
                    default:
                        Autorizado = false;
                        break;

                }



                return Autorizado;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static string ObtenerRutaRedireccion()
        {

            string url = WebConfigurationManager.AppSettings["RedireccionLogin"];
            return string.Format(url + "?AP={0}&T=x", GetIdAplicacion());

        }
    }
}