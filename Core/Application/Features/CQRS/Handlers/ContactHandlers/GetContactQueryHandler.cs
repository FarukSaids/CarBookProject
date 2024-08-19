using Application.Features.CQRS.Results.ContactResults;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {


        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                Name = x.Name,
                ContactID = x.ContactID,
                Message = x.Message,
                Subject = x.Subject,
                SendDate = x.SendDate,
                Email = x.Email 

            }).ToList();
        }
    }
}
