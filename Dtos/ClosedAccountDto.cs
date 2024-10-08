namespace BankingApplicationExercise.Dtos
{
    public class ClosedAccountDto
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public bool Succeeded { get; set; }
    }
}