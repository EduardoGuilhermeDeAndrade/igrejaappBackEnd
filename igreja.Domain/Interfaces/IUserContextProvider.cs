namespace igreja.Domain.Interfaces
{
    public interface IUserContextProvider
    {
        Guid GetCurrentUserId();
        /*sso permite desacoplar o serviço ou a lógica de acesso ao ID do usuário 
         * logado diretamente do ApplicationDbContext.*/
    }
}