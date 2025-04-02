using System;
using System.IO;

namespace Filehandling
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @"D:\Internship Training\datas\inputsample.csv";
            string outputFile = @"D:\Internship Training\datas\gradedata.txt";

            try
            {
                FileStream fs = new FileStream(inputFile, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                Console.WriteLine("Data from input file:");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);

                    FileStream fsWrite = new FileStream(outputFile, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fsWrite);
                    sw.WriteLine(line);
                    sw.Close();
                    fsWrite.Close();
                }


                sr.Close();
                fs.Close();

                Console.WriteLine("File reading and writing completed.");
            }
            catch (FileNotFoundException filenotfound)
            {
                Console.WriteLine("File not found: " + filenotfound.Message);
            }
            catch (UnauthorizedAccessException unauthaccess)
            {
                Console.WriteLine("Access denied: " + unauthaccess.Message);
            }
            catch (IOException ioex)
            {
                Console.WriteLine("I/O error: " + ioex.Message);
            }
        }
    }
}
