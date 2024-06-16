using Microsoft.EntityFrameworkCore;
using Moq;
using Tempo.Knight.Infra.Repositories;
using Tempo.Knight.UnitTests.Fake;
using Xunit;

namespace Tempo.Knight.UnitTests.Repositories
{
    public class KnightsRepositoryTests
    {
        private readonly Mock<DbSet<Domain.Model.Knight>> _mockSet;
        private readonly Mock<KnightDbContext> _mockContext;
        private readonly KnightsRepository _repository;

        public KnightsRepositoryTests()
        {
            _mockSet = new Mock<DbSet<Domain.Model.Knight>>();
            _mockContext = new Mock<KnightDbContext>();
            _mockContext.Setup(c => c.Knights).Returns(_mockSet.Object);
            _repository = new KnightsRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddKnight_ShouldCallAddAsync()
        {
            // Arrange
            var knight = KnightFake.KnightSingle();

            // Act
            await _repository.AddAsync(knight);

            // Assert
            _mockSet.Verify(m => m.AddAsync(knight, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task GetAll_ReturnsAllKnights()
        {
            // Arrange
            var knights = KnightFake.KnightList().AsQueryable();
            _mockSet.As<IQueryable<Domain.Model.Knight>>().Setup(m => m.Provider).Returns(knights.Provider);
            _mockSet.As<IQueryable<Domain.Model.Knight>>().Setup(m => m.Expression).Returns(knights.Expression);
            _mockSet.As<IQueryable<Domain.Model.Knight>>().Setup(m => m.ElementType).Returns(knights.ElementType);
            _mockSet.As<IQueryable<Domain.Model.Knight>>().Setup(m => m.GetEnumerator()).Returns(knights.GetEnumerator());

            // Act
            var result = await _repository.GetAllAsync(x => true);

            // Assert
            Assert.Equal(2, result.Count());
        }
    }

    // Example of a DbContext for EF Core
    public class KnightDbContext : DbContext
    {
        public DbSet<Domain.Model.Knight> Knights { get; set; }
    }
}
