using System;
using System.Xml.Serialization;

using SerializationDLL;

namespace BinaryAndXmlSerialization
{
    //Binary serialization
    [Serializable]
    public class Car
    {
        public int model;

        public Car()
        {
            model = 1;
        }

        public override string ToString()
        {
            return model.ToString();
        }
    }

    //Xml serialization
    public class Person
    {
        [XmlAttribute]
        public string name;

        [XmlAttribute]
        public int age;

        public Person()
        {
            name = "Tod";
            age = 29;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", name, age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Binary serialization
            string pathCar = "D://Car_SerializationFile.txt";

            Car car = new Car();
            Car car2 = null;

            Binary_Serializer.Serialize(pathCar, car);
            Binary_Serializer.Deserialize(pathCar, ref car2);

            Console.WriteLine("[Car]\nModel: {0}\n", car2.model);
            //===


            //Xml serialization
            string pathPerson = "D://Person_SerializationFile.xml";

            Person person = new Person();
            Person person2 = null;

            Xml_Serializer.Serialize(pathPerson, person);
            Xml_Serializer.Deserialize(pathPerson, ref person2);

            Console.WriteLine("[Person]\nName: {0}\nAge: {1}", person2.name, person2.age);
            //===


            Console.ReadKey();
        }
    }
}
