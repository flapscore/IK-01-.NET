namespace laba5.Models
{
    public class Customer
    {
        public int Id { get; set; } // ID клиента
        public string FullName { get; set; } // Полное имя клиента
        public string Email { get; set; } // Электронная почта клиента
        public string PhoneNumber { get; set; } // Номер телефона клиента
        public DateTime DateOfBirth { get; set; } // Дата рождения клиента
        public string PassportDetails { get; set; } // Паспортные данные клиента
    }
}
