using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepo UserRepo { get; }
        IQuoteRepo QuoteRepo { get; }
        void Complete();
    }
}
