namespace App.Domain.Core.Hw20.User.AppService
{
    public interface IUserAppService
    {
        public bool Login(string phoneNumber, string nationalCode);
        
    }
}
