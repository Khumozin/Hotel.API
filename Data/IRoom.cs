using System;
using System.Collections.Generic;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public interface IRoom
    {
        bool SaveChanges();
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Room> GetAllRoomsBySystemConfigID(Guid id);
        Room GetRoomByID(Guid id);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(Room room);
    }
}