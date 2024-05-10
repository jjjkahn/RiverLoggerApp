using AutoMapper;
using RiverLoggerApi.Helpers;
using RiverLoggerApi.Models;
using RiverLoggerApi.Repository.DbModels;
using RiverLoggerApi.Repository.Repository.UserRepository;
namespace RiverLoggerApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<User> GetByEmail(string email)
        {
            var userDbos = await _userRepository.GetByEmail(email);
            return _mapper.Map<User>(userDbos);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var userDbos = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<User>>(userDbos);
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            return _mapper.Map<User>(user);
        }

        public async Task Create(User model)
        {
            // validate
            if (await _userRepository.GetByEmail(model.Email!) != null)
                throw new AppException("User with the email '" + model.Email + "' already exists");

            //map model to new user object
            var user = _mapper.Map<UserDbo>(model);

            // hash password????? 

            //save user
            await _userRepository.Create(user);
        }

        public async Task Update(Guid id, User model)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            // validate
            var emailChanged = !string.IsNullOrEmpty(model.Email) && user.Email != model.Email;
            if (emailChanged && await _userRepository.GetByEmail(model.Email!) != null)
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                //  user.PasswordHash = BCrypt.HashPassword(model.Password);

                // copy model props to user
                _mapper.Map(model, user);

            // save user
            await _userRepository.Update(user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
