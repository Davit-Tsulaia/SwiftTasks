namespace Tasks;

public class Task7
{
    private readonly PupleTeacherContext _context;

    public Task7(PupleTeacherContext context)
    {
        _context = context;
    }
    // თუ studenName ში ეწერება გიორგი იმუშავებს
    public Teacher[] GetAllTeachersByStudent(string studentName)
    {
        return _context.Teachers
            .Where(t => t.Pupils.Any(p => p.FirstName == studentName))
            .ToArray();
    }
}