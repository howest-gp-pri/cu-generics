namespace Pri.Generics.Core.Entities
{
    public class Order<T>
    {
        public T Item { get; }
        public int Quantity { get; }

        public Order(T item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
