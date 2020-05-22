using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FootballersMVVM.Model
{
    class FileOperations
    {
        public static void SaveToFile(List<Footballer> squad)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Footballer>));
            using (StreamWriter writer = new StreamWriter(@"../../../FootballersMVVM/Resources/Footballers.xml"))
            {
                serializer.Serialize(writer, squad);
            }
        }
        public static List<Footballer> LoadFromFile()
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Footballer>));
                using (StreamReader reader = new StreamReader(@"../../../FootballersMVVM/Resources/Footballers.xml"))
                {
                    return (List<Footballer>)deserializer.Deserialize(reader);
                }
            }
            catch
            {
                return new List<Footballer>();
            }
        }
    }
}
