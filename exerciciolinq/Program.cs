using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using exerciciolinq.Entities;
using System.Linq;

namespace exerciciolinq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter full file path: ");
                string path = Console.ReadLine();
                Console.Write("Enter salary: ");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                List<Employee> list = new List<Employee>();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] campos = sr.ReadLine().Split(',');
                        string name = campos[0];
                        string email = campos[1];
                        double salary = double.Parse(campos[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salary));
                    }
                    Console.WriteLine();
                    var r1 = list.Where(x => x.Salary > valor).OrderBy(x => x.Email).Select(x => x.Email);

                    Console.WriteLine("Email of people whose salary is more than $ " + valor.ToString("F2"),CultureInfo.InvariantCulture);
                    foreach (string obj in r1)
                    {
                        Console.WriteLine(obj);
                    }

                    var r2 = list.Where(x => x.Name.StartsWith('M')).Sum(x => x.Salary);
                    Console.WriteLine("Sum of salary of people whose name starts with 'M': " + r2.ToString("F2", CultureInfo.InvariantCulture));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception r)
            {
                Console.WriteLine(r.Message);
            }
            }
        }
    }

