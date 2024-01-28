# Bank API Automation

## Endpoints:
1. POST Endpoint: https://www.localhost:8080/api/account/create
   - Request Payload: { InitialBalance: 1000, AccountName: "Rajesh Mittal", Address: "Ahmedabad, Gujarat" }
   - Response: { Data: { NewBalance: 1000, AccountName: "Rajesh Mittal", AccountNumber: "X123" }, Message: "Account X123 created successfully", Errors: [] }

2. DELETE Endpoint: https://www.localhost:8080/api/account/delete/<accountID>
   - Response: { Data: null, Message: "Account <accountID> deleted successfully", Errors: [] }

3. PUT Endpoint: https://www.localhost:8080/api/account/deposit
   - Request Payload: { AccountNumber: "X123", Amount: 1000 }
   - Response: { Data: { AccountNumber: "X123", NewBalance: 2000 }, Message: "1000$ deposited to Account X123 successfully", Errors: [] }

4. PUT Endpoint: https://www.localhost:8080/api/account/withdraw
   - Request Payload: { AccountNumber: "X123", Amount: 1000 }
   - Response: { Data: { AccountID: "X123", NewBalance: 0 }, Message: "1000$ withdrawn from Account X123 successfully", Errors: [] }

## Test Coverage:
- Scenario 1: Create new Account with valid data
- Scenario 2: Delete an Account
- Scenario 3: Deposit to an Account
- Scenario 4: Withdraw from an Account

## Tech Stacks:
- SpecFlow
- RestSharp
- NUnit
