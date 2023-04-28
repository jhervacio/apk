using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apk.Vistas.Registro;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace apk.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuOperativo : ContentPage
    {
        public MenuOperativo()
        {
            InitializeComponent();
        }

        private void btn_siembra_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Siembra());
        }

        private void btn_cosecha_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cosecha());
        }

        private void almacenado_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Almacenado());
        }

        private void Logistica_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Logistica());
        }
    }
}