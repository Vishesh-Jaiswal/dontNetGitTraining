using XYZHotelsApp.Exceptions;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;
using XYZHotelsApp.Repositories;

namespace XYZHotelsApp.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<int,Hotel> _hotelRepository;
        private readonly IRepository<int,Reservation> _reservationRepository;
        private readonly IRepository<int, Room> _roomRepository;

        public ReservationService(IRepository<int, Hotel> hotelRepository, IRepository<int, Reservation> reservationRepository, IRepository<int, Room> roomRepository)
        {
            _hotelRepository = hotelRepository;
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }
        public bool IsRoomAvailable(Room room)
        {
            return room.Status == RoomStatus.Available && (room.AvailableAgainAt == null || DateTime.UtcNow >= room.AvailableAgainAt);
        }
        public Reservation BookRoom(Reservation reservation)
        {
            var checkRoomNumber = _roomRepository.GetAll().FirstOrDefault(r => r.RoomId == reservation.RoomId);

            if (checkRoomNumber != null && IsRoomAvailable(checkRoomNumber))
            {
                reservation.CheckInDate = DateTime.UtcNow;
                reservation.CheckOutDate = DateTime.UtcNow.AddHours(24);

                checkRoomNumber.Status = RoomStatus.Reserved;
                checkRoomNumber.AvailableAgainAt = DateTime.UtcNow.AddHours(24);

                var result = _reservationRepository.Add(reservation);
                return result;
            }

            throw new RoomIsBooked();
        }

    }
}
