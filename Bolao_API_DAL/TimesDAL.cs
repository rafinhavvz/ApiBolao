using Bolao_API_MODEL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace Bolao_API_DAL
{
    public class TimesDAL
    {
        public List<Times> GetAllItens()
        {
            List<Times> resultados = new List<Times>();

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                        resultados = BancoDados.SelectAll<Times>(connection.ConnectionString, "Times");
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

            return resultados   ;
        }


        public Times GetItemId(int oItemId)
        {
            Times resultados = null;

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        resultados = BancoDados.SelectByID<Times>(connection.ConnectionString, "Times", oItemId);
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

        public void PostItem(Times oItem)
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
                        BancoDados.InsertData(connection.ConnectionString, "Times", oItem);
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

        public Times UpdateItem(Times oItem)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        BancoDados.UpdateData(connection.ConnectionString, "Times", oItem, oItem.ID);
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
                        BancoDados.DeleteData<Times>(connection.ConnectionString, "Times", oItemId);
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