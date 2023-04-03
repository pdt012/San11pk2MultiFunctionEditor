using kmfe.editor.scenarioConfig;
using kmfe.utils;

namespace kmfe
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region test before start


            CodeConvertHelper.Init("enc_3.xml");
            string s = CodeConvertHelper.Pk2Str(new byte[] { 0x92, 0xa5, 0x93, 0x8c, 0x8c, 0x01 });
            Console.WriteLine(s);

            byte[] bs = CodeConvertHelper.Str2Pk("征东将军氕氘氚");
            Console.WriteLine(bs);

            s = CodeConvertHelper.Pk2Str(bs);
            Console.WriteLine(s);
            #endregion

            #region main
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new PathXmlEditor());
            Application.Run(new ScenarioConfigEditor());
            #endregion
        }
    }
}