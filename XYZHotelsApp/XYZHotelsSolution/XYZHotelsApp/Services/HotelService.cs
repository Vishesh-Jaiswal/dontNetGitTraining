using XYZHotelsApp.Exceptions;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;

namespace XYZHotelsApp.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int,Hotel> _hotelRepository;

        public HotelService(IRepository<int, Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Hotel AddHotel(Hotel hotel)
        {
            var result =_hotelRepository.Add(hotel);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public List<Hotel> GetHotels()
        {
            var hotels = _hotelRepository.GetAll();
            if (hotels != null)
            {
                return hotels.ToList();
            }
            throw new NoHotelsAvailableException();
        }

        public Hotel RemoveHotel(Hotel hotel)
        {
            int hotelId = 0;
            var checkHotel = _hotelRepository.GetAll().FirstOrDefault(rh=>rh.HotelId==hotel.HotelId);
            if (checkHotel != null)
            {
                hotelId=checkHotel.HotelId;
                var result = _hotelRepository.Delete(hotelId);
                return result;
            }
            return null;
        }
    }
}
