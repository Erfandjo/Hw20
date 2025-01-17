
using App.Domain.Core.Hw20.User.Entities;

namespace App.Infra.Data.Db.Storage.Memory
{
    public static class CurrentUser
    {
        public static User OnlineUser { get; set; }
    }
}
