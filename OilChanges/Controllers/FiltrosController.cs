using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OilChanges.Repository;
using OilChanges.Shared.DTOs;
using OilChanges.Shared.Model;

namespace OilChanges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public FiltrosController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        // GET: api/Filtros
        [HttpGet("listaFiltros")]
        public ActionResult<IEnumerable<FiltroDTO>> GetFiltros()
        {
            try
            {
                var filtros = _uof.FiltroRepository.Get().ToList();
                if (filtros is null)
                    return NotFound();

                var filtroDto = _mapper.Map<IEnumerable<FiltroDTO>>(filtros);
                return Ok(filtroDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo GetFiltros");
            }
        }

        // GET: api/Filtros/5
        [HttpGet("{id}", Name = "ObterFiltro")]
        public ActionResult<FiltroDTO> GetFiltro(int id)
        {
            try
            {

                var filtros = _uof.FiltroRepository.GetById(f => f.FiltroId.Equals(id));
                if (filtros is null)
                    return NotFound($"Filtro com id= {id} não encontrada...");

                var filtroDto = _mapper.Map<FiltroDTO>(filtros);
                return Ok(filtroDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo GetFiltrosById");
            }
        }

        // PUT: api/Filtros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<FiltroDTO> PutFiltro(int id, FiltroDTO filtroDto)
        {
            try
            {
                if (id != filtroDto.FiltroId)
                {
                    return BadRequest("Dados inválidos");
                }

                var filtro = _mapper.Map<Filtro>(filtroDto);
                var filtroAtualizado = _uof.FiltroRepository.Update(filtro);
                _uof.Commit();

                var filtroAtualizadoDto = _mapper.Map<Filtro>(filtroDto);
                return Ok(filtroAtualizadoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PutFiltro");
            }
        }

        // POST: api/Filtros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<FiltroDTO> PostFiltro(FiltroDTO filtroDto)
        {
            try
            {
                if (filtroDto is null)
                {
                    return BadRequest("Dados invalidos");
                }

                var filtro = _mapper.Map<Filtro>(filtroDto);
                var novoFiltro = _uof.FiltroRepository.Create(filtro);
                _uof.Commit();

                var novoFiltroDto = _mapper.Map<Filtro>(filtroDto);
                return new CreatedAtRouteResult("ObterFiltro", new { id = novoFiltroDto.FiltroId }, novoFiltroDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PostFiltro");
            }
        }

        // DELETE: api/Filtros/5
        [HttpDelete("{id}")]
        public ActionResult<FiltroDTO> DeleteFiltro(int id)
        {
            try
            {
                if (_uof.FiltroRepository == null)
                {
                    return NotFound($"Não existe filtro com este id = {id}");
                }
                var filtro = _uof.FiltroRepository.GetById(f => f.FiltroId.Equals(id));
                if (filtro == null)
                {
                    return NotFound($"Filtro com o id = {id} não encontrado.");
                }

                var filtroDeletado = _uof.FiltroRepository.Delete(filtro);
                _uof.Commit();

                var filtroDeletadoDto = _mapper.Map<FiltroDTO>(filtroDeletado);
                return Ok(filtroDeletadoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo DeleteFiltro");
            }
        }

        //private bool FiltroExists(int id)
        //{
        //    return (_context.Filtros?.Any(e => e.FiltroId == id)).GetValueOrDefault();
        //}
    }
}
