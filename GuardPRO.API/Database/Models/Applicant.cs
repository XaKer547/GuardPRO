namespace GuardPRO.API.Database.Models;

public class Applicant
{
    public int Id { get; set; }
    public string Sername { get; set; }
    public string Name { get; set; }
    public string Patromic { get; set; }
    public Department Department { get; set; }
    public Otdel Otdel { get; set; }
    public int Number { get; set; }
}
