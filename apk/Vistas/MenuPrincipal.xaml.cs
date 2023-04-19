using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace apk.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btn_admin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new aLogin());
        }

        private void btn_operativo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new oLogin());
        }
    }
}