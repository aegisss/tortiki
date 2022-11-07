namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Menu> Menu = new List<Menu>
            {
                new Menu
                {
                    Name = "  Форма",
                    Item_list = new List<Menu>{
                        new Menu
                        {
                            Description = "  Круг",
                            Price = 500
                        },
                        new Menu
                        {
                            Description = "  Квадрат",
                            Price = 450
                        },
                        new Menu
                        {
                            Description = "  Треугольник",
                            Price = 300
                        }
                    }
                },
                new Menu
                {
                    Name = "  Размер",
                    Item_list = new List<Menu>{
                        new Menu
                        {
                            Description = "  Маленький ",
                            Price = 1000
                        },
                        new Menu
                        {
                            Description = "  Большой ",
                            Price = 1250
                        },
                        new Menu
                        {
                            Description = "  Маленький ",
                            Price = 2500
                        }
                    }
                },
                new Menu
                {
                    Name = "  Вкус",
                    Item_list = new List<Menu>{
                        new Menu
                        {
                            Description = "  Ваниль",
                            Price = 100
                        },
                        new Menu
                        {
                            Description = "  Шоколад (bullshit)",
                            Price = 100
                        },
                        new Menu
                        {
                            Description = "  Карамель",
                            Price = 150
                        },
                        new Menu
                        {
                            Description = "  Ягоды",
                            Price = 200
                        },
                        new Menu
                        {
                            Description = "  Кокос (мой любимый)",
                            Price = 250
                        }
                    }
                },
                new Menu
                {
                    Name = "  Колличество коржей (не Максов!!!!)",
                    Item_list = new List<Menu>{
                        new Menu
                        {
                            Description = "  1 корж",
                            Price = 140
                        },
                        new Menu
                        {
                            Description = "  2 коржа",
                            Price = 280
                        },
                        new Menu
                        {
                            Description = "  3 коржа",
                            Price = 400
                        },

                    }
                },
                new Menu
                {
                    Name = "  Добавки",
                    Item_list = new List<Menu>{
                        new Menu
                        {
                            Description = "  Шоколад",
                            Price = 100
                        },
                        new Menu
                        {
                            Description = "  Крем",
                            Price = 100
                        },
                        new Menu
                        {
                            Description = "  Ягоды (Много не бывает)",
                            Price = 200
                        }
                    }
                },
            };
            Menu menu = new Menu();
            menu.Drew_Menu(Menu);
        }
    }
}