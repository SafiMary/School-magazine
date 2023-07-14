using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace School_magazine
{ 
    [Serializable]
    internal class Student
    {
            [XmlAttribute]
            public string Name;
            [XmlAttribute]
            public string Surname;
            [XmlAttribute]
            public DateTime Birthday;
            public Student()
            {

            }
            public Student(string name, string surname, DateTime birthday)
            {
                this.Name = name;
                this.Surname = surname;
                this.Birthday = birthday;
            }
        public override string ToString()
        {
            return $"{this.Name} {this.Surname}{this.Birthday}";
        }
        static public void Serealize_it(List<Student> objectGrath, string filename)
        {
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            using (Stream fStream = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(fStream, objectGrath);
            }
        }
        static public void Deserealize_it(string filename, out List<Student> lst)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (Stream fStream = new FileStream(filename, FileMode.OpenOrCreate,
                FileAccess.Read))
            {
                lst = (List<Student>)xmlSerializer.Deserialize(fStream);
            }
        }
    }
}
