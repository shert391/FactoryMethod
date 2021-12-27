/*Реализация паттерна фабричный метод*/
using System;

namespace Fabrica
{
    public enum CarModel
    {
        Reno,
        Audi,
        Peugeot,
    }
    public abstract class Factory
    {
        private string _nameFactory;

        protected Factory(string nameFactory)
        {
            _nameFactory = nameFactory;
        }

        public abstract Car Create(CarModel model, int number);
    }

    public class FactoryPassengerСars : Factory
    {
        public FactoryPassengerСars(string nameFactory) : base(nameFactory)
        {
            Console.WriteLine($"Создан завод <{nameFactory}> для производства легковых авто!\n");
        }
        public override Car Create(CarModel model, int number) => new PassengerCar(model, number);
    }

    public class FactoryFreightCar : Factory
    {
        public FactoryFreightCar(string nameFactory) : base(nameFactory)
        {
            Console.WriteLine($"Создан завод <{nameFactory}> для производства грузовых авто!\n");
        }
        public override Car Create(CarModel model, int number) => new FreightCar(model, number);
    }

    public abstract class Car
    {
        protected CarModel Model { get; }
        protected int Number { get; }

        protected Car(CarModel model, int number)
        {
            Model = model;
            Number = number;
        }
        public abstract void Move();
    }

    public class PassengerCar : Car
    {
        public PassengerCar(CarModel model, int number) : base(model, number)
        {
            Console.WriteLine($"Выпущен легковой автомобиль.\nМодель: {model}\nНомер: {number}\n");
        }

        public override void Move()
        {
            Console.WriteLine($"Я! Легковой автомобиль модели <{Model}> с номерами <{Number}>... ЕДУ!\n");
        }
    }

    public class FreightCar : Car
    {
        public FreightCar(CarModel model, int number) : base(model, number)
        {
            Console.WriteLine($"Выпущен грузовой автомобиль.\nМодель: {model}\nНомер: {number}\n");
        }

        public override void Move()
        {
            Console.WriteLine($"Я! Грузовой автомобиль модели <{Model}> с номерами <{Number}>... ЕДУ!\n");
        }
    }

    public class Programm
    {
        public static void Main()
        {
            Factory factoryPassengerСars = new FactoryPassengerСars(nameFactory: "Красное солнышко");
            Factory factoryFreightCar = new FactoryFreightCar(nameFactory: "Золтой лучик");

            Car[] cars = new Car[6]
            {
                factoryPassengerСars.Create(CarModel.Audi, 32),
                factoryPassengerСars.Create(CarModel.Peugeot, 111),
                factoryPassengerСars.Create(CarModel.Reno, 228),
                factoryFreightCar.Create(CarModel.Audi, 321),
                factoryFreightCar.Create(CarModel.Peugeot, 222),
                factoryFreightCar.Create(CarModel.Reno, 42124),
            };

            foreach (var car in cars)
            {
                car.Move();
            }

            Console.ReadKey();
        }
    }
}