using System.Collections.Generic;
using System.Drawing;

namespace COMP1019_Lab08_SimplePaint
{
    public class DrawItem
    {
        public DrawMode Mode { get; set; }                  // Loại hình vẽ (Pen, Line, Rectangle, Ellipse)
        public Point Start { get; set; }                  // Tọa độ điểm bắt đầu nhấn chuột
        public Point End { get; set; }                    // Tọa độ điểm kết thúc thả chuột
        public Color Color { get; set; }                  // Màu sắc của nét vẽ
        public float Width { get; set; }                  // Độ dày của nét vẽ
        public List<Point> Points { get; set; } = new List<Point>(); // Danh sách điểm dùng riêng cho chế độ vẽ tự do (Pen)
    }
}