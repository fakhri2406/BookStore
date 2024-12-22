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

        public void AddBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Books (Title, Author, Publisher, Pages, Genre, PublicationYear, Cost, SalePrice, IsContinuation, ContinuationOf) " +
                               "VALUES ('" + book.Title + "', '" + book.Author + "', '" + book.Publisher + "', " + book.Pages + ", '" + book.Genre + "', " +
                               book.PublicationYear + ", " + book.Cost.ToString().Replace(',', '.') + ", " + book.SalePrice.ToString().Replace(',', '.') + ", " +
                               (book.IsContinuation ? "1" : "0") + ", " + (book.ContinuationOf.HasValue ? book.ContinuationOf.Value.ToString() : "NULL") + ")";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Books WHERE BookId=" + bookId;
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Books SET " +
                               "Title='" + book.Title + "', " +
                               "Author='" + book.Author + "', " +
                               "Publisher='" + book.Publisher + "', " +
                               "Pages=" + book.Pages + ", " +
                               "Genre='" + book.Genre + "', " +
                               "PublicationYear=" + book.PublicationYear + ", " +
                               "Cost=" + book.Cost.ToString().Replace(',', '.') + ", " +
                               "SalePrice=" + book.SalePrice.ToString().Replace(',', '.') + ", " +
                               "IsContinuation=" + (book.IsContinuation ? "1" : "0") + ", " +
                               "ContinuationOf=" + (book.ContinuationOf.HasValue ? book.ContinuationOf.Value.ToString() : "NULL") +
                               " WHERE BookId=" + book.BookId;

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password) VALUES ('" + user.Username + "', '" + user.Password + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
