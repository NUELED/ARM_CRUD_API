using ARM_CRUD_API.Common.DTO;
using ARM_CRUD_API.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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



        [HttpPost("getAllStaffs")]
      //  [Route("createStaff")]
        public async Task<IActionResult> CreateStaff([FromBody] StaffDTO staffDTO)
        {

            try
            {
                var resp = _staffService.CreateStaff(staffDTO);

                var response = new SuccessResponse { Title = "Success", Data = resp, StatusCode = StatusCodes.Status200OK, SuccessMessage = "Staff created." };
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorMessage = "Please there was an issue processing your  request at the moment.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

        }


        [HttpGet]
        [Route("getStaff")]
        public async Task<IActionResult> GetStaff(int id)
        {
            try
            {
                var resp = _staffService.GetStaff(id);
                var response = new SuccessResponse { Title = "Success", Data = resp, StatusCode = StatusCodes.Status200OK, SuccessMessage = "Staff retrieved." };
                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest(new ErrorResponse
                {
                    Title = "Unsuccessfull",
                    ErrorMessage = "The staff does not exist.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
     
        }


      
        [HttpGet]
        [Route("getAllStaffs")]
        public async Task<IActionResult> GetAllStaffs()
        {
            try
            {
                var resp = _staffService.GetAllStaffs();
                var response = new SuccessResponse { Title = "Success", Data = resp, StatusCode = StatusCodes.Status200OK, SuccessMessage = "All Staffs retrieved." };
                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest(new ErrorResponse
                {
                    ErrorMessage = "Please there was an issue processing your  request at the moment.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
      
        }


        //UpdateStaffIfExists
        [HttpPut]
        [Route("updateStaffIfExists")]
        public async Task<IActionResult> UpdateStaffIfExists([FromBody] StaffDTO staffDTO)
        {
            try
            {
                var response = _staffService.UpdateStaffIfExists(staffDTO);
                return Ok("Update Successfull");
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse
                {
                    Title = "Unsuccessfull",
                    ErrorMessage = "The was an issue updating.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
    
        }


        [HttpDelete]
        [Route("deleteStaffIfExists")]
        public async Task<IActionResult> DeleteStaffIfExists(int staffId)
        {

            try
            {
                var response = _staffService.DeleteStaffIfExists(staffId);
                return Ok("Delete Successfull");
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse
                {
                    Title = "Unsuccessfull",
                    ErrorMessage = "The was an issue deleting.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
      
        }





    }
}
