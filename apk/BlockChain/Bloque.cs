//using Nethereum.Web3;
//using Nethereum.Contracts;
//using Nethereum.Hex.HexTypes;
//using System.Threading.Tasks;

//public class EthereumLogistica
//{
//    private readonly string _contractAddress;
//    private readonly string _abi;

//    public EthereumLogistica(string contractAddress, string abi)
//    {
//        _contractAddress = contractAddress;
//        _abi = abi;
//    }

//    public async Task SetLogisticaData(string id, string nro_p, string fecha_s, string lugar_s, string fecha_e, string lugar_e)
//    {
//        var web3 = new Web3("https://rinkeby.infura.io/v3/YOUR_PROJECT_ID");
//        var contract = web3.Eth.GetContract(_abi, _contractAddress); //abi-json
//        var function = contract.GetFunction("setLogisticData");

//        var transactionInput = function.CreateTransactionInput(web3.Accounts[0], new HexBigInteger(1000000), null, null, id, nro_p, fecha_s, lugar_s, fecha_e, lugar_e);
//        var transactionHash = await web3.Eth.TransactionManager.SendTransactionAsync(transactionInput);
//        var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
//    }

//    public async Task<(string, string, string, string, string)> GetLogisticaData(string id)
//    {
//        var web3 = new Web3("https://rinkeby.infura.io/v3/YOUR_PROJECT_ID //url mumbai
//            //se devuelve un json -- se guarda para que quede en historial

//using System;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Collections.Generic;

namespace apk.BlockChain
{
        public class ContractService
        {

            private readonly Web3 web3;
            private readonly Contract contract;
            private readonly Account account;

            private static readonly HexBigInteger GAS = new HexBigInteger(4600000);

            public struct Sown
            {
                public int date { get; set; }
                public int typeSeed { get; set; }
                public string rotation { get; set; }
                public int lotNumber { get; set; }
            }

            public struct Harvest
            {
                public int date { get; set; }
                public int abono { get; set; }
                public string dotacion { get; set; }
                public string madurez { get; set; }
                public int size { get; set; }
            }

            public struct Stored
            {
                public int packageNumber { get; set; }
                public int incomeDate { get; set; }
                public int exitDate { get; set; }
                public int temperature { get; set; }
            }

            public struct Logistic
            {
                public int packageId { get; set; }
                public int incomeDate { get; set; }
                public string incomePlace { get; set; }
                public int exitDate { get; set; }
                public string exitPlace { get; set; }
            }
            public ContractService(string provider, string contractAddress, string abi, string privateKey)
            {
                this.account = new Account(privateKey);
                this.web3 = new Web3(account, provider);
                this.contract = web3.Eth.GetContract(abi, contractAddress);
            }

            public string AddSown(int _date, int _typeSeed, string _rotation, int _lotNumber)
            {
                var addSownFunction = contract.GetFunction("insertSown");
                var txHash = addSownFunction.SendTransactionAsync(account.Address, GAS, new HexBigInteger(0), _date, _typeSeed, _rotation, _lotNumber)//,date
                                .ConfigureAwait(false)
                                .GetAwaiter()
                                .GetResult();
                return txHash;
            }
            public List<Sown> getSown()
            {
                var getFactFunction = contract.GetFunction("getSown");
                var task = getFactFunction.CallAsync<List<Sown>>();
                var fact = task.Result;

                return fact;
            }
            public string AddHarvest(int _date, int _abono, string _dotacion, string _madurez, int _size)
            {
                var addHarvestFunction = contract.GetFunction("insertHarvest");
                var txHash = addHarvestFunction.SendTransactionAsync(account.Address, GAS, new HexBigInteger(0), _date, _abono, _dotacion, _madurez, _size)
                                .ConfigureAwait(false)
                                .GetAwaiter()
                                .GetResult();
                return txHash;
            }
            public List<Harvest> getHarvest()
            {
                var getFactFunction = contract.GetFunction("getHarvest");
                var task = getFactFunction.CallAsync<List<Harvest>>();
                var fact = task.Result;

                return fact;
            }
            public string AddStored(int _packageNumber, int _incomeDate, int _exitDate, int _temperature)
            {
                var addStoredFunction = contract.GetFunction("insertStored");
                var txHash = addStoredFunction.SendTransactionAsync(account.Address, GAS, new HexBigInteger(0), _packageNumber, _incomeDate, _exitDate, _temperature)//,date
                                .ConfigureAwait(false)
                                .GetAwaiter()
                                .GetResult();
                return txHash;
            }
            public List<Stored> getStored()
            {
                var getFactFunction = contract.GetFunction("getStored");
                var task = getFactFunction.CallAsync<List<Stored>>();
                var fact = task.Result;

                return fact;
            }
            public string AddLogistic(int _packageId, int _incomeDate, string incomePlace, int _exitDate, string _exitPlace)
            {
                var addLogisticFunction = contract.GetFunction("insertLogistic");
                var txHash = addLogisticFunction.SendTransactionAsync(account.Address, GAS, new HexBigInteger(0), _packageId, _incomeDate, incomePlace, _exitDate, _exitPlace)//,date
                                .ConfigureAwait(false)
                                .GetAwaiter()
                                .GetResult();
                return txHash;
            }
            public List<Logistic> getLogistic()
            {
                var getFactFunction = contract.GetFunction("getLogistic");
                var task = getFactFunction.CallAsync<List<Logistic>>();
                var fact = task.Result;

                return fact;
            }

        }
    }