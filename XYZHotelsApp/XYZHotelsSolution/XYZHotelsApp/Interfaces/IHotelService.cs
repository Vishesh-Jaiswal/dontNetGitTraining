using XYZHotelsApp.Models;
namespace XYZHotelsApp.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetHotels();

        Hotel AddHotel(Hotel hotel);

        Hotel RemoveHotel(Hotel hotel);

    }
}
