using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel
{
    public class DataAddorRead
    {

        public static UserInfo Park = new UserInfo();
        /// <summary>
        /// 保存
        /// </summary>
        public static void SetDataInfo()
        {
            string path = Application.StartupPath + @"\data";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            FileStream fs = new FileStream(path + @"\data2.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bw = new BinaryFormatter();
            bw.Serialize(fs, Park);
            fs.Close();
        }
        /// <summary>
        /// 读取
        /// </summary>
        public static void GetDataInfo()
        {
            string path = Application.StartupPath + @"\data\data2.dat";
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter bw = new BinaryFormatter();
                Park = bw.Deserialize(fs) as UserInfo;
                fs.Close();
            }
          
        }

    }
}
