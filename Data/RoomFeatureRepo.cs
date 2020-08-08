using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public class RoomFeatureRepo : IRoomFeature
    {
        private readonly HotelContext _context;

        public RoomFeatureRepo(HotelContext context)
        {
            _context = context;
        }
        public void AddRoomFeature(RoomFeature roomFeature)
        {
            if (roomFeature == null)
            {
                throw new ArgumentException(nameof(roomFeature));
            }

            roomFeature.ID = Guid.NewGuid();
            _context.RoomFeature.Add(roomFeature);
        }

        public void DeleteRoomFeature(RoomFeature roomFeature)
        {
            if (roomFeature == null)
            {
                throw new ArgumentException(nameof(roomFeature));
            }

            _context.RoomFeature.Remove(roomFeature);
        }

        public IEnumerable<RoomFeature> GetAllRoomFeatures()
        {
            return _context.RoomFeature.ToList();
        }

        public RoomFeature GetRoomFeatureByID(Guid id)
        {
            return _context.RoomFeature.FirstOrDefault(r => r.ID == id);
        }

        public IEnumerable<RoomFeature> GetRoomFeaturesByRoomID(Guid id)
        {
            return _context.RoomFeature.ToList().Where(r => r.RoomID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateRoomFeature(RoomFeature RoomFeature)
        {
            // Does nothing
        }
    }
}