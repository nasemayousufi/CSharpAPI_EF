using System.Xml.Linq;

namespace FinalProject1.Models.Repository
{
    public class DressRepository
    {
        private static List<Dress> dresses = new List<Dress>()
        {
          new Dress{ Id = 1, Brand ="Macys", Color = "Green", Gender="Women", Price = 300, Size = 10},
          new Dress{ Id = 2, Brand ="Macys", Color = "Blue",Gender="Women", Price = 300, Size = 6},
          new Dress{ Id = 3, Brand ="Macys", Color = "Red", Gender="Women", Price = 300, Size = 6}
        };
        public static List<Dress> Getdresses()
        {
            return dresses;
        }
        public static bool DressExists(int id)
        {
            return dresses.Any(x => x.Id == id);
        }
        public static Dress? GetDressById(int id)
        {
            return dresses.FirstOrDefault(x => x.Id == id);
        }

        public static Dress? GetDressByProperties(string? brand, string? gender, string? color, int? size)
        {
            return dresses.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value);

        }
        public static void AddDress(Dress dress)
        {
            int maxId = dresses.Max(x => x.Id);
            dress.Id = maxId + 1;

            dresses.Add(dress);
        }
        public static void UpdateDress(Dress dress)
        {
            var dressToUpdate = dresses.First(x => x.Id == dress.Id);
            dressToUpdate.Brand = dress.Brand;
            dressToUpdate.Price = dress.Price;
            dressToUpdate.Size = dress.Size;
           dressToUpdate.Color = dress.Color;
            dressToUpdate.Gender =  dress.Gender;
        }
        public static void DeleteDress(int Id)
        {   
            var dress = GetDressById(Id);
            if (dress != null)
            {
                dresses.Remove(dress);
            }
        }

    }
}