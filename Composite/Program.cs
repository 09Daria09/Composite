using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public interface Iitem
    {
        decimal GetCost();
        void Print();
    }

    public class Leaf : Iitem
    {
        private string _name;
        private decimal _cost;

        public Leaf(string name, decimal cost)
        {
            _name = name;
            _cost = cost;
        }

        public decimal GetCost()
        {
            return _cost;
        }

        public void Print()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine($"  ◉ {_name}");
        }
    }

    public class Composite : Iitem
    {
        private string _name;
        private decimal _cost;
        private readonly List<Iitem> _Leafs = new List<Iitem>();

        public Composite(string name)
        {
            _name = name;
        }

        public void Add(Iitem Leaf)
        {
            _Leafs.Add(Leaf);
        }

        public decimal GetCost()
        {
            decimal totalCost = 0;

            foreach (var Leaf in _Leafs)
            {
                totalCost += Leaf.GetCost();
            }

            return totalCost;
        }

        public void Print()
        {
            Console.WriteLine($"{_name}");

            foreach (var Leaf in _Leafs)
            {
                Leaf.Print();
            }
        }
    }

    public class Client
    {
        public static Composite BuildOffice()
        {
            var root = new Composite("Офис");

            var reception = new Composite("Приемная");
            reception.Add(new Leaf("Должна быть выполнена в теплых тонах", 500));
            var table = new Composite("Журнальный столик");
            table.Add(new Leaf("10-20 журналов типа «компьютерный мир»", 100));
            reception.Add(table);
            reception.Add(new Leaf("Мягкий диван", 3000));
            reception.Add(new Leaf("Стол секретаря", 2000));
            var computer = new Composite("Компьютер");
            computer.Add(new Leaf("Важно наличие большого объема жесткого диска", 40000));
            computer.Add(new Leaf("Офисный инструментарий", 2000));
            reception.Add(computer);
            reception.Add(new Leaf("Кулер с теплой и холодной водой", 5000));
            root.Add(reception);

            var reception1 = new Composite("Аудиторий 1");
            reception1.Add(new Leaf("10 столов", 5000));
            reception1.Add(new Leaf("Доска", 3000));
            reception1.Add(new Leaf("Стол учителя", 2000));
            var computer1 = new Composite("Компьютер");
            reception1.Add(computer1);
            reception1.Add(new Leaf("Плакаты великих математиков", 1000));
            root.Add(reception1);

            return root;
        }
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            var office = Client.BuildOffice();
            office.Print();
            Console.WriteLine($"Общая стоимость: {office.GetCost()} грн.");
        }
    }
}
