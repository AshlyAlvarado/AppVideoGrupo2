using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AppVideoGrupo2.Modelos;

namespace AppVideoGrupo2.Controladores
{
    public class BaseController
    {
        private readonly static string dbFileName = "AudioBase.db3";

        private readonly SQLiteOpenFlags flags = 
            SQLiteOpenFlags.ReadWrite |
                                                 
            SQLiteOpenFlags.Create |
                                                
            SQLiteOpenFlags.SharedCache;

        private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);
        private SQLiteAsyncConnection connection;
        public BaseController()
        {
        }
        private async Task Init()
        {
            if (connection is not null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(dbPath, flags);
            await connection.CreateTableAsync<Paises>();
        }

        public async Task<int> Insert(Paises registro)
        {
            await Init();
            return await connection.InsertAsync(registro);
        }
        public async Task<List<Paises>> SelectAll()
        {
            await Init();
            return await connection.Table<Paises>().ToListAsync();
        }
        public async Task<Paises> SelectById(int id)
        {
            await Init();
            return await connection.Table<Paises>().Where(col => col.Id == id).FirstOrDefaultAsync();
        }
        public async Task<int> Update(Paises registro)
        {
            await Init();
            return await connection.UpdateAsync(registro);
        }
        public async Task<int> Delete(Paises registro)
        {
            await Init();
            return await connection.DeleteAsync(registro);
        }
    }
}
