using System.Reflection.Metadata;
using XYZHotelsApp.Exceptions;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;

namespace XYZHotelsApp.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int,Room> _roomRepository;
        private readonly IRepository<int,Hotel> _hotelRepository;

        public RoomService(IRepository<int, Room> roomRepository, IRepository<int, Hotel> hotelRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
        }

        public Room AddRoom(Room room)
        {
            var checkHotel = _hotelRepository.GetAll().FirstOrDefault(h => h.HotelId == room.HotelId);
            var checkRoomNumber = _roomRepository.GetAll().FirstOrDefault(r => r.RoomNumber == room.RoomNumber);
            if (checkHotel != null)
            {
                if (checkRoomNumber == null)
                {
                    var result = _roomRepository.Add(room);
                    if (result != null)
                    {
                        result.AvailableAgainAt = DateTime.UtcNow;
                        result.Status = RoomStatus.Available;

                        return result;
                    }
                    else
                        throw new RoomCouldNotBeAdded();
                }
                else
                    throw new RoomNumberAlreadyExists();
            }
            else
                throw new NoHotelsAvailableException();

        }

        public List<Room> GetAllRooms()
        {
            var rooms = _roomRepository.GetAll();
            if (rooms != null)
            {
                return rooms.ToList();
            }
            throw new NoRoomsAvailableException();
        }
    }
}
