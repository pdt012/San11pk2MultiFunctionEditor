using kmfe.editor;
using kmfe.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pk2mfe
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CodeConvertHelper.Init("enc_3.xml");

            #region test before start
            string s = CodeConvertHelper.Pk2Str(new byte[] { 0x92, 0xa5, 0x93, 0x8c, 0x8c, 0x01 });
            Console.WriteLine(s);

            byte[] bs = CodeConvertHelper.Str2Pk("征东将军氕氘氚");
            Console.WriteLine(bs);

            s = CodeConvertHelper.Pk2Str(bs);
            Console.WriteLine(s);
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScenarioConfigEditor());
        }
    }
}
