using ToDo.Domain.Entities;

namespace ToDo.Domain.Test.Entities
{
    [TestFixture]
    public class BaseTests
    {
        private readonly DateTime date = DateTime.UtcNow;

        [Test]
        public void Constructor_Should_Set_Default_Properties()
        {
            var foo = new Base();

            Assert.That(foo.Id, Is.Not.Empty);
            Assert.GreaterOrEqual(foo.CreatedAt, date);
            Assert.That(foo.UpdatedAt, Is.Null);
            Assert.That(foo.IsActive, Is.True);
        }

        [Test]
        public void ChangeUpdateDate_Should_Update_When_IsActive_Is_True()
        {
            var foo = new Base();

            foo.ChangeUpdateDate();

            Assert.That(foo.UpdatedAt, Is.Not.Null);
            Assert.GreaterOrEqual(foo.CreatedAt, date);
        }

        [Test]
        public void ChangeUpdateDate_Should_Not_Update_When_IsActive_Is_False()
        {
            var foo = new Base();
            foo.Deactivate();

            foo.ChangeUpdateDate();

            Assert.That(foo.UpdatedAt, Is.Null);
        }

        [Test]
        public void Deactivate_Should_Set_IsActive_To_False()
        {
            var foo = new Base();

            foo.Deactivate();

            Assert.That(foo.IsActive, Is.False);
        }
    }
}
