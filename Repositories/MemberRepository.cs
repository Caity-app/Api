using System.Linq.Expressions;
using Api.Data;
using Api.Models;

namespace Api.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly CaityContext _context;
    
    public MemberRepository(CaityContext context)
    {
        _context = context;
    }
    
    public Member? GetById(int id)
    {
        return _context.Members.Find(id);
    }

    public IEnumerable<Member> Find(Expression<Func<Member, bool>> predicate)
    {
        return _context.Members.Where(predicate).AsEnumerable();
    }

    public void Add(Member entity)
    {
        _context.Members.Add(entity);
        Save();
    }

    public void Update(Member entity)
    {
        _context.Members.Update(entity);
        Save();
    }

    public void Delete(Member entity)
    {
        _context.Members.Remove(entity);
        Save();
    }
    
    private void Save()
    {
        _context.SaveChanges();
    }
}