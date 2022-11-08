using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using LibP2P.Utilities.Extensions;
using NUnit.Framework;

namespace LibP2P.Utilities.Tests
{
    public class StreamTests
    {
        private static void GenerateRandomBytes(byte[] data)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }
        }

        [Test]
        public void AsReader_GivenMemoryStream_CanReadAll()
        {
            var bytes = new byte[4096];
            GenerateRandomBytes(bytes);
            using (var memory = new MemoryStream(bytes))
            {
                var reader = memory.AsReader();
                var buffer = new byte[bytes.Length];
                var bytesRead = reader.ReadFull(buffer);

                Assert.AreEqual(bytesRead, bytes.Length);
                Assert.AreEqual(buffer, bytes);
            }
        }

        [Test]
        public async Task AsReader_GivenMemoryStream_CanReadAllAsync()
        {
            var bytes = new byte[4096];
            GenerateRandomBytes(bytes);
            using (var memory = new MemoryStream(bytes))
            {
                var reader = memory.AsReader();
                var buffer = new byte[bytes.Length];
                var bytesRead = await reader.ReadFullAsync(buffer);

                Assert.AreEqual(bytesRead, bytes.Length);
                Assert.AreEqual(buffer, bytes);
            }
        }

        [Test]
        public void AsWriter_GivenMemoryStream_CanWriteAll()
        {
            using (var memory = new MemoryStream())
            {
                var writer = memory.AsWriter();
                var bytes = new byte[4096];
                GenerateRandomBytes(bytes);
                writer.Write(bytes, 0, bytes.Length);

                Assert.AreEqual(memory.ToArray(), bytes);
            }
        }

        [Test]
        public async Task AsWriter_GivenMemoryStream_CanWriteAllAsync()
        {
            using (var memory = new MemoryStream())
            {
                var writer = memory.AsWriter();
                var bytes = new byte[4096];
                GenerateRandomBytes(bytes);
                await writer.WriteAsync(bytes, 0, bytes.Length, CancellationToken.None);

                Assert.AreEqual(memory.ToArray(), bytes);
            }
        }
    }
}
