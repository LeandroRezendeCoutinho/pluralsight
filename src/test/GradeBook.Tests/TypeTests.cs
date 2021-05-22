using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
        
    public class TypeTests
    {
        private int count = 0;
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            
            var result = log("Hello");
            
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        
        [Fact]
        public void StringBehaviorLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);
            
            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassedByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByOut()
        {
            Book book1;
            GetBookSetNameByOut(out book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByOut(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByRef(ref Book book, string name)
        {
            book = new Book(name);
        }
        
        [Fact]
        public void CSharpCanPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByValue(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByValue(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferenteObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            Assert.Equal("Book 1", book1.Name);
            Assert.True(ReferenceEquals(book1, book2));
        }

        private Book GetBook(string name)
        {
            return new(name);
        }
    }
}