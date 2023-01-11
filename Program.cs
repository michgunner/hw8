//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

int[,] CreateRandom2dArray()
{
   Console.WriteLine("Please, enter number of rows: ");
   int rows = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("Please, enter number of columns: ");
   int columns = Convert.ToInt32(Console.ReadLine());

   Console.WriteLine("Please, enter min value of an array: ");
   int minValue = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("Please, enter max value of an array: ");
   int maxValue = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine();

   int[,] array = new int[rows, columns];

   for (int i = 0; i < rows; i++)
      for (int j = 0; j < columns; j++)
         array[i, j] = new Random().Next(minValue, maxValue + 1);

   return array;
}



void Show2dArray(int[,] array) 
{
   for (int i = 0; i < array.GetLength(0); i++)
   {
      for (int j = 0; j < array.GetLength(1); j++)
         Console.Write(array[i, j] + " ");
      Console.WriteLine();
   }
   Console.WriteLine();
}

void SortArray(int[,] array)
{
   for(int i = 0; i < array.GetLength(0); i++)
      for(int j = 1; j < array.GetLength(1); j++)
         {
            if(array[i,j] > array[i,j-1])
            {
               int temp = array[i,j];
               array[i,j] = array[i,j-1];
               array[i,j-1] = temp;

               int tempIndex  = j-1;
               while(tempIndex>0)
               {
                  if(array[i, tempIndex] > array[i, tempIndex-1])
                  {
                     temp = array[i,tempIndex];
                     array[i,tempIndex] = array[i,tempIndex-1];
                     array[i,tempIndex-1] = temp;
                     tempIndex--;
                  }else tempIndex = 0;
               }
            }
         }
}
int[,] myArray = CreateRandom2dArray();

Show2dArray(myArray);
SortArray(myArray);
Show2dArray(myArray);

 






//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int MinSum(int[,] array)
{
   int minRow = 1;
   int minSum = 0;
   for (int i = 0; i < array.GetLength(0); i++)
   {
      int sum = -1;
      for (int j = 0; j < array.GetLength(1); j++)
         sum += array[i, j];
      if (i == 0) minSum = sum;
      else
      {
         if (sum < minSum)
         {
            minSum = sum;
            minRow = i + 1;
         }
      }
   }
   return minRow;
}

int row = MinSum(myArray);
Console.WriteLine("Row with min sum is - " + row);




//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.


int[,] MatrixMultiplication(int[,] firMatrix, int[,] secMatrix)
{
   int[,] resultMatrix = new int[2,2];
   for(int i = 0; i < 2; i++)
      for(int j = 0; j < 2; j++)
      {
         resultMatrix[i,j] = firMatrix[i,0]*secMatrix[0,j] + firMatrix[i,1]*secMatrix[1,j];
      }
   return resultMatrix;
}

int[,] secMatrix = CreateRandom2dArray();
int[,] resultMatrix = new int[2,2];
if(secMatrix.GetLength(0) == 2 && secMatrix.GetLength(1)==2)
{
   if(myArray.GetLength(0) == 2 && myArray.GetLength(1)==2)
   {
      Console.WriteLine("The first matrix: ");
      Show2dArray(myArray);
      Console.WriteLine("The secound matrix: ");
      Show2dArray(secMatrix);
      resultMatrix=MatrixMultiplication(myArray,secMatrix);
      Console.WriteLine("The result of multiplication: ");
      Show2dArray(resultMatrix);
   }else Console.WriteLine("Please enter 2x2 matrix");
}else Console.WriteLine("Please enter 2x2 matrix");






//Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

bool IsRecurring(int random, int[] array, int index)
{
   int indexOfRandom;
   bool result;


   indexOfRandom = Array.IndexOf(array, random);
   if (indexOfRandom == -1)
      result = true;
   else result = false;

   return result;
}


int[,,] Create3DArray(int rows, int columns, int depth)
{

   int[,,] array3D = new int[rows, columns, depth];
   int[] checkNum = new int[array3D.Length];
   int random = 0;
   bool isNew = false;
   int index = 0;

   for (int i = 0; i < rows; i++)
      for (int j = 0; j < columns; j++)
         for (int k = 0; k < depth; k++)
         {
            while (!isNew)
            {
               random = new Random().Next(10, 100);
               isNew = IsRecurring(random, checkNum, index);
            }
            array3D[i, j, k] = random;
            checkNum[index] = random;
            index++;
            isNew = false;
         }

   return array3D;
}

void Show3DArray(int[,,] array)
{
   for (int i = 0; i < array.GetLength(0); i++)
   {
      for (int j = 0; j < array.GetLength(1); j++)
      {
         for (int k = 0; k < array.GetLength(2); k++)
            Console.Write(array[i, j, k] + $"({i}, {j}, {k}) ");
         Console.WriteLine();
      }
      Console.WriteLine();
   }
}

Console.WriteLine("Please, enter number of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Please, enter number of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Please, enter size of depth: ");
int depth = Convert.ToInt32(Console.ReadLine());

if (rows * columns * depth >= 90)
{
   Console.WriteLine("This is too much");
}
else
{
   int[,,] my3DArray = Create3DArray(rows, columns, depth);
   Show3DArray(my3DArray);
}






//Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

int[,] CreateSpiralArray()
{
   Console.WriteLine("Please, enter number of rows: ");
   int rows = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("Please, enter number of columns: ");
   int columns = Convert.ToInt32(Console.ReadLine());

   int[,] array = new int[rows, columns];
   int number = 10;
   int rowIndex = 0;
   int columnIndex = 0;
   int leftBorder = 0;
   int upperBorder = 1;
   int cycleCount = 0;

   if (rows > columns)              //возникают проблемы, если массив не квадратичный и меньшая
   {                                //сторона - нечеьное число. Там, если цикл увелчить, то цтфры заменяются, а,
      cycleCount = columns / 2;     //если меньше, то появляются 0
      if (rows % 2 == 1)
         cycleCount++;
   }
   else
   {
      cycleCount = rows / 2;
      if (rows % 2 == 1)
         cycleCount++;
   }


   for (int i = 0; i < cycleCount; i++)
   {
      while (columnIndex < columns - 1)
      {
         number++;
         array[rowIndex, columnIndex] = number;
         columnIndex++;
      }
      columns--;

      while (rowIndex < rows - 1)
      {
         number++;
         array[rowIndex, columnIndex] = number;
         rowIndex++;
      }
      rows--;

      while (columnIndex > leftBorder)
      {
         number++;
         array[rowIndex, columnIndex] = number;
         columnIndex--;
      }
      leftBorder++;

      while (rowIndex > upperBorder)
      {
         number++;
         array[rowIndex, columnIndex] = number;
         rowIndex--;
      }
      upperBorder++;
   }

   array[rowIndex, columnIndex] = number + 1;
   return array;
}

int[,] array = CreateSpiralArray();
Show2dArray(array);