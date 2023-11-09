using System;
using System.ComponentModel.DataAnnotations;
using ClassLibrary1;

namespace YAHAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите машину:\r\n1. Priora\r\n2. Mazda\r\n3. Porsche");
            int choice = Convert.ToInt32(Console.ReadLine());
            int kill = 1;
            Car car;

            switch (choice)
            {
                case 1:
                    car = new Car();
                    kill++;
                    break;
                case 2:
                    car = new CarType2();
                    break;
                case 3:
                    car = new CarType3();
                    break;
                default:
                    Console.WriteLine("Неверный выбор машины!");
                    return;
            }

            // Открыть дверь
            bool doorOpened = false;
            bool openDoorWithEffort = false;

            while (!doorOpened)
            {
                Console.WriteLine(
                    "Выберите действие:\r\n1. Открыть дверь нежно. 2. Приложить силы для открытия двери.");
                int dver = Convert.ToInt32(Console.ReadLine());
                if (kill == 1)
                {
                    if (dver == 1)
                    {
                        Console.Write("Дверь открыта ");
                        doorOpened = true;
                    }
                    else
                    {
                        Console.Write(("Ты критин, но дверь открыта "));
                        doorOpened = true;
                    }
                }
                else
                {
                    if (dver == 1)
                    {
                        Console.WriteLine("Дверь заперта ");
                        continue;
                    }
                    else
                    {
                        Console.Write("Дверь открыта ");
                        doorOpened = true;
                    }
                }


                // Остальной код остается без изменений.
                Console.WriteLine(car.StartEngine());

                bool engineStarted = true;
                while (engineStarted)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Ускориться");
                    Console.WriteLine("2. Замедлиться");
                    Console.WriteLine("3. Заглушить машину");
                    Console.WriteLine("4. Переключить передачу");

                    int action = Convert.ToInt32(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            if (car.Gas())
                            {
                                Console.WriteLine($"Ускорение. Текущая скорость: {car.Speed} км/ч.");
                            }
                            else
                            {
                                Console.WriteLine("Нельзя увеличить скорость на нейтральной передаче.");
                            }

                            break;
                        case 2:
                            if (car.Brake())
                            {
                                Console.WriteLine($"Замедление. Текущая скорость: {car.Speed} км/ч.");
                            }

                            break;
                        case 3:
                            if (car is Car)
                            {
                                Console.WriteLine("Двигатель LADA Priora заглушен");
                            }
                            else if (car is CarType2)
                            {
                                Console.WriteLine("Двигатель Mazda заглушен");
                            }
                            else if (car is CarType3)
                            {
                                Console.WriteLine("Двигатель Porsche заглушен");
                            }

                            engineStarted = false;
                            break;
                        case 4:
                            Console.WriteLine("На какую передачу хотите переключить?");
                           
                            int gear = Convert.ToInt32(Console.ReadLine());
                            
            
                            if (car.SetGear(gear))
                            {
                                Console.WriteLine($"Успешно переключено на {gear} передачу.");
                            }
                            else
                            {
                                Console.WriteLine($"Нельзя переключить на {gear} передачу при текущей скорости.");
                            }

                            break;
                        case 5:
                            if (car.Reverse())
                            {
                                Console.WriteLine("Машина на заднем ходу.");
                            }

                            break;
                    }
                }
            }
        }
    }
}
