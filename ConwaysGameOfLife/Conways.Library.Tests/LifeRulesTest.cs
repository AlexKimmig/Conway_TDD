using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways.Library.Tests
{ 
    //Any live cell with fewer than two live neighbours dies.
    //Any live cell with two or three neighbours lives.
    //Any live cell with more than three live neighbours dies.
    //Any dead cell with exactly three live neighbours becomes a live cell.

    [TestFixture]
    public class LifeRulesTest
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighbors_Dies([Values(0,1)] int liveNeighbors)
        {
            //Arrange
            var currentState = CellState.Alive;

            //Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void LiveCell_2Or3LiveNeighbors_Lives([Values(2,3)] int liveNeighbors)
        {
            //Arrange
            var currentState = CellState.Alive;

            //Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void LiveCell_MoreThan3LiveNeighbors_Dies([Range(4,8)] int liveNeighbors)
        {
            //Arrange
            var currentState = CellState.Alive;

            //Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_Exactly3LiveNeighbors_Lives([Values(3)] int liveNeighbors)
        {
            //Arrange
            var currentState = CellState.Dead;

            //Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void DeadCell_FewerThan3LiveNeighbors_StaysDead([Range(0, 2)] int liveNeighbors)
        {
            //Arrange
            var currentState = CellState.Dead;

            //Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_MoreThan3LiveNeighbors_StaysDead([Range(4, 8)] int liveNeighbors)
        {
            //Arrange
            var currentState = CellState.Dead;

            //Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(CellState.Dead, newState);
        }
    }
}
