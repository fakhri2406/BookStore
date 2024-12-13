using FinalADO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FinalADO.DataAccess
{
    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BookStoreDB"].ConnectionString;
        }

        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Username='" + username + "' AND Password='" + password + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Books";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        BookId = (int)reader["BookId"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Publisher = reader["Publisher"].ToString(),
                        Pages = (int)reader["Pages"],
                        Genre = reader["Genre"].ToString(),
                        PublicationYear = (int)reader["PublicationYear"],
                        Cost = (decimal)reader["Cost"],
                        SalePrice = (decimal)reader["SalePrice"],
                        IsContinuation = (bool)reader["IsContinuation"],
                        ContinuationOf = reader["ContinuationOf"] as int?
                    });
                }
            }
            return books;
        }
    }
}
