using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestUgSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing UgSort");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            EliErkin.UgSort ugsort = new EliErkin.UgSort();
            string[] words = new string[] {"ئالما",
                                            "ئانار",
                                            "ئۆرۈك",
                                            "توغاچ",
                                            "شاپتۇل",
                                            "قاق",
                                            "نەشپۈت",
                                            "قوغۇن",
                                            "تاۋۇز",
                                            "گۈلە",
                                            "گىلاس",
                                            "بانان",
                                            "ئاناناس",
                                            "ماڭگو",
                                            "لەيلى",
                                            "سەبدە",
                                            "ئەتىرگۈل",
                                            "مامكاپ",
                                            "بۇغداي",
                                            "قوناق",
                                            "گۈرۈچ",
                                            "شال",
                                            "بەسەي",
                                            "چامغۇر",
                                            "شوخلا",
                                            "سۈرەت",
                                            "قارىغاي",
                                            "سۈگەت",
                                            "جىگدە",
                                            "توغراق",
                                            "يانتاق",
                                            "سۈرئەت",
                                            "تەلەت",
                                            "بۇغا",
                                            "مارال",
                                            "كېيىك",
                                            "تەلئەت" };
            Console.WriteLine("Array Lenth:"+ words.Length);

            Console.WriteLine("Original array:");
            printArray(words);
            writeToFile(words, "1.OriginalData");

            //## sort string array
            Array.Sort(words, ugsort);
            Console.WriteLine("Sorted array:");
            printArray(words);
            writeToFile(words,"2.SortedArrayData");


            //## sort list
            List<string> lst = new List<string>();
            lst.AddRange(words);
            lst.Sort(ugsort);
            Console.WriteLine("Sorted List:");
            printArray(lst.ToArray());
            writeToFile(words, "3.SortedListData");

            //Direct sort
            string[] sortedWords=ugsort.Sort(words);
            Console.WriteLine("Direct Sorted array:");
            printArray(sortedWords);
            writeToFile(words, "4.DirectSortedData");


            Console.WriteLine("Sorted.");
            Console.WriteLine("Press any key to exit...");


            

        }

        private static void  writeToFile(string[] words,string filename)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in words)
            {
                sb.AppendLine(item);
            }

            string path = Environment.CurrentDirectory + "\\" + filename + ".txt";
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            Console.WriteLine("Sorted data saved on path: " + path);
        }

        private static void printArray(string[] words)
        {
            int count = 1;
            foreach (string word in words)
            {
                Console.WriteLine("\t"+count+"."+word);
                count++;
            }
        }
    }
}
