using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly Datacontext _context;
            public Handler(Datacontext context)
            {
                _context = context;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.FindAsync(request.Id);
            }
        }
    }
}