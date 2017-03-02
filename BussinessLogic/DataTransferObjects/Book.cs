using BussinessLogic.DataTransferObjects;
using System;

namespace BussinessLogic.DataTransferObjects
{
    public class Book : DataTranseferObject
    {
        private int _bookId;

        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }
        private string _isbn;

        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _coverImageUrl;

        public string CoverImageUrl
        {
            get { return _coverImageUrl; }
            set { _coverImageUrl = value; }
        }
        private int _pageNumber;

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }
        private DateTime _publishedDate;

        public DateTime PublishedDate
        {
            get { return _publishedDate; }
            set { _publishedDate = value; }
        }
        private bool _discontinued;

        public bool Discontinued
        {
            get { return _discontinued; }
            set { _discontinued = value; }
        }
        private int _authorId;

        public int AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }
        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }
        private int _publisherId;

        public int PublisherId
        {
            get { return _publisherId; }
            set { _publisherId = value; }
        }
    }
}
