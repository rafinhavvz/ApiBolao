using apiBolao.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace apiBolao.Api_DAL
{
    public class TiposDAL
    {
        public List<Tipos> GetAllItens()
        {
            List<Tipos> resultados = new List<Tipos>();

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                        resultados = BancoDados.SelectAll<Tipos>(connection.ConnectionString, "Tipos");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fechar a conexão com o banco de dados
                    connection?.Close();
                }
            }

            return resultados;
        }


        public Tipos GetItemId(int oItemId)
        {
            Tipos resultados = null;

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        resultados = BancoDados.SelectByID<Tipos>(connection.ConnectionString, "Tipos", oItemId);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fechar a conexão com o banco de dados
                    connection?.Close();
                }
            }

            return resultados;
        }

        public void PostItem(Tipos oItem)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                        BancoDados.InsertData(connection.ConnectionString, "Tipos", oItem);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fechar a conexão com o banco de dados
                    connection?.Close();
                }
            }
        }

        public Tipos UpdateItem(Tipos oItem)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        BancoDados.UpdateData(connection.ConnectionString, "Tipos", oItem, oItem.ID);
                    }
                }

                catch (Exception ex)
                {
                    throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fechar a conexão com o banco de dados
                    connection?.Close();
                    
                }
                return oItem;
            }
        }

        public void DeleteItem(int oItemId)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        BancoDados.DeleteData<Tipos>(connection.ConnectionString, "Tipos", oItemId);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fechar a conexão com o banco de dados
                    connection?.Close();
                }
            }
        }
    }
}