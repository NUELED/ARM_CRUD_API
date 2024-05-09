using ARM_CRUD_API.Common.DTO;
using ARM_CRUD_API.Data;
using ARM_CRUD_API.Entities;
using ARM_CRUD_API.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ARM_CRUD_API.Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffService> _logger;

        public StaffService(ApplicationDbContext db, IMapper mapper, ILogger<StaffService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<StaffDTO> CreateStaff(StaffDTO objDTO)
        {

            var obj = _mapper.Map<Staff>(objDTO);
            obj.Id = 0;
            _logger.LogInformation("Adding a new staff to the database.");

            var addedObj = await _db.Staffs.AddAsync(obj);
            await _db.SaveChangesAsync();
            var objReturned = _mapper.Map<StaffDTO>(addedObj.Entity);

            return objReturned;
        }


        public async Task<bool> DeleteStaffIfExists(int id)
        {
            var obj = await _db.Staffs.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null)
            {
                _logger.LogInformation("Deleting staff with ID: " + id);
                _db.Staffs.Remove(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<StaffDTO> GetStaff(int id)
        {
            _logger.LogInformation("Fetching Staff with ID: " + id);
            var obj = await _db.Staffs.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null)
            {
                return _mapper.Map<StaffDTO>(obj);
            }
            if (_db.Staffs.Any(x => x.Id != id)) throw new ApplicationException("This staff" + id + "does not exists");
            return new StaffDTO();
        }


        public async Task<IEnumerable<StaffDTO>> GetAllStaffs(int? id = null)
        {
            _logger.LogInformation("Fetching allStaffs from the database.");

            var staffEntities = await _db.Staffs.ToListAsync(); 

            if (staffEntities == null)
            {
                _logger.LogWarning("No staff data found in the database.");
                return Enumerable.Empty<StaffDTO>(); // Return an empty collection
            }

            return _mapper.Map<IEnumerable<StaffDTO>>(staffEntities);
        }


        public async Task<bool> UpdateStaffIfExists(StaffDTO objDTO)
        {
            var objFromDb = await _db.Staffs.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
            if (objFromDb != null)
            {

                objFromDb.FirstName = objDTO.FirstName;
                objFromDb.LastName = objDTO.LastName;
                objFromDb.Group = objDTO.Group;
                objFromDb.Position = objDTO.Position;
                objFromDb.Address = objDTO.Address;
                objFromDb.PhoneNumber = objDTO.PhoneNumber;
              

                _logger.LogInformation("Updating a staff.");
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
