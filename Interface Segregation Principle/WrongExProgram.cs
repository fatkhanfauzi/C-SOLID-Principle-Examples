using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Segregation_Principle
{
    class WrongExProgram
    {
        static void Main(string[] args)
        {
            IProgrammer programmer = new Programmer();
            IProgrammer teamLead = new TeamLead();


            Persistence<IProgrammer>.Save(programmer);
            Persistence<IProgrammer>.Save(teamLead);

            Console.Read();
        }

        public interface IProgrammer
        {
            void WorkOnTask(); 
            void AssignTask();
            void CreateSubTask();
        }

        public class Programmer : IProgrammer
        {
            public void WorkOnTask()
            {
                Console.WriteLine("WorkOnTask");
            }

            public void AssignTask()
            {
                //throw new NotImplementedException();
                Console.WriteLine("NotImplementedException");
            }

            public void CreateSubTask()
            {
                //throw new NotImplementedException();
                Console.WriteLine("NotImplementedException");
            }
        }

        public class TeamLead : IProgrammer
        {
            public void WorkOnTask()
            {
                Console.WriteLine("WorkOnTask");
            }

            public void AssignTask()
            {
                Console.WriteLine("AssignTask");
            }

            public void CreateSubTask()
            {
                Console.WriteLine("CreateSubTask");
            }
        }

        class Persistence<T> where T : class
        {
            public static void Save(T obj)
            {
                Console.WriteLine("=========Save========");

                foreach (var item in obj.GetType().GetProperties())
                {
                    Console.WriteLine(item.GetValue(obj, null));
                }

                foreach (var item in obj.GetType().GetMethods().Where(m => !m.IsSpecialName && m.DeclaringType != typeof(object)))
                {
                    Console.WriteLine(item.Invoke(obj, null));
                }
            }
        }
    }
}
