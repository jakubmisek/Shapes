﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SixLabors.Shapes.Tests
{
    using System.Numerics;

    public class LinearLineSegmentTests
    {
        [Fact]
        public void SingleSegmentConstructor()
        {
            LinearLineSegment segment = new LinearLineSegment(new Vector2(0, 0), new Vector2(10, 10));
            System.Collections.Immutable.ImmutableArray<Vector2> flatPath = segment.Flatten();
            Assert.Equal(2, flatPath.Length);
            Assert.Equal(new Vector2(0, 0), flatPath[0]);
            Assert.Equal(new Vector2(10, 10), flatPath[1]);
        }

        [Fact]
        public void MustHaveAtleast2Points()
        {
            ArgumentOutOfRangeException error = Assert.Throws<ArgumentOutOfRangeException>(() => new LinearLineSegment(new[] { new Vector2(0, 0) }));
        }

        [Fact]
        public void NullPointsArrayThrowsCountException()
        {
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => {
                new LinearLineSegment((Vector2[])null);
            });
        }
    }
}
