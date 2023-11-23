using XYZHotelsApp.Contexts;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;

namespace XYZHotelsApp.Repositories
{
    public class RoomRepository : IRepository<int, Room>
    {
        private readonly XYZHotelsDBContext _context;

        public RoomRepository(XYZHotelsDBContext context)
        {
            _context = context;
        }
        public Room Add(Room rooom)
        {
            _context.Rooms.Add(rooom);
            _context.SaveChanges();
            return rooom;
        }

        public Room Delete(int key)
        {
            var room = GetById(key);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return room;
            }
            return null;
        }

        public IList<Room> GetAll()
        {
            if (_context.Rooms.Count() == 0)
                return null;
            return _context.Rooms.ToList();
        }

        public Room GetById(int key)
        {
            var room = _context.Rooms.SingleOrDefault(b => b.RoomId == key);
            return room;
        }

        public Room Update(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
