using System;
using System.Collections.Generic;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public interface IHotelFeature
    {
        bool SaveChanges();
        IEnumerable<HotelFeature> GetAllHotelFeatures();
        HotelFeature GetHotelFeatureID(Guid id);
        IEnumerable<HotelFeature> GetAllHotelFeaturesByConfigID(Guid id);
        void AddHotelFeature(HotelFeature hotelFeature);
        void UpdateHotelFeature(HotelFeature hotelFeature);
        void DeleteHotelFeature(HotelFeature hotelFeature);
    }
}