using System.Text.Json.Serialization;
using System.Text.Json;

namespace Taks1.Helper;


public class DecimalFivePlacesConverter : JsonConverter<decimal>
{
	public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.GetDecimal();
	public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
	{

		writer.WriteStringValue(value.ToString("F5"));
	}
}