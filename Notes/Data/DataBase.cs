using System;
using System.Collections.Generic;
using System.Text;
using Notes.Models;
using SQLite;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace Notes.Data
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection _connection;

        public DataBase(string connectionString)
        {
            _connection = new SQLiteAsyncConnection(connectionString);

            _connection.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> Notes => _connection.Table<Note>().ToListAsync();

        public Task<Note> this[int index]
        {
            get
            {
                return _connection.Table<Note>()
                    .Where(x => x.Id == index)
                    .FirstOrDefaultAsync();
            }
        }

        

    public Task<int> SaveAsync(Note note)
        {
            if (note.Id != 0)
            {
                return _connection.UpdateAsync(note);
            }

            return _connection.InsertAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _connection.DeleteAsync(note);
        }
    }
}
