using System;
using System.Collections.Generic;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public interface IRoomImage
    {
        bool SaveChanges();
        IEnumerable<RoomImage> GetAllRoomImages();
        IEnumerable<RoomImage> GetRoomImagesByRoomID(Guid id);
        RoomImage GetRoomImagesByID(Guid id);
        void AddRoomImage(RoomImage roomImage);
        void UpdateRoomImage(RoomImage roomImage);
        void DeleteRoomImage(RoomImage roomImage);
    }
}