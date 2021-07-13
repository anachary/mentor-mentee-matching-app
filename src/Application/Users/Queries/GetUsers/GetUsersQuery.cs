using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MentorMenteeApp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UsersVm>
    {
        private  IMapper _mapper { get;   set; }
        private IApplicationDbContext _applicationDbContext { get; set; }
        public GetUsersQuery(IMapper mapper, IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;

        }
        public async Task<UsersVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userDtos = await _applicationDbContext.Users
                 .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                 .OrderBy(e => e.FirstName)
                 .ToListAsync(cancellationToken);

            var vm = new UsersVm
            {
                Users = userDtos
            };

            return vm;
        }

    }
}
