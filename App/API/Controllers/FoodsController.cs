using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet]
        public List<VFood> GetAll()
        {
            return _foodService.GetAll();
        }
    }
}
