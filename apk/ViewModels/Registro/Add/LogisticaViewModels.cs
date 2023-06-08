using apk.Models;
using apk.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace apk.ViewModels.Registro.Add
{
    public class LogisticaViewModels :BaseViewModel
    {
        FirebaseLogistica firebaseHelper = new FirebaseLogistica();

        #region Attributes
        public string fecha_s;
        public string fecha_e;
        public string nro_p;
        public string lugar_s;
        public string lugar_e;
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
            var Logistica = new Logistica
            {
                Fecha_S = fecha_s,
                Fecha_E = fecha_e,
                Nro_P = nro_p,
                Lugar_E = lugar_e,
                Lugar_S = lugar_s,
                //AgeField = int.Parse(age),
            };

            await firebaseHelper.AddLogistica(Logistica);

            this.IsRefreshing = true;

            await Task.Delay(500); //pausa

            LoadData();

            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {
            this.ListViewSource = await firebaseHelper.GetAllLogistica();
        }
        #endregion

        #region .
        public ObservableCollection<Logistica> IngredientsCollection = new ObservableCollection<Logistica>();

        private async Task TestListViewBindingAsync()
        {
            var Ingredients = new List<Logistica>();

            {
                Ingredients = await firebaseHelper.GetAllLogistica();
            }
            foreach (var Ingredient in Ingredients)
            {
                IngredientsCollection.Add(Ingredient);
            }

        }

        public ObservableCollection<Almacenado> Almacenados { get; set; }
    
        #endregion

        #region Constructor
        public LogisticaViewModels()
        {
            LoadData();
            // TestListViewBindingAsync();
        }
        #endregion
    }
}

