using BankingApplicationExercise.Interfaces;

namespace BankingApplicationExercise.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(object authenticationToken)
        {
            return true;
        }
    }
}
