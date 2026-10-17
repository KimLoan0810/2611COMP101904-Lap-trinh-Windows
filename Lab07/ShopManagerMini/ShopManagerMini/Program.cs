using System;
using System.Windows.Forms;
using ShopManagerMini.Forms;

namespace ShopManagerMini
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (var login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break;                       // bấm Thoát -> kết thúc

                    var main = new FrmMain(login.CurrentUser);
                    Application.Run(main);

                    if (!main.IsLogout)              // thoát thật
                        break;
                }
            }
        }
    }
}