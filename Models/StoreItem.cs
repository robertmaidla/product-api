namespace ProductApi.Models
{
    public class StoreItem
    {
        public long Id { get; set; }
        public string name { get; set; }

        public StoreItem(string inpName) {
            this.name = inpName;
        }

        public StoreItem() { }
    }
}