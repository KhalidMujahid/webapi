namespace WebApi.Services
{
    public class ItemsService
    {
        private readonly int[] items = { 1, 2, 3, 4, 5 };
        public int[] GetItems()
        {
            return items;
        }

        public int GetItem(int id)
        {
            return items[id];
        }
    }
}