using apk.Models;
using apk.Services;
using apk.Vistas.Registro;
using apk.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace apk.ViewModels.Registro.Edit
{
    public class EditCosechaViewModel:BaseViewModel
    {
        FirebaseCosecha firebaseHelper = new FirebaseCosecha();

        private Guid ID_C;
        public string abono;
        public string dotacion;
        public string tamaño;
        public string madurez;
        public string fecha_c;

        #region Properties
        public Guid ID_C_Txt
        {
            get { return this.ID_C; }
            set { SetValue(ref this.ID_C, value); }
        }
        public string Fecha_C_Txt
        {
            get { return this.fecha_c; }
            set { SetValue(ref this.fecha_c, value); }
        }
        public string AbonoTxt
        {
            get { return this.abono; }
            set { SetValue(ref this.abono, value); }
        }

        public string DotacionTxt
        {
            get { return this.dotacion; }
            set { SetValue(ref this.dotacion, value); }
        }

        public string TamañoTxt
        {
            get { return this.tamaño; }
            set { SetValue(ref this.tamaño, value); }
        }
        public string MadurezTxt
        {
            get { return this.madurez; }
            set { SetValue(ref this.madurez, value); }
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
            var cosecha = new Cosecha
            {
                ID_C = ID_C_Txt,
                Fecha_C = Fecha_C_Txt,
                Abono = AbonoTxt,
                Dotacion = DotacionTxt,
                Tamaño = TamañoTxt,
                Madurez = MadurezTxt,
            };

            await firebaseHelper.UpdateCosecha(cosecha);

            await App.Current.MainPage.Navigation.PushAsync(new CosechaMenu());
        }
        private async void DeleteMethod()
        {
            await firebaseHelper.DeleteCosecha(ID_C_Txt);
            await App.Current.MainPage.Navigation.PushAsync(new CosechaMenu());

        }
        #endregion

        #region Constructor
        public EditCosechaViewModel(Cosecha _cosechaModel)
        {
            ID_C_Txt = _cosechaModel.ID_C;
            Fecha_C_Txt = _cosechaModel.Fecha_C;
            abono = _cosechaModel.Abono;
            dotacion = _cosechaModel.Dotacion;
            tamaño = _cosechaModel.Tamaño;
            madurez = _cosechaModel.Madurez;
        }

        public EditCosechaViewModel()
        {

        }
        #endregion
    }
}
