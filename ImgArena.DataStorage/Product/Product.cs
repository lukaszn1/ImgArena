namespace ImgArena.DataStorage.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }//todo should be enum type
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
