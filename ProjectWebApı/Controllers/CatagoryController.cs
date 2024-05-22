using Entıtıes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBLL.ManagerServices.Abstracs;
using ProjectWebApı.Models.Catagory.RequestModel;
using ProjectWebApı.Models.Catagory.ResponseModel;

namespace ProjectWebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        ICatagoryManager _catagorymanager;
        public CatagoryController( ICatagoryManager catagoryManager)
        {
            _catagorymanager = catagoryManager;
            
        }
        [HttpPost]
        public async Task<IActionResult>CreateCatagory(CreateCatagoryRequestModel item)
        {
            Catagory c = new()
            {
                CatagoryName = item.CatagoryName,
                Description = item.Descriptiom
            };
            string resault = _catagorymanager.Add(c);
            return Ok(resault);
        }

        [HttpGet]
        public async Task<IActionResult> GetCatagories()
        {
            List<CatagoryResponseModel> catagories = _catagorymanager.Select(x => new CatagoryResponseModel
            {
                CatagoryName = x.CatagoryName,
                Description = x.Description,
                CatagoryID = x.ID

            }).ToList();
            return Ok(catagories);
               
            
        }
    }
}
