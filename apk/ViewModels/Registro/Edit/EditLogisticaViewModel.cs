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
    public class EditLogisticaViewModel :BaseViewModel
    {
        FirebaseLogistica firebaseHelper = new FirebaseLogistica();

        private Guid ID_L;
        public string fecha_s;
        public string fecha_e;
        public string nro_p;
        public string lugar_s;
        public string lugar_e;

        #region Properties
        public Guid ID_L_Txt
        {
            get { return this.ID_L; }
            set { SetValue(ref this.ID_L, value); }
        }
        public string Fecha_S_Txt
        {
            get { return this.fecha_s; }
            set { SetValue(ref this.fecha_s, value); }
        }

        public string Fecha_E_Txt
        {
            get { return this.fecha_e; }
            set { SetValue(ref this.fecha_e, value); }
        }

        public string Nro_P_Txt
        {
            get { return this.nro_p; }
            set { SetValue(ref this.nro_p, value); }
        }

        public string Lugar_S_Txt
        {
            get { return this.lugar_s; }
            set { SetValue(ref this.lugar_s, value); }
        }

        public string Lugar_E_Txt
        {
            get { return this.lugar_e; }
            set { SetValue(ref this.lugar_e, value); }
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
            var logistica = new Logistica
            {
                ID_L=ID_L_Txt,
                Fecha_S = Fecha_S_Txt,
                Fecha_E = Fecha_S_Txt,
                Nro_P = Nro_P_Txt,
                Lugar_E = Lugar_E_Txt,
                Lugar_S = Lugar_S_Txt,
            };

            await firebaseHelper.UpdateLogistica(logistica);

            await App.Current.MainPage.Navigation.PushAsync(new LogisticaMenu());
        }
        private async void DeleteMethod()
        {
            await firebaseHelper.DeleteLogistica(ID_L_Txt);
            await App.Current.MainPage.Navigation.PushAsync(new LogisticaMenu());

        }
        #endregion

        #region Constructor
        public EditLogisticaViewModel(Logistica _LogisticaModel)
        {
            ID_L_Txt = _LogisticaModel.ID_L;
            Fecha_S_Txt = _LogisticaModel.Fecha_S;
            Fecha_E_Txt = _LogisticaModel.Fecha_E;
            Nro_P_Txt = _LogisticaModel.Nro_P;
            Lugar_E_Txt = _LogisticaModel.Lugar_E;
            Lugar_S_Txt = _LogisticaModel.Lugar_S;
        }

        public EditLogisticaViewModel()
        {

        }
        #endregion
    }
}
