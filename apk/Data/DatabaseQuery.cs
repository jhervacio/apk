using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using apk.Models;

namespace apk.Data
{
    public class DatabaseQuerys
    {
        #region Creacion - Tabla - DbPath 
        /*  readonly SQLiteAsyncConnection _database;

          public DatabaseQuerys(string dbPath)
          {
              _database = new SQLiteAsyncConnection(dbPath);


              #region Creacion - Tablas

              _database.CreateTableAsync<Users>().Wait();
            //  _database.CreateTableAsync<PersonModel>().Wait();
              #endregion
          }*/

        #endregion


        #region CRUD - USER TABLE
        /* METOD-O SELECT SEARCH BAR()*/
        /*   public Task<Users> GetUserModelAynsc(int id)
           {
               return _database.Table<Users>()
                               .Where(i => i.ID == id)
                               .FirstOrDefaultAsync();
           }*/

        /* METOD-O SELECT ()*/
        /*  public Task<List<Users>> GetUserModel()
          {
              return _database.Table<Users>().ToListAsync();
          }*/

        /* METOD-O GUARDAR Y ACTUALIZAR ()*/
        /*
        public Task<int> SaveUserModelAsync(Users userModel)
        {
            if (userModel.ID != 0)
            {
                return _database.UpdateAsync(userModel);
            }
            else
            {
                return _database.InsertAsync(userModel);
            }
        }
        */
        /* METOD-O ELIMINAR () */
        /*  public Task<int> DeleteUserModelAsync(Users userModel)
          {
              return _database.DeleteAsync(userModel);
          }

          public Task<List<Users>> GetUsersValidate(string email, string password)
          {
              return _database.QueryAsync<Users>("SELECT * FROM UserModel WHERE EmailField = '" + email + "' AND PasswordField = '" + password + "'");
          }

          #endregion
        */
        #endregion
    }
}
