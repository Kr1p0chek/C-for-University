using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Slicer.Style;
using OfficeOpenXml.Drawing.Style.Fill;

namespace Lab5C_
{
    internal class ExcelWork
    {
        public static List<Client> readClients(string excelFilePath, string logFilePath)
        {
            List<Client> clients = new List<Client>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                FileInfo fileInfo = new FileInfo(excelFilePath);
                using (var package = new ExcelPackage(fileInfo))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        Console.WriteLine("В файле нет листов.");
                        return clients;
                    }
                    var worksheet = package.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        int code = Convert.ToInt32(worksheet.Cells[row, 1].Text);
                        string surname = worksheet.Cells[row, 2].Text;
                        string name = worksheet.Cells[row, 3].Text;
                        string fatherName = worksheet.Cells[row, 4].Text;
                        string residense = worksheet.Cells[row, 5].Text;
                        Client client = new Client(code, surname, name, fatherName, residense);

                        clients.Add(client);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return clients;
        }

        public static List<Order> readOrders(string excelFilePath, string logFilePath)
        {
            List<Order> orders = new List<Order>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                FileInfo fileInfo = new FileInfo(excelFilePath);
                using (var package = new ExcelPackage(fileInfo))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        Console.WriteLine("В файле нет листов.");
                        return orders;
                    }
                    var worksheet = package.Workbook.Worksheets[1];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        int code = Convert.ToInt32(worksheet.Cells[row, 1].Text);
                        int clientCode = Convert.ToInt32(worksheet.Cells[row, 2].Text);
                        int serviceCode = Convert.ToInt32(worksheet.Cells[row, 4].Text);
                        DateTime date = DateTime.ParseExact(worksheet.Cells[row, 3].Text, "MM.dd.yyyy", CultureInfo.InvariantCulture);
                        int quantity = Convert.ToInt32(worksheet.Cells[row, 5].Text);
                        Order order = new Order(code, clientCode, serviceCode, date, quantity);

                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return orders;
        }

        public static List<Service> readServices(string excelFilePath, string logFilePath)
        {
            List<Service> services = new List<Service>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                FileInfo fileInfo = new FileInfo(excelFilePath);
                using (var package = new ExcelPackage(fileInfo))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        Console.WriteLine("В файле нет листов.");
                        return services;
                    }
                    var worksheet = package.Workbook.Worksheets[2];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        int code = Convert.ToInt32(worksheet.Cells[row, 1].Text);
                        int typeCode = Convert.ToInt32(worksheet.Cells[row, 2].Text);
                        string name = worksheet.Cells[row, 3].Text;
                        string cost = worksheet.Cells[row, 4].Text;
                        Service service = new Service(code, typeCode, name, cost);

                        services.Add(service);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return services;
        }

        public static List<ServiceType> readServiceTypes(string excelFilePath, string logFilePath)
        {
            List<ServiceType> serviceTypes = new List<ServiceType>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                FileInfo fileInfo = new FileInfo(excelFilePath);
                using (var package = new ExcelPackage(fileInfo))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        Console.WriteLine("В файле нет листов.");
                        return serviceTypes;
                    }
                    var worksheet = package.Workbook.Worksheets[3];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        int code = Convert.ToInt32(worksheet.Cells[row, 1].Text);
                        string name = worksheet.Cells[row, 2].Text;
                        ServiceType serviceType = new ServiceType(code, name);
                        serviceTypes.Add(serviceType);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return serviceTypes;
        }

        public static bool clientAlter(List<Client> clients, int key)
        {
            try
            {
                var recordToAlter = clients.FirstOrDefault(item => item.code == key);
                if (recordToAlter != null)
                {
                    Console.WriteLine(recordToAlter);
                    string input;
                    Console.WriteLine("Введите новую фамилию (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (input != "") { recordToAlter.surname = input; }
                    Console.WriteLine("Введите новое имя (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (input != "") { recordToAlter.name = input; }
                    Console.WriteLine("Введите новое отчество (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (input != "") { recordToAlter.fatherName = input; }
                    Console.WriteLine("Введите новое место жительства (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (input != "") { recordToAlter.residence = "г. " + input; }
                    Console.WriteLine(recordToAlter);
                    return true;
                }
                else
                {
                    Console.WriteLine($"Клиент с кодом {key} не найден.");
                    return true;
                }
            }
            catch (Exception ex) { Console.WriteLine("Ошибка " + ex.Message); }
            return false;
        }

        public static bool serviceTypeAlter(List<ServiceType> serviceTypes, int key)
        {
            try
            {
                var recordToAlter = serviceTypes.FirstOrDefault(item => item.code == key);
                if (recordToAlter != null)
                {
                    Console.WriteLine(recordToAlter);
                    string input;
                    Console.WriteLine("Введите новое название типа услуги (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (input != "") { recordToAlter.name = input; }
                    Console.WriteLine(recordToAlter);
                    return true;
                }
                else
                {
                    Console.WriteLine($"Тип услуги с кодом {key} не найден.");
                    return true;
                }
            }
            catch (Exception ex) { Console.WriteLine("Ошибка " + ex.Message); }
            return false;
        }

        public static bool serviceAlter(List<Service> services, int key, List<ServiceType> serviceTypes)
        {
            try
            {
                var recordToAlter = services.FirstOrDefault(item => item.code == key);
                if (recordToAlter != null)
                {
                    Console.WriteLine(recordToAlter);
                    string input;
                    Console.WriteLine("Введите новый код типа (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    int newValue;
                    if (int.TryParse(input, out newValue)) { if (serviceTypes.Any(item => item.code == newValue)) { recordToAlter.typeCode = newValue; } else { Console.WriteLine("В таблице Типы услуг отсутствует тип с данным кодом, изменение отменено"); } }
                    else { Console.WriteLine("Введённое значение не явяется числом или вы оставили строку пустой, сохранено старое значение"); }
                    Console.WriteLine("Введите новое название услуги (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (input != "") { recordToAlter.name = input; }
                    Console.WriteLine("Введите новую цену услуги (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out newValue)) { if (newValue > 0) recordToAlter.cost = input + " р."; else Console.WriteLine("Значение не может быть <0, сохранено старое значение"); }
                    else { Console.WriteLine("Введённое значение не явяется числом или вы оставили строку пустой, сохранено старое значение"); }
                    Console.WriteLine(recordToAlter);
                    return true;
                }
                else
                {
                    Console.WriteLine($"Услуга с кодом {key} не найден.");
                    return true;
                }
            }
            catch (Exception ex) { Console.WriteLine("Ошибка " + ex.Message); }
            return false;
        }
        public static bool orderAlter(List<Order> orders, int key, List<Service> services, List<Client> clients)
        {
            try
            {
                var recordToAlter = orders.FirstOrDefault(item => item.code == key);
                if (recordToAlter != null)
                {
                    Console.WriteLine(recordToAlter);
                    string input;
                    Console.WriteLine("Введите новый код клиента (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    int newValue;
                    if (int.TryParse(input, out newValue)) { if (clients.Any(item => item.code == newValue)) { recordToAlter.clientCode = newValue; } else { Console.WriteLine("В таблице Клиенты отсутствует клиент с данным кодом, изменение отменено"); } }
                    else { Console.WriteLine("Введённое значение не явяется числом или вы оставили строку пустой, сохранено старое значение"); }
                    Console.WriteLine("Введите новый код услуги (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out newValue)) { if (services.Any(item => item.code == newValue)) { recordToAlter.serviceCode = newValue; } else { Console.WriteLine("В таблице Услуги отсутствует услуга с данным кодом, изменение отменено"); } }
                    else { Console.WriteLine("Введённое значение не явяется числом или вы оставили строку пустой, сохранено старое значение"); }
                    Console.WriteLine("Введите новую дату заказа (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    DateTime newValue2;
                    if (DateTime.TryParse(input, out newValue2)) { recordToAlter.date = newValue2; }
                    else { Console.WriteLine("Введённое значение не явяется датой или вы оставили строку пустой, сохранено старое значение"); }
                    Console.WriteLine("Введите новое количество (нажмите Enter, чтобы оставить текущее значение)");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out newValue)) { if (newValue > 0) recordToAlter.quantity = newValue; else Console.WriteLine("Значение не может быть <0, сохранено старое значение"); }
                    else { Console.WriteLine("Введённое значение не явяется числом или вы оставили строку пустой, сохранено старое значение"); }
                    Console.WriteLine(recordToAlter);
                    return true;
                }
                else
                {
                    Console.WriteLine($"Услуга с кодом {key} не найден.");
                    return true;
                }
            }
            catch (Exception ex) { Console.WriteLine("Ошибка " + ex.Message); }
            return false;
        }

        public static bool addClient(List<Client> clients)
        {
            string input;
            string surname, name, fatherName, residence;
            Console.WriteLine("Добавим нового клиента");
            Console.WriteLine("Введите фамилию");
            input = Console.ReadLine();
            if (input != "") surname = input; else { Console.WriteLine("Значение не может быть пустым, создание отменено"); return false; }
            Console.WriteLine("Введите имя");
            input = Console.ReadLine();
            if (input != "") name = input; else { Console.WriteLine("Значение не может быть пустым, создание отменено"); return false; }
            Console.WriteLine("Введите отчество");
            input = Console.ReadLine();
            if (input != "") fatherName = input; else { Console.WriteLine("Значение не может быть пустым, создание отменено"); return false; }
            Console.WriteLine("Введите город проживания");
            input = Console.ReadLine();
            if (input != "") residence = "г." + input; else { Console.WriteLine("Значение не может быть пустым, создание отменено"); return false; }

            int newCode = clients.Max(c => c.code) + 1;
            Client newClient = new Client(newCode, surname, name, fatherName, residence);
            clients.Add(newClient);
            Console.WriteLine("Добавлен\n" + newClient);
            return true;
        }

        public static bool addServiceType(List<ServiceType> serviceTypes)
        {
            string input;
            string name;
            Console.WriteLine("Добавим новый тип услуги");
            Console.WriteLine("Введите название типа");
            input = Console.ReadLine();
            if (input != "") name = input; else { Console.WriteLine("Значение не может быть пустым, создание отменено"); return false; }

            int newCode = serviceTypes.Max(s => s.code) + 1;
            ServiceType newServiceType = new ServiceType(newCode, name);
            serviceTypes.Add(newServiceType);
            Console.WriteLine("Добавлен\n" + newServiceType);
            return true;
        }

        public static bool addService(List<Service> services, List<ServiceType> serviceTypes)
        {
            string input;
            string name, cost;
            int serviceTypeCode;
            int newValue;
            Console.WriteLine("Добавим новую услугу");
            Console.WriteLine("Введите код типа услуги");
            input = Console.ReadLine();
            if (int.TryParse(input, out newValue)) { if (serviceTypes.Any(item => item.code == newValue)) serviceTypeCode = newValue; else { Console.WriteLine("В таблице Типы услуг отсутствует тип с таким кодом, создание отменено"); return false; } }
            else { Console.WriteLine("Введённое значение не является числом, добавление отменено"); return false; }
            Console.WriteLine("Введите название услуги");
            input = Console.ReadLine();
            if (input != "") name = input; else { Console.WriteLine("Значение не может быть пустым, создание отменено"); return false; }
            Console.WriteLine("Введите стоимость услуги");
            input = Console.ReadLine();
            if (int.TryParse(input, out newValue)) { if (newValue > 0) cost = newValue + " р."; else { Console.WriteLine("Стоимость не может быть ниже 1, создание отменено"); return false; } }
            else { Console.WriteLine("Введённое значение не является числом, добавление отменено"); return false; }


            int newCode = services.Max(s => s.code) + 1;
            Service newService = new Service(newCode, serviceTypeCode, name, cost);
            services.Add(newService);
            Console.WriteLine("Добавлен\n" + newService);
            return true;
        }

        public static bool addOrder(List<Order> orders, List<Service> services, List<Client> clients)
        {
            string input;
            DateTime date;
            int serviceCode, clientCode, quantity;
            int newValue;
            Console.WriteLine("Добавим новый заказ");
            Console.WriteLine("Введите код клиента");
            input = Console.ReadLine();
            if (int.TryParse(input, out newValue)) { if (clients.Any(item => item.code == newValue)) clientCode = newValue; else { Console.WriteLine("В таблице Клиенты отсутствует клиент с таким кодом, создание отменено"); return false; } }
            else { Console.WriteLine("Введённое значение не является числом, добавление отменено"); return false; }
            Console.WriteLine("Введите код услуги");
            input = Console.ReadLine();
            if (int.TryParse(input, out newValue)) { if (services.Any(item => item.code == newValue)) serviceCode = newValue; else { Console.WriteLine("В таблице Услуги отсутствует услуга с таким кодом, создание отменено"); return false; } }
            else { Console.WriteLine("Введённое значение не является числом, добавление отменено"); return false; }
            Console.WriteLine("Введите дату заказа");
            input = Console.ReadLine();
            DateTime newValue2;
            if (input != "") { if (DateTime.TryParse(input, out newValue2)) date = newValue2; else { Console.WriteLine("Введённое значение не является датой, создание отменено"); return false; } }
            else { Console.WriteLine("Значение не может быть пустым, создание отменено"); return false; }
            Console.WriteLine("Введите количество");
            input = Console.ReadLine();
            if (int.TryParse(input, out newValue)) { if (newValue > 0) quantity = newValue; else { Console.WriteLine("Количество не может быть ниже 1, создание отменено"); return false; } }
            else { Console.WriteLine("Введённое значение не является числом, добавление отменено"); return false; }



            int newCode = orders.Max(s => s.code) + 1;
            Order newOrder = new Order(newCode, clientCode, serviceCode, date, quantity);
            orders.Add(newOrder);
            Console.WriteLine("Добавлен\n" + newOrder);
            return true;
        }

        public static bool deleteClient(List<Client> clients, int key, List<Order> orders)
        {
            int clientCode;
            string input = "1";
            if (input != "" && int.TryParse(input, out clientCode))
            {
                if (clients.Any(item => item.code == key))
                { clients.RemoveAll(item => item.code == key); orders.RemoveAll(item => item.clientCode == key); }
                else { Console.WriteLine($"Не найден клиент с кодом {key}"); return false; }
            }
            else { Console.WriteLine("Введённое значение не является числом, удаление отменено"); return false; }
            return true;
        }

        public static bool deleteOrder(List<Order> orders, int key)
        {
            int orderCode;
            string input = "1";
            if (input != "" && int.TryParse(input, out orderCode))
            {
                if (orders.Any(item => item.code == key))
                { orders.RemoveAll(item => item.code == key); }
                else { Console.WriteLine($"Не найден заказ с кодом {key}"); return false; }
            }
            else { Console.WriteLine("Введённое значение не является числом, удаление отменено"); return false; }
            return true;
        }

        public static bool deleteService(List<Service> services, int key, List<Order> orders)
        {
            int serviceCode;
            string input = "1";
            if (input != "" && int.TryParse(input, out serviceCode))
            {
                if (services.Any(item => item.code == key))
                { services.RemoveAll(item => item.code == key); orders.RemoveAll(item => item.serviceCode == key); }
                else { Console.WriteLine($"Не найдена услуга с кодом {key}"); return false; }
            }
            else { Console.WriteLine("Введённое значение не является числом, удаление отменено"); return false; }
            return true;
        }

        public static bool deleteServiceType(List<ServiceType> serviceTypes, int key, List<Order> orders, List<Service> services)
        {
            int serviceTypeCode;
            string input = "1";
            if (input != "" && int.TryParse(input, out serviceTypeCode))
            {
                if (serviceTypes.Any(item => item.code == key))
                {
                    serviceTypes.RemoveAll(item => item.code == key);
                    var serviceCodesToRemove = services.Where(item => item.typeCode == key).Select(item => item.code).ToList();
                    services.RemoveAll(item => item.typeCode == key);
                    { foreach (var item in serviceCodesToRemove) { orders.RemoveAll(order => order.serviceCode == item); } }
                }
                else { Console.WriteLine($"Не найден тип услуги с кодом {serviceTypeCode}"); return false; }
            }
            else { Console.WriteLine("Введённое значение не является числом, удаление отменено"); return false; }
            return true;
        }

        public static decimal calculateTotalVladivostok(List<Client> clients, List<ServiceType> serviceTypes,
        List<Service> services, List<Order> orders)
        {
            var clientCodes = clients
                .Where(client => client.residence.StartsWith("г. Владивосток"))
                .Select(client => client.code);

            var serviceCodes = services
                .Where(service => service.typeCode == serviceTypes.FirstOrDefault(st => st.name == "Полиграфия")?.code)
                .Select(service => service.code);

            var totalCost = orders
                .Where(order => clientCodes.Contains(order.clientCode) &&
                                serviceCodes.Contains(order.serviceCode) &&
                                order.date.Year == 2018 && order.date.Month == 6)
                .Sum(order =>
                {
                    var servicePrice = services.FirstOrDefault(service => service.code == order.serviceCode)?.cost;
                    if (servicePrice != null && decimal.TryParse(servicePrice.Replace(" р.", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                    {
                        return price * order.quantity;
                    }
                    return 0;
                });

            return totalCost;
        }

        public static void cityStats(List<Client> clients)
        {
            var cityCounts = clients
            .GroupBy(client => client.residence)
            .Select(group => new
            {
                City = group.Key,
                Count = group.Count()
            })
            .OrderByDescending(cityCount => cityCount.Count);

            Console.WriteLine("Город - Количество клиентов:");
            foreach (var cityCount in cityCounts)
            {
                Console.WriteLine($"{cityCount.City}: {cityCount.Count}");
            }
        }

        public static void сountOrdersByServiceType(List<Order> orders, List<Service> services, List<ServiceType> serviceTypes)
        {
            var orderCounts = orders
                .GroupBy(order => services.First(service => service.code == order.serviceCode).typeCode)
                .Select(group => new
                {
                    serviceTypeCode = group.Key,
                    Count = group.Count()
                })
                .Join(serviceTypes,
                    orderCount => orderCount.serviceTypeCode,
                    serviceType => serviceType.code,
                    (orderCount, serviceType) => new
                    {
                        ServiceTypeName = serviceType.name,
                        Count = orderCount.Count
                    })
                .OrderByDescending(result => result.Count);

            Console.WriteLine("Тип услуги - Количество заказов:");
            foreach (var orderCount in orderCounts)
            {
                Console.WriteLine($"{orderCount.ServiceTypeName}: {orderCount.Count}");
            }
        }

        public static void сalculateNetProfit(List<Order> orders, List<Service> services, int year, int month)
        {
            decimal netProfit = 0;

            foreach (var order in orders.Where(o => o.date.Year == year && o.date.Month == month))
            {
                // Извлекаем цену из строки и конвертируем в decimal
                var service = services.First(s => s.code == order.serviceCode);
                string priceString = service.cost.Replace(" р.", "").Trim();
                if (decimal.TryParse(priceString, out decimal price))
                {
                    netProfit += price * order.quantity;
                }
                else
                {
                    throw new FormatException($"Некорректный формат цены: {service.cost}");
                }
            }

            // Печать чистой прибыли
            Console.WriteLine($"Выручка за {month}.{year}: {netProfit} р.");
        }

        public static void printClients(List<Client> clients)
        {
            foreach (var item in  clients)
                Console.WriteLine(item);
        }

        public static void printOrders(List<Order> orders)
        {
            foreach (var item in orders)
                Console.WriteLine(item);
        }

        public static void printServices(List<Service> services)
        {
            foreach (var item in services)
                Console.WriteLine(item);
        }

        public static void printServiceTypes(List<ServiceType> serviceTypes)
        {
            foreach (var item in serviceTypes)
                Console.WriteLine(item);
        }

        public static void saveDataToExcel(List<Client> clients, List<ServiceType> serviceTypes, List<Service> services, List<Order> orders, string filePath)
        {
            try
            {
                File.Delete(filePath);

                using (var package = new ExcelPackage())
                {
                    var clientSheet = package.Workbook.Worksheets.Add("Клиенты");
                    clientSheet.Cells[1, 1].Value = "Код клиента";
                    clientSheet.Cells[1, 2].Value = "Фамилия";
                    clientSheet.Cells[1, 3].Value = "Имя";
                    clientSheet.Cells[1, 4].Value = "Отчество";
                    clientSheet.Cells[1, 5].Value = "Место жительства";

                    for (int i = 0; i < clients.Count; i++)
                    {
                        clientSheet.Cells[i + 2, 1].Value = clients[i].code;
                        clientSheet.Cells[i + 2, 2].Value = clients[i].surname;
                        clientSheet.Cells[i + 2, 3].Value = clients[i].name;
                        clientSheet.Cells[i + 2, 4].Value = clients[i].fatherName;
                        clientSheet.Cells[i + 2, 5].Value = clients[i].residence;
                    }

                    var orderSheet = package.Workbook.Worksheets.Add("Заказы");
                    orderSheet.Cells[1, 1].Value = "Код заказа";
                    orderSheet.Cells[1, 2].Value = "Код клиента";
                    orderSheet.Cells[1, 3].Value = "Дата заказа";
                    orderSheet.Cells[1, 4].Value = "Код услуги";
                    orderSheet.Cells[1, 5].Value = "Количество";

                    for (int i = 0; i < orders.Count; i++)
                    {
                        orderSheet.Cells[i + 2, 1].Value = orders[i].code;
                        orderSheet.Cells[i + 2, 2].Value = orders[i].clientCode;
                        orderSheet.Cells[i + 2, 3].Value = orders[i].date.ToString("MM.dd.yyyy");
                        orderSheet.Cells[i + 2, 4].Value = orders[i].serviceCode;
                        orderSheet.Cells[i + 2, 5].Value = orders[i].quantity;
                    }

                    var serviceSheet = package.Workbook.Worksheets.Add("Услуги");
                    serviceSheet.Cells[1, 1].Value = "Код услуги";
                    serviceSheet.Cells[1, 2].Value = "Код типа";
                    serviceSheet.Cells[1, 3].Value = "Название";
                    serviceSheet.Cells[1, 4].Value = "Стоимость";

                    for (int i = 0; i < services.Count; i++)
                    {
                        serviceSheet.Cells[i + 2, 1].Value = services[i].code;
                        serviceSheet.Cells[i + 2, 2].Value = services[i].typeCode;
                        serviceSheet.Cells[i + 2, 3].Value = services[i].name;
                        serviceSheet.Cells[i + 2, 4].Value = services[i].cost;
                    }

                    var serviceTypeSheet = package.Workbook.Worksheets.Add("Типы услуг");
                    serviceTypeSheet.Cells[1, 1].Value = "Код типа";
                    serviceTypeSheet.Cells[1, 2].Value = "Название";

                    for (int i = 0; i < serviceTypes.Count; i++)
                    {
                        serviceTypeSheet.Cells[i + 2, 1].Value = serviceTypes[i].code;
                        serviceTypeSheet.Cells[i + 2, 2].Value = serviceTypes[i].name;
                    }

                    FileInfo excelFile = new FileInfo(filePath);
                    package.SaveAs(excelFile);
                }

                Console.WriteLine($"Данные успешно сохранены в файл: {filePath}");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка" + ex.Message); }
        }
    }
}
