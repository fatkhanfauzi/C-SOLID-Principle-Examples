using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Segregation_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            ISoftwareEngineer programmer = new Programmer();
            ISoftwareEngineer teamLead = new TeamLead();


            Persistence<ISoftwareEngineer>.Save(programmer);
            Persistence<ISoftwareEngineer>.Save(teamLead);

            Console.Read();
        }

        public interface ISoftwareEngineer
        {
            void WorkOnTask();
        }

        public interface ITeamLead : ISoftwareEngineer
        {
            void AssignTask();
            void CreateSubTask();
        }

        public class Programmer : ISoftwareEngineer
        {
            public void WorkOnTask()
            {
                Console.WriteLine("WorkOnTask");
            }
        }

        public class TeamLead : ITeamLead
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
