using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
    [TestFixture]
    public class GradingCalculatorNUnitTest
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


        [Test]
        public void GradingScore_InputScore95_InputAttendence90_OutputGradeA()
        {

            gradingCalculator.AttendancePercentage = 90;
            gradingCalculator.Score = 95;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("A"));

            // Oplossing volgens de cursus is de getGrade() in een variable resultaat steken en dan deze in de Assert gebruiken
            // Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GradingScore_InputScore85_InputAttendence90_OutputGradeB()
        {

            gradingCalculator.AttendancePercentage = 90;
            gradingCalculator.Score = 85;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("B"));

        }

        [Test]
        public void GradingScore_InputScore65_InputAttendence55_OutputGradeC()
        {

            gradingCalculator.AttendancePercentage = 90;
            gradingCalculator.Score = 65;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("C"));

        }

        [Test]
        public void GradingScore_InputScore95_InputAttendence65_OutputGradeB()
        {

            gradingCalculator.AttendancePercentage = 65;
            gradingCalculator.Score = 95;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("B"));

        }

        [TestCase(95, 55, ExpectedResult = "F")] 
        [TestCase(65, 55, ExpectedResult = "F")] 
        [TestCase(50, 90, ExpectedResult = "F")] 
        [Test]
        public string GradingScore_InputScore_InputAttendence_OutputGrade(int Score, int Attendence)
        {
            // Oplossing volgens de cursus zonder expectedResult en dan test Asserten volgens de voorgaande UnitTesten.
            
            gradingCalculator.AttendancePercentage = Attendence;
            gradingCalculator.Score = Score;

            return gradingCalculator.GetGrade();

        }

        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        [Test]
        public string GradingScoreAllCases_InputScore_InputAttendence_OutputGrade(int Score, int Attendence)
        {
            // Oplossing volgens de cursus zonder expectedResult en dan test Asserten volgens de voorgaande UnitTesten.

            gradingCalculator.AttendancePercentage = Attendence;
            gradingCalculator.Score = Score;

            return gradingCalculator.GetGrade();

        }


    }
}
