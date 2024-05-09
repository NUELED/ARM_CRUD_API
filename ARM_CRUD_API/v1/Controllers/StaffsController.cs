using ARM_CRUD_API.Common.DTO;
using ARM_CRUD_API.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARM_CRUD_API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffsController(IStaffService staffService)
        {
                _staffService = staffService;
        }



        [HttpPost]
        [Route("createStaff")]
        public async Task<IActionResult> CreateStaff([FromBody] StaffDTO staffDTO)
        {
            var response = _staffService.CreateStaff(staffDTO); 
            return Ok(response);
        }


        [HttpGet]
        [Route("getStaff")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var response = _staffService.GetStaff(id);
            return Ok(response);
        }


      
        [HttpGet]
        [Route("getAllStaffs")]
        public async Task<IActionResult> GetAllStaffs()
        {
            var response = _staffService.GetAllStaffs();
            return Ok(response);
        }


        //UpdateStaffIfExists
        [HttpPut]
        [Route("updateStaffIfExists")]
        public async Task<IActionResult> UpdateStaffIfExists([FromBody] StaffDTO staffDTO)
        {
            var response = _staffService.UpdateStaffIfExists(staffDTO);
            return Ok("Update Successfull");
        }


        [HttpDelete]
        [Route("deleteStaffIfExists")]
        public async Task<IActionResult> DeleteStaffIfExists(int staffId)
        {
            var response = _staffService.DeleteStaffIfExists(staffId);
            return Ok("Delete Successfull");    
        }





    }
}
