using System;
using System.IO;

namespace TransposeData
{
    class Program
    {
        static readonly string filepath = System.IO.Directory.GetCurrentDirectory().Split("bin")[0]+"Files";
        static int row = 0;
        static int column = 0;
        static string[,] array2D;

        public static void TransposeCSV(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filepath + "\\" +filename +".csv");  //read data
                row = lines.Length;
                column = lines[0].Split(";").Length;
                array2D = new string[column, row];  //transposed array
                for (int i = 0; i < row; i++)
                {
                    string[] it = lines[i].Split(";");
                    for (int j = 0; j < column; j++)
                    {
                        array2D[j, i] = it[j];  //storing data in transposed array
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            WriteData(filename);        //write transposed data into new file
        }
        public static void WriteData(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath + "\\" + filename + "_transposed.csv"))
                {
                    for (int i = 0; i < column; i++)
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
            string file1 = "ProgrammingTaskInput";      //Assignment data
            string file2 = "ProgrammingTaskInput 2";    //Data with only 1 row and multiple columns
            string file3 = "ProgrammingTaskInput 3";    //Missing Data
            TransposeCSV(file1);
        }
    }
}
