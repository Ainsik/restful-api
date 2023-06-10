namespace core.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Specialization { get; set; }
    public virtual Address Address { get; set; }
}