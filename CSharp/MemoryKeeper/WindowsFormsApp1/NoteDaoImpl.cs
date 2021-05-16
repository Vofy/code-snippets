using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace MemoryKeeper
{
    class NoteDaoImpl : NoteDao
    {
        private const string dbFileName = "data.sqlite";

        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MemoryKeeper");
        private static string dbConnectionString = "Data Source=" + Path.Combine(dbPath, dbFileName);

        private static NoteDaoImpl instance;

        private static SQLiteConnection dbConnection;

        public static NoteDaoImpl GetDatabaseAccess()
        {
            if (instance == null)
                instance = new NoteDaoImpl();

            return instance;
        }

        private NoteDaoImpl()
        {
            if (!DatabaseExists()) CreateDatabase();

            CreateConnection();
        }

        private static void CreateConnection()
        {
            dbConnection = new SQLiteConnection(dbConnectionString);
        }

        private static bool DatabaseExists()
        {
            bool databaseExists = false;

            if (File.Exists(Path.Combine(dbPath, dbFileName)))
            {
                databaseExists = true;
            }

            return databaseExists;
        }

        private static void CreateDatabase()
        {
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }

            SQLiteConnection.CreateFile(Path.Combine(dbPath, dbFileName));
            CreateConnection();

            using (SQLiteCommand dbCommand = new SQLiteCommand(
                "CREATE TABLE `notes`(" +
                    "`id` INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "`title` TEXT," +
                    "`content` TEXT," +
                    "`time_updated` TEXT," +
                    "`deadline` TEXT);" +
                "CREATE INDEX notes_time_updated_idx ON `notes`(`time_updated`);" +
                "CREATE INDEX notes_deadline_idx ON `notes`(`deadline`);", dbConnection))
            {
                dbConnection.Open();
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        public List<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();

            using (SQLiteCommand dbCommand = new SQLiteCommand("SELECT * FROM `notes` ORDER BY deadline ASC, time_updated DESC", dbConnection))
            {
                dbConnection.Open();
                using (SQLiteDataReader dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                        notes.Add(new Note(
                            Convert.ToInt32(dataReader["id"]),
                            Convert.ToString(dataReader["title"]),
                            Convert.ToString(dataReader["content"]),
                            Convert.ToString(dataReader["time_updated"]),
                            Convert.ToString(dataReader["deadline"])));
                }
                dbConnection.Close();
            }

            return notes;
        }

        public Note GetNote(int id)
        {
            using (SQLiteCommand dbCommand = new SQLiteCommand("SELECT FROM * TABLE `notes` WHERE `id`=@id LIMIT 1", dbConnection))
            {
                Note note;

                dbConnection.Open();

                // dbCommand.Parameters["@id"].Value = id;
                // dbCommand.Parameters.Add("@id", DbType.Int32).Value = id;
                dbCommand.Parameters.AddWithValue("@id", id);

                using (SQLiteDataReader dataReader = dbCommand.ExecuteReader())
                {
                    dataReader.Read();
                    note = new Note(
                        Convert.ToInt32(dataReader["id"]),
                        Convert.ToString(dataReader["title"]),
                        Convert.ToString(dataReader["content"]),
                        Convert.ToString(dataReader["time_updated"]),
                        Convert.ToString(dataReader["deadline"]));
                }

                dbConnection.Close();

                return note;
            }
        }

        public void AddNote(Note note)
        {
            using (SQLiteCommand dbCommand = new SQLiteCommand("INSERT INTO `notes`(`title`, `content`, `time_updated`, `deadline`) VALUES (@title, @content, datetime(), @deadline)", dbConnection))
            {
                dbConnection.Open();

                dbCommand.Parameters.AddWithValue("@title", note.Title);
                dbCommand.Parameters.AddWithValue("@content", note.Content);
                dbCommand.Parameters.AddWithValue("@time_updated", note.TimeUpdated);
                dbCommand.Parameters.AddWithValue("@deadline", note.Deadline);

                dbCommand.Prepare();
                dbCommand.ExecuteNonQuery();

                dbConnection.Close();
            }
        }

        public void UpdateNote(Note note)
        {
            using (SQLiteCommand dbCommand = new SQLiteCommand("UPDATE `notes` SET `title` = @title, `content` = @content, `time_updated` = datetime(), `deadline` = @deadline WHERE `id` = @id ", dbConnection))
            {
                dbConnection.Open();

                dbCommand.Parameters.AddWithValue("@title", note.Title);
                dbCommand.Parameters.AddWithValue("@content", note.Content);
                dbCommand.Parameters.AddWithValue("@time_updated", note.TimeUpdated);
                dbCommand.Parameters.AddWithValue("@deadline", note.Deadline);
                dbCommand.Parameters.AddWithValue("@id", note.Id);

                dbCommand.Prepare();
                dbCommand.ExecuteNonQuery();

                dbConnection.Close();
            }
        }

        public void DeleteNote(Note note)
        {
            using (SQLiteCommand dbCommand = new SQLiteCommand("DELETE FROM `notes` WHERE `id` = @id ", dbConnection))
            {
                dbConnection.Open();

                dbCommand.Parameters.AddWithValue("@id", note.Id);

                dbCommand.ExecuteNonQuery();

                dbConnection.Close();
            }
        }
    }
}
