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
    public partial class SiembraMenu : ContentPage
    {
        public SiembraMenu()
        {
            InitializeComponent();
            BindingContext = new SiembraViewModels();
        }
    }
}