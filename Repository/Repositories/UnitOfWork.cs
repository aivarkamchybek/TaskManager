using Domain.Interfaces;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuoteContext _context;
        public IUserRepo UserRepo { get; }
        public IQuoteRepo QuoteRepo { get; }

        public UnitOfWork(QuoteContext context)
        {
            _context = context;
            UserRepo = new UserRepo(context);
            QuoteRepo = new QuoteRepo(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
