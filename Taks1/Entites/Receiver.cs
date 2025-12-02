using System.Net;

namespace Taks1.Entites;

public class Receiver
{
	public Guid Id { get; set; } = Guid.CreateVersion7();
	public string Name { get; set; } = string.Empty; // اسم المستلم
	public string ResponsibleAuthority { get; set; } = string.Empty; // نوع الجهة
	public string Address { get; set; } = string.Empty;
}
