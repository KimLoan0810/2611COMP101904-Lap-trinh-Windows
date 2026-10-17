using System.ComponentModel;

namespace ShopManagerMini.Models
{
    public class Product
    {
        [DisplayName("Mã SP")] public string Id { get; set; }
        [DisplayName("Tên sản phẩm")] public string Name { get; set; }
        [DisplayName("Loại")] public string Category { get; set; }
        [DisplayName("Đơn giá")] public decimal Price { get; set; }
        [DisplayName("Số lượng")] public int Quantity { get; set; }
    }
}