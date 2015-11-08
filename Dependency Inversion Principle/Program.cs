using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IVehicle>().To<Car>();
            kernel.Bind<IVehicleController>().To<VehicleController>();

            var vehicleBind = kernel.Get<IVehicleController>();

            vehicleBind.Accelerate();
            vehicleBind.Brake();

            Console.Read();
        }
    }

    public interface IVehicle
    {
        void Accelerate();
        void Brake();
    }

    public class Car : IVehicle
    {
        public void Accelerate()
        {
            Console.WriteLine("Car accelerates...");
        }

        public void Brake()
        {
            Console.WriteLine("Car stopped.");
        }
    }

    public class Truck : IVehicle
    {
        public void Accelerate()
        {
            Console.WriteLine("Truck accelerates...");
        }

        public void Brake()
        {
            Console.WriteLine("Truck stopped.");
        }
    }

    public interface IVehicleController
    {
        void Accelerate();
        void Brake();
    }

    public class VehicleController : IVehicleController
    {
        IVehicle _vehicle;

        public VehicleController(IVehicle vehicle)
        {
            this._vehicle = vehicle;
        }

        public void Accelerate()
        {
            _vehicle.Accelerate();
        }

        public void Brake()
        {
            _vehicle.Brake();
        }
    }
}
