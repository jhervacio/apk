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
    public class AlmacenadoViewModels :BaseViewModel
    {
        FirebaseAlmacenado firebaseHelper = new FirebaseAlmacenado();

        #region Attributes
        public string id_c;
        public string fecha_i;
        public string fecha_s;
        public string nro_p;
        public string temperatura;
        public bool isRefreshing = false;
        public bool isVisible;
        public bool isEnabled;
        public bool isRunning;
        public object listViewSource;
        #endregion

        #region Properties

        public string ID_C_Txt
        {
            get { return this.id_c; }
            set { SetValue(ref this.id_c, value); }
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
            var almacenado = new Almacenado
            {
                ID_C = id_c,
                Fecha_I = fecha_i,
                Fecha_S = fecha_s,
                Nro_P = nro_p,
                Temperatura = temperatura,
                //AgeField = int.Parse(age),
            };

            await firebaseHelper.AddAlmacenado(almacenado);

            this.IsRefreshing = true;

            await Task.Delay(500); //pausa

            LoadData();

            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {
            this.ListViewSource = await firebaseHelper.GetAllAlmacenado();
        }
        #endregion

        #region .
        public ObservableCollection<Almacenado> IngredientsCollection = new ObservableCollection<Almacenado>();

        private async Task TestListViewBindingAsync()
        {
            var Ingredients = new List<Almacenado>();

            {
                Ingredients = await firebaseHelper.GetAllAlmacenado();
            }
            foreach (var Ingredient in Ingredients)
            {
                IngredientsCollection.Add(Ingredient);
            }

        }

        public ObservableCollection<Cosecha> Cosechas { get; set; }

        public async Task<List<Guid>> GetAlmacenadoIDs()
        {
            List<Guid> almacenadoIDs = new List<Guid>();

            // Aquí obtienes los datos de las tablas de Siembra desde Firebase
            var almacenados = await firebaseHelper.GetAllAlmacenado();

            foreach (var almacenado in almacenados)
            {
                almacenadoIDs.Add(almacenado.ID_A);
            }

            return almacenadoIDs;
        }
        public List<Almacenado>AlmacenadoIDs { get; set; } // Lista de Siembra con las ID_S
        public Almacenado SelectedAlmacenadoID { get; set; }
        #endregion

        #region Constructor
        public AlmacenadoViewModels()
        {
            LoadData();
            // TestListViewBindingAsync();
        }
        #endregion
    }
}

