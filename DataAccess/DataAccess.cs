﻿using FinalADO.Models;
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
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

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
                string query = @"INSERT INTO Books 
                                 (Title, Author, Publisher, Pages, Genre, PublicationYear, Cost, SalePrice, IsContinuation, ContinuationOf) 
                                 VALUES 
                                 (@Title, @Author, @Publisher, @Pages, @Genre, @PublicationYear, @Cost, @SalePrice, @IsContinuation, @ContinuationOf)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@Pages", book.Pages);
                cmd.Parameters.AddWithValue("@Genre", book.Genre);
                cmd.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
                cmd.Parameters.AddWithValue("@Cost", book.Cost);
                cmd.Parameters.AddWithValue("@SalePrice", book.SalePrice);
                cmd.Parameters.AddWithValue("@IsContinuation", book.IsContinuation);

                if (book.ContinuationOf.HasValue)
                {
                    cmd.Parameters.AddWithValue("@ContinuationOf", book.ContinuationOf.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContinuationOf", DBNull.Value);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Books WHERE BookId = @BookId";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@BookId", bookId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Books SET 
                                 Title = @Title,
                                 Author = @Author,
                                 Publisher = @Publisher,
                                 Pages = @Pages,
                                 Genre = @Genre,
                                 PublicationYear = @PublicationYear,
                                 Cost = @Cost,
                                 SalePrice = @SalePrice,
                                 IsContinuation = @IsContinuation,
                                 ContinuationOf = @ContinuationOf
                                 WHERE BookId = @BookId";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@Pages", book.Pages);
                cmd.Parameters.AddWithValue("@Genre", book.Genre);
                cmd.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
                cmd.Parameters.AddWithValue("@Cost", book.Cost);
                cmd.Parameters.AddWithValue("@SalePrice", book.SalePrice);
                cmd.Parameters.AddWithValue("@IsContinuation", book.IsContinuation);
                cmd.Parameters.AddWithValue("@BookId", book.BookId);

                if (book.ContinuationOf.HasValue)
                {
                    cmd.Parameters.AddWithValue("@ContinuationOf", book.ContinuationOf.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContinuationOf", DBNull.Value);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
