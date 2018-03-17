using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerializationDLL
{
    public static class Binary_Serializer
    {
        static BinaryFormatter serializer;

        public static void Serialize<T>(string path, T obj) where T : new()
        {
            serializer = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fileStream, obj);
            }
        }

        public static void Deserialize<T>(string path, ref T obj) where T : new()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            else
            {
                serializer = new BinaryFormatter();

                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    obj = (T)serializer.Deserialize(fileStream);
                }
            }
        }
    }

    public static class Xml_Serializer
    {
        static XmlSerializer serializer;

        public static void Serialize<T>(string path, T obj) where T : new()
        {
            serializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, obj);
            }
        }

        public static void Deserialize<T>(string path, ref T obj) where T : new()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            else
            {
                serializer = new XmlSerializer(typeof(T));

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    obj = (T)serializer.Deserialize(fs);
                }
            }
        }
    }
}
