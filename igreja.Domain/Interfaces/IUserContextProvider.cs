namespace igreja.Domain.Interfaces
{
    public interface IUserContextProvider
    {
        Guid GetCurrentUserId();
        Guid GetCurrentTenantId();

        //void ClearCurrentUser();
        /*Isso permite desacoplar o serviço ou a lógica de acesso ao ID do usuário e Tenant Id
         * logado diretamente do ApplicationDbContext.*/
        //void SetCurrentUser(Guid userId, Guid tenantId);

    }
}