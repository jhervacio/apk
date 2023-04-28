using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apk.Models;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Xamarin.Essentials;

namespace apk.Services
{
    public class FirebaseHelper
    {
        public async Task<List<Users>> GetAllUsers()
        {

            return (await firebase
              .Child("Users")
              .OnceAsync<Users>()).Select(item => new Users
              {
                  ID = item.Object.ID,
                  Correo = item.Object.Correo,
                  Nombre = item.Object.Nombre,
                  Apellido = item.Object.Apellido,
                  Telefono = item.Object.Telefono,
                  Contraseña=item.Object.Contraseña
              }).ToList();
        }

        public async Task<List<Users>> GetAllUsers2()
        {
            return (await firebase.Child("Users").OnceAsync<Users>()).Select(item => new Users
            {
                Correo = item.Object.Correo,
                Contraseña = item.Object.Contraseña
            }).ToList();
        }
       
        public async Task AddUsers(Users _usersModel)
        {
            await firebase
            .Child("Users")
            .PostAsync(new Users()
            {
                ID = Guid.NewGuid(),
                Correo = _usersModel.Correo,
                Nombre = _usersModel.Nombre,
                Apellido= _usersModel.Apellido, 
                Telefono= _usersModel.Telefono, 
                Contraseña=_usersModel.Contraseña
            });
        }

        public async Task UpdateUsers(Users _userModel)
        {
            var toUpdateUsers = (await firebase
              .Child("Users")
              .OnceAsync<Users>()).Where(a => a.Object.ID == _userModel.ID).FirstOrDefault();

            await firebase
              .Child("Users")
              .Child(toUpdateUsers.Key)
              .PutAsync(new Users() { ID = _userModel.ID , Nombre = _userModel.Nombre, Apellido = _userModel.Apellido, Correo=_userModel.Correo, Telefono=_userModel.Telefono, Contraseña=_userModel.Contraseña });
        }

        public async Task DeleteUsers(Guid id)
        {
            var toDeleteUsers = (await firebase
              .Child("Users")
              .OnceAsync<Users>()).Where(a => a.Object.ID == id).FirstOrDefault();
            await firebase.Child("Users").Child(toDeleteUsers.Key).DeleteAsync();

        }

    /*    public async Task<Users> GetUserByEmail(string email)
        {
            try
            {
                // Obtener una referencia a la lista de usuarios en la base de datos
                var usersRef = firebase.Child("users");

                // Obtener el usuario con el correo electrónico especificado
                var snapshot = await usersRef
                    .OrderBy("Email")
                    .EqualTo(email)
                    .OnceAsync<Users>();
                var user = snapshot.FirstOrDefault()?.Value as Users;

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    */
     /*   public async Task<Users> GetUserByEmail2(string email)
        {
            var users = await GetAllUsers2();

            return users.FirstOrDefault(u => u.Correo == email);
        }*/
        /*
        public async Task<PersonModel> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<PersonModel>();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }



        public async Task UpdatePerson(int personId, string name)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<PersonModel>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new PersonModel() { PersonId = personId, NameField = name });
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<PersonModel>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
        */
        FirebaseClient firebase;
     //   private readonly FirebaseClient firebase;
        public FirebaseHelper()
        {
            firebase = new FirebaseClient("https://paltaproyect-default-rtdb.firebaseio.com/");
        }
    }
}
