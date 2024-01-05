using ConsoleApp2;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RingNode_InitializesCorrectly() 
        {
            int value = 5;
            var node = new RingNode<int>(value); 

            Assert.That(node.Value, Is.EqualTo(value));
            Assert.That(node.Next, Is.Null);
        }

        [Test]
        public void Append_AddsItemToEndOfBuffer()
        {
            var buffer = new RingBuffer<int>();
            buffer.Append(10);

            Assert.That(buffer, Is.Not.Empty);
            Assert.That(buffer, Contains.Item(10));
        }

        [Test]
        public void AppendFront_AddsItemToStartOfBuffer() 
        {
            var buffer = new RingBuffer<int>();
            buffer.AppendFront(20);

            Assert.That(buffer, Is.Not.Empty);
            
        }

        [Test]
        public void Detach_RemovesItemFromBuffer()
        {
            var buffer = new RingBuffer<int>();
            buffer.Append(30);
            buffer.Append(40);
            bool result = buffer.Detach(30);

            Assert.That(result, Is.True);
            Assert.That(buffer, Does.Not.Contain(30));
        }

        [Test]
        public void Detach_ReturnsFalseIfItemNotPresent()
        {
            var buffer = new RingBuffer<int>();
            buffer.Append(50);

            bool result = buffer.Detach(60);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetEnumerator_EnumeratesItemsInOrder()
        {
            var buffer = new RingBuffer<int>();
            buffer.Append(1);
            buffer.Append(2);
            buffer.Append(3);

            int[] expected = { 1, 2, 3 };
            Assert.That(buffer, Is.EquivalentTo(expected));
        }

        [Test]
        public void ToString_ReturnsCorrectStringRepresentation() 
        {
            var buffer = new RingBuffer<int>();
            buffer.Append(1);
            buffer.Append(2);
            buffer.Append(3);

            string expected = "1 2 3";
            Assert.That(buffer.ToString(), Is.EqualTo(expected));
        }
    }
}