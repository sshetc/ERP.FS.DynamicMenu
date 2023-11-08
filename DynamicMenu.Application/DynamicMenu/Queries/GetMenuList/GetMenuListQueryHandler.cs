using AutoMapper;
using AutoMapper.QueryableExtensions;
using DynamicMenu.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicMenu.Application.DynamicMenu.Queries.GetMenuList
{
    public class GetMenuListQueryHandler : IRequestHandler<GetMenuListQuery, MenuListVm>
    {
        private readonly IDynamicMenuDbContext _context;
        private readonly IMapper _mapper;
        public GetMenuListQueryHandler(IDynamicMenuDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

        public async Task<MenuListVm> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
        {
            var menuQuery = await _context.Menu.Where(menu => menu.CompanyId == request.CompanyId &&
                                                 menu.UserId == request.UserId)
                                                 .ProjectTo<MenuLookUpDto>(_mapper.ConfigurationProvider)
                                                 .ToListAsync();

            return new MenuListVm() { Menu = menuQuery };
        }

    }
}
