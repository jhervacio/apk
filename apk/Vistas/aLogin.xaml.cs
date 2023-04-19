using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace apk.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class aLogin : ContentPage
    {
        public aLogin()
        {
            InitializeComponent();
        }
         public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public ICommand Volvercommand => new Command(async () => await Volver());

        private void btn_signIn_Clicked(object sender, EventArgs e)
        {
            if (txtEmail.Text == "admin" && txtPassword.Text=="123")
            {
                Navigation.PushAsync(new MenuAdmin());
            }
            else
            {
                DisplayAlert("Alert", "Email O Contraseña invalidos!", "Ok");
            }
        }
    }
}