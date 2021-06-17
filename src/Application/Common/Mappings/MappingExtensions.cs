using AutoMapper;
using AutoMapper.QueryableExtensions;
using MentorMenteeApp.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Common.Mappings
{
    public static class MappingExtensions
    {

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}
