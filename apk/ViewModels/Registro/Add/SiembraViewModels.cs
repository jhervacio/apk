using apk.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using apk.Models;

namespace apk.ViewModels.Registro.Add
{
    public class SiembraViewModels :BaseViewModel
    {
        FirebaseSiembra firebaseHelper = new FirebaseSiembra();

        #region Attributes
        public string fecha_s;
        public string t_semilla;
        public string rot_tierra;
        public string nro_lote;
        public bool isRefreshing = false;
        public bool isVisible;
        public bool isEnabled;
        public bool isRunning;
        public object listViewSource;
        #endregion

        #region Properties
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


        public ICommand InsertCommand
        {
            get
            {
                return new RelayCommand(InsertMethod);
            }
        }

        #region Methods
        private async void InsertMethod()
        {
            var siembra= new Siembra
            {
                Fecha_Siembra = fecha_s,
                T_Semilla = t_semilla,
                Rot_Tierra = rot_tierra,
                Nro_Lote = nro_lote,
               
                //AgeField = int.Parse(age),
            };

            await firebaseHelper.AddSiembra(siembra);

            this.IsRefreshing = true;

            await Task.Delay(500); //pausa

            LoadData();

            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {
            this.ListViewSource = await firebaseHelper.GetAllSiembra();
        }
        #endregion

        #region .
        public ObservableCollection<Siembra> IngredientsCollection = new ObservableCollection<Siembra>();

        private async Task TestListViewBindingAsync()
        {
            var Ingredients = new List<Siembra>();

            {
                Ingredients = await firebaseHelper.GetAllSiembra();
            }
            foreach (var Ingredient in Ingredients)
            {
                IngredientsCollection.Add(Ingredient);
            }

        }
        #endregion

        #region Constructor
        public SiembraViewModels()
        {
            LoadData();
            // TestListViewBindingAsync();
        }
        #endregion
    }
}

