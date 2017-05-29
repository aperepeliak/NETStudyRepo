using System;
using Moq;
using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    public class CartRepositoryTests
    {
        private MockRepository _mockRepo;
        private Mock<ICartDatabase> _db;
        private Cart _cart;
        private CartRepository _repo;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new MockRepository(MockBehavior.Strict);
            _db = _mockRepo.Create<ICartDatabase>();
            _cart = new Cart();
            _repo = new CartRepository(_db.Object);
        }

        [Test]
        public void RepoCanSaveCart()
        {
            _db.Setup(db => db.SaveCart(_cart)).Returns(12345);

            var result = _repo.SaveCart(_cart);

            Assert.That(result, Is.EqualTo(12345));
        }

        [Test]
        public void ExceptionsInSaveCartReturnZero()
        {
            _db.Setup(db => db.SaveCart(_cart)).Throws<ApplicationException>();

            var result = _repo.SaveCart(_cart);

            Assert.That(result, Is.EqualTo(0));
        }
    }

    public class CartRepository
    {
        private ICartDatabase _db;

        public CartRepository(ICartDatabase db)
        {
            _db = db;
        }

        public long SaveCart(Cart cart)
        {
            long returnValue;
            try
            {
                returnValue = _db.SaveCart(cart);
            }
            catch (Exception)
            {
                returnValue = 0;
            }

            return returnValue;
        }
    }
}
