using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using apk.Models;
using apk.ViewModels;

namespace apk.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUsers : ContentPage
    {
        public EditUsers()
        {
            InitializeComponent();
            BindingContext = new EditUsersViewModel();
        }
        public EditUsers(Users _usersModel)
        {
            InitializeComponent();
            BindingContext = new EditUsersViewModel(_usersModel);
        }
    }
}