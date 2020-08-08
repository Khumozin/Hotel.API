using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public class HotelFeatureRepo : IHotelFeature
    {
        private readonly HotelContext _context;

        public HotelFeatureRepo(HotelContext context)
        {
            _context = context;
        }
        public void AddHotelFeature(HotelFeature hotelFeature)
        {
            if (hotelFeature == null)
            {
                throw new ArgumentException(nameof(hotelFeature));
            }

            hotelFeature.ID = Guid.NewGuid();
            _context.HotelFeature.Add(hotelFeature);
        }

        public void DeleteHotelFeature(HotelFeature hotelFeature)
        {
            if (hotelFeature == null)
            {
                throw new ArgumentException(nameof(hotelFeature));
            }

            _context.HotelFeature.Remove(hotelFeature);
        }

        public IEnumerable<HotelFeature> GetAllHotelFeatures()
        {
            return _context.HotelFeature.ToList();
        }

        public IEnumerable<HotelFeature> GetAllHotelFeaturesByConfigID(Guid id)
        {
            return _context.HotelFeature.ToList().Where(h => h.SystemConfigID == id);
        }

        public HotelFeature GetHotelFeatureID(Guid id)
        {
            return _context.HotelFeature.FirstOrDefault(h => h.ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateHotelFeature(HotelFeature hotelFeature)
        {
            // Does nothing
        }
    }
}