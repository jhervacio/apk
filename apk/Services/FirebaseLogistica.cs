//using Firebase.Auth;
//using Firebase.Database;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using apk.Models;
//using System.Linq;

//namespace apk.Services
//{
//    public class FirebaseLogistica
//    {
//        public async Task<List<Logistica>> GetAllLogistica()
//        {

//            return (await firebase
//              .Child("Logistica")
//              .OnceAsync<Logistica>()).Select(item => new Logistica
//              {
//                  ID_L = item.Object.ID_L,
//                  Nro_P = item.Object.Nro_P,
//                  Fecha_I = item.Object.Fecha_I,
//                  Fecha_S = item.Object.Fecha_S,
//                  Temperatura = item.Object.Temperatura,
//              }).ToList();
//        }

//        public async Task AddLogistica(Logistica _LogisticaModel)
//        {
//            await firebase
//            .Child("Logistica")
//            .PostAsync(new Logistica()
//            {
//                ID_A = Guid.NewGuid(),
//                Nro_P = _LogisticaModel.Nro_P,
//                Fecha_I = _LogisticaModel.Fecha_I,
//                Fecha_S = _LogisticaModel.Fecha_S,
//                Temperatura = _LogisticaModel.Temperatura,
//            });
//        }

//        public async Task UpdateLogistica(Logistica _LogisticaModel)
//        {
//            var toUpdateLogistica = (await firebase
//              .Child("Logistica")
//              .OnceAsync<Logistica>()).Where(a => a.Object.ID_A == _LogisticaModel.ID_A).FirstOrDefault();

//            await firebase
//              .Child("Logistica")
//              .Child(toUpdateLogistica.Key)
//              .PutAsync(new Logistica() { ID_A = _LogisticaModel.ID_A, Nro_P = _LogisticaModel.Nro_P, Fecha_I = _LogisticaModel.Fecha_I, Fecha_S = _LogisticaModel.Fecha_S, Temperatura = _LogisticaModel.Temperatura });
//        }

//        public async Task DeleteLogistica(Guid id_a)
//        {
//            var toDeleteLogistica = (await firebase
//              .Child("Logistica")
//              .OnceAsync<Logistica>()).Where(a => a.Object.ID_A == id_a).FirstOrDefault();
//            await firebase.Child("Logistica").Child(toDeleteLogistica.Key).DeleteAsync();

//        }

//        FirebaseClient firebase;
//        //   private readonly FirebaseClient firebase;
//        public FirebaseLogistica()
//        {
//            firebase = new FirebaseClient("https://paltaproyect-default-rtdb.firebaseio.com/");
//        }
//    }
//}
