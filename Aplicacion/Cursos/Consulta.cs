using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListaCursos : IRequest<List<Curso>> { }

        public class Manejador : IRequestHandler<ListaCursos, List<Curso>>
        {
            private readonly CursosOnlineContext _context;
            //private readonly IMapper _mapper;
            public Manejador(CursosOnlineContext context)//, IMapper mapper)
            {
                _context = context;
                //_mapper = mapper;
            }

            public async Task<List<Curso>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Curso.ToListAsync();
                //.Include(x => x.ComentarioLista)
                //.Include(x => x.PrecioPromocion)
                //.Include(x => x.InstructoresLink)
                //.ThenInclude(x => x.Instructor).ToListAsync();

                //var cursosDto = _mapper.Map<List<Curso>, List<CursoDto>>(cursos);

                return cursos;
            }

            
        }
    }
}
