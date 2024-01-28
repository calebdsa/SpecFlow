using BankApiAutomation.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharpTest.Models;

namespace BankApiAutomation.Utils
{
    public class ApiUtils
    {
        private static RestClient client;

        static ApiUtils()
        {
            client = new RestClient("https://www.localhost:8080/api/account");
        }

        public static RestResponse Deposit(CreateAccountRequest account)
        {
            var request = new RestRequest("deposit", Method.Put);
            request.AddJsonBody(account);
            return client.Execute(request);
        }

        public static RestResponse Withdraw(CreateAccountRequest account)
        {
            var request = new RestRequest("withdraw", Method.Put);
            request.AddJsonBody(account);
            return client.Execute(request);
        }

        public string SerializeObjectToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T DeserializeJsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public ApiResponse<CreateAccountResponse> CreateAccount(CreateAccountRequest request)
        {
            var requestJson = SerializeObjectToJson(request);

            var restRequest = new RestRequest("api/account/create", Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(requestJson);

            var response = client.Execute(restRequest);

            return new ApiResponse<CreateAccountResponse>
            {
                StatusCode = (int)response.StatusCode,
                Data = DeserializeJsonToObject<CreateAccountResponse>(response.Content),
                Message = response.StatusDescription,
                Errors = new string[0]
            };
        }

        public ApiResponse<DepositeAccountResponse> DepositeORWithdrawAccount(DepositeAccountRequest request, string resource)
        {
            var requestJson = SerializeObjectToJson(request);

            var restRequest = new RestRequest($"api/account/{resource}", Method.Put)
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(requestJson);

            var response = client.Execute(restRequest);

            return new ApiResponse<DepositeAccountResponse>
            {
                StatusCode = (int)response.StatusCode,
                Data = DeserializeJsonToObject<DepositeAccountResponse>(response.Content),
                Message = response.StatusDescription,
                Errors = new string[0]
            };
        }

        public ApiResponse<DeleteAccountResponse> DeleteAccount(string accountId)
        {
            var request = new RestRequest($"delete/{accountId}", Method.Delete);
            var response = client.Execute(request);


            return new ApiResponse<DeleteAccountResponse>
            {
                StatusCode = (int)response.StatusCode,
                Data = DeserializeJsonToObject<DeleteAccountResponse>(response.Content),
                Message = response.StatusDescription,
                Errors = new string[0]
            };
        }
    }
}
