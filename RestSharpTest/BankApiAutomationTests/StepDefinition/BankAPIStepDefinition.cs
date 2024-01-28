using System.Security.Principal;
using System.Threading.Tasks;
using RestSharpTest.BankApiAutomationTests.Steps;
using RestSharpTest.Models;
using TechTalk.SpecFlow;

namespace RestSharpTest.BankApiAutomationTests.StepDefinition
{
    [Binding]
    public class BankAPIStepDefinition
    {
        private readonly BankApiSteps _bankApiSteps;
        private ApiResponse<CreateAccountResponse> _response;
        private ApiResponse<DeleteAccountResponse> _deleteResponse;
        private ApiResponse<DepositeAccountResponse> _depositeResponse;
        private ApiResponse<DepositeAccountResponse> _withdrawResponse;
        private string _accountNumber;
        private int _depositeAmount;
        private int _withdrawAmount;

        [Given(@"Account Initial Balance is \$(\d+)")]
        public void GivenAccountInitialBalanceIs(int initialBalance)
        {
            _bankApiSteps.AccountInitialBalance(initialBalance);
        }

        [Given(@"Account name is ""(.*)""")]
        public void GivenAccountNameIs(string accountName)
        {
            _bankApiSteps.AccountNameIs(accountName);

        }

        [Given(@"Address is ""(.*)""")]
        public void GivenAddressIs(string address)
        {
            _bankApiSteps.AddressIs(address);
        }

        [When(@"POST endpoint triggered to create new account with above details")]
        public void WhenPOSTEndpointTriggeredToCreateNewAccountWithAboveDetails()
        {
            _response=_bankApiSteps.CreateNewAccountWithAboveDetails();
        }

        [Then(@"Verify the response code is (\d+)")]
        public void ThenVerifyTheResponseCodeIs(int expectedStatusCode)
        {
            _bankApiSteps.VerifyTheResponseCodeIs(expectedStatusCode, _response);
        }

        [Then(@"Verify no error is returned")]
        public void ThenVerifyNoErrorIsReturned()
        {
            _bankApiSteps.VerifyNoErrorIsReturned(_response);
        }

        [Then(@"Verify the success message ""(.*)""")]
        public void ThenVerifyTheSuccessMessage(string expectedSuccessMessage)
        {
            _bankApiSteps.VerifyTheSuccessMessage(expectedSuccessMessage, _response);
        }

        [Then(@"Verify the account details are correctly returned in the JSON response")]
        public void ThenVerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse()
        {
            _bankApiSteps.VerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse(_response);
        }

        [Then(@"Store Account Number as""(.*)""")]
        public void ThenStoreAccountNumberAs()
        {
            _bankApiSteps.StoreAccountNumber(_response);
        }

        [Given(@"Get the Account Number")]
        public void GivenGetAccountNumber()
        {
            _accountNumber = _bankApiSteps.AccountNumberIs();
        }

        [When(@"DELETE endpoint triggered to delete the account")]
        public void WhenDELETEEndpointTriggeredToDeleteTheAccount()
        {
            _deleteResponse = _bankApiSteps.DeleteTheAccount(_accountNumber);
        }

        [Then(@"Verify the success message ""(.*)""")]
        public void ThenVerifyTheDeleteSuccessMessage(string expectedSuccessMessage)
        {
            _bankApiSteps.VerifyDeleteSuccessMessage(expectedSuccessMessage, _deleteResponse);
        }

        [Given(@"Deposite Amount is (\d+)")]
        public void GivenDepositeAmountIs(int amount)
        {
            _depositeAmount = amount;
        }

        [When(@"PUT endpoint triggered to deposit to the account")]
        public void WhenPUTEndpointTriggeredToDepositToTheAccount()
        {
            _depositeResponse = _bankApiSteps.DepositeAccount(_accountNumber, _depositeAmount);
        }

        [Given(@"Withdraw Amount is (\d+)")]
        public void GivenWithDrawAmountIs(int amount)
        {
            _withdrawAmount = amount;
        }

        [When(@"PUT endpoint triggered to withdraw from the account")]
        public void WhenPUTEndpointTriggeredToWithdrawFromTheAccount()
        {
            _withdrawResponse = _bankApiSteps.DepositeAccount(_accountNumber, _withdrawAmount);
        }

        [Then(@"Verify the deposite new balance is (\d+)")]
        public void ThenVerifyTheDepositeNewBalanceIs(int newBalance)
        {
            _bankApiSteps.VerifyNewBalance(_depositeResponse, newBalance);
        }

        [Then(@"Verify the withdraw new balance is (\d+)")]
        public void ThenVerifyTheWithdrawNewBalanceIs(int newBalance)
        {
            _bankApiSteps.VerifyNewBalance(_depositeResponse, newBalance);
        }
    }
}
