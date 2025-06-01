namespace Application.DTOs
{
    public class UpdateTransactionDto
    {
        public Guid Id { get; set; }  // required to update
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool IsIncome { get; set; }
    }
}
