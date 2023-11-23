using XYZHotelsApp.Models;

namespace XYZHotelsApp.Interfaces
{
    public interface IReservationService
    {
        Reservation BookRoom(Reservation reservation);
    }
}
