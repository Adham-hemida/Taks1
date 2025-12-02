using System.Net;

namespace Taks1.Entites;

public class Issuer
{
	public Guid Id { get; set; } = Guid.CreateVersion7(); // رقم التسجيل (Registration Number)
	public string Name { get; set; } = string.Empty; // اسم المصدر
	public string ResponsibleAuthority { get; set; } = string.Empty;
	public string Address { get; set; } = string.Empty;

}
