using Bolao_API_MODEL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace Bolao_API_DAL
{
    public class CampeonatosDAL
    {
        public List<Campeonatos> GetAllItens()
        {
            List<Campeonatos> resultados = new List<Campeonatos>();

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                        resultados = BancoDados.SelectAll<Campeonatos>(connection.ConnectionString, "Campeonatos");
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


        public Campeonatos GetItemId(int oItemId)
        {
            Campeonatos resultados = null;

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        resultados = BancoDados.SelectByID<Campeonatos>(connection.ConnectionString, "Campeonatos", oItemId);
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

        public void PostItem(Campeonatos oItem)
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
                        BancoDados.InsertData(connection.ConnectionString, "Campeonatos", oItem);
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

        public Campeonatos UpdateItem(Campeonatos oItem)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        BancoDados.UpdateData(connection.ConnectionString, "Campeonatos", oItem, oItem.ID);
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
                        BancoDados.DeleteData<Campeonatos>(connection.ConnectionString, "Campeonatos", oItemId);
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