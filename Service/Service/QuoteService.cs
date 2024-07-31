using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class QuoteService : IQuoteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Quote> GetAll()
        {
            return _unitOfWork.QuoteRepo.GetAll();
        }

        public Quote GetById(int id)
        {
            return _unitOfWork.QuoteRepo.GetById(id);
        }

        public void Add(Quote quote)
        {
            if (quote == null)
                throw new ArgumentNullException(nameof(quote));

            _unitOfWork.QuoteRepo.Add(quote);
            _unitOfWork.Complete();
        }

        public void Update(Quote quote)
        {
            if (quote == null)
                throw new ArgumentNullException(nameof(quote));

            var existingQuote = _unitOfWork.QuoteRepo.GetById(quote.QuoteID);
            if (existingQuote == null)
                throw new KeyNotFoundException($"Quote with ID {quote.QuoteID} not found.");

            existingQuote.QuoteType = quote.QuoteType;
            existingQuote.Description = quote.Description;
            existingQuote.DueDate = quote.DueDate;
            existingQuote.Premium = quote.Premium;
            existingQuote.Sales = quote.Sales;

            _unitOfWork.QuoteRepo.Update(existingQuote);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var quote = _unitOfWork.QuoteRepo.GetById(id);
            if (quote == null)
                throw new KeyNotFoundException($"Quote with ID {id} not found.");

            _unitOfWork.QuoteRepo.Delete(id);
            _unitOfWork.Complete();
        }


    }
}
