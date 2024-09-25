using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OilChanges.Repository;
using OilChanges.Shared.DTOs;
using OilChanges.Shared.Model;

namespace OilChanges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OleosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public OleosController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        // GET: api/Oleos
        [HttpGet("listaOleos")]
        public ActionResult<IEnumerable<OleoDTO>> GetOleos()
        {
            try
            {
                var oleos = _uof.OleoRepository.Get().ToList();
                if (oleos is null)
                    return NotFound();

                var oleoDto = _mapper.Map<IEnumerable<OleoDTO>>(oleos);
                return Ok(oleoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo GetOleos");
            }
        }

        // GET: api/Oleos/5
        [HttpGet("{id}", Name = "ObterOleo")]
        public ActionResult<OleoDTO> GetOleo(int id)
        {
            try
            {
                var oleos = _uof.OleoRepository.GetById(o => o.OleoId.Equals(id));
                if (oleos == null)
                {
                    return NotFound($"Oleo com id= {id} não encontrada...");
                }
                var oleoDto = _mapper.Map<OleoDTO>(oleos);
                return Ok(oleoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo GetOleosById");
            }
        }

        // PUT: api/Oleos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<OleoDTO> PutOleo(int id, OleoDTO oleoDto)
        {
            try
            {
                if (id != oleoDto.OleoId)
                {
                    return BadRequest("Dados inválidos");
                }

                var oleo = _mapper.Map<Oleo>(oleoDto);
                var oleoAtualizado = _uof.OleoRepository.Update(oleo);
                _uof.Commit();

                var oleoAtualizadoDto = _mapper.Map<Oleo>(oleoDto);
                return Ok(oleoAtualizadoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PutOleo");
            }
        }

        // POST: api/Oleos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<OleoDTO> PostOleo(OleoDTO oleoDto)
        {
            try
            {
                if (oleoDto is null)
                {
                    return BadRequest("Dados invalidos");
                }

                var oleo = _mapper.Map<Oleo>(oleoDto);
                var novoOleo = _uof.OleoRepository.Create(oleo);
                _uof.Commit();

                var novoOleoDto = _mapper.Map<OleoDTO>(novoOleo);
                return new CreatedAtRouteResult("ObterOleo", new { id = novoOleoDto.OleoId }, novoOleoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PostOleo");
            }
        }

        // DELETE: api/Oleos/5
        [HttpDelete("{id}")]
        public ActionResult<OleoDTO> DeleteOleo(int id)
        {
            try
            {
                if (_uof.OleoRepository == null)
                {
                    return NotFound($"Não existe oleo com este id = {id}");
                }
                var oleo = _uof.OleoRepository.GetById(v => v.OleoId.Equals(id));
                if (oleo == null)
                {
                    return NotFound($"Oleo com o id = {id} não encontrado.");
                }

                var oleoDeletado = _uof.OleoRepository.Delete(oleo);
                _uof.Commit();

                var oleoDeletadoDto = _mapper.Map<OleoDTO>(oleoDeletado);
                return Ok(oleoDeletadoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PostOleo");
            }
        }

        //private bool OleoExists(int id)
        //{
        //    return (_context.Oleos?.Any(e => e.OleoId == id)).GetValueOrDefault();
        //}
    }
}
