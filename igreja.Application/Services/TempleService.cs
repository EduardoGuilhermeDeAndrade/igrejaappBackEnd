using AutoMapper;
using igreja.Application.DTOs.Temple;
using igreja.Application.Interfaces;
using igreja.Domain.Common;
using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
namespace igreja.Application.Services
{
    public class TempleService : ITempleService
    {
        private readonly ITempleRepository _templeRepository;
        private readonly IMapper _mapper;

        public TempleService(ITempleRepository templeRepository, IMapper mapper)
        {
            _templeRepository = templeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TempleDto>>> GetAllTemplesAsync()
        {
            var temples = await _templeRepository.GetAllAsync();
            var templesDto = _mapper.Map<IEnumerable<TempleDto>>(temples);

            return new ApiResponse<IEnumerable<TempleDto>>(templesDto);
        }

        public async Task<ApiResponse<TempleDto?>> GetTempleByIdAsync(Guid id)
        {
            var temple = await _templeRepository.GetByIdAsync(id);
            if (temple == null)
                return new ApiResponse<TempleDto?>("O Templo não foi encontrado.", false);

            var templeResult = _mapper.Map<TempleDto>(temple);

            return new ApiResponse<TempleDto?>(templeResult);
        }

        public async Task<ApiResponse<IEnumerable<TempleDto>>> GetTemplesByChurchAsync(Guid churchId)
        {
            var temples = await _templeRepository.GetByChurchIdAsync(churchId);
            var templesDto = _mapper.Map<IEnumerable<TempleDto>>(temples);

            return new ApiResponse<IEnumerable<TempleDto>>(templesDto);
        }

        public async Task<ApiResponse<bool>> AddTempleAsync(TempleAddDto templeAddDto)
        {
            if (string.IsNullOrEmpty(templeAddDto.Name))
                return new ApiResponse<bool>("O nome do Templo é obrigatório.", false);

            try
            {
                var templeAdd = _mapper.Map<Temple>(templeAddDto);

                templeAdd.Deleted = false;
                await _templeRepository.AddAsync(templeAdd);

                return new ApiResponse<bool>("Templo adicionada com sucesso.", true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>($"Erro ao adicionar temple: {ex.Message}", false);
            }
        }

        public async Task<ApiResponse<bool>> UpdateTempleAsync(Guid id, TempleUpdateDto templeUpdateDto)
        {
            var templeEntity = await _templeRepository.GetByIdAsync(templeUpdateDto.Id);
            if (templeEntity == null)
                return new ApiResponse<bool>("O templo solicitado não foi encontrado.", false);

            var templeEntityAdd = _mapper.Map<Temple>(templeUpdateDto);

            templeEntityAdd.Changed = DateTime.Now;

            await _templeRepository.UpdateAsync(templeEntityAdd);
            return new ApiResponse<bool>("Templo atualizado com sucesso.", true);
        }

        public async Task<ApiResponse<bool>> DeleteTempleAsync(Guid id)
        {
            var temple = await _templeRepository.GetByIdAsync(id);
            if (temple == null)
                return new ApiResponse<bool>("O templo não foi encontrado.", false);

            temple.Deleted = true;
            temple.Changed = DateTime.Now;
            await _templeRepository.DeleteLogicalAsync(temple);

            return new ApiResponse<bool>("Templo excluído com sucesso.", true);
        }


    }
}
