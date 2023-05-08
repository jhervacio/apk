using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

public class RegistroPalta
{
    public string tipoSemilla;
    public uint fechaSiembra;
    public uint cantidadSemillas;
}

public class RegistroPaltaContract
{
    private readonly Web3 web3;
    private readonly string contractAddress;
    private readonly Nethereum.Contracts.Contract contract;

    public RegistroPaltaContract(string url, string privateKey, string contractAddress)
    {
        var account = new Account(privateKey);
        this.web3 = new Web3(account, url);
        this.contractAddress = contractAddress;
        this.contract = web3.Eth.GetContract(ABI, contractAddress);
    }

    public async Task<RegistroPalta> VerSiembraAsync()
    {
        var function = contract.GetFunction("verSiembra");
        var result = await function.CallDeserializingToObjectAsync<RegistroPalta>();
        return result;
    }

    public async Task RegistrarSiembraAsync(string tipoSemilla, uint fechaSiembra, uint cantidadSemillas)
    {
        var function = contract.GetFunction("registrarSiembra");
        var transaction = await function.SendTransactionAsync(Account, tipoSemilla, fechaSiembra, cantidadSemillas);
    }

    private string ABI = @"[{""constant"":false,""inputs"":[{""name"":""_tipoSemilla"",""type"":""string""},{""name"":""_fechaSiembra"",""type"":""uint256""},{""name"":""_cantidadSemillas"",""type"":""uint256""}],""name"":""registrarSiembra"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""verSiembra"",""outputs"":[{""name"":""_tipoSemilla"",""type"":""string""},{""name"":""_fechaSiembra"",""type"":""uint256""},{""name"":""_cantidadSemillas"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""}]";

    private string Account => web3.TransactionManager.Account.Address;
}
