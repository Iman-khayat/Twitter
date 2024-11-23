public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> RegisterUserAsync(User user)
    {
        // Hash the password before saving
        user.PasswordHash = _passwordHasher.HashPassword(user);
        return await _userRepository.AddUserAsync(user);
    }

    public async Task<User> LoginUserAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user != null && _passwordHasher.VerifyHashedPassword(user, password))
        {
            return user;
        }
        return null;
    }

    // ... other methods for password reset, profile updates, etc.
}