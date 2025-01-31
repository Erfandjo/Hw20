namespace App.Domain.Core.Hw20.User.AppService
{
    public interface IUserAppService
    {
        public Task<bool> Login(string phoneNumber, string nationalCode , CancellationToken cancellation);
        
    }
}
