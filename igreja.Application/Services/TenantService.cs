using AutoMapper;
using igreja.Application.DTOs.Tenant;
using igreja.Application.Interfaces;
using igreja.Domain.Common;
using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
namespace igreja.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public TenantService(ITenantRepository tenantRepository, IMapper mapper)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TenantDto>>> GetAllTenantsAsync()
        {
            var tenants = await _tenantRepository.GetAllAsync();
            var tenantsDto = _mapper.Map<IEnumerable<TenantDto>>(tenants);

            return new ApiResponse<IEnumerable<TenantDto>>(tenantsDto);
        }

        public async Task<ApiResponse<TenantDto?>> GetTenatByIdAsync(Guid id)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);
            if (tenant == null)
                return new ApiResponse<TenantDto?>("O Cliente não foi encontrado.", false);

            var tenantResult = _mapper.Map<TenantDto>(tenant);

            return new ApiResponse<TenantDto?>(tenantResult);
        }

        public async Task<ApiResponse<bool>> AddTenatAsync(TenantAddDto tenantAddDto)
        {
            if (string.IsNullOrEmpty(tenantAddDto.Name))
                return new ApiResponse<bool>("O nome do Cliente é obrigatório.", false);

            try
            {
                var tenantAdd = _mapper.Map<Tenant>(tenantAddDto);

                tenantAdd.Deleted = false;
                await _tenantRepository.AddAsync(tenantAdd);

                return new ApiResponse<bool>("Cliente adicionada com sucesso.", true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>($"Erro ao adicionar tenant: {ex.Message}", false);
            }
        }

        public async Task<ApiResponse<bool>> UpdateTenantAsync(Guid id, TenantUpdateDto tenantUpdateDto)
        {
            var tenantEntity = await _tenantRepository.GetByIdAsync(tenantUpdateDto.Id);
            if (tenantEntity == null)
                return new ApiResponse<bool>("O Cliente solicitado não foi encontrado.", false);

            var tenantEntityAdd = _mapper.Map<Tenant>(tenantUpdateDto);

            tenantEntityAdd.Changed = DateTime.Now;

            await _tenantRepository.UpdateAsync(tenantEntityAdd);
            return new ApiResponse<bool>("Cliente atualizado com sucesso.", true);
        }

        public async Task<ApiResponse<bool>> DeleteTenantAsync(Guid id)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);
            if (tenant == null)
                return new ApiResponse<bool>("O Cliente não foi encontrado.", false);

            tenant.Deleted = true;
            tenant.Changed = DateTime.Now;
            await _tenantRepository.DeleteLogicalAsync(tenant);

            return new ApiResponse<bool>("Cliente excluído com sucesso.", true);
        }


    }
}
