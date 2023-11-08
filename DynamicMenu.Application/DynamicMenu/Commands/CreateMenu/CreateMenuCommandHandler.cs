using AutoMapper;
using DynamicMenu.Application.Interfaces;
using DynamicMenu.Domain;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DynamicMenu.Application.DynamicMenu.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, string>
    {
        private readonly IDynamicMenuDbContext _context;
        private readonly IMapper _mapper;
        public CreateMenuCommandHandler(IDynamicMenuDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = _mapper.Map<Menu>(request);
            await _context.Menu.AddAsync(menu, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return JsonConvert.SerializeObject(menu);
        }

    }
}
