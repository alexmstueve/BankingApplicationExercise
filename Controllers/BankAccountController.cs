using System.Security.Authentication;
using BankingApplicationExercise.Interfaces;
using BankingApplicationExercise.Resources;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankingApplicationExercise.Controllers
{
    [Route("api/bankAccount")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private IAuthenticationService AuthenticationService;
        private IBankAccountService BankAccountService;

        public BankAccountController(IAuthenticationService authenticationService,
            IBankAccountService bankAccountService) 
        {
            AuthenticationService = authenticationService;
            BankAccountService = bankAccountService;
        }

        [HttpPut("deposit")]
        public IActionResult Deposit(DepositResource depositResource)
        {
            try
            {
                AuthenticationService.Authenticate(depositResource);

                var result = BankAccountService.Deposit(depositResource);

                return Ok(result);
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("withdrawal")]
        //public IActionResult Withdrawal(WithdrawalResource withdrawalResource)
        //{
        //    try
        //    {
        //        AuthenticationService.Authenticate(depositResource);

        //        var result = BankAccountService.Deposit(depositResource);

        //        return Ok(result);
        //    }
        //    catch (AuthenticationException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
