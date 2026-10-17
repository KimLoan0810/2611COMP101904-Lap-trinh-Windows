using System.Drawing;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    public class DrawSurface : Panel
    {
        public DrawSurface()
        {
            DoubleBuffered = true; // Kích hoạt bộ đệm kép để giảm nhấp nháy khi vẽ
            BackColor = Color.White; // Đặt màu nền mặc định cho vùng vẽ là màu trắng
            Dock = DockStyle.Fill;   // Phủ kín không gian được cấp phép
        }
    }
}