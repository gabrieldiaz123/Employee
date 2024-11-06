using System.Text;

namespace Employee.Functions
{

    public class GeneralFunctions
    {
        public GeneralFunctions(IConfiguration configuration)

        {
            //esta vaci a un no se usa//
        }

        //este es el long que se llamara en el controller//
        public void AddLog(string newLog)
        {
            string carpetaLog = AppDomain.CurrentDomain.BaseDirectory + "Log//";
            if (!Directory.Exists(carpetaLog))
            {
                Directory.CreateDirectory(carpetaLog);
            }
            string RutaLog = carpetaLog + AppDomain.CurrentDomain.FriendlyName + "_" + DateTime.Now.ToString("dd-MM-yyy") + ".Log";
            var registro = DateTime.Now + "" + newLog + "\n";
            var BytsNewlog = new UTF8Encoding(true).GetBytes(registro);
            using (FileStream Log = File.Open(RutaLog, FileMode.Append))
            {
                Log.Write(BytsNewlog, 0, BytsNewlog.Length);
            }
        }
    }
}
