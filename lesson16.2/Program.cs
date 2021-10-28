using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;


namespace lesson16._2
{
    class Program
    {
        /*Необходимо разработать программу для получения информации о товаре из json-файла.
            Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
        static void Main(string[] args)
        {
            string file = "G:/Рабочий стол/Повышение квалификации/Products.json";
            string jsonStringArray = File.ReadAllText(file);
            decimal maxprice = 0;
            string mostExpensiveProduct="";
            char startJsonString = '{';
            char endJsonString = '}';
            char[] chars = jsonStringArray.ToCharArray();
            int startPoint = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i]==startJsonString)
                {
                    startPoint = i;
                }
                if (chars[i] == endJsonString)
                {
                    string jsonString = jsonStringArray.Substring(startPoint, i - startPoint + 1);
                    Goods product = JsonSerializer.Deserialize<Goods>(jsonString);
                    if (maxprice < product.PriceProduct)
                    {
                        maxprice = product.PriceProduct;
                        mostExpensiveProduct = product.NameProduct;
                    }
                }
            }
            Console.WriteLine(jsonStringArray);
            Console.WriteLine("Самый дорогой товар: {0}, по цене: {1}",mostExpensiveProduct,maxprice);
            Console.ReadKey();
        }
    }
    class Goods
    {
        [JsonPropertyName("Код товара")]
        public int CodeProduct { get; set; }
        [JsonPropertyName("Наименование товара")]

        public string NameProduct { get; set; }
        [JsonPropertyName("Цена товара")]

        public decimal PriceProduct { get; set; }
    }
}
