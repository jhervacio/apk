using apk.ViewModels.Registro.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using apk.BlockChain;

namespace apk.Vistas.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SiembraMenu : ContentPage
    {
        private ContractService contractService;
        private string provider = "https://matic-mumbai.chainstacklabs.com";
        private string contractAddress = "0x65344AF205b6c617dF24945771F9BdcBC8BE2fA1";
        private string privateKey = "0x184d7e927c317c5f4a6acae5713f1c4ff51ae49364fd0b32999a03e154bf41f5";
        private string abi = "[{\"inputs\":[],\"name\":\"getHarvest\",\"outputs\":[{\"components\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"abono\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"dotacion\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"madurez\",\"type\":\"string\"},{\"internalType\":\"uint8\",\"name\":\"size\",\"type\":\"uint8\"}],\"internalType\":\"structTraceability.Harvest[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getLogistic\",\"outputs\":[{\"components\":[{\"internalType\":\"uint256\",\"name\":\"packageId\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"incomePlace\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"exitPlace\",\"type\":\"string\"}],\"internalType\":\"structTraceability.Logistic[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getSown\",\"outputs\":[{\"components\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"typeSeed\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"rotation\",\"type\":\"string\"},{\"internalType\":\"uint32\",\"name\":\"lotNumber\",\"type\":\"uint32\"}],\"internalType\":\"structTraceability.Sown[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getStored\",\"outputs\":[{\"components\":[{\"internalType\":\"uint32\",\"name\":\"packageNumber\",\"type\":\"uint32\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"temperature\",\"type\":\"uint8\"}],\"internalType\":\"structTraceability.Stored[]\",\"name\":\"\",\"type\":\"tuple[]\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"harvestArr\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"abono\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"dotacion\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"madurez\",\"type\":\"string\"},{\"internalType\":\"uint8\",\"name\":\"size\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"_abono\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"_dotacion\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"_madurez\",\"type\":\"string\"},{\"internalType\":\"uint8\",\"name\":\"_size\",\"type\":\"uint8\"}],\"name\":\"insertHarvest\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_packageId\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"_incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"incomePlace\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"_exitDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"_exitPlace\",\"type\":\"string\"}],\"name\":\"insertLogistic\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"_typeSeed\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"_rotation\",\"type\":\"string\"},{\"internalType\":\"uint32\",\"name\":\"_lotNumber\",\"type\":\"uint32\"}],\"name\":\"insertSown\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint32\",\"name\":\"_packageNumber\",\"type\":\"uint32\"},{\"internalType\":\"uint256\",\"name\":\"_incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"_exitDate\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"_temperature\",\"type\":\"uint8\"}],\"name\":\"insertStored\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"logisticArr\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"packageId\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"incomePlace\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"exitPlace\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"sownArr\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"date\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"typeSeed\",\"type\":\"uint8\"},{\"internalType\":\"string\",\"name\":\"rotation\",\"type\":\"string\"},{\"internalType\":\"uint32\",\"name\":\"lotNumber\",\"type\":\"uint32\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"storedArr\",\"outputs\":[{\"internalType\":\"uint32\",\"name\":\"packageNumber\",\"type\":\"uint32\"},{\"internalType\":\"uint256\",\"name\":\"incomeDate\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"exitDate\",\"type\":\"uint256\"},{\"internalType\":\"uint8\",\"name\":\"temperature\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";

        public SiembraMenu()
        {
            InitializeComponent();
            contractService = new ContractService( provider,  contractAddress,  abi, privateKey);
            BindingContext = new SiembraViewModels();
            //contractService.AddSown(15022023, 2, "2 veces", 3)
            try {
                int fecha = Convert.ToInt16(FechaTxt.Text);
                int semilla = Convert.ToInt16(SemillaTxt.Text);
                string rotacion = Convert.ToString(RotacionTxt.Text);
                int lote = Convert.ToInt16(LoteTxt.Text);
                contractService.AddSown(Convert.ToInt16(FechaTxt.Text),Convert.ToInt16(SemillaTxt.Text),RotacionTxt.Text,Convert.ToInt16(LoteTxt.Text));
            
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
