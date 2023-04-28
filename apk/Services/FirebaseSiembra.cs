using apk.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace apk.Services
{
    public  class FirebaseSiembra
    {
        public async Task<List<Siembra>> GetAllSiembra()
        {

            return (await firebase
              .Child("Siembra")
              .OnceAsync<Siembra>()).Select(item => new Siembra
              {
                  ID_S = item.Object.ID_S,
                  Fecha_Siembra = item.Object.Fecha_Siembra,
                  T_Semilla = item.Object.T_Semilla,
                  Rot_Tierra = item.Object.Rot_Tierra,
                  Nro_Lote = item.Object.Nro_Lote,
              }).ToList();
        }

        public async Task AddSiembra(Siembra _siembraModel)
        {
            await firebase
            .Child("Siembra")
            .PostAsync(new Siembra()
            {
                ID_S = Guid.NewGuid(),
                Fecha_Siembra= _siembraModel.Fecha_Siembra,
                Rot_Tierra = _siembraModel.Rot_Tierra,
                T_Semilla = _siembraModel.T_Semilla,
                Nro_Lote = _siembraModel.Nro_Lote
            });
        }

        public async Task UpdateSiembra(Siembra _siembraModel)
        {
            var toUpdateSiembra = (await firebase
              .Child("Siembra")
              .OnceAsync<Siembra>()).Where(a => a.Object.ID_S == _siembraModel.ID_S).FirstOrDefault();

            await firebase
              .Child("Siembra")
              .Child(toUpdateSiembra.Key)
              .PutAsync(new Siembra() { ID_S = _siembraModel.ID_S, Fecha_Siembra = _siembraModel.Fecha_Siembra, Rot_Tierra = _siembraModel.Rot_Tierra, T_Semilla = _siembraModel.Rot_Tierra, Nro_Lote = _siembraModel.Nro_Lote });
        }

        public async Task DeleteSiembra(Guid id_s)
        {
            var toDeleteSemilla = (await firebase
              .Child("Siembra")
              .OnceAsync<Siembra>()).Where(a => a.Object.ID_S == id_s).FirstOrDefault();
            await firebase.Child("Semilla").Child(toDeleteSemilla.Key).DeleteAsync();

        }

        FirebaseClient firebase;
        //   private readonly FirebaseClient firebase;
        public FirebaseSiembra()
        {
            firebase = new FirebaseClient("https://paltaproyect-default-rtdb.firebaseio.com/");
        }
    }
}
