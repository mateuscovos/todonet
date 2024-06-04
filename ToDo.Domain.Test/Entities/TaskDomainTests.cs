using ToDo.Domain.Entities;

namespace ToDo.Domain.Test.Entities
{
    [TestFixture]
    public class TaskDomainTests
    {
        [Test]
        public void New_Should_CreateTask_With_Valid_Properties()
        {
            var name = "Buy something";
            var description = "Foo, bar, etc";
            var expireAt = DateTime.UtcNow.AddDays(2);

            var foo = TaskDomain.New(name, description, expireAt);

            Assert.That(foo.Name, Is.EqualTo(name));
            Assert.That(foo.Description, Is.EqualTo(description));
            Assert.That(foo.IsDone, Is.False);
            Assert.That(foo.ExpireAt, Is.EqualTo(expireAt));
        }

        [Test]
        public void New_Should_Throw_ArgumentNullException_When_Name_Is_Null()
        {
            var description = "Foo, Bar";
            var expireAt = DateTime.UtcNow.AddDays(2);

            Assert.Throws<ArgumentException>(() => TaskDomain.New(null, description, expireAt));
        }

        [Test]
        public void New_Should_Throw_ArgumentNullException_When_Description_Is_Null()
        {
            var name = "Something";
            var expireAt = DateTime.UtcNow.AddDays(2);

            Assert.Throws<ArgumentException>(() => TaskDomain.New(name, null, expireAt));
        }

        [Test]
        public void New_Should_Throw_ArgumentException_When_Name_Length_Is_Less_Than_Three()
        {
            var name = "Foo";
            var description = "Foo, bar";
            var expireAt = DateTime.UtcNow.AddDays(2);

            Assert.Throws<ArgumentException>(() => TaskDomain.New(name, description, expireAt));
        }

        [Test]
        public void New_Should_Throw_ArgumentException_When_Description_Length_Is_Less_Than_Three()
        {
            var name = "Something";
            var description = "bar";
            var expireAt = DateTime.UtcNow.AddDays(2);

            Assert.Throws<ArgumentException>(() => TaskDomain.New(name, description, expireAt));
        }

        [Test]
        public void New_Should_Throw_ArgumentException_When_ExpireAt_Is_In_The_Past()
        {
            var name = "Create a todo app 👀";
            var description = "oof, foo, bar";
            var expireAt = DateTime.UtcNow.AddDays(-1);

            Assert.Throws<ArgumentException>(() => TaskDomain.New(name, description, expireAt));
        }

        [Test]
        public void ChangeName_Should_Update_Name_When_Task_IsNotDone_And_IsActive()
        {
            var name = "Something Something";
            var description = "Something, foo, abar";
            var expireAt = DateTime.UtcNow.AddDays(2);
            var foo = TaskDomain.New(name, description, expireAt);

            var newName = "Buy Something";

            foo.ChangeName(newName);

            Assert.That(foo.Name, Is.EqualTo(newName));
        }
    }
}
