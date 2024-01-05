namespace lab6.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; } // Идентификатор запроса

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // Свойство для проверки наличия идентификатора запроса
    }
}