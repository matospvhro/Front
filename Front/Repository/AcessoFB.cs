using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Front.Repository
{
    public class AcessoFB
    {
        private static readonly AcessoFB instanciaFireBird = new AcessoFB();

        //private AcessoFB() { }

        public static AcessoFB GetInstancia()
        {
            return instanciaFireBird;
        }

        public FbConnection GetConexao()
        {            
            string conn = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
            return new FbConnection(conn);
        }

        public bool TestarConexao()
        {
            bool boll = false;
            using (FbConnection conexaoFireBird = AcessoFB.GetInstancia().GetConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    boll = true;
                    conexaoFireBird.Close();
                }
                catch (Exception)
                {
                    return boll = false;
                }
            }
            return boll;
        }

        //public object BuscarMarca()
        //{
        //    using (FbConnection conexaoFireBird = AcessoFB.GetInstancia().GetConexao())
        //    {
        //        try
        //        {
        //            conexaoFireBird.Open();
        //            string mSQL = "select gp.id_marca_produto, gp.nome_marca_produto from marcas_produtos gp order by gp.nome_marca_produto";
        //            FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
        //            FbDataAdapter da = new FbDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            return dt;
        //        }

        //        catch (FbException fbex)
        //        {
        //            throw fbex;
        //        }
        //        finally
        //        {
        //            conexaoFireBird.Close();
        //        }
        //    }
        //}
    }
}