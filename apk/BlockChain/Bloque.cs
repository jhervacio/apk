using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using System.Threading.Tasks;

public class EthereumLogistica
{
    private readonly string _contractAddress;
    private readonly string _abi;

    public EthereumLogistica(string contractAddress, string abi)
    {
        _contractAddress = contractAddress;
        _abi = abi;
    }

    public async Task SetLogisticaData(string id, string nro_p, string fecha_s, string lugar_s, string fecha_e, string lugar_e)
    {
        var web3 = new Web3("https://rinkeby.infura.io/v3/YOUR_PROJECT_ID");
        var contract = web3.Eth.GetContract(_abi, _contractAddress); //abi-json
        var function = contract.GetFunction("setLogisticData");

        var transactionInput = function.CreateTransactionInput(web3.Accounts[0], new HexBigInteger(1000000), null, null, id, nro_p, fecha_s, lugar_s, fecha_e, lugar_e);
        var transactionHash = await web3.Eth.TransactionManager.SendTransactionAsync(transactionInput);
        var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
    }

    public async Task<(string, string, string, string, string)> GetLogisticaData(string id)
    {
        var web3 = new Web3("https://rinkeby.infura.io/v3/YOUR_PROJECT_ID //url mumbai
            //se devuelve un json -- se guarda para que quede en historial