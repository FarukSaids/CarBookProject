using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {


        private readonly IRepository<Category> _repoistory;

        public GetCategoryByIdQueryHandler(IRepository<Category> repoistory)
        {
            _repoistory = repoistory;
        }


        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _repoistory.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryID = values.CategoryID,
                Name = values.Name,

            };
        }
    }
}
