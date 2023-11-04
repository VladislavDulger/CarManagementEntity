namespace CarManagementEntity
{
    internal class Program
    {
        static void Main()
        {
            CarsDB carInfo = new();

            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить автомобиль");
                Console.WriteLine("2. Редактировать автомобиль");
                Console.WriteLine("3. Удалить автомобиль");
                Console.WriteLine("4. Просмотреть список автомобилей");
                Console.WriteLine("5. Сохранить данные в JSON файл");
                Console.WriteLine("6. Загрузить данные из JSON файла");
                Console.WriteLine("7. Выход");

                string inputComandStr = Console.ReadLine();

                int inputComand = 0;

                try
                {
                    inputComand = int.Parse(inputComandStr);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Нет такой команды.");
                }

                #region UserChoice
                switch (inputComand)
                {
                    case 1:

                        Console.WriteLine("Введите бренд автомобиля: " +
                                          "Mazda, Honda, Toyota, Lexus, MercedesBenz,Volkswagen");
                        if (Enum.TryParse<EnumCarsBrands>(Console.ReadLine(), out var brand))
                        {
                            Console.WriteLine("Введите модель автомобиля:");
                            string model = Console.ReadLine();
                            carInfo.AddCar(new Car { Brand = brand, Model = model });
                            Console.WriteLine("Автомобиль успешно добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный бренд автомобиля.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Введите ID автомобиля для редактирования.");
                        if (int.TryParse(Console.ReadLine(), out var carId))
                        {
                            Console.WriteLine("Введите бренд автомобиля: " +
                                              "Mazda, Honda, Toyota, Lexus, MercedesBenz,Volkswagen:");

                            if (Enum.TryParse<EnumCarsBrands>(Console.ReadLine(), out var newBrand))
                            {
                                Console.WriteLine("Введите новую модель автомобиля:");
                                string newModel = Console.ReadLine();
                                carInfo.EditCar(carId, newBrand, newModel);
                                Console.WriteLine("Автомобиль успешно отредактирован.");
                            }
                            else
                            {
                                Console.WriteLine("Неверный бренд автомобиля.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ID автомобиля.");
                        }
                        break;
                        
                    case 3:
                        Console.WriteLine("Введите ID автомобиля для удаления:");
                        if (int.TryParse(Console.ReadLine(), out var carID))
                        {
                            carInfo.RemoveCar(carID);
                            Console.WriteLine("Автомобиль успешно удален.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный ID автомобиля.");
                        }
                        break;

                    case 4:
                        var cars = carInfo.GetCars();
                        foreach (var car in cars)
                        {
                            Console.WriteLine($"ID: {car.Id}, Бренд: {car.Brand}, Модель: {car.Model}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Введите имя файла для сохранения:");
                        string fileName = Console.ReadLine();
                        var carsToSave = carInfo.GetCars();
                        JsonFileManager.SaveToJson(carsToSave, fileName);
                        Console.WriteLine($"Список автомобилей сохранен в файл {fileName}.");
                        break;
                    case 6:
                        Console.WriteLine("Введите имя файла для загрузки:");
                        string loadFileName = Console.ReadLine();
                        var carsToLoad = JsonFileManager.LoadFromJson(loadFileName);
                        foreach (var car in carsToLoad)
                        {
                            Console.WriteLine($"ID: {car.Id}, Бренд: {car.Brand}, Модель: {car.Model}");
                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверная команда, попробуйте снова.");
                        break;
                }
                #endregion
            }
        }
    }
}