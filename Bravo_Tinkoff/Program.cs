/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 18.07.2017
 * Time: 22:14
 * 
 * Программа для определения наилучших операций ддя компенсации баллов браво
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bravo_Tinkoff
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Считываем числа из txt файла
			string path = @"C:\Users\Admin\Documents\SharpDevelop Projects\Bravo_Tinkoff\bravo.txt";
			var logFile = File.ReadAllLines(path); // возвращает список строк
			var logList = new List<string>(logFile);
			
			string s = "";									//строка для накопления нулей
			
			List<int> price = logList.ConvertAll(x => Convert.ToInt32(x)); // нужно строки переделать в integer
			//int[] price = new int[]{1,2,3};
			//int[] price =  logList.ConvertAll(x => Convert.ToInt32(x));
			int komb = (int)Math.Pow(2, price.Count()); // количество сумм, которые нужно перебрать
			int[] sum = new int[komb-1]; // массив для сохранения результата каждой суммы
			char[] bit = new char[price.Count]; // массив для двоичного числа
			//int[] arr = new int[]{0,0,0};
			int[] blizko = new int[komb];
			int min = 10000000;
			string ss = "";
			foreach (int digit in price) // накапливаем строку для двоичного числа, равному 2^n
			{
				s += "0";
			}
			for(int j = 1; j< komb-1; j++) // основной счётчик для перебора всех сумм
			{
				////////////ФОРМИРУЕМ БИТ-МАСКУ ДЛЯ 
				string BinaryCode = Convert.ToString(j, 2); // получили строку, напр. будет "10" для десятичной двойки
				bit = BinaryCode.ToCharArray(); 			// перевели в массив символов {'1','0'}
				int[] Aint = Array.ConvertAll(bit, c => (int)Char.GetNumericValue(c)); // получили массив int {1,0}
				//int output = Aint //переводим массив int[] в одну цифру для последующего дополнения нулями
   				//	 .Select((t, i) => t * Convert.ToInt32(Math.Pow(10, Aint.Length - i - 1)))
    			//	 .Sum();
    			int result = 0; //переменная для хранения числа ,которое получаем из массива Aint
    			int multipicator = 1; // множитель для получения разрядов единого числа

    			/*for (int l = Aint.Length - 1; l >= 0; l--)
				{
 					  result += Aint[l] * multipicator;
  						 multipicator *= 10;
				} // получили число, обозначающее комбинацию. Число нужно для того, чтобы дополнить бит-маску нулями */
    			//--------------------*/
    			//Способ выше получает System.OverflowException. Вот второй:*/
    			
				for(int l = 0; l < Aint.Length; l++)
					{
					
  						 // result += Aint[l] * Convert.ToInt32(Math.Pow(10, Aint.Length-l-1));
  						  Console.WriteLine(Math.Pow(10, Aint.Length-l-1));
    				}
				//И он тоже получает переполнение
				//вот ещё
				string a;
				/*foreach(int test in Aint)
					{
							a+=test.toString();
					}
				result=int.parse(a);*/
				

/*var result = int.Parse(Aint
    .Select(x => x.ToString())
    .Aggregate((prev, next) => prev + next));*/


    			//Console.WriteLine(result);
				string s1 = result.ToString(s); // дополняем нулями до количества цифр в исходном массиве
				int[] ia = s1.Select(n => Convert.ToInt32(n-'0')).ToArray(); // преобразуем строку в массив int
				//Console.WriteLine(s);

				for(int i=0; i<ia.Length; i++) // счётчик для наполнения суммы
				{
					sum[j]  += price[i]*ia[i];
					
				}
				
				//Console.WriteLine(sum[j]);
				blizko[j] = 30 - sum[j];
				if ((blizko[j] <= min) &&(blizko[j] >= 0))
				{
						min = blizko[j];
						ss = s1;
				}
				//Console.WriteLine(blizko[j]);
			}
			//int min = blizko.Min();
			Console.WriteLine(min);
			Console.WriteLine(ss);
			// TODO: Implement Functionality Here
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}