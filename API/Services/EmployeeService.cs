using API.Entities;
using API.Models;
using API.Uow;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IEmployeeService
    {
        IList<EmployeeModel> GetAll();
        EmployeeModel GetById(int id);
        EmployeeModel Update(int id, EmployeeModel model);
        EmployeeModel Insert(EmployeeModel model);
        EmployeeModel Delete(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private DbSet<Employee> EmployeeSet => _unitOfWork.Set<Employee>();

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IList<EmployeeModel> GetAll()
        {
            var result = EmployeeSet.AsNoTracking().ToList();
            return _mapper.Map<IList<EmployeeModel>>(result);
        }

        public EmployeeModel GetById(int id)
        {
            var result = EmployeeSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return _mapper.Map<EmployeeModel>(result);
        }

        public EmployeeModel Update(int id, EmployeeModel model)
        {
            var employee = _mapper.Map<Employee>(model);
            EmployeeSet.Update(employee);
            _unitOfWork.Save();
            return model;
        }

        public EmployeeModel Insert(EmployeeModel model)
        {
            var employee = _mapper.Map<Employee>(model);
            EmployeeSet.Add(employee);
            _unitOfWork.Save();
            return model;
        }

        public EmployeeModel Delete(int id)
        {
            var employee = EmployeeSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
            EmployeeSet.Remove(employee);
            _unitOfWork.Save();
            return _mapper.Map<EmployeeModel>(employee);
        }
    }
}
