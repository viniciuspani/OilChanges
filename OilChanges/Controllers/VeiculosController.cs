using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OilChanges.Repository;
using OilChanges.Shared.Model;
using OilChanges.Shared.DTOs;

namespace OilChanges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public VeiculosController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet("fabricantes/{marca}")]
        public  ActionResult<IEnumerable<VeiculoDTO>> GetVeiculosFabricantes(string marca)
        {
            try
            {
                var veiculos =  _uof.VeiculoRepository.GetVeiculoMarca(marca).ToList();
                if (veiculos is null)
                    return NotFound();

                var veiculoDto = _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
                return Ok(veiculoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação. Metodo GetFabricantes");
            }            
        }

        // GET: api/Veiculos
        [HttpGet("listaVeiculos")]
        public  ActionResult<IEnumerable<VeiculoDTO>> GetVeiculos()
        {
            try
            {
                var veiculos = _uof.VeiculoRepository.Get().ToList();
                if (veiculos is null)
                    return NotFound();

                var veiculoDto = _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
                return Ok(veiculoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo GetVeiculo");
            }
        }

        // GET: api/Veiculos/5
        [HttpGet("{id:int}", Name = "ObterVeiculos")]
        public  ActionResult<VeiculoDTO> GetVeiculo(int id)
        {
            try
            {
                var veiculo =  _uof.VeiculoRepository.GetById(v => v.VeiculoId.Equals(id));
                if (veiculo == null)
                {
                    return NotFound($"Veiculo com id= {id} não encontrada...");
                }
                var veiculoDto = _mapper.Map<VeiculoDTO>(veiculo);
                return Ok(veiculoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo GetById");
            }           
            
        }

        // PUT: api/Veiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public  ActionResult<VeiculoDTO> PutVeiculo(int id, VeiculoDTO veiculoDto)
        {
            try
            {
                if (id != veiculoDto.VeiculoId)
                {
                    return BadRequest("Dados inválidos");
                }

                var veiculo = _mapper.Map<Veiculo>(veiculoDto);
                var veiculoAtualizado = _uof.VeiculoRepository.Update(veiculo);
                _uof.Commit();

                var veiculoAtualizadoDto = _mapper.Map<VeiculoDTO>(veiculoAtualizado);
                return Ok(veiculoAtualizadoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PutVeiculo");
            }            
        }

        // POST: api/Veiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<VeiculoDTO> PostVeiculo(VeiculoDTO veiculoDto)
        {
            try
            {
                if (veiculoDto is null)
                {
                    return BadRequest("Dados invalidos");
                }

                var veiculo = _mapper.Map<Veiculo>(veiculoDto);
                var novoVeiculo = _uof.VeiculoRepository.Create(veiculo);
                _uof.Commit();

                var novoVeiculoDto = _mapper.Map<VeiculoDTO>(novoVeiculo);
                return new CreatedAtRouteResult("ObterVeiculos", new { id = novoVeiculoDto.VeiculoId }, novoVeiculoDto);
            }
            catch (Exception)
            {


                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PostVeiculo");
            }
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public  ActionResult<VeiculoDTO> DeleteVeiculo(int id)
        {
            try
            {
                if (_uof.VeiculoRepository == null)
                {
                    return NotFound($"Não existe veiculo com este id = {id}");
                }
                var veiculo = _uof.VeiculoRepository.GetById(v => v.VeiculoId.Equals(id));
                if (veiculo == null)
                {
                    return NotFound($"Veiculo com o id = {id} não encontrado.");
                }

                var veiculoDeletado = _uof.VeiculoRepository.Delete(veiculo);
                _uof.Commit();

                var veiculoDeletadoDto = _mapper.Map<VeiculoDTO>(veiculoDeletado);
                return Ok(veiculoDeletadoDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Metodo PostVeiculo");
            }
        }

        //private bool VeiculoExists(int id)
        //{
        //    //return (_uof.Veiculos?.Any(e => e.VeiculoId == id)).GetValueOrDefault();
        //    return _uof.VeiculoRepository.GetById(v => v.VeiculoId == id).GetType().Equals(typeof(Veiculo));

        //}
    }
}
