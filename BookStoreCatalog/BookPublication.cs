using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BookStoreCatalog
{
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]
    public class BookPublication
    {
        public BookAuthor Author { get; init; }

        public string Title { get; init; }

        public string Publisher { get; init; }

        public DateTime Published { get; init; }

        public BookBindingKind BookBinding { get; init; }

        public BookNumber Isbn { get; init; }

        public BookPublication(BookAuthor author, string title, string publisher, DateTime published, BookBindingKind bookBinding, BookNumber isbn)
        {
           this.Author = author ?? throw new ArgumentNullException(nameof(author));
           this.Title = !string.IsNullOrWhiteSpace(title) ? title : throw new ArgumentNullException(nameof(title));
           this.Publisher = !string.IsNullOrWhiteSpace(publisher) ? publisher : throw new ArgumentNullException(nameof(publisher));
           this.Published = published;
           this.BookBinding = bookBinding;
           this.Isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
        }

        public BookPublication(string authorName, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbnCode)
            : this(new BookAuthor(authorName), title, publisher, published, bookBinding, new BookNumber(isbnCode))
        {
        }

        public BookPublication(string authorName, string isniCode, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbnCode)
            : this(new BookAuthor(authorName, isniCode), title, publisher, published, bookBinding, new BookNumber(isbnCode))
        {
        }

        public string GetPublicationDateString()
        {
            return this.Published.ToString("MMMM, yyyy", CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return $"{this.Title} by {this.Author.AuthorName}";
        }
    }
}
