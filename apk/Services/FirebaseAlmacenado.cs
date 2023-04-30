using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using apk.Models;

namespace apk.Services
{
    public class FirebaseAlmacenado
    {
        public async Task<List<Almacenado>> GetAllAlmacenado()
        {

            return (await firebase
              .Child("Almacenado")
              .OnceAsync<Almacenado>()).Select(item => new Almacenado
              {
                  ID_A = item.Object.ID_A,
                  Nro_P = item.Object.Nro_P,
                  Fecha_I = item.Object.Fecha_I,
                  Fecha_S = item.Object.Fecha_S,
                  Temperatura = item.Object.Temperatura,
              }).ToList();
        }

        public async Task AddAlmacenado(Almacenado _AlmacenadoModel)
        {
            await firebase
            .Child("Almacenado")
            .PostAsync(new Almacenado()
            {
                ID_A = Guid.NewGuid(),
                Nro_P = _AlmacenadoModel.Nro_P,
                Fecha_I = _AlmacenadoModel.Fecha_I,
                Fecha_S = _AlmacenadoModel.Fecha_S,
                Temperatura = _AlmacenadoModel.Temperatura,
            });
        }

        public async Task UpdateAlmacenado(Almacenado _AlmacenadoModel)
        {
            var toUpdateAlmacenado = (await firebase
              .Child("Almacenado")
              .OnceAsync<Almacenado>()).Where(a => a.Object.ID_A == _AlmacenadoModel.ID_A).FirstOrDefault();

            await firebase
              .Child("Almacenado")
              .Child(toUpdateAlmacenado.Key)
              .PutAsync(new Almacenado() { ID_A = _AlmacenadoModel.ID_A, Nro_P = _AlmacenadoModel.Nro_P, Fecha_I = _AlmacenadoModel.Fecha_I, Fecha_S = _AlmacenadoModel.Fecha_S, Temperatura = _AlmacenadoModel.Temperatura });
        }

        public async Task DeleteAlmacenado(Guid id_a)
        {
            var toDeleteAlmacenado = (await firebase
              .Child("Almacenado")
              .OnceAsync<Almacenado>()).Where(a => a.Object.ID_A == id_a).FirstOrDefault();
            await firebase.Child("Almacenado").Child(toDeleteAlmacenado.Key).DeleteAsync();

        }

        FirebaseClient firebase;
        //   private readonly FirebaseClient firebase;
        public FirebaseAlmacenado()
        {
            firebase = new FirebaseClient("https://paltaproyect-default-rtdb.firebaseio.com/");
        }
    }
}
