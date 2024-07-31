using Domain.Entities;
using Domain.Interfaces;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class QuoteRepo : GenericRepo<Quote>, IQuoteRepo
    {
        public QuoteRepo(QuoteContext context) : base(context) { }
    }
}
