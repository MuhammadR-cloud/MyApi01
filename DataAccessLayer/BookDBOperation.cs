using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookDBOperation
    {
        static string connString = "Data Source=DESKTOP-AOVI42O\\SQLEXPRESS;Initial Catalog=BookStoreManagementSystem;Integrated Security=True";
        public static List<Book> GetBooks()
        {

            List<Book> bookList = new List<Book>();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "spGetAllBooks";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookID = Convert.ToInt32(reader[0]);
                    book.CategoryID = Convert.ToInt32(reader[1]);
                    book.BookName = reader[2].ToString();
                    book.TotalPages = Convert.ToInt32(reader[3]);
                    book.AuthorName1 = reader[4].ToString();
                    book.AuthorName2 = reader[5].ToString();
                    book.Price = Convert.ToDecimal(reader[6]);
                    book.CreatedOn = Convert.ToDateTime(reader[7]);
                    book.UpdatedOn = Convert.ToDateTime(reader[8]);
                    bookList.Add(book);
                }
                //cmd.CommandText = "spGetAllBooks";
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BookID", Value = book.BookID });
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CategoryID", Value = book.CategoryID });
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BookName", Value = book.TotalPages });
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@AuthorName1", Value = book.AuthorName1 });
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@AuthorName2", Value = book.AuthorName2 });
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = book.Price });
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CreatedOn", Value = book.CreatedOn });
                //cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UpdatedOn", Value = book.UpdatedOn });

                //cmd.ExecuteNonQuery();

                // bookList.Add(book);



            }

            catch (Exception ex)
            {

            }
            sqlConnection.Close();

            return bookList;

        }

        public static Book GetBook(int BookID)
        {
            Book book = new Book();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "spGetOneBook";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BookID", Value = BookID });
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        book.BookID = Convert.ToInt32(reader[0]);
                        book.CategoryID = Convert.ToInt32(reader[1]);
                        book.BookName = reader[2].ToString();
                        book.TotalPages = Convert.ToInt32(reader[3]);
                        book.AuthorName1 = reader[4].ToString();
                        book.AuthorName2 = reader[5].ToString();
                        book.Price = Convert.ToDecimal(reader[6]);
                        book.CreatedOn = Convert.ToDateTime(reader[7]);
                        book.UpdatedOn = Convert.ToDateTime(reader[8]);
                    }

                }

            }

            catch (Exception ex)
            {

            }
            sqlConnection.Close();

            return book;
            
        }

        public static void AddBook(Book book)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "spInsertBook";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CategoryID", Value = book.CategoryID });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BookName", Value = book.BookName });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TotalPages", Value = book.TotalPages });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@AuthorName1", Value = book.AuthorName1 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@AuthorName2", Value = book.AuthorName2 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = book.Price });
              
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            sqlConnection.Close();

        }


        public static void UpdateBook(Book book)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "spUpdateBook";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BookID", Value = book.BookID });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CategoryID", Value = book.CategoryID });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BookName", Value = book.BookName });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TotalPages", Value = book.TotalPages });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@AuthorName1", Value = book.AuthorName1 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@AuthorName2", Value = book.AuthorName2 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = book.Price });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CreatedOn", Value = book.CreatedOn });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UpdatedOn", Value = book.UpdatedOn });
                
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            sqlConnection.Close();

        }



        public static void DeleteBook(int BookID)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "spDeleteBook";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { ParameterName = "@BookID", Value = BookID });
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }

            sqlConnection.Close();

        }
    }
}
