namespace MicroerviceOrnegi.Shared.Services
{
    public class IIdentityServiceFake : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("332ee8cd-f3f6-49fa-92e2-5fdb188b3377");
        public string UserName => "umutatras";
    }
}
