using System;

namespace energy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Console.ReadKey();
            Console.Title = "Массив данных потребленной энергии";
            // создаю двумерный массив
            int tarif_1 = 15;
            int tarif_2 = tarif_1/3*4;
            int tarif_3 = tarif_1/3*2;
            int tarif_4 = tarif_1/15;
            int[,] mas = new int[4, 5] 
                {
                // вношу данные по 4м типам потребителей
                    {63, 126, 271, 94, 13 },
                    {242, 276, 303, 88, 223},
                    {115, 94, 222, 78, 47},
                    {325, 250, 116, 187, 400}
                };
            Console.WriteLine("Исходные данные:");
            Console.WriteLine();
            Console.WriteLine($"Тарифная ставка расчета для обычных клиентов =  {tarif_1}");
            Console.WriteLine($"Тарифная ставка расчета с лимитом до 250 =  {tarif_1}, сверх 250 = {tarif_2}");
            Console.WriteLine($"Тарифная ставка расчета - льготная =  {tarif_3}");
            Console.WriteLine($"Тарифная ставка расчета для нужд отопления =  {tarif_4}");
            //            Console.WriteLine("Тарифная ставка расчета =  {0}", tarif);
            Console.WriteLine();
            Console.WriteLine("Значения по 4м типам потребителей:");
            for (int i=0; i< 4; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(mas[i, j] + "\t ");
                }
            }
            Console.ReadKey();
            // Создаю одномерный массив, в который запишу все данные с двумерного массива
            int [] odnom_mas = new int[20];
            int k = 0;
            int kol_energii = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    odnom_mas[k] = mas[i, j];
                    k++;
                    //подсчитываю сумму затраченной энергии
                    kol_energii += mas[i, j];
                }
            }
            //Вывод в консоль собранного одномерного массива
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Одномерный массив по типу клиентов:");
            Console.WriteLine();
            for (k=0; k<20; k++)
            {
               Console.Write(odnom_mas[k] + " ");
            }
            Console.ReadKey();
            // Сортировка собранного одномерного массива
            Array.Sort(odnom_mas);
            // Обратная сортировка массива
            Array.Reverse(odnom_mas);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Массив по количеству потреблённой клиентами энергии по убыванию:");
            Console.WriteLine();
            for (k = 0; k < 20; k++)
            {
                Console.Write(odnom_mas[k] + " ");
            }
            Console.ReadKey();
            //Создаю двумерный массив для цен
            int[,] mas_cen = new int[4,5];
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    switch (i)
                    {
                        case 0:
                            mas_cen[i, j] = mas[i, j] * tarif_1;
                            break;
                        case 1:
                            if (mas[i, j] > 250)
                            {
                                mas_cen[i, j] = (mas[i, j] - 250) * tarif_2 + 250 * tarif_1;
                            }
                            else
                            {
                                mas_cen[i, j] = mas[i, j] * tarif_1;
                            }
                            break;
                        case 2:
                            mas_cen[i, j] = mas[i, j] * tarif_3;
                            break;
                        case 3:
                            mas_cen[i, j] = mas[i, j] * tarif_4;
                            break;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Значения по 4м типам потребителей в деньгах:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(mas_cen[i, j] + "\t ");
                }
            }
            Console.ReadKey();
            int[] odnom_mas_cen = new int[20];
            k = 0;
            int sum_cen = 0;
            for ( int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    odnom_mas_cen[k] = mas_cen[i, j];
                    k++;
                    sum_cen += mas_cen[i, j];
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Массив по величине оплаты клиентами по возрастанию:");
            Console.WriteLine();
            Array.Sort(odnom_mas_cen);
            for (k = 0; k < 20; k++)
            {
                Console.Write(odnom_mas_cen[k] + " ");
            }
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Общая сумма оплаты всех клиентов за потреблённую энергию = {sum_cen}");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Общая сумма оплаты всех клиентов без льгот и лимитов = {kol_energii*tarif_1}");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Общий размер льготы LG=SUM0–SUM = {kol_energii * tarif_1- sum_cen}");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

