using System;
using System.Globalization;
using OfficeOpenXml;
using Lab5C_;
using OfficeOpenXml.Drawing.Style.Fill;

public interface IEntity
{
    int code { get; }
}
class Client
{
    public int code { get; set; }
    public string surname { get; set; }
    public string name { get; set; }
    public string fatherName { get; set; }
    public string residence { get; set; }

    public Client(int code, string surname, string name, string fatherName, string residense)
    {
        this.code = code;
        this.surname = surname;
        this.name = name;
        this.fatherName = fatherName;
        this.residence = residense;
    }

    public override string ToString()
    {
        return $"Код: {code}, Фамилия: {surname}, Имя: {name}, Отчество: {fatherName}, Место жительства: {residence}";
    }
}

class Order
{
    public int code { get; set; }
    public int clientCode { get; set; }
    public int serviceCode { get; set; }
    public DateTime date { get; set; }
    public int quantity { get; set; }

    public Order(int code, int clientCode, int serviceCode, DateTime date, int quantity)
    {
        this.code = code;
        this.clientCode = clientCode;
        this.serviceCode = serviceCode;
        this.date = date;
        this.quantity = quantity;
    }

    public override string ToString()
    {
        return $"Код: {code}, Код клиента: {clientCode}, Код услуги: {serviceCode}, Дата заказа: {date.ToShortDateString()}, Количество: {quantity}";
    }
}

class Service
{
    public int code { get; set; }
    public int typeCode { get; set; }
    public string name { get; set; }

    public string cost { get; set; }

    public Service(int code, int typeCode, string name, string cost)
    {
        this.code = code;
        this.typeCode = typeCode;
        this.name = name;
        this.cost = cost;
    }

    public override string ToString()
    {
        return $"Код: {code}, Код типа: {typeCode}, Название: {name}, Стоимость: {cost}";
    }
}

class ServiceType
{
    public int code { get; set; }

    public string name { get; set; }

    public ServiceType(int code, string name)
    {
        this.code = code;
        this.name = name;
    }

    public override string ToString()
    {
        return $"Код: {code}, Название: {name}";
    }
}


internal class Program
{
    public static void Main()
    {
        string excelFilePath = "LR5-var7.xlsx";
        string logFilePath = "defaultLog.txt";
        var clients = ExcelWork.readClients(excelFilePath, logFilePath);
        var orders = ExcelWork.readOrders(excelFilePath, logFilePath);
        var services = ExcelWork.readServices(excelFilePath,logFilePath);
        var serviceTypes = ExcelWork.readServiceTypes(excelFilePath, logFilePath);

        while (true)
        {
            try
            {
                string par1 = " ";
                string par2 = " ";
                Console.WriteLine("Введите действие\n 1 - добавить запись, 2 - изменить запись,\n 3 - удалить запись, 4 - вывести таблицу,\n 5 - задание из примера, 6 - вывести прибыл за месяц и год,\n 7 - вывести список городов и кол-во клиентов вних,\n 8 - вывести кол-во заказов для каждого типа услуг\n 9 - закрыть программу");
                par1 = Console.ReadLine();
                switch (par1)
                {
                    case "1":
                        Console.WriteLine("Введите таблицу\n 1 - Клиенты, 2 - Заказы, 3 - Услуги, 4 - Типы услуг");
                        par2 = Console.ReadLine();
                        switch (par2)
                        {
                            case "1": ExcelWork.addClient(clients); break;
                            case "2": ExcelWork.addOrder(orders, services, clients); break;
                            case "3": ExcelWork.addService(services, serviceTypes); break;
                            case "4": ExcelWork.addServiceType(serviceTypes); break;
                            default: Console.WriteLine("Неизвестная таблица"); break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите таблицу\n 1 - Клиенты, 2 - Заказы, 3 - Услуги, 4 - Типы услуг");
                        par2 = Console.ReadLine();
                        string input = " ";
                        switch (par2)
                        {
                            case "1":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine(); int id;
                                if (int.TryParse(input, out id)) ExcelWork.clientAlter(clients, id); else Console.WriteLine("Ошибка, код не число"); break;
                            case "2":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine();
                                if (int.TryParse(input, out id)) ExcelWork.orderAlter(orders, id, services, clients); else Console.WriteLine("Ошибка, код не число"); break;
                            case "3":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine();
                                if (int.TryParse(input, out id)) ExcelWork.serviceAlter(services, id, serviceTypes); else Console.WriteLine("Ошибка, код не число"); break;
                            case "4":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine();
                                if (int.TryParse(input, out id)) ExcelWork.serviceTypeAlter(serviceTypes, id); else Console.WriteLine("Ошибка, код не число"); break;
                            default: Console.WriteLine("Неизвестная таблица"); break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Введите таблицу\n 1 - Клиенты, 2 - Заказы, 3 - Услуги, 4 - Типы услуг");
                        par2 = Console.ReadLine();
                        switch (par2)
                        {
                            case "1":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine(); int id;
                                if (int.TryParse(input, out id)) ExcelWork.deleteClient(clients, id, orders); else Console.WriteLine("Ошибка, код не число"); break;
                            case "2":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine();
                                if (int.TryParse(input, out id)) ExcelWork.deleteOrder(orders, id); else Console.WriteLine("Ошибка, код не число"); break;
                            case "3":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine();
                                if (int.TryParse(input, out id)) ExcelWork.deleteService(services, id, orders); else Console.WriteLine("Ошибка, код не число"); break;
                            case "4":
                                Console.WriteLine("Введите ключ (код)"); input = Console.ReadLine();
                                if (int.TryParse(input, out id)) ExcelWork.deleteServiceType(serviceTypes, id, orders, services); else Console.WriteLine("Ошибка, код не число"); break;
                            default: Console.WriteLine("Неизвестная таблица"); break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Введите таблицу\n 1 - Клиенты, 2 - Заказы, 3 - Услуги, 4 - Типы услуг");
                        par2 = Console.ReadLine();
                        switch (par2)
                        {
                            case "1":
                                ExcelWork.printClients(clients); break;
                            case "2":
                                ExcelWork.printOrders(orders); break;
                            case "3":
                                ExcelWork.printServices(services); break;
                            case "4":
                                ExcelWork.printServiceTypes(serviceTypes); break;
                            default: Console.WriteLine("Неизвестная таблица"); break;
                        }
                        break;
                    case "5": ExcelWork.calculateTotalVladivostok(clients, serviceTypes, services, orders); break;
                    case "6":
                        int year, month;
                        Console.WriteLine("Введите год"); input = Console.ReadLine();
                        if (int.TryParse(input, out year))
                        {
                            Console.WriteLine("Введите месяц"); input = Console.ReadLine();
                            if (int.TryParse(input, out month)) { ExcelWork.сalculateNetProfit(orders, services, year, month); break; }
                            else { Console.WriteLine("Введённое значение не число"); break; }
                        }
                        else { Console.WriteLine("Введённое значение не число"); break; }
                    case "7":
                        ExcelWork.cityStats(clients); break;
                    case "8":
                        ExcelWork.сountOrdersByServiceType(orders, services, serviceTypes); break;
                    case "9":
                        return; break;
                        default : Console.WriteLine("Завершение программы..."); return; break;

                }
            }
            catch (Exception ex) { Console.WriteLine("Ошибка" + ex.Message); }

            try
            {
                string input;
                Console.WriteLine("Если хотите сохранить изменения введите 1"); input = Console.ReadLine();
                if (input == "1") { ExcelWork.saveDataToExcel(clients, serviceTypes, services, orders, excelFilePath); }
                else { Console.WriteLine("Изменения отменены"); }
            }
            catch (Exception ex) { Console.WriteLine("Ошибка при сохранении: " + ex.Message); }
            Console.Clear();
        }
    }
}

