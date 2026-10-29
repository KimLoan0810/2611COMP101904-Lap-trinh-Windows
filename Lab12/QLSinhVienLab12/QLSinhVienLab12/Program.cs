using System.Globalization;
using QLSinhVienLab12.Forms;

namespace QLSinhVienLab12
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Dùng dấu CHẤM làm dấu thập phân (8.5) cho cả ứng dụng
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            ApplicationConfiguration.Initialize();
            Application.Run(new FrmNhapDiemTheoLop());
        }
    }
}