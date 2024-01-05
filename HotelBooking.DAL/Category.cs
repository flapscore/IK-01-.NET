using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL
{
    public class Category
    {
        public int CategoryId { get; set; } // Идентификатор категории
        public string Name { get; set; } // Название категории команты
        public decimal Price { get; set; } // Стоимость комнаты в данной категории
        
    }
}
