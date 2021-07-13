using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MentorMenteeApp.Application.Common.Interfaces;
using MentorMenteeApp.Application.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Users.Queries.GetUser
{
    public class GetUserDetailQuery : IRequest<UserDetailVm>
    {
        public int UserId { get; set; }
        private IMapper _mapper;
        private IApplicationDbContext _applicationDbContext;

          
        public GetUserDetailQuery(IMapper mapper, IApplicationDbContext  applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;

        }
        public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            UserDetailVm user = await _applicationDbContext.Users.ProjectTo<UserDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(v => v.Id == request.UserId);
            return user;
  
        }
    }
}
