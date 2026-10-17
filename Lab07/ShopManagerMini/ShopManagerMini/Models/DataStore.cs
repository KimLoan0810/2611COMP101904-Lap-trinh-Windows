using System.Collections.Generic;

namespace ShopManagerMini.Models
{
    public static class DataStore
    {
        public static List<User> Users = new List<User>
        {
            new User { Username = "admin", Password = "123", FullName = "Quản trị viên",     Role = "Admin" },
            new User { Username = "user",  Password = "123", FullName = "Nhân viên bán hàng", Role = "User"  }
        };

        public static List<Product> Products = new List<Product>
        {
            new Product { Id = "SP01", Name = "Mì gói",   Category = "Thực phẩm", Price = 5000,  Quantity = 100 },
            new Product { Id = "SP02", Name = "Nước suối", Category = "Đồ uống",   Price = 7000,  Quantity = 50 }
        };

        public static List<Customer> Customers = new List<Customer>();
    }
}