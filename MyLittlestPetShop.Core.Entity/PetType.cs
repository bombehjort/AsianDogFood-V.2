namespace AsianDogFood.Core.Entity
{
    public class PetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public enum PetType
        {
            GoldenRetriever,
            Dobberman,
            Raccoon,
            Phinx,
            Shiba,
            Apple,
            Mosquito,
            Dog,
            Cat
        }
    }
}