using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Application.Abstractions.Token;
using TaskManagerAPI.Application.Dto;
using TaskManagerAPI.Application.Exceptions;
using TaskManagerAPI.Application.Features.Commands.UserCommand.Login;
using TaskManagerAPI.Application.Helpers;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IMailService _mailService;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenHandler, IMailService mailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _mailService = mailService;
    }
    
    public async Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime)
    {
        User? user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new NotFoundUserException();
        }

        SignInResult signInResult =await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (signInResult.Succeeded)
        {
            Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
            return token;

        }

        throw new AuthenticationErrorException();


    }

    public async Task PasswordResetAsync(string email)
    {
        User user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
           string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

         //  byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);

          // resetToken = WebEncoders.Base64UrlEncode(tokenBytes);
          
          //encode ediyoruz helper aracılığı ile
          resetToken = resetToken.UrlEncode();
          
           await _mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
        }
        
    }

    public async Task<bool> PasswordVerify(string resetToken, string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
            //resetToken = Encoding.UTF8.GetString(tokenBytes);
            //decode ediyoruz helper aracılığı ile
            
            resetToken = resetToken.UrlDecode();
            
           return await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword",resetToken);
        }
        return false;
    }
}