using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public class SystemConfigRepo : ISystemConfig
    {
        private readonly HotelContext _context;

        public SystemConfigRepo(HotelContext context)
        {
            _context = context;
        }
        public void CreateSystemConfig(SystemConfig systemConfig)
        {
            if (systemConfig == null)
            {
                throw new ArgumentException(nameof(systemConfig));
            }

            systemConfig.ID = Guid.NewGuid();
            _context.SystemConfig.Add(systemConfig);
        }

        public void DeleteSystemConfig(SystemConfig systemConfig)
        {
            if (systemConfig == null)
            {
                throw new ArgumentException(nameof(systemConfig));
            }

            _context.SystemConfig.Remove(systemConfig);
        }

        public IEnumerable<SystemConfig> GetAllSystemConfigs()
        {
            return _context.SystemConfig.ToList();
        }

        public SystemConfig GetSystemConfigByID(Guid id)
        {
            return _context.SystemConfig.FirstOrDefault(s => s.ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateSystemConfig(SystemConfig systemConfig)
        {
            // Does Nothing
        }
    }
}