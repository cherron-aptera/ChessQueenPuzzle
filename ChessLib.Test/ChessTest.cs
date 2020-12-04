using System;
using Xunit;

namespace ChessLib.Test
{
    public class ChessTest
    {
        [Fact]
        public void Test_0()
        {
            var board = new QueenBoard(5, new int[] { });

            Assert.Equal(25, board.CalculateSafes());
        }

        [Fact]
        public void Test_1()
        {
            var board = new QueenBoard(5, new int[] { 0 });

            Assert.Equal(12, board.CalculateSafes());
        }

        [Fact]
        public void Test_1_in_6()
        {
            var board = new QueenBoard(5, new int[] { 6 });

            Assert.Equal(10, board.CalculateSafes());
        }

        [Fact]
        public void Test5()
        {
            var board = new QueenBoard(5, new int[]{ 0, 1, 2, 3, 4 });

            Assert.Equal(0, board.CalculateSafes());
        }
    }
}
