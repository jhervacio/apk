using apk.ViewModels;
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
    public partial class oLogin : ContentPage
    {
        public oLogin()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }


        private async void btn_signIn_Clicked(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Text;

            var user = await new LoginViewModel().GetUsers(email, password);

            if (user != null)
            {
                // El inicio de sesión fue exitoso, navegar a la página principal de la aplicación
                await Navigation.PushAsync(new MenuOperativo());
            }
        }
    }
}