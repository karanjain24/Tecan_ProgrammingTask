using System;
using System.Collections;
using System.IO;

namespace TransposeData
{
    class Program
    {
        static readonly string filepath = "C:\\Users\\karan\\source\\repos\\PracticeCSV\\Files\\";
        static readonly string filename = "ProgrammingTaskInput";
        static int row = 0;
        static int col = 0;
        static int counter = 0;
        static ArrayList listValues = new ArrayList();
        static string[,] array2D;
        static ArrayList dictionary = new ArrayList();

        public static void TransposeCSV(string filename)
        {
            ReadData(filename); //read data frm file
            StoreData();        //store data into list
            WriteData();        //write transposed data into new file
        }

        public static void ReadData(string filename)
        {
            try
            {
                using (var reader = new StreamReader(filepath + filename + ".csv"))
                {
                    while (reader.EndOfStream == false)
                    {
                        var line = reader.ReadLine();
                        row += 1;
                        string[] items = line.Split(";");
                        foreach (var v in items)
                        {
                            counter += 1;
                            listValues.Add(v);
                        }
                        col = counter;
                        counter = 0;
                    }
                }
                //read listValues data
                Console.WriteLine("List:\n");
                foreach (var v in listValues)
                    Console.WriteLine(v);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void StoreData()
        {
            //Console.WriteLine("Row: "+col+"\nColumn: "+row);
            array2D = new string[col, row];
            for (int i = 0; i < col; i++)
            {
                string al = null;
                for (int j = 0; j < row; j++)
                {
                    for (int k = 0; k < listValues.Count; k++)
                    {
                        string t1 = ((string)listValues[k]).Substring(0, 1);
                        string temp = (string)listValues[k];

                        if (dictionary.Contains(temp))
                            continue;
                        else if (j == 0)
                        {
                            al = t1;
                            array2D[i, j] = temp;
                            dictionary.Add(temp);
                            break;
                        }
                        else if (j != 0 && al.Equals(t1))
                        {
                            array2D[i, j] = temp;
                            dictionary.Add(temp);
                            break;
                        }
                    }
                }
            }

            //reading stored  data
            Console.WriteLine("Stored Data: \n");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.WriteLine(array2D[i,j]);
                }
                Console.WriteLine();
            }
        }

        public static void WriteData()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath + filename + "_transposed.csv"))
                {
                    for (int i = 0; i < col; i++)
                    {
                        for (int j = 0; j < row; j++)
                        {
                            writer.Write(array2D[i, j]);
                            if (j < row - 1)
                                writer.Write(";");
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            TransposeCSV(filename);
        }
    }
}
