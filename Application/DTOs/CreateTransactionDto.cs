namespace Application.DTOs
{
    public class CreateTransactionDto
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool IsIncome { get; set; }
    }
}
