using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chat_v1
{
    /// <summary>
    /// Статичний клас, що виконує серіалізацію\десеріалізацію простих об'єктів
    /// </summary>
    public static class SimpleFormatters
    {
        private static BinaryFormatter _formatter = new BinaryFormatter();
        public static byte[] ObjectToBytes(object files)
        {
            MemoryStream stream = new MemoryStream();
            _formatter.Serialize(stream, files);
            byte[] result = stream.ToArray();
            stream.Dispose();
            return result;
        }
        public static object BytesToObject(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            object result = _formatter.Deserialize(stream);
            stream.Dispose();
            return result;
        }
    }
}
