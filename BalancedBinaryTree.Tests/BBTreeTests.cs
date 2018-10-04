using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace BalancedBinaryTree.Tests
{
    public class BBTreeTests
    {
        [Fact]
        public void Ctor_NoArguments_ShouldCreateEmptyTree()
        {
            var sut = new BBTree<int>();

            sut.Contains(5).Should().BeFalse();

        }

        [Fact]
        public void Contains_OneElementAdded_ReturnsTrue()
        {
            var sut = new BBTree<int>();

            sut.Add(5);

            sut.Contains(5).Should().BeTrue();
        }

        [Fact]
        public void CumulativeAddingElementShouldContainThatElement()
        {
            var sut = new BBTree<int>();
            var elements = new List<int>
            {
                5, 15, -5, default(int), int.MaxValue, 3
            };

            elements.ForEach( element => sut.Add(element));

            elements.ForEach(element => sut.Contains(element).Should().BeTrue());}
        }
}
