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
    public class FirebaseCosecha
    {
        public async Task<List<Cosecha>> GetAllCosecha()
        {

            return (await firebase
              .Child("Cosecha")
              .OnceAsync<Cosecha>()).Select(item => new Cosecha
              {
                  ID_C = item.Object.ID_C,
                  ID_S = item.Object.ID_S,
                  Fecha_C = item.Object.Fecha_C,
                  Abono = item.Object.Abono,
                  Dotacion = item.Object.Dotacion,
                  Tamaño = item.Object.Tamaño,
                  Madurez= item.Object.Madurez,
              }).ToList();
        }

        public async Task AddCosecha(Cosecha _cosechaModel)
        {
            await firebase
            .Child("Cosecha")
            .PostAsync(new Cosecha()
            {
                ID_C = Guid.NewGuid(),
                ID_S = _cosechaModel.ID_S,
                Fecha_C = _cosechaModel.Fecha_C,
                Abono = _cosechaModel.Abono,
                Dotacion = _cosechaModel.Dotacion,
                Tamaño = _cosechaModel.Tamaño,
                Madurez = _cosechaModel.Madurez,
            });
        }

        public async Task UpdateCosecha(Cosecha _cosechaModel)
        {
            var toUpdateCosecha = (await firebase
              .Child("Cosecha")
              .OnceAsync<Cosecha>()).Where(a => a.Object.ID_C == _cosechaModel.ID_C).FirstOrDefault();

            await firebase
              .Child("Cosecha")
              .Child(toUpdateCosecha.Key)
              .PutAsync(new Cosecha() { ID_C = _cosechaModel.ID_C, ID_S = _cosechaModel.ID_S, Fecha_C = _cosechaModel.Fecha_C, Abono = _cosechaModel.Abono, Dotacion = _cosechaModel.Dotacion, Tamaño = _cosechaModel.Tamaño, Madurez = _cosechaModel.Madurez });
        }

        public async Task DeleteCosecha(Guid id_c)
        {
            var toDeleteCosecha = (await firebase
              .Child("Cosecha")
              .OnceAsync<Cosecha>()).Where(a => a.Object.ID_C == id_c).FirstOrDefault();
            await firebase.Child("Cosecha").Child(toDeleteCosecha.Key).DeleteAsync();

        }

        FirebaseClient firebase;
        //   private readonly FirebaseClient firebase;
        public FirebaseCosecha()
        {
            firebase = new FirebaseClient("https://paltaproyect-default-rtdb.firebaseio.com/");
        }
    }
}
