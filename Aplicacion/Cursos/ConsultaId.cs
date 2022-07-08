using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<Curso>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<CursoUnico, Curso>
        {
            private readonly CursosOnlineContext _context;
            //private readonly IMapper _mapper;
            public Manejador(CursosOnlineContext context)//, IMapper mapper)
            {
                _context = context;
                //_mapper = mapper;
            }
            public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var curso = await _context.Curso.FindAsync(request.Id);
               //.Include(x => x.ComentarioLista)
               //.Include(x => x.PrecioPromocion)
               //.Include(x => x.InstructoresLink)
               //.ThenInclude(y => y.Instructor)
               //.FirstOrDefaultAsync(a => a.CursoId == request.Id);

                if (curso == null)
                {
                    throw new Exception("No se puede eliminar curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se encontro el curso" });
                }

                //var cursoDto = _mapper.Map<Curso, CursoDto>(curso);
                return curso;
            }
        }
    }
}
