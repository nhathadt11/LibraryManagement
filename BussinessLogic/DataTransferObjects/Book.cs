using DatabaseAccess.DataTransferObjects;
using System;
using System.Runtime.Serialization;

namespace DatabaseAccess.DataTransferObjects
{
    [DataContract]
    public class Book : DataTranseferObject
    {
        private int _bookId;
        [DataMember]
        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }
        private string _isbn;
        [DataMember]
        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }
        [DataMember]
        private string _title;
        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _description;
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _coverImageUrl;
        [DataMember]
        public string CoverImageUrl
        {
            get { return _coverImageUrl; }
            set { _coverImageUrl = value; }
        }
        private int _pageNumber;
        [DataMember]
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }
        private DateTime _publishedDate;
        [DataMember]
        public DateTime PublishedDate
        {
            get { return _publishedDate; }
            set { _publishedDate = value; }
        }
        private bool _discontinued;
        [DataMember]
        public bool Discontinued
        {
            get { return _discontinued; }
            set { _discontinued = value; }
        }
        private int _authorId;
        [DataMember]
        public int AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }
        private int _categoryId;
        [DataMember]
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }
        private int _publisherId;
        [DataMember]
        public int PublisherId
        {
            get { return _publisherId; }
            set { _publisherId = value; }
        }
    }
}
