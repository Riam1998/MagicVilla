using AutoMapper;
using Prueba_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Prueba_Web.Services.IServices;
using Prueba_Web.Models;
using Newtonsoft.Json;

namespace Prueba_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaController(IVillaService villaService, IMapper mapper)
        {
           _villaService = villaService;
           _mapper = mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<PruebaDto> villaList = new();
            var response = await _villaService.ObtenerT<APIResponse>();
            if (response != null && response.IsExitoso) 
            {
                villaList = JsonConvert.DeserializeObject<List<PruebaDto>>(Convert.ToString(response.Resultado));
            }
            return View(villaList);
        }

        public async Task<IActionResult> CrearVilla()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearVilla(PruebaCreateDto modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.Crear<APIResponse>(modelo);
                if (response != null && response.IsExitoso)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(modelo);
        }
       
        public async Task<IActionResult> ActualizarVilla(int villaId)
        {
            var response = await _villaService.Obtener<APIResponse>(villaId);
            if (response != null && response.IsExitoso)
            {
                PruebaDto model = JsonConvert.DeserializeObject<PruebaDto>(Convert.ToString(response.Resultado));
                return View(_mapper.Map<PruebaUpdateDto>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarVilla(PruebaUpdateDto modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.Actualizar<APIResponse>(modelo);

                if (response != null && response.IsExitoso)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(modelo);
        }

        public async Task<IActionResult> RemoverVilla(int villaId)
        {
            var response = await _villaService.Obtener<APIResponse>(villaId);

            if (response != null && response.IsExitoso)
            {
                PruebaDto model = JsonConvert.DeserializeObject<PruebaDto>(Convert.ToString(response.Resultado));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverVilla(PruebaDto modelo)
        {
            
            var response = await _villaService.Remover<APIResponse>(modelo.Id);

            if (response != null && response.IsExitoso)
            {
                return RedirectToAction(nameof(IndexVilla));
            }
            
            return View(modelo);
        }

    }
}
