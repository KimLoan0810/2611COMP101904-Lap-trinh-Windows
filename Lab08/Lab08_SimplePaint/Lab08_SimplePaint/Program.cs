using System;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Khởi cấu hình ứng dụng WinForms
            ApplicationConfiguration.Initialize();
            // Chạy form chính của ứng dụng (FrmPaint sẽ được tạo ở bước tiếp theo)
            Application.Run(new FrmPaint());
        }
    }
}