using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase{

    private readonly TwitterDBContext _context;

    public UserController ( TwitterDBContext context){
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult>CreateUser(User user){
       _context.Users.Add(user);
       await _context.SaveChangesAsync();
       return Ok(User);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult>GetUser(int id){
        var user= await _context.Users.FindAsync(id);
        if (user== null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}