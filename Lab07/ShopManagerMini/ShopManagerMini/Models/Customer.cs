using System.ComponentModel;

namespace ShopManagerMini.Models
{
    public class Customer
    {
        [DisplayName("Mã KH")] public string Id { get; set; }
        [DisplayName("Họ tên")] public string FullName { get; set; }
        [DisplayName("SĐT")] public string Phone { get; set; }
        [DisplayName("Loại KH")] public string CustomerType { get; set; }
    }
}