
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FirstUnitTest
{

    public class GradingCalculatorXUnitTest
    {
        GradingCalculator gradingCalculator = new();

        // Opdracht - maak een globale variable van GradingCalcultator Instance
        // Correcte manier volgens oplossing

        // Private GradingCalculator gradingCalculator;
        // [Setup]
        // public void Setup()
        // {
        // gradingCalculator = new GradingCalculator();
        // }


        [Fact]
        public void GradingScore_InputScore95_InputAttendence90_OutputGradeA()
        {

            gradingCalculator.AttendancePercentage = 90;
            gradingCalculator.Score = 95;

            Assert.Equal("A", gradingCalculator.GetGrade());

            // Oplossing volgens de cursus is de getGrade() in een variable resultaat steken en dan deze in de Assert gebruiken
            // Assert.That(result, Is.EqualTo("A"));
        }

        [Fact]
        public void GradingScore_InputScore85_InputAttendence90_OutputGradeB()
        {

            gradingCalculator.AttendancePercentage = 90;
            gradingCalculator.Score = 85;

            Assert.Equal("B", gradingCalculator.GetGrade());

        }

        [Fact]
        public void GradingScore_InputScore65_InputAttendence55_OutputGradeC()
        {

            gradingCalculator.AttendancePercentage = 90;
            gradingCalculator.Score = 65;

            Assert.Equal("C", gradingCalculator.GetGrade());

        }

        [Fact]
        public void GradingScore_InputScore95_InputAttendence65_OutputGradeB()
        {

            gradingCalculator.AttendancePercentage = 65;
            gradingCalculator.Score = 95;

            Assert.Equal("B", gradingCalculator.GetGrade());

        }

        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        [Theory]
        public void GradingScore_InputScore_InputAttendence_OutputGrade(int Score, int Attendence, string expectedResult)
        {
            // Oplossing volgens de cursus zonder expectedResult en dan test Asserten volgens de voorgaande UnitTesten.

            gradingCalculator.AttendancePercentage = Attendence;
            gradingCalculator.Score = Score;

            var result = gradingCalculator.GetGrade();

            Assert.Equal(expectedResult, result);

        }

        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        [Theory]
        public void GradingScoreAllCases_InputScore_InputAttendence_OutputGrade(int Score, int Attendence, string expectedResult)
        {

            gradingCalculator.AttendancePercentage = Attendence;
            gradingCalculator.Score = Score;

            var result =  gradingCalculator.GetGrade();

            Assert.Equal(expectedResult,result);

        }


    }
}
