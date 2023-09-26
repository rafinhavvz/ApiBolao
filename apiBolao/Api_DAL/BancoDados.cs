using apiBolao.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace apiBolao.Api_DAL
{
    public class BancoDados
    {
        // Método genérico para realizar SELECT * em qualquer tabela
        public static List<T> SelectAll<T>(string connectionString, string tableName) where T : new()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection?.Open();

                string sql = $"SELECT * FROM {tableName}";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<T> resultList = new List<T>();

                        while (reader.Read())
                        {
                            T item = new T();

                            foreach (var prop in item.GetType().GetProperties())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(item, reader[prop.Name]);
                                }
                            }

                            resultList.Add(item);
                        }

                        return resultList;
                    }
                }
            }
        }

        // Método genérico para realizar SELECT por ID em qualquer tabela
        public static T SelectByID<T>(string connectionString, string tableName, int id) where T : new()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection?.Open();

                string sql = $"SELECT * FROM {tableName} WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            T item = new T();

                            foreach (var prop in item.GetType().GetProperties())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(item, reader[prop.Name]);
                                }
                            }

                            return item;
                        }

                        return default; // Retorna null se o ID não for encontrado
                    }
                }
            }
        }

       

        // Método genérico para inserir valores em qualquer tabela
        public static void InsertData<T>(string connectionString, string tableName, T data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection?.Open();
                var dataType = data.GetType().GetProperties().Where(prop => !prop.Name.Equals("ID", StringComparison.OrdinalIgnoreCase));

                // Montar a consulta SQL genérica
                string columnNames = GetColumnNames(dataType);
                string paramNames = GetParamNames(dataType);

                string sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({paramNames})";


                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Adicionar parâmetros com base nas propriedades do objeto
                    foreach (var prop in dataType)
                    {
                        command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(data));
                        
                    }

                    // Executar a consulta
                    command.ExecuteNonQuery();
                }
            }
            
        }



        public static void InsertDataArray<T>(string connectionString, string tableName, IEnumerable<T> dataArray)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection?.Open();
                var sampleData = dataArray.FirstOrDefault(); // Obter uma instância para determinar as propriedades
                if (sampleData == null)
                {
                    throw new ArgumentException("O array de dados está vazio.", nameof(dataArray));
                }

                var dataType = sampleData.GetType().GetProperties().Where(prop => !prop.Name.Equals("ID", StringComparison.OrdinalIgnoreCase));

                string columnNames = GetColumnNames(dataType);
                string paramNames = GetParamNames(dataType);

                string sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({paramNames})";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    foreach (var data in dataArray)
                    {
                        foreach (var prop in dataType)
                        {
                            command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(data));
                        }

                        command.ExecuteNonQuery();
                        command.Parameters.Clear(); // Limpar parâmetros para o próximo conjunto de dados
                    }
                }
            }
        }

        public static int InsertDataAndReturnId<T>(string connectionString, string tableName, T data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var dataType = data.GetType().GetProperties().Where(prop => !prop.Name.Equals("ID", StringComparison.OrdinalIgnoreCase));

                // Montar a consulta SQL genérica
                string columnNames = GetColumnNames(dataType);
                string paramNames = GetParamNames(dataType);

                string sql = $"INSERT INTO {tableName} ({columnNames}) OUTPUT INSERTED.ID VALUES ({paramNames})";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Adicionar parâmetros com base nas propriedades do objeto
                    foreach (var prop in dataType)
                    {
                        command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(data));
                    }

                    // Executar a consulta e obter o ID gerado
                    int generatedId = Convert.ToInt32(command.ExecuteScalar());
                    return generatedId;
                }
            }
        }

        // Método genérico para realizar UPDATE em qualquer tabela
        public static void UpdateData<T>(string connectionString, string tableName, T data, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection?.Open();
                var dataType = data.GetType().GetProperties().Where(prop => !prop.Name.Equals("ID", StringComparison.OrdinalIgnoreCase));

                // Montar a parte SET da consulta SQL genérica
                string setClause = string.Join(", ", dataType.Select(prop => $"{prop.Name} = @{prop.Name}"));

                string sql = $"UPDATE {tableName} SET {setClause} WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Adicionar parâmetros com base nas propriedades do objeto
                    foreach (var prop in dataType)
                    {
                        command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(data));
                    }

                    command.Parameters.AddWithValue("@ID", id);

                    // Executar a consulta
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método genérico para realizar DELETE em qualquer tabela
        public static void DeleteData<T>(string connectionString, string tableName, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection?.Open();

                string sql = $"DELETE FROM {tableName} WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    // Executar a consulta
                    command.ExecuteNonQuery();
                }
            }
        }


        // Obter os nomes das colunas separados por vírgula
        static string GetColumnNames(IEnumerable<PropertyInfo> props)
        {
            string columnNames = string.Join(", ", props.Select(prop => prop.Name));
            return columnNames;
        }

        // Obter os nomes dos parâmetros separados por vírgula
        static string GetParamNames(IEnumerable<PropertyInfo> props)
        {
            string paramNames = string.Join(", ", props.Select(prop => "@" + prop.Name));
            return paramNames;
        }
    }
}