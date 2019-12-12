using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Banking.API.Controllers;
using Banking.Tests.DataObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Banking.API.Models;

namespace Banking.Tests.Controllers
{
    [TestClass]
    public class TestAccountController
    {
        // TODO: Swap out object for Test AccountRepo, when implemented.
        AccountRepoTest testAccountRepo = null;
        Mock<ILogger<AccountsController>> testLogger = null;
        AccountsController testAccountController = null;

        [TestInitialize]
        public void BeforeEachTest()
        {
            // Generate mock Logger.
            testLogger = new Mock<ILogger<AccountsController>>();

            // Generate testAccountRepo.
            testAccountRepo = new AccountRepoTest();

            // Generate controller
            // TODO: Update following injection when functionality completed:
            testAccountController = new AccountsController(testAccountRepo, testLogger.Object);
        }
        
        [TestCleanup]
        public void AfterEachTest()
        {
            testLogger = null;
            testAccountRepo = null;
            testAccountController = null;
        }

        [TestMethod]
        public void GetAllAccountsByUserID_ValidID()
        {
            // Arrange.

            // Act. 
            var response = testAccountController.GetAllAccountsByUserID(10);
            response.Wait(1);
            var responseResult = response.Result.Result;

            // Assert.
            Assert.IsInstanceOfType(responseResult, typeof(OkObjectResult));
            var responseValue = (responseResult as OkObjectResult).Value as List<Account>;

            Assert.AreEqual(responseValue.Count, 1);
        }

        [TestMethod]
        public void GetAllAccountsByUserID_NonExistingID()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetAllAccountsByUserID(-1);
            response.Wait(1);
            var responseResult = response.Result.Result;

            // Assert.
            Assert.IsInstanceOfType(responseResult, typeof(NotFoundObjectResult));
            Assert.AreEqual((responseResult as NotFoundObjectResult).Value, -1);

        }

        [TestMethod]
        public void GetAllAccountsByUserID_InvalidID()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetAllAccountsByUserID(30);
            response.Wait(1);
            var responseResult = response.Result.Result;

            // Assert.
            Assert.IsInstanceOfType(responseResult, typeof(OkObjectResult));
            var responseValue = (responseResult as OkObjectResult).Value as List<Account>;

            Assert.AreNotEqual(responseValue.Count, 1);
        }

        [TestMethod]
        public void GetAllAccountsByUserID_ServerError()
        {
            // Arrange.
            testAccountRepo = new AccountRepoTest(false);
            testAccountController = new AccountsController(testAccountRepo, testLogger.Object);

            // TODO: reinject testAccountController.

            // Act.
            var response = testAccountController.GetAllAccountsByUserID(10);
            response.Wait(1);
            var responseResult = response.Result.Result;

            // Assert.
            Assert.IsInstanceOfType(responseResult, typeof(ObjectResult));
            Assert.AreEqual((responseResult as ObjectResult).StatusCode, 500);
        }

        [TestMethod]
        public void GetAllAccountsByUserIDAndAccountType_ValidIDAndValidAccountType()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetAllAccountsByUserIDAndTypeID(1, 1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAllAccountsByUserIDAndAccountType_NonExistingID()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetAllAccountsByUserIDAndTypeID(-1, 1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAllAccountsByUserIDAndAccountType_InvalidID()
        {
            // Arrange.
            // TODO: set user credientals to different user.

            // Act.
            var response = testAccountController.GetAllAccountsByUserIDAndTypeID(3, 1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAllAccountsByUserIDAndAccountType_ValidIDAndNoValidAccounts()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetAllAccountsByUserIDAndTypeID(2, 4);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAllAccountsByUserIDAndAccountType_ServerError()
        {
            // Arrange.
            // TODO: redefine testAccountRepo to be empty.
            // TODO: reinject testAccountController.

            // Act.
            var response = testAccountController.GetAllAccountsByUserIDAndTypeID(1, 1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAccountDetailsByAccountID_ValidID()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetAccountDetailsByAccountID(1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAccountDetailsByAccountID_NonExistingID()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetAccountDetailsByAccountID(-1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAccountDetailsByAccountID_InvalidUser()
        {
            // Arrange.
            // TODO: set user credientals to different user.

            // Act.
            var response = testAccountController.GetAccountDetailsByAccountID(3);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetAccountDetailsByAccountID_ServerError()
        {
            // Arrange.
            // TODO: redefine testAccountRepo to be empty.
            // TODO: reinject testAccountController.

            // Act.
            var response = testAccountController.GetAccountDetailsByAccountID(1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetTransactionDetailsByAccountID_ValidID()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetTransactionDetailsByAccountID(1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetTransactionDetailsByAccountID_NonExistingID()
        {
            // Arrange.

            // Act.
            var response = testAccountController.GetTransactionDetailsByAccountID(-1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetTransactionDetailsByAccountID_InvalidUser()
        {
            // Arrange.
            // TODO: set user credientals to different user.

            // Act.
            var response = testAccountController.GetTransactionDetailsByAccountID(3);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }

        [TestMethod]
        public void GetTransactionDetailsByAccountID_ServerError()
        {
            // Arrange.
            // TODO: redefine testAccountRepo to be empty.
            // TODO: reinject testAccountController.

            // Act.
            var response = testAccountController.GetTransactionDetailsByAccountID(1);
            response.Wait(1);
            var resultValue = response.Result.Value;

            // Assert.
        }
    }
}