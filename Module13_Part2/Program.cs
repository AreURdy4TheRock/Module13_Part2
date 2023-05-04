using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Module13_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "f:\\cdev_Text.txt";
            var items = new Dictionary<string, int>();
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText(path);
            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            // убираем знаки препинания
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Записываем каждое слово в словарь
            foreach (var word in words)
            {
                items.TryAdd(word, 0);
                if (items.ContainsKey(word))
                {
                    items[word]++;
                }
            }
            // 10 раз находим самое большое значение в словаре, выводим и удаляем по ключу
            for(int i = 0 ; i < 10; i++) 
            { 
                int max = 0;
                string top = "";
                foreach (var word in items)
                {
                    if (max<word.Value)
                    {
                        max = word.Value;
                        top = word.Key;
                    }
                    
                }
                
                Console.WriteLine(top +" " +max);
                items.Remove(top);
            }

        }
    }
}
