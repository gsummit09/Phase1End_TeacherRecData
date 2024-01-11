using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace End_Phase1_Project
{
    public class Program
    {
        public static string filePath = "D:\\Assisted Practice Project\\End_Phase1_Project\\TeacherData.txt";
        public static void writeData()
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Teachers Records");
            sw.WriteLine("ID \t Name \t Class \t Section");

            sw.Close();
            fs.Close();
        }
        // Append data
        public static void AppendData()
        {
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                Console.Write("Please add teacher's ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teacher's Name:");
                string name = Console.ReadLine();
                Console.Write("Please add teacher's Class Number:");
                int classNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teacher's Section:");
                string section =Console.ReadLine();

                Teacher t1 = new Teacher(id, name, classNum, section);
                sw.WriteLine("{0}\t{1}\t{2}\t{3}", t1.id, t1.name, t1.ClassNum, t1.section);
            } catch (IOException ex) { Console.WriteLine(ex.Message); }
            catch(Exception ex1) { Console.WriteLine(ex1.Message); }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        // Read data
        public static void ReadData()
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while(str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close ();
        }
        public static void UpdateData(int id)
        {
            FileStream fs3 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr3 = new StreamReader(fs3);
            try
            {
                Console.Write("Please add teacher's Name:");
                string name = Console.ReadLine();
                Console.Write("Please add teacher's Class Number:");
                int ClassNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teachers's Section:");
                string section = Console.ReadLine();

                Teacher t1 =new Teacher(id, name,ClassNum, section);
                string updateData = $"{t1.id} \t {t1.name} \t {t1.ClassNum} \t {t1.section}";
                string[] lines;
                using(fs3)
                {
                    using (sr3)
                    {
                        lines = File.ReadAllLines(filePath);
                        for(int i=2; i<lines.Length; i++)
                        {
                            string[] split = lines[i].Split(',');
                            foreach(var item in split)
                            {
                                if (Char.GetNumericValue(item[0])==id)
                                {
                                    lines[i] = updateData;
                                }
                            }
                        }
                        foreach(var item in lines)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                using(FileStream fs = new FileStream(filePath,FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using(StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach(var item in lines)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("** Teacher Records System **\n\n" +
               "(1) to enter new data \n" +
               "(2) to update existing data \n" +
               "(3) to display teacher records \n" +
               "(4) to exit \n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        writeData();
                        AppendData();
                        break;
                    case 2:
                        ReadData();
                        Console.Write("Please enter teacher's ID to update:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        UpdateData(id);
                        break;
                    case 3:
                        ReadData();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
                if (choice == 4) { break; }

            }
        }
    }
}
