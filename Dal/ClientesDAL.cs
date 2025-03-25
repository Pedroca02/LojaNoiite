using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;
using System.Security.Cryptography.Pkcs;

namespace Dal
{
    public class ClientesDal
    {

        public void Incluir(ClienteInformation cliente)
        {
            //cria objeto cn para receber a conexão
            SqlConnection cn = new SqlConnection();
            try
            {
                //carrega a string de conexão do SQL
                cn.ConnectionString = "Data Source=DESKTOP-A87AVTM;Initial Catalog=LOJINHA;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
                //cria objeto cmd para executar comandos
                SqlCommand cmd = new SqlCommand();
                //cmd recebe a string de conexão
                cmd.Connection = cn;
                //defineque udsremod Stored Procedure do SQL Server
                cmd.CommandType = CommandType.StoredProcedure;
                //nome da Stored Procedure que será usada
                cmd.CommandText = " insere_cliente";
                //parâmetros da Stored Procedure

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.NVarChar, 100);
                pemail.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 80);
                ptelefone.Value = cliente.Telefone;
                cmd.Parameters.Add(ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();

                cliente.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

            }
            catch (Exception ex)
            {

                throw new Exception("servidor SQL Erro:" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Alterar(ClienteInformation cliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "altera_Cliente";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = cliente.Codigo;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.Int);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.Int);
                pemail.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.Int);
                ptelefone.Value = cliente.Telefone;
                cmd.Parameters.Add(pcodigo);
            }
            catch (Exception ex)
            {
                throw new Exception("erro no servidor sql" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        public void Excluir(int codigo)
        {
            Sql
        }


            

                

        


    }
        
}
