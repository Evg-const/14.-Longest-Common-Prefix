using System;

namespace _14.Longest_Common_Prefix
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = 0;                               // текущее количество строк в массиве
            string[] input = new string[count];         // ссылка на массив строк
            string s;
            string[] temp;                               // дополнительная переменная-ссылка - сохраняет старый массив строк


            Console.WriteLine("Введите слова. Если закончили ввод: нажмите Enter");

            do
            {
                s = Console.ReadLine();                             // Ввести строку
                if (s != "")                                        // Проверка, пустая ли строка
                {
                    count++;                                        // если строка не пустая, то добавить строку в массив
                    temp = new string[count];                         // предварительно выделить память для нового массива в котором на 1 элемент больше
                    for (int l = 0; l < temp.Length - 1; l++)        // скопировать старый массив в новый
                        temp[l] = input[l];
                    temp[count - 1] = s;                             // добавить последнюю введенную строку в массив AS2 
                    input = temp;                                     // перенаправить ссылку AS на AS2
                }
            } while (s != "");

            Console.WriteLine(LongestCommonPrefix(input));
            Console.Read();


            string LongestCommonPrefix(string[] strs)
            {
                if (strs.Length == 0)
                {
                    return "Нет значений";
                }
                if (Array.IndexOf(strs, "") != -1)
                {        //Ищет в масиве пустое значение, если есть - взвращает -1
                    return "Нет значений";
                }

                string res = strs[0];                       //Используем первое слово как маску для перебора
                int i = res.Length;                         //Узнаем длинну первого слова

                foreach (string word in strs)               //перебираем слова в массиве
                {
                    int j = 0;                              //счетчик для номера буквы по порядку
                    foreach (char c in word)                //перебираем буквы в слове
                    {
                        if (j >= i || res[j] != c)          //Если счетчик больше или равен длинны первого слова или буква в слове не равна заданной букве - выброс 
                            break;
                        j += 1;
                    }
                    i = Math.Min(i, j);                     //узнаем минимальное из счетчика проходов и минимальной длинны первого слова
                }
                return res.Substring(0, i);                 //режем первое слово по маске

            }



        }

    }
}

