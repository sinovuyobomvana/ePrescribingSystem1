//using EPrescribingSystem.Areas.Admin.ViewModel;
//using EPrescribingSystem.Areas.Doctor.ViewModel;
//using EPrescribingSystem.Data;
//using EPrescribingSystem.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace EPrescribingSystem.Areas.Doctor.Data.Repository
//{
//    public class ConditionRepository : IConditionRepository
//    {

//        private readonly IConditionRepository _conditionRepository;
//        private readonly EprescribingDBContext _context;

//        public ConditionRepository(EprescribingDBContext context)
//        {
//            _context = context;
//        }
//        public async Task AddAsync(ConditionViewModel condition)
//        {
//            await _context.ConditionDiagnoses.AddAsync(condition.condition);
//            await _context.SaveChangesAsync();
//        }

//        public Task AddAsync(MedicalPracticeViewModel medicalPractice)
//        {
//            throw new System.NotImplementedException();
//        }

//        public ConditionDiagnosis Delete(ConditionDiagnosis conditionDiagnosis)
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task DeleteAsync(int id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public async Task<IEnumerable<ConditionDiagnosis>> GetAllAsync()
//        {
//            var result = await _context.ConditionDiagnoses.Include(x => x.ConditionID).ToListAsync();
//            return result;
//        }

//        public ConditionDiagnosis GetById(int id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<ConditionDiagnosis> GetByIdAsync(int id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<MedicalPractice> UpdateAsync(ConditionDiagnosis newConditionDiagnosis)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
