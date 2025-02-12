using AutoMapper;
using igreja.Application.DTOs.Church;
using igreja.Application.DTOs.MyTask;
using igreja.Application.Interfaces;
using igreja.Domain.Common;
using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Infrastructure.Repositories;

namespace igreja.Application.Services
{
    public class ChurchService : IChurchService
    {
        private readonly IChurchRepository _churchRepository;
        private readonly ITempleRepository _templeRepository;
        private readonly IMapper _mapper;

        public ChurchService(IChurchRepository churchRepository, IMapper mapper, ITempleRepository templeRepository)
        {
            _churchRepository = churchRepository;
            _mapper = mapper;
            _templeRepository = templeRepository;
        }

        public async Task<ApiResponse<IEnumerable<ChurchDto>>> GetAllChurchsAsync()
        {
            var church = await _churchRepository.GetAllAsync();
            var churchDtoResponse = _mapper.Map<IEnumerable<ChurchDto>>(church);

            return new ApiResponse<IEnumerable<ChurchDto>>(churchDtoResponse);
        }

        public async Task<ApiResponse<IEnumerable<ChurchWithTempleDto>>> GetAllWithTemplesNameAsync()
        {
            var church = await _churchRepository.GetAllWithTempleNameAsync();

            var churchWithTempleDtoResponse = _mapper.Map<IEnumerable<ChurchWithTempleDto>>(church);

            return new ApiResponse<IEnumerable<ChurchWithTempleDto>>(churchWithTempleDtoResponse);
        }

        public async Task<ApiResponse<ChurchDto?>> GetChurchByIdAsync(Guid id)
        {
            var church = await _churchRepository.GetByIdAsync(id);
            if (church == null)
                return new ApiResponse<ChurchDto?>("Igreja não encontrada.", false);

            var churchDto = _mapper.Map<ChurchDto>(church);

            return new ApiResponse<ChurchDto?>(churchDto);
        }

        public async Task<ApiResponse<bool>> AddChurchAsync(ChurchAddDto churchAddDto)
        {
            if (string.IsNullOrEmpty(churchAddDto.Name))
                return new ApiResponse<bool>("O nome da igreja é obrigatório.", false);

            try
            {
                var churchAdd = _mapper.Map<Church>(churchAddDto);

                churchAdd.Deleted = false;
                await _churchRepository.AddAsync(churchAdd);

                return new ApiResponse<bool>("Igreja adicionada com sucesso.", true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>($"Erro ao adicionar igreja: {ex.Message}", false);
            }
        }

        public async Task<ApiResponse<bool>> UpdateChurchAsync(Guid id, ChurchUpdateDto churchUpdateDto)
        {
            var churchEntity = await _churchRepository.GetByIdAsync(churchUpdateDto.Id);
            if (churchEntity == null)
                return new ApiResponse<bool>("A igreja solicitada não foi encontrada.", false);

            var churchEntityAdd = _mapper.Map<Church>(churchUpdateDto);

            churchEntityAdd.Changed = DateTime.Now;

            await _churchRepository.UpdateAsync(churchEntityAdd);
            return new ApiResponse<bool>("Igreja atualizada com sucesso.", true);
        }

        public async Task<ApiResponse<bool>> DeleteChurchAsync(Guid id)
        {
            var church = await _churchRepository.GetByIdAsync(id);
            if (church == null)
                return new ApiResponse<bool>("O nome da igreja é obrigatório.", false);

            //Se a igreja tiver templo, não pode excluir
            var temple = await _templeRepository.GetByChurchIdAsync(church.Id);
            if (temple.Count() != 0)
                return new ApiResponse<bool>("Esta igreja possui templos cadastrados. É necessário apaga-los primeiro.", false);

            //Os movimentos financeiros relacionados vão continuar funcionando porque se trata de deleção lógica
            church.Deleted = true;
            church.Changed = DateTime.Now;
            await _churchRepository.DeleteLogicalAsync(church);
            return new ApiResponse<bool>("Igreja deletada com sucesso.", true);
        }
    }
}
