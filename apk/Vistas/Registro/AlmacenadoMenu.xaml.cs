using apk.ViewModels.Registro.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apk.BlockChain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using apk.Models;

namespace apk.Vistas.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlmacenadoMenu : ContentPage

    {
        //   var provider = "https://matic-mumbai.chainstacklabs.com";
        // var contractAddress = "0x65344AF205b6c617dF24945771F9BdcBC8BE2fA1";
        //var privateKey = "0x184d7e927c317c5f4a6acae5713f1c4ff51ae49364fd0b32999a03e154bf41f5";
        //var abi = "[{\"inputs\":[],\"name\":\"getHarvest\",\"outputs\":[{\"components\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"abono\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"dotacion\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"madurez\",\"type\":\"string\"},{\"internalType\":\"uint8\",\"name\":\"size\",\"type\":\"uint8\"}],\"internalType\":\"structTraceability.Harvest[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getLogistic\",\"outputs\":[{\"components\":[{\"internalType\":\"uint256\",\"name\":\"packageId\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"incomePlace\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"exitPlace\",\"type\":\"string\"}],\"internalType\":\"structTraceability.Logistic[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getSown\",\"outputs\":[{\"components\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"typeSeed\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"rotation\",\"type\":\"string\"},{\"internalType\":\"uint32\",\"name\":\"lotNumber\",\"type\":\"uint32\"}],\"internalType\":\"structTraceability.Sown[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getStored\",\"outputs\":[{\"components\":[{\"internalType\":\"uint32\",\"name\":\"packageNumber\",\"type\":\"uint32\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"temperature\",\"type\":\"uint8\"}],\"internalType\":\"structTraceability.Stored[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"harvestArr\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"abono\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"dotacion\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"madurez\",\"type\":\"string\"},{\"internalType\":\"uint8\",\"name\":\"size\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"_abono\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"_dotacion\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"_madurez\",\"type\":\"string\"},{\"internalType\":\"uint8\",\"name\":\"_size\",\"type\":\"uint8\"}],\"name\":\"insertHarvest\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_packageId\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"_incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"incomePlace\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"_exitDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"_exitPlace\",\"type\":\"string\"}],\"name\":\"insertLogistic\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"_typeSeed\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"_rotation\",\"type\":\"string\"},{\"internalType\":\"uint32\",\"name\":\"_lotNumber\",\"type\":\"uint32\"}],\"name\":\"insertSown\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint32\",\"name\":\"_packageNumber\",\"type\":\"uint32\"},{\"internalType\":\"uint256\",\"name\":\"_incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"_exitDate\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"_temperature\",\"type\":\"uint8\"}],\"name\":\"insertStored\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"logisticArr\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"packageId\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"incomePlace\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"exitPlace\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"sownArr\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"typeSeed\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"rotation\",\"type\":\"string\"},{\"internalType\":\"uint32\",\"name\":\"lotNumber\",\"type\":\"uint32\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"storedArr\",\"outputs\":[{\"internalType\":\"uint32\",\"name\":\"packageNumber\",\"type\":\"uint32\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"temperature\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
        private CosechaViewModels vm;
        public AlmacenadoMenu()
        {
            InitializeComponent();
            BindingContext = new AlmacenadoViewModels();
            vm = new CosechaViewModels();
            LoadCosechaIDs();
        }

        private void cosechaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCosecha = cosechaPicker.SelectedItem as Cosecha;
            if (selectedCosecha != null)
            {
                // Aquí puedes realizar alguna acción con la siembra seleccionada
            }
        }
        private async void LoadCosechaIDs()
        {
            List<Guid> cosechaIDs = await vm.GetCosechaIDs();// Método en tu ViewModel para obtener las IDs de Siembra
            foreach (var id in cosechaIDs)
            {
                cosechaPicker.Items.Add(id.ToString());
            }
        }
    }
}