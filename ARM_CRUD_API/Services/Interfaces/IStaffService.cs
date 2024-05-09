using ARM_CRUD_API.Common.DTO;

namespace ARM_CRUD_API.Services.Interfaces
{
    public interface IStaffService
    {

        Task<StaffDTO> CreateStaff(StaffDTO objDTO);
        Task<bool> DeleteStaffIfExists(int id);
        Task<StaffDTO> GetStaff(int id);
        Task<IEnumerable<StaffDTO>> GetAllStaffs(int? id = null);
        Task<bool> UpdateStaffIfExists(StaffDTO objDTO);


    }
}
