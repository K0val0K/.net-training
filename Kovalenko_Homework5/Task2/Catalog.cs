using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Catalog : IEnumerable
    {
        private readonly Dictionary<string, Book> _catalog;
        public Dictionary<string, Book>.KeyCollection Keys { get { return _catalog.Keys; } } 
        public Dictionary<string, Book>.ValueCollection Books { get { return _catalog.Values; } } 

        public Catalog()
        {
            _catalog = new Dictionary<string, Book>();
        }

        public Book this[string key] 
        {
            get 
            {
                if (!IsCorrectKey(key))
                {
                    throw new ArgumentException("key is not in ISBN13 format");
                }
                TryGetValue(key, out Book book);
                return book;
            }
            set
            {
                if (!IsCorrectKey(key))
                {
                    throw new ArgumentException("key is not in ISBN13 format");
                }
                Add(key, value);
            }
        }

        public void Add(string key, Book book)
        {
            if(!IsCorrectKey(key))
            {
                throw new ArgumentException("key is not in ISBN13 format");
            }
            _catalog.Add(ConvertToOnlyNumbersFormat(key), book);
        }

        public bool TryGetValue(string key, out Book book)
        {
            if (!IsCorrectKey(key))
            {
                book = default;
                return false;
            }
            return _catalog.TryGetValue(ConvertToOnlyNumbersFormat(key),out book);
        }

        public bool Remove(string key)
        {
            if (!IsCorrectKey(key))
            {
                throw new ArgumentException("key is not in ISBN13 format");
            }
            return _catalog.Remove(ConvertToOnlyNumbersFormat(key));
        }

        public bool ContaisKey(string key) 
        {
            if (!IsCorrectKey(key))
            {
                throw new ArgumentException("key is not in ISBN13 format");
            }
            return _catalog.Remove(ConvertToOnlyNumbersFormat(key));
        }
        
        public bool ContainsValue(Book book) =>  _catalog.ContainsValue(book);

        public IEnumerator GetEnumerator()
        {
            return _catalog.GetEnumerator();
        }

        private bool IsCorrectKey(string key)
        {
            if (key == null) throw new ArgumentNullException();

            var correctFormat = new Regex("^([0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1})|([0-9]{13})$");
            return correctFormat.IsMatch(key);
        }

        private string ConvertToOnlyNumbersFormat(string key)
        {
            if (key == null) throw new ArgumentNullException();

            var stringBuilder = new StringBuilder(key);
            stringBuilder.Replace("-", "");
            return stringBuilder.ToString();
        }
    }
}
