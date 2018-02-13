using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P3_Serialisation
{

    
    class Student
    {
        public string Family  {get; private set;}
        public IDictionary<string, int> Subj { get; private set; }
        public double AVG {get; private set;}
        
        public Student(string Family, IDictionary<string, int> Subj)
        {
            this.Family = Family;
            this.Subj = Subj;
            double AVG = 0;
            foreach (var s in Subj)
                AVG += s.Value;
            this.AVG = AVG / this.Subj.Count;

        }
        public override string ToString()
        {
            string res = Family + "  ";
            foreach (var s in Subj)
                res += " "+ s.Value+ "   ";
            res +=  AVG;
            return res;
        }
        
        public static bool StudentAVG(Student obj1, Student obj2)
        {
            return obj1.AVG < obj2.AVG;
        }
    }
    
    class Program
    {
        static void Main()
        {
            IDictionary<string, int>[] st = { new Dictionary<string, int>(),
                new Dictionary<string, int>(),
                new Dictionary<string, int>(),
                new Dictionary<string, int>()};
            
            Random rnd = new Random();
            
            foreach (var s in st)
            {
                s.Add("Math", 100 + rnd.Next(0,50)*(-1)^rnd.Next(2,3)-2);
                s.Add("Java", 100 + rnd.Next(0,50)*(-1)^rnd.Next(2,3)-2);
                s.Add("Ukr", 100 + rnd.Next(0,50)*(-1)^rnd.Next(2,3)-2);
                s.Add("TFKZ", 100 + rnd.Next(0,50)*(-1)^rnd.Next(2,3)-2);
            }
            
            Student[] studentinfo = { new Student("Spring",st[0]),
                                  new Student("Winter",st[1]),
                                  new Student("Ivanov",st[2]),
                                  new Student("Coyote",st[3])};
            
        

            Console.WriteLine("Sorting students by average grades: \n" +
                "-------------------------------------\n"+
                "Family  Math  Java  Ukr  TFKZ  Average\n  ");
            
            foreach (var ui in studentinfo)
                Console.WriteLine(ui);

            Console.ReadLine();
        }
    }
}
