using System;
using System.Collections.Generic;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public interface IEmail
    {
        bool SaveChanges();
        IEnumerable<Email> GetAllEmailsByConfigID(Guid id);
        Email GetEmailByID(Guid id);
        void AddEmail(Email email);
        void UpdateEmail(Email email);
        void DeleteEmail(Email email);
    }
}