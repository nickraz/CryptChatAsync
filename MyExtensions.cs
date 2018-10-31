using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptChatAsync
{
    public static class MyExtensions
    {
        /// <summary>
        /// Преобразование строки в массив байтов
        /// </summary>
        /// <param name="s">Исходный текст</param>
        /// <returns>Возвращает массив байтов</returns>
        public static byte[] toBytes(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        /// <summary>
        /// Преобразование массива байтов в строку
        /// </summary>
        /// <param name="bytes">Массив байтов</param>
        /// <returns>Возвращает строку</returns>
        public static string toString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
