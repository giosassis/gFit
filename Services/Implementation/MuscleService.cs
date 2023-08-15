using AutoMapper;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interface;
using static gFit.Context.DTOs.MuscleDto;

namespace gFit.Services.Implementation
{
    public class MuscleService : IMuscleService
    {
        private readonly IMapper _mapper;
        private readonly IMuscleRepository _muscleRepository;

        public MuscleService(IMapper mapper, IMuscleRepository muscleRepository)
        {
            _mapper = mapper;
            _muscleRepository = muscleRepository;
        }

        public async Task<IEnumerable<MuscleReadDTO>> GetAllMusclesAsync()
        {
            var muscles = await _muscleRepository.GetAllMusclesAsync();
            return _mapper.Map<IEnumerable<MuscleReadDTO>>(muscles);
        }

        public async Task<MuscleReadDTO> GetMuscleByIdAsync(Guid id)
        {
            var muscle = await _muscleRepository.GetMuscleByIdAsync(id);
            return _mapper.Map<MuscleReadDTO>(muscle);
        }

        public async Task<MuscleReadDTO> CreateMuscleAsync(MuscleCreateDTO muscleCreateDTO)
        {
            var muscle = _mapper.Map<Muscle>(muscleCreateDTO);

            var createdMuscle = await _muscleRepository.CreateMuscleAsync(muscle);
            return _mapper.Map<MuscleReadDTO>(createdMuscle);
        }

        public async Task<MuscleReadDTO> UpdateMuscleAsync(Guid id, MuscleUpdateDTO muscleUpdateDTO)
        {
            var existingMuscle = await _muscleRepository.GetMuscleByIdAsync(id);

            if (existingMuscle == null)
            {
                throw new Exception("Muscle not found");
            }

            _mapper.Map(muscleUpdateDTO, existingMuscle);

            var updatedMuscle = await _muscleRepository.UpdateMuscleAsync(id, existingMuscle);
            return _mapper.Map<MuscleReadDTO>(updatedMuscle);
        }

        public async Task DeleteMuscleAsync(Guid id)
        {
            var existingMuscle = await _muscleRepository.GetMuscleByIdAsync(id);

            if (existingMuscle == null)
            {
                return;
            }

            await _muscleRepository.DeleteMuscleAsync(id);
        }
    }
}
