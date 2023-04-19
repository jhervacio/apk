using GalaSoft.MvvmLight.Command;
//using Firebase.Auth;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using apk.Models;
using apk.Services;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;

namespace apk.ViewModels
{
    public class UsersViewModels :BaseViewModel
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        #region Attributes
        public string correo;
        public string nombre;
        public string apellido;
        public string telefono;
        public string contraseña;
        public bool isRefreshing = false;
        public bool isVisible;
        public bool isEnabled;
        public bool isRunning;
        public object listViewSource;
        #endregion

        #region Properties
        public string CorreoTxt
        {
            get { return this.correo; }
            set { SetValue(ref this.correo, value); }
        }

        public string ContraseñaTxt
        {
            get { return this.contraseña; }
            set { SetValue(ref this.contraseña, value); }
        }

        public string NombreTxt
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string ApellidoTxt
        {
            get { return this.apellido; }
            set { SetValue(ref this.apellido, value); }
        }
        public string TelefonoTxt
        {
            get { return this.telefono; }
            set { SetValue(ref this.telefono, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public object ListViewSource
        {

            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Commands
        public ICommand InsertCommand
        {
            get
            {
                return new RelayCommand(InsertMethod);
            }
        }
        /*  public ICommand LoginCommand
          {
              get
              {
                  return new RelayCommand(LoginMethod);
              }
          }*/
        #endregion
        /*    public async void LoginMethod()
            {
                if (string.IsNullOrEmpty(this.correo))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "You must enter an email.",
                        "Accept");
                    return;
                }
                if (string.IsNullOrEmpty(this.contraseña))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "You must enter a password.",
                        "Accept");
                    return;
                }

                string WebAPIkey = "AIzaSyCv4ChrVr6dzGnkmLxHMYBzvLwzc8OGNu4";


                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                try
                {
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(CorreoTxt.ToString(), ContraseñaTxt.ToString());
                    var content = await auth.GetFreshAuthAsync();
                    var serializedcontnet = JsonConvert.SerializeObject(content);

                    Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

                    //Puede navegar al tener autorizacion
                    await Application.Current.MainPage.Navigation.PushAsync(new ContainerTabbedPags());
                    this.IsRunningTxt = false;
                    this.IsVisibleTxt = false;
                    this.IsEnabledTxt = true;
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");

                    this.IsRunningTxt = false;
                    this.IsVisibleTxt = false;
                    this.IsEnabledTxt = true;
                }

            }*/
        #region Methods
        private async void InsertMethod()
        {
            var user = new Users
            {
                Nombre = nombre,
                Apellido = apellido,
                Correo= correo,
                Telefono=telefono,
                Contraseña=contraseña,
                //AgeField = int.Parse(age),
            };

            await firebaseHelper.AddUsers(user);

            this.IsRefreshing = true;

            await Task.Delay(1000); //pausa

            LoadData();

            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {
            this.ListViewSource = await firebaseHelper.GetAllUsers();
        }
        #endregion

        #region .
        public ObservableCollection<Users> IngredientsCollection = new ObservableCollection<Users>();

        private async Task TestListViewBindingAsync()
        {
            var Ingredients = new List<Users>();

            {
                Ingredients = await firebaseHelper.GetAllUsers();
            }
            foreach (var Ingredient in Ingredients)
            {
                IngredientsCollection.Add(Ingredient);
            }

        }
        #endregion

        #region Constructor
        public UsersViewModels()
        {
            LoadData();
           // TestListViewBindingAsync();
        }
        #endregion
    }
}

