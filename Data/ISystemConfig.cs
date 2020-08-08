using System;
using System.Collections.Generic;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public interface ISystemConfig
    {
        bool SaveChanges();
        IEnumerable<SystemConfig> GetAllSystemConfigs();
        SystemConfig GetSystemConfigByID(Guid id);
        void CreateSystemConfig(SystemConfig systemConfig);
        void UpdateSystemConfig(SystemConfig systemConfig);
        void DeleteSystemConfig(SystemConfig systemConfig);
    }
}