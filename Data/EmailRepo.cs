using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.API.Models;

namespace Hotel.API.Data
{
    public class EmailRepo : IEmail
    {
        private readonly HotelContext _context;

        public EmailRepo(HotelContext context)
        {
            _context = context;
        }

        public void AddEmail(Email email)
        {
            if (email == null)
            {
                throw new ArgumentException(nameof(email));
            }

            email.ID = Guid.NewGuid();
            email.DateSent = DateTime.Now.ToString();
            _context.Email.Add(email);
        }

        public void DeleteEmail(Email email)
        {
            if (email == null)
            {
                throw new ArgumentException(nameof(email));
            }

            _context.Email.Remove(email);
        }

        public IEnumerable<Email> GetAllEmailsByConfigID(Guid id)
        {
            return _context.Email.ToList().Where(e => e.SystemConfigID == id);
        }

        public Email GetEmailByID(Guid id)
        {
            return _context.Email.FirstOrDefault(e => e.ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateEmail(Email email)
        {
            // Does nothing
        }
    }
}