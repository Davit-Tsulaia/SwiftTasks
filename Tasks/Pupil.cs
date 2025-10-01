namespace Tasks;

public class Pupil
{
    public int PupilId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Class { get; set; }

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}