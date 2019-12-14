using FirebirdSql.Data.FirebirdClient;
using Front.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
            var conexao =  conn;
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
                    string mSQL = "select * from  produtos p where p.envia_web = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);

                    FbDataReader dr = cmd.ExecuteReader();
                    IList<Produto> lista = new List<Produto>();
                    while (dr.Read())
                    {
                        Produto p = new Produto();
                        p.ID_PRODUTO = (string)dr["ID_PRODUTO"];
                        p.CODIGO_FABRICANTE = (string)dr["CODIGO_FABRICANTE"];
                        p.Produtos_Descricoes = new AcessoFB().BuscarProdutoDescricoesPorId(p.ID_PRODUTO);
                        p.Produto_Estoque = new AcessoFB().BuscarProdutoEstoquePorId(p.ID_PRODUTO);
                        p.Produto_Preco = new AcessoFB().BuscarProdutoPorPrecoPorId(p.ID_PRODUTO);
                        p.Foto = new AcessoFB().BuscarFotoDoProduto(p.ID_PRODUTO);
                        if (p.Foto.FOTOGRAFIA != null)
                        {
                            MemoryStream ms = new MemoryStream(p.Foto.FOTOGRAFIA);
                            Image returnImage = Image.FromStream(ms);
                            p.Imagem = returnImage;
                        }

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

        private Foto BuscarFotoDoProduto(string iD_PRODUTO)
        {
            using (FbConnection conexaoFireBird = AcessoFB.GetInstancia().GetConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from fotos p where p.id_Produto = @Id";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.Parameters.AddWithValue("@id", iD_PRODUTO);
                    FbDataReader dr = cmd.ExecuteReader();
                    Foto p = new Foto();
                    if (dr.Read() != false)
                    {
                        p.FOTOGRAFIA = (byte[])dr["FOTOGRAFIA"];
                    }
                    else
                    {
                        p.FOTOGRAFIA = null;
                    }

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

        public Produto_Preco BuscarProdutoPorPrecoPorId(string iD_PRODUTO)
        {
            using (FbConnection conexaoFireBird = AcessoFB.GetInstancia().GetConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from produtos_precos p where p.id_Produto = @Id";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.Parameters.AddWithValue("@id", iD_PRODUTO);
                    FbDataReader dr = cmd.ExecuteReader();
                    Produto_Preco p = new Produto_Preco();
                    if (dr.Read() != false)
                    {
                        p.PRECO_VENDA = (double)dr["PRECO_VENDA"];
                    }
                    else
                    {
                        p.PRECO_VENDA = 0;
                    }

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

        public Produto_Estoque BuscarProdutoEstoquePorId(string iD_PRODUTO)
        {
            using (FbConnection conexaoFireBird = AcessoFB.GetInstancia().GetConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from produtos_estoques p where p.id_Produto = @Id";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.Parameters.AddWithValue("@id", iD_PRODUTO);
                    FbDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    Produto_Estoque p = new Produto_Estoque();
                    p.ESTOQUE_INTEIRO = (double)dr["ESTOQUE_INTEIRO"];

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

        private Produtos_Descricoes BuscarProdutoDescricoesPorId(string iD_PRODUTO)
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
                    p.DESCRICAO = (string)dr["DESCRICAO"];

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