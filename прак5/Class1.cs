using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu
    {
        private bool Change_item = true;
        private bool Start = true;
        private int Up = 1;
        private int Left = 0;
        private string Arrow = "->";
        private int AllPrice;
        private int SupportElement;
        private List<Menu> Order = new List<Menu>
        {

        };

        public string Name;
        public string Description;
        public int Price;
        public List<Menu> Item_list = new List<Menu>
        {
        };

        private void Drew_Arrow(List<Menu> list) // функция отображения стрелок
        {
            Console.SetCursorPosition(Left, Up); ;
            Console.WriteLine(Arrow);
            ConsoleKeyInfo key = Console.ReadKey();
            if (Change_item == true)
            {
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Start = false;
                }
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace)
                {
                    Start = false;
                    Change_item = true;
                    Console.Clear();
                    Arrow = "->";
                    Left = 0;
                    Up = 1;
                }
            }

            if (key.Key == ConsoleKey.Enter)
            {
                if (Change_item == true && Up != list.Count() + 2)
                {
                    Console.Clear();
                    Change_item = false;
                    Drew_Element_List(list);
                }
                else if (Change_item == false && Up == list.Count() + 1)
                {
                    CreateNewItemMenu(list);
                    Console.Clear();

                }
                else if (Change_item == false)
                {
                    AllPrice += list[Up - 1].Price;
                    Start = false;
                    Change_item = true;
                    Order.Add(list[Up - 1]);
                }
                else
                {
                    CreateFielOrder();
                }
            }

            if (key.Key == ConsoleKey.UpArrow)
            {
                Up--;
                Arrow = "->";
                Left = 0;
                if (Up < 1)
                {
                    if (Change_item == true)
                    {
                        Up = list.Count() + 2;
                        Arrow = "<-";
                        Left = 15;
                    }
                    else
                    {
                        Up = list.Count()+1;
                        Arrow = "<-";
                        Left = 20;
                    }
                }
                else if (Up == list.Count + 1)
                {
                    Up = list.Count;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                Up++;
                Arrow = "->";
                Left = 0;
                if (Up > list.Count)
                {
                    if (Change_item == true)
                    {
                        if (Up > list.Count() + 2)
                        {
                            Up = 1;
                        }
                        else
                        {
                            Up = list.Count() + 2;
                            Arrow = "<-";
                            Left = 15;
                        }
                    }
                    else
                    {
                        if (Up == list.Count() + 1)
                        {
                            Arrow = "<-";
                            Left = 20;
                        } else if (Up > list.Count() + 1)
                        {
                            Up = 1;
                        }
                    }
                }
            }
        }

        public void Drew_Menu(List<Menu> list) // функция отображения пунктов в меню
        {
            Console.CursorVisible = false;
            while (Start)
            {
                Console.Clear();
                Console.WriteLine("Заказ тортов : ");
                foreach (var element_list in list)
                {
                    Console.WriteLine(element_list.Name);
                }
                Console.WriteLine("Стоимоть заказа - " + AllPrice + " Р");
                Console.WriteLine("Сделать заказ ");
                Console.Write("Ваш заказ : ");
                foreach (var element in Order)
                {
                    Console.Write(element.Description);
                }
                Console.WriteLine();
                Drew_Arrow(list);
            }
        }

        private void Drew_Element_List(List<Menu> list) // функция отображения подпунктов меню
        {
            var element_list = list[Up - 1];
            Up = 1;
            while (Start)
            {
                Console.Clear();
                Console.WriteLine("Меню:" + element_list.Name);
                foreach (var element_list_list in element_list.Item_list)
                {
                    Console.WriteLine(element_list_list.Description + " - " + element_list_list.Price);
                }
                Console.WriteLine("Добавить пункт меню ");
                Drew_Arrow(element_list.Item_list);
            }
            Start = true;
        }

        private void CreateFielOrder() // функция создания файла с итогом
        {
            string file = "D:\\MyOrder.txt";
            if (File.Exists(file))
            {
                File.AppendAllText(file,"\n");
            }
            string txt = AllPrice.ToString();
            File.AppendAllText(file, DateTime.Now + "\n" + "Цена = " + txt + "\n" + "Состав торта: \n");
            if (Order.Count() == 0)
            {
                txt = "  Ваш заказ пустой";
                File.AppendAllText(file, txt + "\n");
            }
            else
            {
                foreach (var element in Order)
                {
                    txt = element.Description;
                    File.AppendAllText(file, txt + "\n");
                }
            }
            Order.Clear();
            Price = 0;
        }

        private void CreateNewItemMenu(List<Menu> list) // создание нового подпункта меню
        {
            var Menu = new Menu()
            {
                Description = "",
                Price = 0
            };
            Console.Clear();
            Console.Write("Введите название : ");
            Menu.Description = "  " + Console.ReadLine();
            Console.Write("Введите цену : ");
            Menu.Price = Convert.ToInt32(Console.ReadLine());
            list.Add(Menu);
            Up = 1;
            Left = 0;
            Arrow = "->";
        }
    }
}