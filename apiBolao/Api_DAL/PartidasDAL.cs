using apiBolao.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace apiBolao.Api_DAL
{
    public class PartidasDAL
    {
        public List<Partidas> GetAllItens()
        {
            List<Partidas> resultados = new List<Partidas>();

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                        resultados = BancoDados.SelectAll<Partidas>(connection.ConnectionString, "Partidas");
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


        public List<PartidaComTimes> GetItemId(int oItemId)
        {
            List<PartidaComTimes> resultados = new List<PartidaComTimes>();

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    // Consulta para obter as partidas com o IDBolao correspondente
                    resultados = (from partida in db.Partidas
                                  join timeHome in db.Times on partida.IDTeamHome equals timeHome.ID
                                  join timeAway in db.Times on partida.IDTeamAway equals timeAway.ID
                                  where partida.IDBolao == oItemId
                                  select new PartidaComTimes
                                  {
                                      ID = partida.ID,
                                      IDBolao = partida.IDBolao,
                                      IDTeamHome = partida.IDTeamHome,
                                      IDTeamAway = partida.IDTeamAway,
                                      TimeHomeName = timeHome.Name,
                                      TimeHomeLogo = timeHome.Logo,
                                      TimeAwayName = timeAway.Name,
                                      TimeAwayLogo = timeAway.Logo,
                                      Data = partida.Data,
                                      Resultado = partida.Resultado,
                                      Status = partida.Status,
                                  }).ToList();
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

        public void PostItem(IEnumerable<Partidas> oItem)
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
                        BancoDados.InsertDataArray(connection.ConnectionString, "Partidas", oItem);
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

        public Partidas UpdateItem(Partidas oItem)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        BancoDados.UpdateData(connection.ConnectionString, "Partidas", oItem, oItem.ID);
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
                        BancoDados.DeleteData<Partidas>(connection.ConnectionString, "Partidas", oItemId);
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