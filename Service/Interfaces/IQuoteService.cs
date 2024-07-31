using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IQuoteService
    {
        IEnumerable<Quote> GetAll();
        Quote GetById(int id);
        void Add (Quote quote);
        void Update (Quote quote);
        void Delete (int id);
    }
}
