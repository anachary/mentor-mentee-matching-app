using MediatR;
using MentorMenteeApp.Application.Common.Exceptions;
using MentorMenteeApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Users.Command.DeleteUser
{
    public class DeleteUser : IRequest
    {

        public int Id { get; set; }

        public class DeleteUserHandler : IRequestHandler<DeleteUser>
        {
            readonly IApplicationDbContext _context;
            readonly IIdentityService _identityService;

            public DeleteUserHandler(IApplicationDbContext context, IIdentityService identityService)
            {
                _context = context;
                _identityService = identityService;
            }

            public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(entity), request.Id);
                }


                if (entity!= null)
                {
                    await _identityService.DeleteUserAsync(entity.Id.ToString());
                }


                // TODO: Update this logic, this will only work if the employee has no associated territories or orders.Emp

                _context.Users.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }

}
