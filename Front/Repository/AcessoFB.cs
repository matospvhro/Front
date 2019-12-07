using FirebirdSql.Data.FirebirdClient;
using Front.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            var conexao = "Sever=" + "127.0.0.1" + conn + "Database=" + "c:\\fdb\\dm.fdb";
            return new FbConnection(conexao);
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

        public IList<Produto> ListaProdutos()
        {
            using (FbConnection conexaoFireBird = AcessoFB.GetInstancia().GetConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from produto";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);

                    FbDataReader dr = cmd.ExecuteReader();
                    IList<Produto> lista = new List<Produto>();
                    while (dr.Read())
                    {
                        Produto p = new Produto();
                        p.ID_PRODUTO = (int)dr["ID_PRODUTO"];
                        p.Produtos_Descricoes = new AcessoFB().BuscarProdutoDescricoesPorId(p.ID_PRODUTO);
                        lista.Add(p);
                    }
                    return lista;
                }

                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        private Produtos_Descricoes BuscarProdutoDescricoesPorId(int iD_PRODUTO)
        {
            using (FbConnection conexaoFireBird = AcessoFB.GetInstancia().GetConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from produtos_descricoes p  where p.id_Produto = @Id";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.Parameters.AddWithValue("@id", iD_PRODUTO);
                    FbDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    Produtos_Descricoes p = new Produtos_Descricoes();
                    p.ID_PRODUTO = (string)dr["DESCRICAO"];

                    return p;
                }

                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
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