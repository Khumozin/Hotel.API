using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public class RoomRepo : IRoom
    {
        private readonly HotelContext _context;

        public RoomRepo(HotelContext context)
        {
            _context = context;
        }

        public void AddRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentException(nameof(room));
            }

            room.ID = Guid.NewGuid();
            _context.Room.Add(room);
        }

        public void DeleteRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentException(nameof(room));
            }

            _context.Room.Remove(room);
        }

        public Room GetRoomByID(Guid id)
        {
            return _context.Room.FirstOrDefault(r => r.ID == id);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Room.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateRoom(Room room)
        {
            // Does nothing
        }

        public IEnumerable<Room> GetAllRoomsBySystemConfigID(Guid id)
        {
            return _context.Room.ToList().Where(r => r.SystemConfigID == id);
        }
    }
}