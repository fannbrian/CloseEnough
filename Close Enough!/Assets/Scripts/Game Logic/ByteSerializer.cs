using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CloseEnough
{
	/// <summary>
	/// Serializes objects into byte array to send 
	/// </summary>
	public static class ByteSerializer<T>
	{
		public static byte[] Serialize(T obj)
		{
			if (obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);

			return ms.ToArray();
		}

		// Convert a byte array to an Object
		public static T Deserialize(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			memStream.Write(arrBytes, 0, arrBytes.Length);
			memStream.Seek(0, SeekOrigin.Begin);
			T obj = (T)binForm.Deserialize(memStream);

			return obj;
		}
	}
}