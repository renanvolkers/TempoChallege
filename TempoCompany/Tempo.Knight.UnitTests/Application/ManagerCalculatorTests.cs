using AutoMapper;
using Tempo.Knight.Application.Manager.Calculator;
using Tempo.Knight.Domain.Model;
using Tempo.Knight.Domain.Model.Calculator;
using Tempo.Knight.Dto.Responses;
using Tempo.Knight.UnitTests.Fake;
using Moq;
using Xunit;

namespace Tempo.Knight.UnitTests.Repositories
{
    public class ManagerCalculatorTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IAttackCalculator> _mockAttackCalculator;
        private readonly Mock<IExperienceCalculator> _mockExperienceCalculator;
        private readonly Mock<ICombatTrainingCalculator> _mockCombatTraining;
        private readonly ManagerCalculator _managerCalculator;
        private readonly ExperienceCalculator _experienceCalculator;


        public ManagerCalculatorTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockAttackCalculator = new Mock<IAttackCalculator>();
            _mockExperienceCalculator = new Mock<IExperienceCalculator>();
            _mockCombatTraining = new Mock<ICombatTrainingCalculator>();

            _managerCalculator = new ManagerCalculator(_mockMapper.Object, _mockAttackCalculator.Object, _mockExperienceCalculator.Object, _mockCombatTraining.Object);

            _experienceCalculator = new ExperienceCalculator();

        }

        [Fact]
        public void Calculator_CalculatesExperienceCorrectly()
        {
            // Arrange
            var knights = KnightFake.KnightList();

            var responseWeapons = new List<ResponseWeapon>(); // Assume it is mapped correctly
            _mockMapper.Setup(m => m.Map<List<ResponseWeapon>>(It.IsAny<List<Weapon>>())).Returns(responseWeapons);


            // Act
            var result = _managerCalculator.Calculator(knights);

            //Assert
                var responseKnight = result.First();
            Assert.Equal(100, responseKnight.Experience);

            _mockExperienceCalculator.Verify(e => e.CalculateExperience(It.IsAny<Domain.Model.Knight>()), Times.Once);
        }



        [Theory]

        [InlineData("2022-01-01", 0)] // Age < 7 should return 0 experience
        [InlineData("2017-01-01", 0)] // Age == 7 should return 0 experience
        [InlineData("2015-01-01", 176)] // Expected value based on the formula
        [InlineData("2014-01-01", 265)] // Expected value based on the formula
        [InlineData("2013-01-01", 353)] // Expected value based on the formula
        [InlineData("2011-01-01", 530)] // Expected value based on the formula
        [InlineData("2006-01-01", 972)] // Expected value based on the formula
        public void CalculateExperience_ShouldReturnExpectedExperience(string birthdayString, int expectedExperience)
        {
            // Arrange
            var birthday = DateTime.Parse(birthdayString);
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;

            var knight = new Domain.Model.Knight
            {
                Id = Guid.NewGuid(),
                Name = "Arthur",
                Nickname = "The Brave",
                Birthday = birthday,
                Weapons = new List<Weapon>(),
                KnightAttributes = new List<KnightAttribute>(),
                KeyAttribute = "Strength",
                CharacterType = "Warrior",
                CreatedBy= "system"
            };

            // Act
            var experience = _experienceCalculator.CalculateExperience(knight);

            // Assert
            Assert.Equal(expectedExperience, experience);
        }

        //Teste 1 
// InlineData("2011-01-01", 346) // Expected value based on the formula
// age=13
//(int) Math.Floor((knight.Age - 7) * Math.Pow(22, 1.45));
//(int) Math.Floor((6) * Math.Pow(22, 1.45));
//        Math.Floor((6        *        88.41)  )
//        Math.Floor((530,46)  )
//			        530

    }
}
