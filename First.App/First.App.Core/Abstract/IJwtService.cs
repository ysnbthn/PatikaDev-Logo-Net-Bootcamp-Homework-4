using First.App.Business.DTOs;

namespace First.App.Business.Abstract
{
    public interface IJwtService
    {
        TokenDto Authenticate(UserDto user);
    }
}
