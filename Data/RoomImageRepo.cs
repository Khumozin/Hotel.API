using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public class RoomImageRepo : IRoomImage
    {
        private readonly HotelContext _context;

        public RoomImageRepo(HotelContext context)
        {
            _context = context;
        }
        public void AddRoomImage(RoomImage roomImage)
        {
            if (roomImage == null)
            {
                throw new ArgumentException(nameof(roomImage));
            }

            roomImage.ID = Guid.NewGuid();
            _context.RoomImage.Add(roomImage);
        }

        public void DeleteRoomImage(RoomImage roomImage)
        {
            if (roomImage == null)
            {
                throw new ArgumentException(nameof(roomImage));
            }

            _context.RoomImage.Remove(roomImage);
        }

        public IEnumerable<RoomImage> GetAllRoomImages()
        {
            return _context.RoomImage.ToList();
        }

        public RoomImage GetRoomImagesByID(Guid id)
        {
            return _context.RoomImage.FirstOrDefault(r => r.ID == id);
        }

        public IEnumerable<RoomImage> GetRoomImagesByRoomID(Guid id)
        {
            return _context.RoomImage.ToList().Where(r => r.RoomID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateRoomImage(RoomImage roomImage)
        {
            // Does nothing
        }
    }
}