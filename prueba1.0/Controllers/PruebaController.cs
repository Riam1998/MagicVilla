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
    public class PruebaController : ControllerBase
    {
        private readonly ILogger<PruebaController> _logger;
        private readonly IPruebaRepositorio _pruebaRepo;
        private readonly IMapper _mapper;
        protected ApiResponse _response;
        public PruebaController(ILogger<PruebaController> looger, IPruebaRepositorio pruebaRepo, IMapper mapper)
        {
                _logger = looger;
                _pruebaRepo = pruebaRepo;
                _mapper = mapper;
                _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetVillas()
        {
            try
            {
                _logger.LogInformation("Mostrando Villas");

                IEnumerable<Prueba> pruebaList = await _pruebaRepo.GetAll();
                _response.Resultado = _mapper.Map<IEnumerable<PruebaDto>>(pruebaList);
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

        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetVilla(int id)
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
                var vl = await _pruebaRepo.GetA(v => v.Id == id);
                if (vl == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Resultado = _mapper.Map<PruebaDto>(vl);
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
        public async Task<ActionResult<ApiResponse>> CrearVilla([FromBody] PruebaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _pruebaRepo.GetA(v => v.Nombre.ToLower() == createDto.Nombre.ToLower()) != null)
                {
                    ModelState.AddModelError("NombreExistente", "La Villa con ese Nombre ya Existe!");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                /*pruebaDto.Id = PruebaStore.pruebaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
                PruebaStore.pruebaList.Add(pruebaDto);*/
                Prueba modelo = _mapper.Map<Prueba>(createDto);
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
                await _pruebaRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = modelo.Id }, modelo);
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
        public async Task<IActionResult> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _pruebaRepo.GetA(v => v.Id == id);
                if (villa == null)
                {
                    _response.IsExitoso = false;  
                    _response.StatusCode = HttpStatusCode.NotFound; 
                    return NotFound(_response);
                }
                //PruebaStore.pruebaList.Remove(villa);
                await _pruebaRepo.Remove(villa);
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
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] PruebaUpdateDto updateDto)
        {
            if (updateDto == null || id!= updateDto.Id)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            //var villa = PruebaStore.pruebaList.FirstOrDefault(v => v.Id == id);
            //villa.Nombre = pruebaDto.Nombre;
            Prueba modelo = _mapper.Map<Prueba>(updateDto);
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
            await _pruebaRepo.Actualizar(modelo);
            _response.StatusCode = HttpStatusCode.NoContent;
            _logger.LogInformation("Datos Actualizados");
            return Ok(_response);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<PruebaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _pruebaRepo.GetA(v => v.Id == id, tracked:false);

            PruebaUpdateDto pruebaDto = _mapper.Map<PruebaUpdateDto>(villa);

            //PruebaUpdateDto pruebaDto = new()
            //{
            //    Id = villa.Id,
            //    Nombre = villa.Nombre,
            //    Detalle = villa.Detalle,
            //    ImagenUrl = villa.ImagenUrl,
            //    Ocupantes = villa.Ocupantes,
            //    Tarifa = villa.Tarifa,
            //    MetrosCuadrados = villa.MetrosCuadrados,
            //    Amenidad = villa.Amenidad
            //};
            if (villa == null) return BadRequest();

            patchDto.ApplyTo(pruebaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Prueba modelo = _mapper.Map<Prueba>(pruebaDto);
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
            await _pruebaRepo.Actualizar(modelo);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }

    }
}
