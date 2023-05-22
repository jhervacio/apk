using System;
using System.Collections.Generic;
using System.Text;
using apk.Models;
using apk.Services;
using apk.Vistas.Registro;
using apk.Vistas;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace apk.ViewModels.Registro.Edit
{
    public class EditAlmacenadoViewModel : BaseViewModel
    {
        FirebaseAlmacenado firebaseHelper = new FirebaseAlmacenado();

        private Guid ID_A;
        public string fecha_i;
        public string fecha_s;
        public string nro_p;
        public string temperatura;

        #region Properties
        public Guid ID_A_Txt
        {
            get { return this.ID_A; }
            set { SetValue(ref this.ID_A, value); }
        }
        public string Fecha_I_Txt
        {
            get { return this.fecha_i; }
            set { SetValue(ref this.fecha_i, value); }
        }

        public string Fecha_S_Txt
        {
            get { return this.fecha_s; }
            set { SetValue(ref this.fecha_s, value); }
        }

        public string Nro_P_Txt
        {
            get { return this.nro_p; }
            set { SetValue(ref this.nro_p, value); }
        }

        public string TemperaturaTxt
        {
            get { return this.temperatura; }
            set { SetValue(ref this.temperatura, value); }
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
        var Almacenado = new Almacenado
        {
            ID_A = ID_A_Txt,
            Fecha_I = Fecha_I_Txt,
            Fecha_S = Fecha_S_Txt,
            Nro_P = Nro_P_Txt,
            Temperatura = TemperaturaTxt,
        };

        await firebaseHelper.UpdateAlmacenado(Almacenado);

        await App.Current.MainPage.Navigation.PushAsync(new AlmacenadoMenu());
    }
    private async void DeleteMethod()
    {
        await firebaseHelper.DeleteAlmacenado(ID_A_Txt);
        await App.Current.MainPage.Navigation.PushAsync(new MenuAdmin());

    }
    #endregion

    #region Constructor
    public EditAlmacenadoViewModel(Almacenado _AlmacenadoModel)
    {
        ID_A_Txt = _AlmacenadoModel.ID_A;
        Fecha_S_Txt = _AlmacenadoModel.Fecha_S;
        Fecha_I_Txt = _AlmacenadoModel.Fecha_I;
        Nro_P_Txt = _AlmacenadoModel.Nro_P;
        TemperaturaTxt = _AlmacenadoModel.Temperatura;
    }

    public EditAlmacenadoViewModel()
    {

    }
    #endregion
}
}