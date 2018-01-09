using System.Threading.Tasks;

namespace FoodBook.Models
{
    public interface IDialer
    {
        Task<bool> DialAsync(string number);
    }
}
