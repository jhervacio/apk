using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using apk.Models;
using apk.Services;
using apk.Vistas;

namespace apk.ViewModels
{
    public class EditUsersViewModel: BaseViewModel
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        private Guid ID;
        private string correo;
        private string nombre;
        private string apellido;
        private string telefono;
        private string contraseña;

        #region Properties
        public Guid IDTxt
        {
            get { return this.ID; }
            set { SetValue(ref this.ID, value); }
        }
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
        #endregion

        #region Commands
        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(UpdateMethod);
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteMethod);
            }
        }
        #endregion

        #region Methods

        private async void UpdateMethod()
        {
            var person = new Users
            {
                ID = IDTxt,
                Nombre = NombreTxt,
                Apellido = ApellidoTxt,
                Correo = CorreoTxt,
                Telefono = TelefonoTxt,
                Contraseña = ContraseñaTxt,
            };

            await firebaseHelper.UpdateUsers(person);

            await App.Current.MainPage.Navigation.PushAsync(new MenuAdmin());
        }
        private async void DeleteMethod()
        {
            await firebaseHelper.DeleteUsers(IDTxt);
            await App.Current.MainPage.Navigation.PushAsync(new MenuAdmin());

        }
        #endregion

        #region Constructor
        public EditUsersViewModel(Users _usersModel)
        {
            IDTxt = _usersModel.ID;
            CorreoTxt = _usersModel.Correo;
            NombreTxt = _usersModel.Nombre;
            ApellidoTxt = _usersModel.Apellido;
            TelefonoTxt = _usersModel.Telefono;
            ContraseñaTxt = _usersModel.Contraseña;
        }

        public EditUsersViewModel()
        {

        }
        #endregion
    }

}
