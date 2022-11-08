using System.Text;
using LibP2P.Utilities.Extensions;
using Multiformats.Hash;
using Multiformats.Hash.Algorithms;
using NUnit.Framework;

namespace LibP2P.Utilities.Tests
{
    public class MultihashTests
    {
        [Test]
        public void Compare_GivenEqualHashes_ReturnsZero()
        {
            var mh1 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello world"));
            var mh2 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello world"));

            Assert.AreEqual(mh1.Compare(mh2), 0);
        }

        [Test]
        public void Compare_GivenNonEqualHashes_ReturnsOneOrMinusOne()
        {
            var mh1 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello world"));
            var mh2 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello_world!"));

            Assert.AreNotEqual(mh1.Compare(mh2), 0);
        }
    }
}
