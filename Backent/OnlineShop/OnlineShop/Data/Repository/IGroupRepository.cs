namespace OnlineShop.Data;

public interface IGroupRepository
{

}
public class GroupRepository : IGroupRepository
{
    private OnlineShopeDbContext _context;
    public GroupRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }
}
