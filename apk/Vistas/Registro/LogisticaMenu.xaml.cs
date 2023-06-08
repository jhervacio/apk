using apk.Models;
using apk.ViewModels.Registro.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace apk.Vistas.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogisticaMenu : ContentPage
    {
        private AlmacenadoViewModels vm;
        public LogisticaMenu()
        {
            InitializeComponent();
            BindingContext = new LogisticaViewModels();
            vm = new AlmacenadoViewModels();
            LoadAlmacenadoIDs();
            
        }

        private void almacenadoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAlmacenado = almacenadoPicker.SelectedItem as Almacenado;
            if (selectedAlmacenado != null)
            {
                // Aquí puedes realizar alguna acción con la siembra seleccionada
            }
        }
        private async void LoadAlmacenadoIDs()
        {
            List<Guid> almacenadoIDs = await vm.GetAlmacenadoIDs();// Método en tu ViewModel para obtener las IDs de Siembra
            foreach (var id in almacenadoIDs)
            {
                almacenadoPicker.Items.Add(id.ToString());
            }
        }
    }
}