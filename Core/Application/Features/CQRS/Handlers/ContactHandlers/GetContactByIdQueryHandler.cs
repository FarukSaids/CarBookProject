using Application.Features.CQRS.Queries.ConactQueries;

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
    public class GetContactByIdQueryHandler
    {



        private readonly IRepository<Contact> _repoistory;

        public GetContactByIdQueryHandler(IRepository<Contact> repoistory)
        {
            _repoistory = repoistory;
        }


        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repoistory.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Name = values.Name,
                Email= values.Email,    
                SendDate = values.SendDate,
                Subject = values.Subject,
                Message = values.Message

            };
        }
    }
}
