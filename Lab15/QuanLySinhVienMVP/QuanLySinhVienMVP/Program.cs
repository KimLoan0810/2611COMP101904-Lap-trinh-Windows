using System.Globalization;
using QuanLySinhVienMVP.Views;

namespace QuanLySinhVienMVP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Hiển thị điểm với dấu chấm thập phân (7.5)
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            ApplicationConfiguration.Initialize();
            Application.Run(new FrmStudent());
        }
    }
}