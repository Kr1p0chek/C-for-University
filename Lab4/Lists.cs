using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Serialization;

namespace Lab4_C_
{
    internal class Lists
    {
        public static void MoveFirstToEnd(List<int> list)
        {
            Console.WriteLine("Исходный список:");
            PrintList(list);
            if (list.Count > 0)
            {
                int firstElement = list[0];
                list.RemoveAt(0);
                list.Add(firstElement);
                Console.WriteLine("Список после переноса:");
                PrintList(list);
            }
            else
            {
                Console.WriteLine("В списке отсутствуют элементы");
            }
        }

        static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void lettersWork(string filePath)
        {
            try
            {
                string text = File.ReadAllText(filePath);
                var words = Regex.Split(text, @"\W+").Select(w => w.ToLower()).ToArray();
                var oddWords = new List<string>();
                var evenWords = new List<string>();

                for (int i = 0; i < words.Length; i++)
                {
                    if (string.IsNullOrEmpty(words[i])) continue;

                    if (i % 2 == 0)
                        oddWords.Add(words[i]);
                    else
                        evenWords.Add(words[i]);
                }
                var deafConsonants = new HashSet<char> { 'п', 'ф', 'к', 'т', 'с', 'щ', 'ц', 'х', 'ш', 'ч' };
                var OddLetters = new HashSet<char>(deafConsonants);
                for (int i = 0; i < oddWords.Count; i++)
                {
                    chars1(oddWords[i], OddLetters);
                }

                var AttLetters = new HashSet<char>();
                for (int i = 0; i < evenWords.Count; i++)
                {
                    chars2(deafConsonants, evenWords[i], AttLetters);
                }

                var Result = new HashSet<char>();
                Result = new HashSet<char>(OddLetters);
                Result.IntersectWith(AttLetters);
                if (Result.Count > 0)
                {
                    var orderedResult = Result.OrderBy(c => c);
                    Console.WriteLine("Глухие согласные, которые входят в каждое нечетное слово и не входят хотя бы в одно четное слово:");
                    foreach (var consonant in orderedResult)
                    {
                        Console.Write(consonant + " ");
                    }
                    Console.WriteLine();
                }
                else { Console.WriteLine("Нет букв, удовлетворяющих условиям"); }
            }
            catch (FileNotFoundException e) { Console.WriteLine("Cannot open file " + e.Message); throw; }
            catch (IOException e) { Console.WriteLine("Acces error " + e.Message); throw; }
            catch (Exception e) { Console.WriteLine("Unknown error " + e.Message); throw; }
        }

        static void chars1(string word, HashSet<char> OddLetters)
        {
            HashSet<char> wordSet = new HashSet<char>(word);
            OddLetters.IntersectWith(wordSet);
        }

        static void chars2(HashSet<char> chars, string word, HashSet<char> AttLetters)
        {
            HashSet<char> wordSet = new HashSet<char>(word);
            foreach (var item in chars)
            {
                if (!wordSet.Contains(item))
                    AttLetters.Add(item);
            }
        }

        public static void delIfSameNeighbors(LinkedList<int> nums)
        {
            Console.WriteLine("До удаления:");
            foreach (var item in nums)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
            if (nums.Count < 2)
            {
                Console.WriteLine("В списке менее 2ух элементов");
                return;
            }
            LinkedListNode<int> now = nums.First;
            while (now.Next != null)
            {
                if (now.Previous == null)
                {
                    if (now.Next.Value == nums.Last.Value)
                    {
                        nums.RemoveFirst();
                        now = nums.First;
                    }
                    else
                        now = now.Next;
                }
                else
                {
                    if (now.Next.Value == now.Previous.Value)
                    {
                        LinkedListNode<int> remove = now;
                        now = now.Next;
                        nums.Remove(remove);
                    }
                    else
                        now = now.Next;
                }
            }
            if (now.Previous.Value == nums.First.Value)
            {
                nums.RemoveLast();
            }
            Console.WriteLine("После удаления:");
            foreach (var item in nums)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }

        public static void fabricsBuysResult(HashSet<string> fabrics, List<HashSet<string>> customersBuys)
        {
            if (fabrics.Count == 0 || customersBuys.Count == 0)
            {
                Console.WriteLine("В одном из списков Фабрики или Покупки отсутствуют элементы");
                return;
            }
            HashSet<string> allBuys = new HashSet<string>();
            foreach (var item in customersBuys)
            {
                if (allBuys.Count == 0)
                    allBuys = new HashSet<string>(item);
                else
                    allBuys.IntersectWith(item);
            }
            allBuys.IntersectWith(fabrics);
            HashSet<string> someBuys = new HashSet<string>();
            foreach (var item in customersBuys)
            {
                if (someBuys.Count == 0)
                    someBuys = new HashSet<string>(item);
                else
                    someBuys.UnionWith(item);
            }
            someBuys.IntersectWith(fabrics);
            someBuys.ExceptWith(allBuys);
            HashSet<string> noBuys = new HashSet<string>(fabrics);
            noBuys.ExceptWith(allBuys);
            noBuys.ExceptWith(someBuys);

            var sortedAllBuys = allBuys.OrderBy(c => c);
            var sortedSomeBuys = someBuys.OrderBy(c => c);
            var sortedNoBuys = noBuys.OrderBy(c => c);
            Console.WriteLine("Каждый покупатель купил продукцию следующих фабрик:");
            if (allBuys.Count == 0)
                Console.WriteLine("Таких фабрик нет");
            else
            {
                foreach (var item in sortedAllBuys)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Хотя бы один покупатель купил продукцию следующих фабрик:");
            if (someBuys.Count == 0)
                Console.WriteLine("Таких фабрик нет");
            else
            {
                foreach (var item in sortedSomeBuys)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Ни один покупатель не купил продукцию следующих фабрик:");
            if (noBuys.Count == 0)
                Console.WriteLine("Таких фабрик нет");
            else
            {
                foreach (var item in sortedNoBuys)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }

        public static List<Store> DeserializeStores(string filePath)
        {
            try
            {
                List<Store> stores = new List<Store>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Store>));
                if (File.Exists("stores.xml"))
                {
                    FileStream fs = new FileStream("stores.xml", FileMode.Open);
                    stores = (List<Store>)serializer.Deserialize(fs);
                }
                else
                {
                    Console.WriteLine("Файл с данными о магазинах не найден. Пожалуйста, создайте его с данными о магазинах.");
                    return stores;
                }
                return stores;
            }
            catch (Exception e) { Console.WriteLine("Ошибка " + e.Message); throw; } 
        }

        public static void GetMinPriceStoresCount(string filePath)
        {
            try
            {
                List<Store> stores = DeserializeStores(filePath);
                var minPrices = new Dictionary<int, int>();
                var storeCounts = new Dictionary<int, int>();

                if (stores.Count == 0) { Console.WriteLine("Данные о магазинах отсутствуют "); return; }

                foreach (var store in stores)
                {
                    if (!minPrices.ContainsKey(store.FatContent))
                    {
                        minPrices[store.FatContent] = store.Price;
                        storeCounts[store.FatContent] = 1;
                    }
                    else
                    {
                        if (store.Price < minPrices[store.FatContent])
                        {
                            minPrices[store.FatContent] = store.Price;
                            storeCounts[store.FatContent] = 1;
                        }
                        else if (store.Price == minPrices[store.FatContent])
                        {
                            storeCounts[store.FatContent]++;
                        }
                    }
                }
                Console.WriteLine("Результат:");
                Console.Write((storeCounts.ContainsKey(15) ? storeCounts[15] : 0) + " ");
                Console.Write((storeCounts.ContainsKey(20) ? storeCounts[20] : 0) + " ");
                Console.Write(storeCounts.ContainsKey(25) ? storeCounts[25] : 0);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw; }
        }

        static void SerializeStores(List<Store> stores, string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Store>));
                FileStream fs = new FileStream(filePath, FileMode.Create);
                serializer.Serialize(fs, stores);
            }
            catch (Exception e) { Console.WriteLine("Ошибка "); throw; }
        }

        public static void FillStoresData(string filePath)
        {
            Console.Write("Введите количество магазинов: ");
            int n;
            try
            {
                n = int.Parse(Console.ReadLine());
                while (n < 1)
                {
                    Console.Write("Введите количество магазинов (>0): ");
                    n = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception e) { Console.WriteLine("Ошибка типа"); throw; }
            List<Store> stores = new List<Store>();
            try
            {
                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    var parts = input.Split(' ');

                    string firm = parts[0];
                    string street = parts[1];
                    int fatContent = int.Parse(parts[2]);
                    int price = int.Parse(parts[3]);
                    if (firm.Length > 20 || street.Length > 20 || !(fatContent == 15 || fatContent == 20 || fatContent == 25) || price < 1) continue;
                    stores.Add(new Store(firm, street, fatContent, price));
                }
            }
            catch ( Exception e) { Console.WriteLine("Ошибка типа"); throw; }
            try
            {
                SerializeStores(stores, filePath);
            }
            catch (Exception e) {Console.WriteLine(e.Message); throw; }
        }

    }
}
