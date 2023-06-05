using System;
using System.Collections.Generic;
using apk.ViewModels.Registro.Add;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using apk.Models;

namespace apk.Vistas.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CosechaMenu : ContentPage
    {
        private SiembraViewModels vm;
        public CosechaMenu()
        {
            InitializeComponent();
           BindingContext = new CosechaViewModels();
          vm = new SiembraViewModels();
           // BindingContext = vm;
            LoadSiembraIDs();

        }
        private void SiembraPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSiembra = siembraPicker.SelectedItem as Siembra;
            if (selectedSiembra != null)
            {
                // Aquí puedes realizar alguna acción con la siembra seleccionada
            }
        }
        private async void LoadSiembraIDs()
        {
            List<Guid> siembraIDs = await vm.GetSiembraIDs(); // Método en tu ViewModel para obtener las IDs de Siembra
            foreach (var id in siembraIDs)
            {
                siembraPicker.Items.Add(id.ToString());
            }
        }
        //private void SiembraPicker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Manejar el evento cuando se selecciona un elemento en el ComboBox
        //    // Aquí puedes obtener el valor seleccionado: siembraPicker.SelectedItem.ToString();
        //}
    }
}