using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            var data = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(data);
        }

        public IDataResult<List<UserForListDto>> GetAllDto()
        {
            var data = _userDal.GetAllDto();
            return new SuccessDataResult<List<UserForListDto>>(data);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var data = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(data);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var data = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(data);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
