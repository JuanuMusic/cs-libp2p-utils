using System;
using LibP2P.Utilities.Extensions;
using NUnit.Framework;

namespace LibP2P.Utilities.Tests
{
    public class TupleTests
    {
        [Test]
        public void Swap_GivenTwoValues_ReturnsSwappedTuple()
        {
            var tuple = Tuple.Create(1, 2);
            
            Assert.AreEqual(tuple.Swap(), Tuple.Create(2, 1));
        }
    }
}
