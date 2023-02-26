namespace OnlineShop.Data;
public interface IUserRepository
{
}
public class UserRepository : IUserRepository
{
    private OnlineShopeDbContext _context;
    public UserRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }

}
