namespace Taks1.Entites;

public class Receiver
{
	public Guid Id { get; set; } = Guid.CreateVersion7();
	public string Name { get; set; } = string.Empty; 
	public string ResponsibleAuthority { get; set; } = string.Empty; 
	public string Address { get; set; } = string.Empty;
}
