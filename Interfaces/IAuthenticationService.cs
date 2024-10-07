namespace BankingApplicationExercise.Interfaces
{
    public interface IAuthenticationService
    {
        public bool Authenticate(object authenticationToken);
    }
}