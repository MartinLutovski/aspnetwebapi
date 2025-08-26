using Avenga.NotesApp.Domain.Enums;
using Avenga.NotesApp.Domain.Models;
using Microsoft.Data.SqlClient;

namespace Avenga.NotesApp.DataAccess.AdoImplementations
{
    public class NoteAdoRepository : IRepository<Note>
    {
        private string _connectionString;
        public NoteAdoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Note entity)
        {
            // 1. Create new connection to the SQL DATABASE
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            // 2. Open the connection
            sqlConnection.Open();
            // 3. Create a sql command
            SqlCommand command = new SqlCommand();
            // 4. Connect the command
            command.Connection = sqlConnection;
            // 5. Write the command text (SQL Query)
            command.CommandText = "INSERT into dbo.Notes(Text, Priority, Tag, UserId)" + 
                "VALUES(@text, @priority, @tag, @userId)";
            // 6. Add parameters to the command
            command.Parameters.AddWithValue("@text", entity.Text);
            command.Parameters.AddWithValue("@priority", entity.Priority);
            command.Parameters.AddWithValue("@tag", entity.Tag);
            command.Parameters.AddWithValue("@userId", entity.UserId);
            // 7. Execute the command
            command.ExecuteNonQuery();
            // 8. Close the connection
            sqlConnection.Close();
        }

        public void Delete(Note entity)
        {
            // 1. Create new connection to the SQL DATABASE
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            // 2. Open the connection
            sqlConnection.Open();
            // 3. Create a sql command
            SqlCommand command = new SqlCommand();
            // 4. Connect the command
            command.Connection = sqlConnection;
            // 5. Write the command text (SQL Query)
            command.CommandText = "DELETE FROM dbo.Notes WHERE Id = @id";
            // 6. Add parameters to the command
            command.Parameters.AddWithValue("@id", entity.Id);
            // 7. Execute the command
            command.ExecuteNonQuery();
            // 8. Close the connection
            sqlConnection.Close();


        }

        public List<Note> GetAll()
        {
            // 1. Create new connection to the SQL DATABASE
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            // 2. Open the connection
            sqlConnection.Open();
            // 3. Create a sql command
            SqlCommand command = new SqlCommand();
            // 4. Connect the command
            command.Connection = sqlConnection;
            // 5. Write the command text (SQL Query)
            command.CommandText = "SELECT * FROM dbo.Notes";
            List<Note> notesDb = new List<Note>();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                notesDb.Add(new Note
                {
                    Id = (int)sqlDataReader["Id"],
                    Text = (string)sqlDataReader["Text"],
                    Priority = (Priority)sqlDataReader["Priority"],
                    Tag = (Tag)sqlDataReader["Tag"],
                    UserId = (int)sqlDataReader["UserId"]
                });
            }
            sqlConnection.Close();
            return notesDb;
        }

        public Note GetById(int id)
        {
            // 1. Create new connection to the SQL DATABASE
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            // 2. Open the connection
            sqlConnection.Open();
            // 3. Create a sql command
            SqlCommand command = new SqlCommand();
            // 4. Connect the command
            command.Connection = sqlConnection;
            // 5. Write the command text (SQL Query)
            command.CommandText = "SELECT * FROM dbo.Notes WHERE Id = @id";
            // 6. Add parameters to the command
            command.Parameters.AddWithValue("@id", id);
            List<Note> notesDb = new List<Note>();
            // 7. Execute the command
            SqlDataReader sqlDataReader = command.ExecuteReader();
            // 8. Read the data
            
            if (sqlDataReader.Read())
            {
                notesDb.Add(new Note
                {
                    Id = (int)sqlDataReader["Id"],
                    Text = (string)sqlDataReader["Text"],
                    Priority = (Priority)sqlDataReader["Priority"],
                    Tag = (Tag)sqlDataReader["Tag"],
                    UserId = (int)sqlDataReader["UserId"]
                });
            }
            // 9. Close the connection
            sqlConnection.Close();
            return notesDb.FirstOrDefault();
        }

        public void Update(Note entity)
        {
            // 1. Create new connection to the SQL DATABASE
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            // 2. Open the connection
            sqlConnection.Open();
            // 3. Create a sql command
            SqlCommand command = new SqlCommand();
            // 4. Connect the command
            command.Connection = sqlConnection;
            // 5. Write the command text (SQL Query)
            command.CommandText = "UPDATE dbo.Notes SET Text = @text, Priority = @priority, Tag = @tag, UserId = @userId" + "" +
                "WHERE Id = @id";
            // 6. Add parameters to the command
            command.Parameters.AddWithValue("@id", entity.Id);
            command.Parameters.AddWithValue("@priority", entity.Priority);
            command.Parameters.AddWithValue("@tag", entity.Tag);
            command.Parameters.AddWithValue("@text", entity.Text);
            command.Parameters.AddWithValue("@userId", entity.UserId);
            // 7. Execute the command
            command.ExecuteNonQuery();
            // 8. Close the connection
            sqlConnection.Close();

        }
    }
}
