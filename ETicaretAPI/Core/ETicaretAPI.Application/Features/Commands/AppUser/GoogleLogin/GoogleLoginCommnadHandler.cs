using ETicaretAPI.Application.Abstraction.Services;
using MediatR;


namespace ETicaretAPI.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommnadHandler : IRequestHandler<GoogleLoginCommnadRequest, GoogleLoginCommnadResponse>
    {
        readonly IAuthService _authService;

        public GoogleLoginCommnadHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommnadResponse> Handle(GoogleLoginCommnadRequest request, CancellationToken cancellationToken)
        {
           var token = await _authService.GoogleLoginAsync(request.IdToken, 900);
            return new()
            {
                Token = token
            };
        }
    }
}
