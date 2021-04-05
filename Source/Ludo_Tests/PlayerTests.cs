using FluentAssertions;
using LudoGame;
using System.Collections.Generic;
using Xunit;

namespace Ludo_Tests
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerIsCreated()
        {
            var square = new Square(1);
            Player actual = new("green", square);
            actual.Should().BeOfType<Player>();
            actual.StartSquare.Should().BeEquivalentTo(square);
            actual.Color.Should().BeEquivalentTo("green");
        }

        [Fact]
        public void PlayerCanOnlySelectUniqueColor()
        {
            var square = new Square(1);

            List<string> actualColors = new();

            actualColors.Add(Board.ChooseColor("Green"));
            actualColors.Add(Board.ChooseColor("Green"));
            actualColors.Add(Board.ChooseColor("Blue"));

            actualColors.Should().OnlyHaveUniqueItems();
        }
    }
}