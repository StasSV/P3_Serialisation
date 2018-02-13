using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace P3_Serialisation
{

   [Serializable]
    public class Student
    {
        public string name  {get; set;}
        public string surName  {get; set;}
        public string faculty  {get; set;}
        public string direction {get; set;}
        public int course  {get; set;}
        public int group  {get; set;}
        public int studcard   {get; set;}

        public Student()
        {
        }

        public Student(string name,string surName,string faculty,string direction,int course,int group,int studcard)
        {
            this.name = name;
            this.surName = surName;
            this.faculty = faculty;
            this.direction = direction;
            this.course = course;
            this.group = group;
            this.studcard = studcard;
            

        }
    }
    
    class Program
    {
        static void Main()
        {
            Collection <Student> students = new Collection <Student>();
            students.Add(new Student("John","Kennedy","Informatics","Applied Mathematics",1,1,100000111));
            students.Add(new Student("Rick","Nilson","Informatics","Applied Mathematics",2,1,100000211));
            students.Add(new Student("Morty","Fox","Informatics","Applied Mathematics",1,2,100000121));
            students.Add(new Student("Nill","Armstrong","Informatics","Applied Mathematics",3,2,100000321));
            students.Add(new Student("Barry","Hills","Informatics","Applied Mathematics",4,1,100000411));
            students.Add(new Student("Don","Shon","Informatics","Applied Mathematics",2,1,100000212));
            students.Add(new Student("Peter","Pin","Informatics","Applied Mathematics",1,4,100000141));
           
            
            foreach (Student s in students)
            {
                Console.WriteLine("Name : {0}   Surname : {1}   Faculty of : {2}   Direction : {3}   Course :{4}   Group :{5}    StudentCard :{6}   ", s.name,s.surName,s.faculty,s.direction,s.course,s.group,s.studcard);
            }
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++Serialisation process is runnning ..... ++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            BinaryFormatter bf1 = new BinaryFormatter();
            using (FileStream f1 = new FileStream("Students.dat", FileMode.OpenOrCreate))
            {
                bf1.Serialize(f1, students);
            }
            Console.WriteLine();
            Console.WriteLine("Binary Serialisation ....................DONE ");
            Console.WriteLine();
            XmlSerializer xs1 = new XmlSerializer(typeof(Collection<Student>));
            using (FileStream f2 = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                xs1.Serialize(f2, students);
            }
            Console.WriteLine();
            Console.WriteLine("XML Serialisation .......................DONE ");
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++Deserialisation process is runnning ..... ++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            using (FileStream f3 = new FileStream("Students.dat", FileMode.OpenOrCreate))
            {
                Collection<Student> studentsnew = (Collection<Student>)bf1.Deserialize(f3);
                foreach (Student s in studentsnew)
                {
                    Console.WriteLine("Name : {0}   Surname : {1}   Faculty of : {2}   Direction : {3}   Course :{4}   Group :{5}    StudentCard :{6}   ", s.name,s.surName,s.faculty,s.direction,s.course,s.group,s.studcard);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Binary Deserialisation ....................DONE ");
            Console.WriteLine();
            
            using (FileStream f4 = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                Collection<Student> studentsnew = (Collection<Student>)xs1.Deserialize(f4);

                foreach (Student s in studentsnew)
                {
                    Console.WriteLine("Name : {0}   Surname : {1}   Faculty of : {2}   Direction : {3}   Course :{4}   Group :{5}    StudentCard :{6}   ", s.name,s.surName,s.faculty,s.direction,s.course,s.group,s.studcard);
                }
            }
            Console.WriteLine();
            Console.WriteLine("XML Deserialisation ....................DONE ");
            Console.WriteLine();
            Console.ReadLine();
            
            
        }
    }
}
