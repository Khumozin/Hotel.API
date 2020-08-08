using System;
using System.Collections.Generic;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public interface IRoomFeature
    {
        bool SaveChanges();
        IEnumerable<RoomFeature> GetAllRoomFeatures();
        IEnumerable<RoomFeature> GetRoomFeaturesByRoomID(Guid id);
        RoomFeature GetRoomFeatureByID(Guid id);
        void AddRoomFeature(RoomFeature roomFeature);
        void UpdateRoomFeature(RoomFeature roomFeature);
        void DeleteRoomFeature(RoomFeature roomFeature);
    }
}