namespace Library.TaskManagement.Models
{
    public class Item 
    {
        public string fileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        //public int Quantity { get; set; }
        //public int Weight { get; set; }
        public int Price { get; set; }
        public bool Bogo { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} :: {Description}";
        }

        //public Item(ItemViewModel ivm)
        //{

        //}
    }
}
