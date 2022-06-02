using AutoMapper;
using AzureAPI.Core.Exceptions;
using AzureAPI.Domain.Entity;
using AzureAPI.Infra.Interfaces;
using AzureAPI.Service.DTO;
using AzureAPI.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureAPI.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.GetAll();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetById(long id)
        {
            var user = await _userRepository.GetById(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);
            if (userExists != null)
            {
                throw new DomainException("Já existe um usuário cadastrado com o email informado");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByEmail(name);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetById(userDTO.Id);

            if (userExists == null)
                throw new DomainException("Não existe nenhum usuário com o ID informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }
    }
}
