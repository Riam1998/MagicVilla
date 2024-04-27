using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba1._0.Datos;
using prueba1._0.Modelos;
using prueba1._0.Modelos.Dto;
using prueba1._0.Repositorio.IRepositorio;

namespace prueba1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IPruebaRepositorio _pruebaRepo;
        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected ApiResponse _response;
        public NumeroVillaController(ILogger<NumeroVillaController> looger, IPruebaRepositorio pruebaRepo, INumeroVillaRepositorio numeroRepo, IMapper mapper)
        {
                _logger = looger;
                _pruebaRepo = pruebaRepo;
                _numeroRepo = numeroRepo;
                _mapper = mapper;
                _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetNumeroVillas()
        {
            try
            {
                _logger.LogInformation("Mostrando Numero Villas");

                IEnumerable<NumeroVilla> numeroVillaList = await _numeroRepo.GetAll();
                _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDto>>(numeroVillaList);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("id:int", Name = "GetNumeroVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetNumeroVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error al traer Villa con Id " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                //var vl = PruebaStore.pruebaList.FirstOrDefault(v => v.Id == id);
                var nv = await _numeroRepo.GetA(v => v.VillaNo == id);
                if (nv == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Resultado = _mapper.Map<NumeroVillaDto>(nv);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CrearNumeroVilla([FromBody] NumeroVillaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _numeroRepo.GetA(v => v.VillaNo == createDto.VillaNo) != null)
                {
                    ModelState.AddModelError("NUmeroVillaExistente", "El numero de Villa ya Existe!");
                    return BadRequest(ModelState);
                }
                if (await _pruebaRepo.GetA(v=>v.Id==createDto.VillaId)==null)
                {
                    ModelState.AddModelError("ClaveForaneaNoExistente", "El Id de la Villa no Existe!");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                /*pruebaDto.Id = PruebaStore.pruebaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
                PruebaStore.pruebaList.Add(pruebaDto);*/
                NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDto);
                //Prueba modelo = new()
                //{
                //    Nombre = pruebaDto.Nombre,
                //    Detalle = pruebaDto.Detalle,
                //    ImagenUrl = pruebaDto.ImagenUrl,
                //    Ocupantes = pruebaDto.Ocupantes,
                //    Tarifa = pruebaDto.Tarifa,
                //    MetrosCuadrados = pruebaDto.MetrosCuadrados,
                //    Amenidad = pruebaDto.Amenidad
                //};
                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;
                await _numeroRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNo }, modelo);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNumeroVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var numeroVilla = await _numeroRepo.GetA(v => v.VillaNo == id);
                if (numeroVilla == null)
                {
                    _response.IsExitoso = false;  
                    _response.StatusCode = HttpStatusCode.NotFound; 
                    return NotFound(_response);
                }
                //PruebaStore.pruebaList.Remove(villa);
                await _numeroRepo.Remove(numeroVilla);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                   
            }
            return BadRequest(_response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNumeroVilla(int id, [FromBody] NumeroVillaUpdateDto updateDto)
        {
            if (updateDto == null || id!= updateDto.VillaNo)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            if (await _pruebaRepo.GetA(v=>v.Id==updateDto.VillaId)==null)
            {
                ModelState.AddModelError("ClaveForaneaNoExistente", "El Id de la Villa no Existe!");
                return BadRequest(ModelState);
            }
            //var villa = PruebaStore.pruebaList.FirstOrDefault(v => v.Id == id);
            //villa.Nombre = pruebaDto.Nombre;
            NumeroVilla modelo = _mapper.Map<NumeroVilla>(updateDto);
            //Prueba modelo = new()
            //{
            //    Id = pruebaDto.Id,
            //    Nombre = pruebaDto.Nombre,
            //    Detalle = pruebaDto.Detalle,
            //    ImagenUrl = pruebaDto.ImagenUrl,
            //    Ocupantes = pruebaDto.Ocupantes,
            //    Tarifa = pruebaDto.Tarifa,
            //    MetrosCuadrados = pruebaDto.MetrosCuadrados,
            //    Amenidad = pruebaDto.Amenidad
            //};
            modelo.FechaActualizacion = DateTime.Now;
            await _numeroRepo.Actualizar(modelo);
            _response.StatusCode = HttpStatusCode.NoContent;
            _logger.LogInformation("Datos Actualizados");
            return Ok(_response);
        }
    }
}
