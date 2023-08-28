using Bolao_API_MODEL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Entity;

namespace Bolao_API_DAL
{
    public class ApostasDAL
    {
        public List<Apostas> GetAllItens()
        {
            List<Apostas> resultados = new List<Apostas>();

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                        resultados = BancoDados.SelectAll<Apostas>(connection.ConnectionString, "Apostas");
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


        public Apostas GetItemId(int oItemId)
        {
            Apostas resultados = null;

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        resultados = BancoDados.SelectByID<Apostas>(connection.ConnectionString, "Apostas", oItemId);
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

        public int PostItem(Apostas oItem)
        {
            int idGerado = 0;

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                         idGerado = BancoDados.InsertDataAndReturnId(connection.ConnectionString, "Apostas", oItem);
                       

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
                return idGerado;
            }
        }

        public Apostas UpdateItem(Apostas oItem)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        BancoDados.UpdateData(connection.ConnectionString, "Apostas", oItem, oItem.ID);
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
                        BancoDados.DeleteData<Apostas>(connection.ConnectionString, "Apostas", oItemId);
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