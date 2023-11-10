using System;

class BinaryMultiplicationProgram
{
    static string SubtractBinary(string binaryNum1, string binaryNum2)
    {
        // Вычисляем максимальную длину из двух чисел
        int maxLength = Math.Max(binaryNum1.Length, binaryNum2.Length);

        // Дополним числа нулями слева до одинаковой длины
        binaryNum1 = binaryNum1.PadLeft(maxLength, '0');
        binaryNum2 = binaryNum2.PadLeft(maxLength, '0');

        char carry = '0';
        string result = "";

        // Начинаем вычитать с конца чисел
        for (int i = maxLength - 1; i >= 0; i--)
        {
            char bit1 = binaryNum1[i];
            char bit2 = binaryNum2[i];

            // Выполняем вычитание битов и учитываем перенос
            char bit1Char = (char)(bit1 - '0');
            char bit2Char = (char)(bit2 - '0');
            char carryChar = (char)(carry - '0');

            int temp = bit1Char - bit2Char - carryChar;
            if (temp < 0)
            {
                carry = '1';
                temp += 2;
            }
            else
            {
                carry = '0';
            }

            result = temp + result;
        }

        return result.TrimStart('0');
    }


    static string MultiplyBinary(string binaryNum1, string binaryNum2)
    {
        // Инициализация результата нулем
        string result = "0";

        // Итерация по битам второго числа (binaryNum2) справа налево
        for (int i = binaryNum2.Length - 1; i >= 0; i--)
        {
            // Если текущий бит второго числа равен '1'
            if (binaryNum2[i] == '1')
            {
                // Вычисление временного результата, добавляя нули справа в зависимости от текущего разряда
                string temp = binaryNum1.PadRight(binaryNum1.Length + binaryNum2.Length - 1 - i, '0');

                // Сложение временного результата с текущим общим результатом
                result = AddBinary(result, temp);
            }
        }

        // Удаление ведущих нулей из результата
        return result.TrimStart('0');
    }


// Функция для сложения двух бинарных чисел в виде строк
static string AddBinary(string binaryNum1, string binaryNum2)
    {
        // Вычисляем максимальную длину из двух чисел
        int maxLength = Math.Max(binaryNum1.Length, binaryNum2.Length);

        // Дополним числа нулями слева до одинаковой длины
        binaryNum1 = binaryNum1.PadLeft(maxLength, '0');
        binaryNum2 = binaryNum2.PadLeft(maxLength, '0');

        // Инициализация переменных для хранения текущего бита переноса и результата сложения
        char carry = '0';
        string result = "";

        // Начинаем складывать с конца чисел
        for (int i = maxLength - 1; i >= 0; i--)
        {
            // Получаем текущие биты из обоих чисел
            char bit1 = binaryNum1[i];
            char bit2 = binaryNum2[i];

            // Преобразуем биты в числа и также преобразуем бит переноса
            char bit1Char = (char)(bit1 - '0');
            char bit2Char = (char)(bit2 - '0');
            char carryChar = (char)(carry - '0');

            // Вычисляем сумму текущих битов и бита переноса
            char sumChar = (char)((bit1Char + bit2Char + carryChar) % 2 + '0');

            // Обновляем бит переноса для следующего разряда
            carry = (char)((bit1Char + bit2Char + carryChar) / 2 + '0');

            // Добавляем текущий бит суммы к результату
            result = sumChar + result;
        }

        // Если есть оставшийся перенос, добавим его к результату
        if (carry == '1')
            result = carry + result;

        // Возвращаем итоговый результат сложения бинарных чисел
        return result;
    }

    static void Main()
    {
        Console.Write("Введите первое число в десятичной системе: ");
        int decimalNum1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите второе число в десятичной системе: ");
        int decimalNum2 = Convert.ToInt32(Console.ReadLine());

        // Преобразуем числа в двоичную систему
        string binaryNum1 = Convert.ToString(decimalNum1, 2);
        string binaryNum2 = Convert.ToString(decimalNum2, 2);

        // Выполняем умножение
        string prodResult = MultiplyBinary(binaryNum1, binaryNum2);
        // Выполняем сложение
        string prodResult2 = AddBinary(binaryNum1, binaryNum2);
        // Выполняем вычитание
        string prodResult3 = SubtractBinary(binaryNum1, binaryNum2);
        // Преобразуем результат в десятичную систему счисления
        int decimalResult = Convert.ToInt32(prodResult, 2);
        int decimalResult2 = Convert.ToInt32(prodResult2, 2);
        int decimalResult3 = Convert.ToInt32(prodResult3, 2);
        Console.WriteLine($"Результат умножения: {decimalResult}");
        Console.WriteLine($"Результат сложения: {decimalResult2}");
        Console.WriteLine($"Результат вычитания: {decimalResult3}");

        Console.WriteLine("Введите первое true или false, для логических операций");
        bool b1 = Convert.ToBoolean(Console.ReadLine());
        Console.WriteLine("Введите второе true или false с которым будет выполняться логические операции");
        bool b2 = Convert.ToBoolean(Console.ReadLine());
        Console.WriteLine($"Логическое И: {b1 & b2}");
        Console.WriteLine($"Логическое ИЛИ: {b1 | b2}");
        Console.WriteLine($"Логическое НЕ: НЕ {b1} = {!b1}; НЕ {b2} = {!b2}  ");

    }
}
