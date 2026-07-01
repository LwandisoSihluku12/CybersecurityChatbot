// Services/TaskDatabaseManager.cs
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using CybersecurityChatbot.WPF.Models;

namespace CybersecurityChatbot.WPF.Services
{
    public class TaskDatabaseManager
    {
        private readonly string _connectionString = "Server=localhost;Database=cybersecurity_chatbot;Uid=root;Pwd=password123;"; // CHANGE YOUR_PASSWORD

        public TaskDatabaseManager()
        {
            // Ensure the database and table exist on startup
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string createDbSql = "CREATE DATABASE IF NOT EXISTS cybersecurity_chatbot;";
                using (var cmd = new MySqlCommand(createDbSql, connection)) cmd.ExecuteNonQuery();

                string createTableSql = @"CREATE TABLE IF NOT EXISTS Tasks (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Title VARCHAR(255) NOT NULL,
                    Description TEXT,
                    ReminderDate DATETIME,
                    IsCompleted BOOLEAN DEFAULT FALSE
                );";
                using (var cmd = new MySqlCommand(createTableSql, connection)) cmd.ExecuteNonQuery();
            }
        }

        public void AddTask(CybersecurityTask task)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted) VALUES (@Title, @Description, @ReminderDate, @IsCompleted)";
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReminderDate", task.ReminderDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<CybersecurityTask> GetTasks()
        {
            List<CybersecurityTask> tasks = new List<CybersecurityTask>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Title, Description, ReminderDate, IsCompleted FROM Tasks";
                using (var cmd = new MySqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new CybersecurityTask
                        {
                            Id = reader.GetInt32("Id"),
                            Title = reader.GetString("Title"),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                            ReminderDate = reader.IsDBNull(reader.GetOrdinal("ReminderDate")) ? (DateTime?)null : reader.GetDateTime("ReminderDate"),
                            IsCompleted = reader.GetBoolean("IsCompleted")
                        });
                    }
                }
            }
            return tasks;
        }

        public void UpdateTask(CybersecurityTask task)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE Tasks SET Title = @Title, Description = @Description, ReminderDate = @ReminderDate, IsCompleted = @IsCompleted WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReminderDate", task.ReminderDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                    cmd.Parameters.AddWithValue("@Id", task.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTask(int taskId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Tasks WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", taskId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}