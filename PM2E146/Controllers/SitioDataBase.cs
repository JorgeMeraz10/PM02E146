using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E146.Models;
using System.Threading.Tasks;

namespace PM2E146.Controllers
{
    class SitioDataBase
    {

        readonly SQLiteAsyncConnection dbbase;
        public SitioDataBase(string dbpath)
        {
            dbbase = new SQLiteAsyncConnection(dbpath);


            dbbase.CreateTableAsync<sitios>();
        }

        public Task<int> sitioSave(sitios direcc)
        {
            if (direcc.id != 0)
            {
                return dbbase.UpdateAsync(direcc);
            }
            else
            {
                return dbbase.InsertAsync(direcc);
            }
        }
        public Task<List<sitios>> ObtenerlistadoSitio()

        {
            return dbbase.Table<sitios>().ToListAsync();
        }

        public Task<int> eliminarsitio(sitios direcc)
        {
            return dbbase.DeleteAsync(direcc);

        }
        public Task<sitios> ObtenerLongitud(string uLongitud)
        {
            return dbbase.Table<sitios>().Where(i => i.longitud == uLongitud).FirstOrDefaultAsync();
        }

        public Task<sitios> ObtenerLatitud(string uLatitud)
        {
            return dbbase.Table<sitios>().Where(i => i.latitud == uLatitud).FirstOrDefaultAsync();
        }

        public Task<sitios> ObtenerDescripcion(String uDescripcion)
        {
            return dbbase.Table<sitios>().Where(i => i.descripcion == uDescripcion).FirstOrDefaultAsync();
        }


    }
}
