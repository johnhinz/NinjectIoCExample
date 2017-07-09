using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NinjectIoCExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize the 
            StandardKernel kernel = new StandardKernel();
            // load IoC configuration from the bindings class
            kernel.Load(Assembly.GetExecutingAssembly());
            // resolve dependent class
            IDependency dependency = kernel.Get<IDependency>();

            Dependent dependent = new Dependent(dependency);

            dependent.DoSomething();
            Console.ReadLine();
        }
    }

    public class Dependent
    {
        private IDependency _dependency;

        public Dependent(IDependency dependency)
        {
            _dependency = dependency;
        }
        public void DoSomething()
        {
            _dependency.DoSomeWork();
        }
    }

    public interface IDependency
    {
        void DoSomeWork();
    }

    public class DependencyOne : IDependency
    {
        public void DoSomeWork()
        {
            Console.WriteLine("DependencyOne doing work");
        }
    }

    public class DependencyTwo : IDependency
    {
        public void DoSomeWork()
        {
            Console.WriteLine("DependencyTwo doing some work");
        }
    }
}
