using System;
using System.Threading.Tasks;
using BankApiAutomation.Models;
using BankApiAutomation.Utils;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using RestSharpTest.Models;
using TechTalk.SpecFlow;

namespace RestSharpTest.BankApiAutomationTests.Steps
{
    [Binding]
    public class BankApiSteps
    {
        private readonly ApiUtils _apiHelper;
        private ApiResponse<CreateAccountResponse> _createAccountResponse;
        ApiResponse<DepositeAccountResponse> _depositeAccountResponse;

        // Use ScenarioContext to share data between steps
        private readonly ScenarioContext _scenarioContext;

        public BankApiSteps(ScenarioContext scenarioContext)
        {
            _apiHelper = new ApiUtils();
            _scenarioContext = scenarioContext;
        }

        public void AccountInitialBalance(int initialBalance)
        {
            _scenarioContext["InitialBalance"] = initialBalance;
        }

        public void AccountNameIs(string accountName)
        {
            _scenarioContext["AccountName"] = accountName;
        }

        public void AddressIs(string address)
        {
            _scenarioContext["Address"] = address;
        }

        public void DepositeAmount(int depositeAmount)
        {
            _scenarioContext["DepositeAmount"] = depositeAmount;
        }

        public void WithdrawAmount(int withdrawAmount)
        {
            _scenarioContext["WithdrawAmount"] = withdrawAmount;
        }

        public ApiResponse<CreateAccountResponse> CreateNewAccountWithAboveDetails()
        {
            var initialBalance = Convert.ToInt32(_scenarioContext["InitialBalance"]);
            var accountName = _scenarioContext["AccountName"].ToString();
            var address = _scenarioContext["Address"].ToString();

            var request = new CreateAccountRequest
            {
                InitialBalance = initialBalance,
                AccountName = accountName,
                Address = address
            };

            _createAccountResponse = _apiHelper.CreateAccount(request);
            return _createAccountResponse;
        }

        public void VerifyTheResponseCodeIs(int expectedStatusCode, ApiResponse<CreateAccountResponse> _createAccountResponse)
        {
            Assert.Equals(expectedStatusCode, _createAccountResponse.StatusCode);
        }

        public void VerifyNoErrorIsReturned(ApiResponse<CreateAccountResponse> _createAccountResponse)
        {
            ClassicAssert.IsEmpty(_createAccountResponse.Errors);
        }

        public void VerifyTheSuccessMessage(string expectedSuccessMessage, ApiResponse<CreateAccountResponse> _createAccountResponse)
        {
            ClassicAssert.AreEqual(expectedSuccessMessage, _createAccountResponse.Message);
        }

        public void VerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse(ApiResponse<CreateAccountResponse> _createAccountResponse)
        {

            ClassicAssert.IsNotNull(_createAccountResponse.Data);
            ClassicAssert.IsNotEmpty(_createAccountResponse.Data.AccountNumber);

        }

        public void StoreAccountNumber(ApiResponse<CreateAccountResponse> _createAccountResponse)
        {

            _scenarioContext["AccountNumber"]=_createAccountResponse.Data.AccountNumber;

        }

        public ApiResponse<DeleteAccountResponse> DeleteTheAccount(String accNo)
        {
            return _apiHelper.DeleteAccount(accNo);
        }

        public void VerifyDeleteSuccessMessage(string expectedSuccessMessage, ApiResponse<DeleteAccountResponse> _deleteAccountResponse)
        {
            ClassicAssert.AreEqual(expectedSuccessMessage, _deleteAccountResponse.Message);
        }

        public String AccountNumberIs()
        {
            return _scenarioContext["AccountNumber"].ToString();
        }

        public ApiResponse<DepositeAccountResponse> DepositeAccount(String accNo, int depositeAmount)
        {

            var request = new DepositeAccountRequest
            {
                AccountNumber = accNo,
                Amount = depositeAmount
            };

            _depositeAccountResponse = _apiHelper.DepositeORWithdrawAccount(request, "deposite");
            return _depositeAccountResponse;
        }

        public ApiResponse<DepositeAccountResponse> WithdrawAccount(String accNo, int depositeAmount)
        {

            var request = new DepositeAccountRequest
            {
                AccountNumber = accNo,
                Amount = depositeAmount
            };

            _depositeAccountResponse = _apiHelper.DepositeORWithdrawAccount(request, "withdraw");
            return _depositeAccountResponse;
        }

        public void VerifyNewBalance(ApiResponse<DepositeAccountResponse> _depositeAccountResponse, int newBalance)
        {
            ClassicAssert.AreEqual(newBalance, _depositeAccountResponse.Data.Data.NewBalance);
        }
    }
}
