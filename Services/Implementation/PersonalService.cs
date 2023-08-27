using System.Text;
using AutoMapper;
using gFit.Models;
using gFit.Repositories.Interface;
using System.Security.Cryptography;
using gFit.Validator;
using static gFit.Context.DTOs.PersonalDto;
using gFit.Services.Interface;


namespace gFit.Services.Implementation
{
    public class PersonalService : IPersonalService
    {
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;
     

        public PersonalService(IMapper mapper, IPersonalRepository personalRepository)
        {
            _mapper = mapper;
            _personalRepository = personalRepository;
        }

        public async Task<IEnumerable<PersonalReadDTO>> GetAllPersonalsAsync()
        {
            var personals = await _personalRepository.GetAllPersonalsAsync();
            return _mapper.Map<IEnumerable<PersonalReadDTO>>(personals);
        }

        public async Task<PersonalReadDTO> GetPersonalByIdAsync(Guid id)
        {
            var personal = await _personalRepository.GetPersonalByIdAsync(id);
            return _mapper.Map<PersonalReadDTO>(personal);
        }

        public async Task<PersonalReadDTO> GetPersonalByEmailAsync(string email)
        {
            var personal = await _personalRepository.GetPersonalByEmailAsync(email);
            Console.WriteLine(personal);
            return _mapper.Map<PersonalReadDTO>(personal);
        }
        public async Task<PersonalReadDTO> CreatePersonalAsync(PersonalCreateDTO personalCreateDTO)
        {
            // Validation of email format 
            if (!IsValidEmail(personalCreateDTO.Email))
            {
                throw new ArgumentException("Invalid email format");
            }

            // Security Requirements of password 
            if (!PasswordValidator.Validate(personalCreateDTO.Password))
            {
                throw new ArgumentException("Password must meet security requirements.");
            }

            // Check if CREF exists 
            var crefExists = await _personalRepository.CheckCrefExists(personalCreateDTO.Cref);
            if (crefExists)
            {
                throw new ArgumentException("CREF already exists.");
            }

            string hashedPassword = PasswordHasher(personalCreateDTO.Password);

            var personal = _mapper.Map<Personal>(personalCreateDTO);
            personal.Password = hashedPassword;
            personal.CreatedAt = DateTime.UtcNow;
            personal.UpdatedAt = DateTime.UtcNow;
            personal.EmailConfirmationToken = Guid.NewGuid().ToString();

            var createdPersonal = await _personalRepository.CreatePersonalAsync(personal);
<<<<<<< HEAD

=======
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
            return _mapper.Map<PersonalReadDTO>(createdPersonal);
        }

        public async Task<PersonalReadDTO> UpdatePersonalAsync(Guid id, PersonalUpdateDTO personalUpdateDTO)
        {
            var existingPersonal = await _personalRepository.GetPersonalByIdAsync(id);

            if (existingPersonal == null)
            {
                throw new Exception("Personal not found");
            }

<<<<<<< HEAD
<<<<<<< HEAD
            // Update the existingPersonal object with data from personalUpdateDTO
            existingPersonal.Name = personalUpdateDTO.Name;
            existingPersonal.Email = personalUpdateDTO.Email;
            existingPersonal.Description = personalUpdateDTO.Description;
            existingPersonal.IsEmailConfirmed = personalUpdateDTO.IsEmailConfirmed;
            existingPersonal.EmailConfirmationToken = personalUpdateDTO.EmailConfirmationToken;
=======
            existingPersonal.Name = personalUpdateDTO.Name;
            existingPersonal.Email = personalUpdateDTO.Email;
            existingPersonal.Description = personalUpdateDTO.Description;
            existingPersonal.IsEmailConfirmed = true;
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
=======
            existingPersonal.IsEmailConfirmed = personalUpdateDTO.IsEmailConfirmed;
>>>>>>> 003d765eabac9824d2c7ed685066ad4f1344f2e7
            existingPersonal.UpdatedAt = personalUpdateDTO.UpdatedAt;

            var updatedPersonal = await _personalRepository.UpdatePersonalAsync(id, existingPersonal);
            return _mapper.Map<PersonalReadDTO>(updatedPersonal);
        }

        public async Task DeletePersonalAsync(Guid id)
        {
            var existingPersonal = await _personalRepository.GetPersonalByIdAsync(id);

            if (existingPersonal == null)
            {
                return;
            }

            await _personalRepository.DeletePersonalAsync(id);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static string PasswordHasher(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}