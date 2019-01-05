using Acosta.Domain;
using System;
using System.Data;
using UniversalDatabaseConectorV_Optimizada_2;

namespace Acosta.Data
{
    public class DbFunctions
    {
        DbConn cnn = new DbConn();

        public DataSet Ds_SPE_CONSULTAR(ParametersModel parametros)
        {
            try
            {
                string NombreSp = "[SPE_CONSULTAR]";
                #region Variables_Control
                object[] Param_Accion = { "@Accion", parametros.Accion };
                object[] Param_p1 = { "@p1", parametros.P1 };
                object[] Param_p2 = { "@p2", parametros.P2 };
                object[] Param_p3 = { "@p3", parametros.P3 };
                object[] Param_p4 = { "@p4", parametros.P4 };
                object[] Param_p5 = { "@p5", parametros.P5 };
                object[] Param_p6 = { "@p6", parametros.P6 };
                object[] Param_p7 = { "@p7", parametros.P7 };
                object[] Param_p8 = { "@p8", parametros.P8 };
                object[] Param_p9 = { "@p9", parametros.P9 };
                object[] Param_p10 = { "@p10", parametros.P10 };
                object[] Param_idgav = { "@idgav", parametros.Idgav };
                #endregion
                #region Variables_Texto
                object[] Param_pstr1 = { "@pstr1", parametros.Pstr1 };
                object[] Param_pstr2 = { "@pstr2", parametros.Pstr2 };
                object[] Param_pstr3 = { "@pstr3", parametros.Pstr3 };
                object[] Param_pstr4 = { "@pstr4", parametros.Pstr4 };
                object[] Param_pstr5 = { "@pstr5", parametros.Pstr5 };
                object[] Param_pstr6 = { "@pstr6", parametros.Pstr6 };
                object[] Param_pstr7 = { "@pstr7", parametros.Pstr7 };
                object[] Param_pstr8 = { "@pstr8", parametros.Pstr8 };
                object[] Param_pstr9 = { "@pstr9", parametros.Pstr9 };
                object[] Param_pstr10 = { "@pstr10", parametros.Pstr10 };
                object[] Param_pstr11 = { "@pstr11", parametros.Pstr11 };
                object[] Param_pstr12 = { "@pstr12", parametros.Pstr12 };
                object[] Param_pstr13 = { "@pstr13", parametros.Pstr13 };
                object[] Param_pstr14 = { "@pstr14", parametros.Pstr14 };
                object[] Param_pstr15 = { "@pstr15", parametros.Pstr15 };
                object[] Param_pstr16 = { "@pstr16", parametros.Pstr16 };
                object[] Param_pstr17 = { "@pstr17", parametros.Pstr17 };
                object[] Param_pstr18 = { "@pstr18", parametros.Pstr18 };
                object[] Param_pstr19 = { "@pstr19", parametros.Pstr19 };
                object[] Param_pstr20 = { "@pstr20", parametros.Pstr20 };
                #endregion
                #region Variables_Numerico
                object[] Param_pdec1 = { "@pdec1", parametros.Pdec1 };
                object[] Param_pdec2 = { "@pdec2", parametros.Pdec2 };
                object[] Param_pdec3 = { "@pdec3", parametros.Pdec3 };
                object[] Param_pdec4 = { "@pdec4", parametros.Pdec4 };
                object[] Param_pdec5 = { "@pdec5", parametros.Pdec5 };
                object[] Param_pdec6 = { "@pdec6", parametros.Pdec6 };
                object[] Param_pdec7 = { "@pdec7", parametros.Pdec7 };
                object[] Param_pdec8 = { "@pdec8", parametros.Pdec8 };
                object[] Param_pdec9 = { "@pdec9", parametros.Pdec9 };
                object[] Param_pdec10 = { "@pdec10", parametros.Pdec10 };
                object[] Param_pdec11 = { "@pdec11", parametros.Pdec11 };
                object[] Param_pdec12 = { "@pdec12", parametros.Pdec12 };
                object[] Param_pdec13 = { "@pdec13", parametros.Pdec13 };
                object[] Param_pdec14 = { "@pdec14", parametros.Pdec14 };
                object[] Param_pdec15 = { "@pdec15", parametros.Pdec15 };
                object[] Param_pdec16 = { "@pdec16", parametros.Pdec16 };
                object[] Param_pdec17 = { "@pdec17", parametros.Pdec17 };
                object[] Param_pdec18 = { "@pdec18", parametros.Pdec18 };
                object[] Param_pdec19 = { "@pdec19", parametros.Pdec19 };
                object[] Param_pdec20 = { "@pdec20", parametros.Pdec20 };
                #endregion
                #region Variables_XML
                object[] Param_pxml = { "@pxml", parametros.Pxml };
                #endregion

                return cnn.EjecutarSpDataReader(NombreSp, cnn.CRM, Param_Accion
                    , Param_p1, Param_p2, Param_p3, Param_p4, Param_p5, Param_p6, Param_p7, Param_p8, Param_p9, Param_p10, Param_idgav
                    , Param_pstr1, Param_pstr2, Param_pstr3, Param_pstr4, Param_pstr5, Param_pstr6, Param_pstr7, Param_pstr8, Param_pstr9, Param_pstr10
                    , Param_pstr11, Param_pstr12, Param_pstr13, Param_pstr14, Param_pstr15, Param_pstr16, Param_pstr17, Param_pstr18, Param_pstr19, Param_pstr20
                    , Param_pdec1, Param_pdec2, Param_pdec3, Param_pdec4, Param_pdec5, Param_pdec6, Param_pdec7, Param_pdec8, Param_pdec9, Param_pdec10
                    , Param_pdec11, Param_pdec12, Param_pdec13, Param_pdec14, Param_pdec15, Param_pdec16, Param_pdec17, Param_pdec18, Param_pdec19, Param_pdec20
                    , Param_pxml
                    );
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                DataSet ds = new DataSet();
                return ds;
            }
        }

        public DataSet Ds_SPE_CONSULTAR_PERMISO(string token, string idPantalla)
        {
            try
            {
                var parametros = new ParametersModel();
                string NombreSp = "SPE_CONSULTAR";
                #region Variables_Control
                object[] Param_Accion = { "@Accion", 1 };
                object[] Param_p1 = { "@p1", parametros.P1 };
                object[] Param_p2 = { "@p2", parametros.P2 };
                object[] Param_p3 = { "@p3", parametros.P3 };
                object[] Param_p4 = { "@p4", parametros.P4 };
                object[] Param_p5 = { "@p5", parametros.P5 };
                object[] Param_p6 = { "@p6", parametros.P6 };
                object[] Param_p7 = { "@p7", parametros.P7 };
                object[] Param_p8 = { "@p8", parametros.P8 };
                object[] Param_p9 = { "@p9", parametros.P9 };
                object[] Param_p10 = { "@p10", parametros.P10 };
                object[] Param_idgav = { "@idgav", parametros.Idgav };
                #endregion
                #region Variables_Texto
                object[] Param_pstr1 = { "@pstr1", token };
                object[] Param_pstr2 = { "@pstr2", idPantalla };
                object[] Param_pstr3 = { "@pstr3", parametros.Pstr3 };
                object[] Param_pstr4 = { "@pstr4", parametros.Pstr4 };
                object[] Param_pstr5 = { "@pstr5", parametros.Pstr5 };
                object[] Param_pstr6 = { "@pstr6", parametros.Pstr6 };
                object[] Param_pstr7 = { "@pstr7", parametros.Pstr7 };
                object[] Param_pstr8 = { "@pstr8", parametros.Pstr8 };
                object[] Param_pstr9 = { "@pstr9", parametros.Pstr9 };
                object[] Param_pstr10 = { "@pstr10", parametros.Pstr10 };
                object[] Param_pstr11 = { "@pstr11", parametros.Pstr11 };
                object[] Param_pstr12 = { "@pstr12", parametros.Pstr12 };
                object[] Param_pstr13 = { "@pstr13", parametros.Pstr13 };
                object[] Param_pstr14 = { "@pstr14", parametros.Pstr14 };
                object[] Param_pstr15 = { "@pstr15", parametros.Pstr15 };
                object[] Param_pstr16 = { "@pstr16", parametros.Pstr16 };
                object[] Param_pstr17 = { "@pstr17", parametros.Pstr17 };
                object[] Param_pstr18 = { "@pstr18", parametros.Pstr18 };
                object[] Param_pstr19 = { "@pstr19", parametros.Pstr19 };
                object[] Param_pstr20 = { "@pstr20", parametros.Pstr20 };
                #endregion
                #region Variables_Numerico
                object[] Param_pdec1 = { "@pdec1", parametros.Pdec1 };
                object[] Param_pdec2 = { "@pdec2", parametros.Pdec2 };
                object[] Param_pdec3 = { "@pdec3", parametros.Pdec3 };
                object[] Param_pdec4 = { "@pdec4", parametros.Pdec4 };
                object[] Param_pdec5 = { "@pdec5", parametros.Pdec5 };
                object[] Param_pdec6 = { "@pdec6", parametros.Pdec6 };
                object[] Param_pdec7 = { "@pdec7", parametros.Pdec7 };
                object[] Param_pdec8 = { "@pdec8", parametros.Pdec8 };
                object[] Param_pdec9 = { "@pdec9", parametros.Pdec9 };
                object[] Param_pdec10 = { "@pdec10", parametros.Pdec10 };
                object[] Param_pdec11 = { "@pdec11", parametros.Pdec11 };
                object[] Param_pdec12 = { "@pdec12", parametros.Pdec12 };
                object[] Param_pdec13 = { "@pdec13", parametros.Pdec13 };
                object[] Param_pdec14 = { "@pdec14", parametros.Pdec14 };
                object[] Param_pdec15 = { "@pdec15", parametros.Pdec15 };
                object[] Param_pdec16 = { "@pdec16", parametros.Pdec16 };
                object[] Param_pdec17 = { "@pdec17", parametros.Pdec17 };
                object[] Param_pdec18 = { "@pdec18", parametros.Pdec18 };
                object[] Param_pdec19 = { "@pdec19", parametros.Pdec19 };
                object[] Param_pdec20 = { "@pdec20", parametros.Pdec20 };
                #endregion
                #region Variables_XML
                object[] Param_pxml = { "@pxml", parametros.Pxml };
                #endregion

                return cnn.EjecutarSpDataReader(NombreSp, cnn.GAV_SAFE, Param_Accion
                    , Param_p1, Param_p2, Param_p3, Param_p4, Param_p5, Param_p6, Param_p7, Param_p8, Param_p9, Param_p10, Param_idgav
                    , Param_pstr1, Param_pstr2, Param_pstr3, Param_pstr4, Param_pstr5, Param_pstr6, Param_pstr7, Param_pstr8, Param_pstr9, Param_pstr10
                    , Param_pstr11, Param_pstr12, Param_pstr13, Param_pstr14, Param_pstr15, Param_pstr16, Param_pstr17, Param_pstr18, Param_pstr19, Param_pstr20
                    , Param_pdec1, Param_pdec2, Param_pdec3, Param_pdec4, Param_pdec5, Param_pdec6, Param_pdec7, Param_pdec8, Param_pdec9, Param_pdec10
                    , Param_pdec11, Param_pdec12, Param_pdec13, Param_pdec14, Param_pdec15, Param_pdec16, Param_pdec17, Param_pdec18, Param_pdec19, Param_pdec20
                    , Param_pxml
                    );
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                DataSet ds = new DataSet();
                return ds;
            }
        }

        public DataSet Ds_SPPrueba_ConexionDLL(string CadenaConexion)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = cnn.EjecutarSpDataReader(ProceduresName.sel_FechaHoraSQL, CadenaConexion);
            }
            catch (Exception e)
            {
                ds = new DataSet();
                throw e;
            }
            return ds;
        }
    }
}
