using XYZHotelsApp.Models;

namespace XYZHotelsApp.Interfaces
{
    public interface IRoomService
    {
        Room AddRoom(Room room);

        List<Room> GetAllRooms();
    }
}
