using Lab4_C_;

[Serializable]
public class Store
{
    public string Firm { get; set; }
    public string Street { get; set; }
    public int FatContent { get; set; }
    public int Price { get; set; }

    public Store() { }

    public Store(string firm, string street, int fatContent, int price)
    {
        Firm = firm;
        Street = street;
        FatContent = fatContent;
        Price = price;
    }
}
internal class Program
{
    public static void Main() 
    {
        List<string> L = new List<string> { "10", "20", "30", "40", "50" };
        Console.WriteLine("Задание 1:");
        Lists.MoveFirstToEnd(L);

        Console.WriteLine("\nЗадание 4:");
        string filePath = "text.txt";
        Lists.lettersWork(filePath);

        Console.WriteLine("\nЗадание 2:");
        LinkedList<string> l = new LinkedList<string> (new [] { "7", "1", "4", "5", "1" });
        Lists.delIfSameNeighbors(l);

        Console.WriteLine("\nЗадание 3:");
        List<HashSet<string>> customersBuys = new List<HashSet<string>> ();
        int n = 1;
        Console.WriteLine("Сколько было покупателей? (данные о фабриках, чью продукцию купил каждый покупатель, будут заполнены случайно)");
        try
        {
            n = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e) { Console.WriteLine("Ошибка " + e.Message); }
        if (n < 1)
        {
            Console.WriteLine("Невозможно выполнить задание для этого числа покупателей");
        }
        else
        {
            HashSet<string> fabrics = new HashSet<string>(new[] { "Fabric A", "Fabric B", "Fabric C", "Fabric D", "Fabric E", "Fabric F" });
            List<string> fabricsList = new List<string>(fabrics);
            for (int i = 1; i <= n; i++)
            {
                Random random = new Random();
                int count = random.Next(1, 7);
                HashSet<string> buys = new HashSet<string>();
                for (int j = 0; j < count; j++)
                {
                    string buy = fabricsList[random.Next(fabricsList.Count)];
                    while (buys.Contains(buy))
                        buy = fabricsList[random.Next(fabricsList.Count)];
                    buys.Add(buy);
                }
                customersBuys.Add(buys);
            }
            Lists.fabricsBuysResult(fabrics, customersBuys);
        }

        Console.WriteLine("\nЗадание 5");
        string xmlFile = "stores.xml";
        try
        {
            Lists.FillStoresData(xmlFile);
            Lists.GetMinPriceStoresCount(xmlFile);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}