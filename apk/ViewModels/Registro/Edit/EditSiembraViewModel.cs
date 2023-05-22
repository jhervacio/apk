using apk.Models;
using apk.Services;
using apk.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Globalization;
using apk.Vistas.Registro;

namespace apk.ViewModels.Registro.Edit
{
    public class EditSiembraViewModel: BaseViewModel
    {
        FirebaseSiembra firebaseHelper = new FirebaseSiembra();

        private Guid ID_S;
        public string t_semilla;
        public string rot_tierra;
        public string nro_lote;
        public string fecha_s;

        #region Properties
        public Guid ID_S_Txt
        {
            get { return this.ID_S; }
            set { SetValue(ref this.ID_S, value); }
        }
        public string Fecha_S_Txt
        {
            get { return this.fecha_s; }
            set { SetValue(ref this.fecha_s, value); }
        }
        public string T_SemillaTxt
        {
            get { return this.t_semilla; }
            set { SetValue(ref this.t_semilla, value); }
        }

        public string Rot_TierraTxt
        {
            get { return this.rot_tierra; }
            set { SetValue(ref this.rot_tierra, value); }
        }

        public string Nro_LoteTxt
        {
            get { return this.nro_lote; }
            set { SetValue(ref this.nro_lote, value); }
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
            var siembra = new Siembra
            {
                ID_S = ID_S_Txt,
                Fecha_Siembra = Fecha_S_Txt,
                T_Semilla = T_SemillaTxt,
                Rot_Tierra = Rot_TierraTxt,
                Nro_Lote = Nro_LoteTxt,
            };

            await firebaseHelper.UpdateSiembra(siembra);

            await App.Current.MainPage.Navigation.PushAsync(new SiembraMenu());
        }
        private async void DeleteMethod()
        {
            await firebaseHelper.DeleteSiembra(ID_S_Txt);
            await App.Current.MainPage.Navigation.PushAsync(new MenuAdmin());

        }
        #endregion

        #region Constructor
        public EditSiembraViewModel(Siembra _siembraModel)
        {
            ID_S_Txt = _siembraModel.ID_S;
            Fecha_S_Txt = _siembraModel.Fecha_Siembra;
            T_SemillaTxt = _siembraModel.T_Semilla;
            Rot_TierraTxt = _siembraModel.Rot_Tierra;
            Nro_LoteTxt = _siembraModel.Nro_Lote;
        }

        public EditSiembraViewModel()
        {

        }
        #endregion
    }
}
