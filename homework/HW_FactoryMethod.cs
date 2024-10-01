using System;

namespace TaxiOrderFactory
{
    // Абстрактный класс заказа
    public abstract class Order
    {
        public abstract string GetOrderType();

        public override string ToString()
        {
            return GetOrderType();
        }
    }

    // Конкретный класс стандартного заказа
    public class StandardOrder : Order
    {
        public override string GetOrderType()
        {
            return "Standard Order";
        }
    }

    // Конкретный класс премиум заказа
    public class PremiumOrder : Order
    {
        public override string GetOrderType()
        {
            return "Premium Order";
        }
    }

    // Фабрика для создания заказов
    public static class OrderFactory
    {
        public static Order CreateOrder(string orderType)
        {
            switch (orderType.ToLower())
            {
                case "standard":
                    return new StandardOrder();
                case "premium":
                    return new PremiumOrder();
                default:
                    throw new ArgumentException("Unknown order type");
            }
        }
    }

    // Пример использования
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = OrderFactory.CreateOrder("standard");
            Order order2 = OrderFactory.CreateOrder("premium");

            Console.WriteLine(order1.GetOrderType());  // Вывод: Standard Order
            Console.WriteLine(order2.GetOrderType());  // Вывод: Premium Order

            Console.Read();
        }
    }
}
