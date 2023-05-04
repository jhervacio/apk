using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using apk.Models;
using System.Linq;
using Firebase.Database.Query;

namespace apk.Services
{
    public class FirebaseLogistica
    {
        public async Task<List<Logistica>> GetAllLogistica()
        {

            return (await firebase
              .Child("Logistica")
              .OnceAsync<Logistica>()).Select(item => new Logistica
              {
                  ID_L = item.Object.ID_L,
                  Nro_P = item.Object.Nro_P,
                  Fecha_S = item.Object.Fecha_S,
                  Lugar_S= item.Object.Lugar_S,
                  Fecha_E= item.Object.Fecha_E,
                  Lugar_E= item.Object.Lugar_E,
              }).ToList();
        }

        public async Task AddLogistica(Logistica _LogisticaModel)
        {
            await firebase
            .Child("Logistica")
            .PostAsync(new Logistica()
            {
                ID_L = Guid.NewGuid(),
                Nro_P = _LogisticaModel.Nro_P,
                Fecha_S = _LogisticaModel.Fecha_S,
                Lugar_S = _LogisticaModel.Lugar_S,
                Fecha_E = _LogisticaModel.Fecha_E,
                Lugar_E = _LogisticaModel.Lugar_E,
            });
        }

        public async Task UpdateLogistica(Logistica _LogisticaModel)
        {
            var toUpdateLogistica = (await firebase
              .Child("Logistica")
              .OnceAsync<Logistica>()).Where(a => a.Object.ID_L == _LogisticaModel.ID_L).FirstOrDefault();

            await firebase
              .Child("Logistica")
              .Child(toUpdateLogistica.Key)
              .PutAsync(new Logistica() { ID_L = _LogisticaModel.ID_L, Nro_P = _LogisticaModel.Nro_P, Fecha_S = _LogisticaModel.Fecha_S, Lugar_S = _LogisticaModel.Lugar_S, Fecha_E = _LogisticaModel.Fecha_E, Lugar_E=_LogisticaModel.Lugar_E });
        }

        public async Task DeleteLogistica(Guid id_l)
        {
            var toDeleteLogistica = (await firebase
              .Child("Logistica")
              .OnceAsync<Logistica>()).Where(a => a.Object.ID_L == id_l).FirstOrDefault();
            await firebase.Child("Logistica").Child(toDeleteLogistica.Key).DeleteAsync();

        }

        FirebaseClient firebase;
        //   private readonly FirebaseClient firebase;
        public FirebaseLogistica()
        {
            firebase = new FirebaseClient("https://paltaproyect-default-rtdb.firebaseio.com/");
        }
    }
}
