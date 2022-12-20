using CrudTest.AcceptanceTest.Drivers;
using CrudTest.Domain.Dto;
using System;
using CrudTest.Domain.Commands;
using CrudTest.Domain.ValuesObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CrudTest.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class CreateReadEditDeleteCustomerStepDefinitions
    {
        readonly CustomerApi _api;
        readonly ScenarioContext _context;
        public CreateReadEditDeleteCustomerStepDefinitions(CustomerApi api, ScenarioContext context)
        {
            _api = api;
            _context = context;
        }

        CustomerInputDto? _customerInput;


        [Given(@"system error codes are following")]
        public void GivenSystemErrorCodesAreFollowing(Table table)
        {
            var errorCodes = table.CreateSet<CodesDesc>().ToList();
            _context.Add("errorCodes", errorCodes);
        }

        [When(@"user creates a customer with following data")]
        public async Task WhenUserCreatesACustomerWithFollowingData(Table table)
        {
            _customerInput = table.CreateSet<CustomerInputDto>().Single();
            var response = await _api.CreateAsync(new Domain.Commands.CustomerCreateCommand
            {
                Data = _customerInput
            });
            if (response?.StatusCode == 200)
                _context.Add("createdCustomer", response.Data);
            else
                _context.Add("invalidCustomer", response);
        }

        [Then(@"user can lookup all customers and filter by Email of ""(.*)"" and get ""(.*)"" records")]
        public async Task ThenUserCanLookupAllCustomersAndFilterByEmailOfAndGetRecords(string email, int count)
        {
            var response = await _api.GetListAsync(new Domain.Queries.CustomerGetListQuery
            {
                Email = email,
                Page = 1,
                PageSize = 1000
            });
            response?.StatusCode.Should().Be(200);
            response?.Data.TotalCount.Should().Be(count);
        }

        [When(@"user edit customer with new email of ""(.*)""")]
        public async Task WhenUserEditCustomerWithNewEmailOf(string email)
        {
            var createdCustomer = _context.Get<CustomerDto>("createdCustomer");
            var response = await _api.UpdateAsync(new Domain.Commands.CustomerUpdateCommand
            {
                Id = createdCustomer.Id,
                Data = new CustomerInputDto
                {
                    Email = email,
                    DateOfBirth = createdCustomer.DateOfBirth,
                    Firstname = createdCustomer.Firstname,
                    Lastname = createdCustomer.Lastname,
                    PhoneNumber = createdCustomer.PhoneNumber
                }
            });
            response?.StatusCode.Should().Be(200);
        }

        [When(@"user delete customer by Email of ""(.*)""")]
        public async Task WhenUserDeleteCustomerByEmailOf(string email)
        {
            var response = await _api.DeleteByEmailAsync(email);
            response?.StatusCode.Should().Be(200);
        }


        [Then(@"user receive error code ""(.*)""")]
        public void ThenUserReceiveErrorCode(int code)
        {
            var response = _context.Get<Response<CustomerDto>>("invalidCustomer");
            _context.Remove("invalidCustomer");
            response?.SubStatuses.Select(a => a.StatusCode).FirstOrDefault().Should().Be(code);
            var message = _context.Get<List<CodesDesc>>("errorCodes");
            var item = message.SingleOrDefault(a => a.Code == code);
            response?.SubStatuses.Select(a => a.Message).FirstOrDefault().Should().Be(item?.Description);
        }
    }
}
