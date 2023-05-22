using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apk.ViewModels.Registro.Add;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace apk.Vistas.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CosechaMenu : ContentPage
    {
        public CosechaMenu()
        {
            InitializeComponent();
            BindingContext = new CosechaViewModels();
        }
    }
}