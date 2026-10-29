using System.Globalization;
using StudentReportDemo.Forms;

namespace StudentReportDemo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Hiển thị số với dấu CHẤM thập phân (8.2)
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            ApplicationConfiguration.Initialize();
            Application.Run(new FrmBaoCaoSinhVien());
        }
    }
}