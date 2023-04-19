using apk.Models;
using apk.Services;
using Firebase.Database;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace apk.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

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
                  Contraseña = item.Object.Contraseña
              }).ToList();
        }
        /*  public async Task<Users> GetUsers(Users Id)
          {
              var allUsers = await GetAllUsers();
              await firebase.Child("Users").OnceAsync<Users>();
              return allUsers.FirstOrDefault(a => a.ID == Id.ID);
          }*/

        /*/  public async Task<Users> GetUsers(string Id, string email, string password)
          {
              var allUsers = await GetAllUsers();
              await firebase.Child("Users").OnceAsync<Users>();
              var userId = Guid.Parse(Id);
              var user = allUsers.FirstOrDefault(a => a.ID == userId);

              if (user != null && user.Correo == email && user.Contraseña == password)
              {
                  return user;
              }
              else
              {
                  MessageBox.Show("Usuario o contraseña no válidos");
                  return null;
              }
          }
        */

    /*   public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(GetUsers(string email,string password));
            }
        }*/

        public async Task<Users> GetUsers(string email, string password)
        {
            var allUsers = await GetAllUsers();
            await firebase.Child("Users").OnceAsync<Users>();
            var user = allUsers.FirstOrDefault(a => a.Correo == email && a.Contraseña == password);

            if (user != null)
            {
                return user;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Usuario o contraseña no validos", "OK");
                // MessageBox.Show("Usuario o contraseña no válidos");
                return null;
            }
        }

        /*   public async Task GetUsers(Users Id)
           {
               var allUsers = (await firebase
                 .Child("Users")
                 .OnceAsync<Users>()).Where(a => a.Object.ID == Id.ID).FirstOrDefault();
           }*/

        FirebaseClient firebase;
        public LoginViewModel()
        {
            firebase = new FirebaseClient("https://paltaproyect-default-rtdb.firebaseio.com/");
        }
    }
}
