using apiBolao.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace apiBolao.Api_DAL
{
    public class ApostasPartidasDAL
    {
        public List<ApostasPartidas> GetAllItens()
        {
            List<ApostasPartidas> resultados = new List<ApostasPartidas>();

            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        // Chamar o método genérico para inserir valores
                        resultados = BancoDados.SelectAll<ApostasPartidas>(connection.ConnectionString, "ApostasPartidas");
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

        public List<ResultadoAposta> GetItemId(int oItemId)
        {
            List<ResultadoAposta> resultadosApostas = new List<ResultadoAposta>();

            using (var db = new dbContext())
            {
                var connect = db.Database.GetDbConnection() as SqlConnection;
                try
                {
                    
                    using (SqlConnection connection = new SqlConnection(connect.ConnectionString))
                    {
                        connection?.Open();

                        string sql = @"
                    SELECT AP.idAposta AS IDBolao,
                           P.idTeamHome AS IDTeamHome,
                           P.idTeamAway AS IDTeamAway,
                           P.data AS Data,
                           P.resultado As ResultadoReal,
                           AP.resultado AS ResultadoAposta,
                           AP.status AS Status,
                           TH.name AS NomeTimeHome, TH.logo AS LogoTimeHome,
                           TA.name AS NomeTimeAway, TA.logo AS LogoTimeAway
                    FROM ApostasPartidas AS AP
                    JOIN Partidas AS P ON AP.idPartida = P.ID
                    JOIN Times AS TH ON P.idTeamHome = TH.ID
                    JOIN Times AS TA ON P.idTeamAway = TA.ID"
                    ;
                        sql += $" WHERE AP.idAposta = {oItemId}";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Aqui você pode criar um objeto para armazenar os resultados ou fazer o processamento necessário
                                    int idBolao = reader.GetInt32(reader.GetOrdinal("IDBolao"));
                                    int idTeamHome = reader.GetInt32(reader.GetOrdinal("IDTeamHome"));
                                    int idTeamAway = reader.GetInt32(reader.GetOrdinal("IDTeamAway"));
                                    DateTime data = reader.GetDateTime(reader.GetOrdinal("Data"));
                                    string ResultadoApost = reader.GetString(reader.GetOrdinal("ResultadoAposta"));
                                    int ResultadoReal = reader.GetInt32(reader.GetOrdinal("ResultadoReal"));
                                    string Status = reader.GetString(reader.GetOrdinal("Status"));
                                    string NomeTimeHome = reader.GetString(reader.GetOrdinal("NomeTimeHome"));
                                    string NomeTimeAway = reader.GetString(reader.GetOrdinal("NomeTimeAway"));
                                    string LogoTimeHome = reader.GetString(reader.GetOrdinal("LogoTimeHome"));
                                    string LogoTimeAway = reader.GetString(reader.GetOrdinal("LogoTimeAway"));
                                    // ... continuar para outras colunas

                                    // Exemplo de criação do objeto ResultadoAposta, se você tiver essa classe
                                    ResultadoAposta resultadoAposta = new ResultadoAposta
                                    {
                                        IDBolao = idBolao,
                                        IDTeamHome = idTeamHome,
                                        IDTeamAway = idTeamAway,
                                        Data = data,
                                        ResultadoApost = ResultadoApost,
                                        ResultadoReal = ResultadoReal,
                                        Status = Status,
                                        NomeTimeHome = NomeTimeHome,
                                        NomeTimeAway = NomeTimeAway,
                                        LogoTimeHome = LogoTimeHome,
                                        LogoTimeAway = LogoTimeAway,
                                        // ... continuar para outras propriedades
                                    };

                                    resultadosApostas.Add(resultadoAposta);
                                
                                }
                            }

                        }
                    }

                    }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}");
                }
            }

            return resultadosApostas;
        }

        public void PostItem(IEnumerable<ApostasPartidas> oItem)
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
                        BancoDados.InsertDataArray(connection.ConnectionString, "ApostasPartidas", oItem);
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

        public ApostasPartidas UpdateItem(ApostasPartidas oItem)
        {
            using (var db = new dbContext())
            {
                // Obter a conexão do contexto do Entity Framework
                var connection = db.Database.GetDbConnection() as SqlConnection;

                try
                {
                    if (connection != null)
                    {
                        BancoDados.UpdateData(connection.ConnectionString, "ApostasPartidas", oItem, oItem.ID);
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
                        BancoDados.DeleteData<ApostasPartidas>(connection.ConnectionString, "ApostasPartidas", oItemId);
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