using apk.Models;
using apk.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace apk.ViewModels.Registro.Add
{
    public class CosechaViewModels :BaseViewModel
    {
        FirebaseCosecha firebaseHelper = new FirebaseCosecha();

        #region Attributes
        public string id_s;
        public string fecha_c;
        public string abono;
        public string dotacion;
        public string tamaño;
        public string madurez;
        public bool isRefreshing = false;
        public bool isVisible;
        public bool isEnabled;
        public bool isRunning;
        public object listViewSource;
        #endregion

        #region Properties

        public string ID_S_Txt
        {
            get { return this.id_s; }
            set { SetValue(ref this.id_s, value); }
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
            var cosecha = new Cosecha
            {
                ID_S = id_s,
                Fecha_C = fecha_c,
                Abono = abono,
                Dotacion = dotacion,
                Tamaño = tamaño,
                Madurez = madurez,
                //AgeField = int.Parse(age),
            };

            await firebaseHelper.AddCosecha(cosecha);

            this.IsRefreshing = true;

            await Task.Delay(500); //pausa

            LoadData();

            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {
            this.ListViewSource = await firebaseHelper.GetAllCosecha();
        }
        #endregion

        #region .
        public ObservableCollection<Cosecha> IngredientsCollection = new ObservableCollection<Cosecha>();

        private async Task TestListViewBindingAsync()
        {
            var Ingredients = new List<Cosecha>();

            {
                Ingredients = await firebaseHelper.GetAllCosecha();
            }
            foreach (var Ingredient in Ingredients)
            {
                IngredientsCollection.Add(Ingredient);
            }

        }

        public ObservableCollection<Siembra> Siembras { get; set; }

        public async Task<List<Guid>> GetCosechaIDs()
        {
            List<Guid> cosechaIDs = new List<Guid>();

            // Aquí obtienes los datos de las tablas de Siembra desde Firebase
            var cosechas = await firebaseHelper.GetAllCosecha();

            foreach (var cosecha in cosechas)
            {
                cosechaIDs.Add(cosecha.ID_C);
            }

            return cosechaIDs;
        }
        public List<Cosecha> CosechaIDs { get; set; } // Lista de Siembra con las ID_S
        public Cosecha SelectedCosechaID { get; set; }
        #endregion

        #region Constructor
        public CosechaViewModels()
        {
            LoadData();
          //  Siembras = new ObservableCollection<Siembra>();
            // TestListViewBindingAsync();
        }

        //public async Task LoadData()
        //{
        //    var siembras = await firebaseHelper.GetAllSiembra();
        //    Siembras.Clear();
        //    foreach (var siembra in siembras)
        //    {
        //        Siembras.Add(siembra);
        //    }
        //}
        #endregion
    }

}