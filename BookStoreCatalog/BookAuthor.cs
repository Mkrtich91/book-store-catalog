namespace BookStoreCatalog
{
    public class BookAuthor
    {
        public BookAuthor(string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentNullException(nameof(authorName));
            }

            this.AuthorName = authorName;
            this.HasIsni = false;
        }

        public BookAuthor(string authorName, string isniCode)
        : this(authorName)
        {
            if (isniCode == null)
            {
                throw new ArgumentNullException(nameof(isniCode));
            }

            this.HasIsni = true;
            this.Isni = new NameIdentifier(isniCode);
        }

        public BookAuthor(string authorName, NameIdentifier nameIdentifier)
        : this(authorName)
        {
        this.Isni = nameIdentifier ?? throw new ArgumentNullException(nameof(nameIdentifier));

        this.HasIsni = true;
        }

        public string AuthorName { get; private set; }

        public bool HasIsni { get; private set; }

        public NameIdentifier Isni { get; private set; }

        public override string ToString()
        {
            if (this.HasIsni)
            {
                return $"{this.AuthorName} (ISNI:{this.Isni.Code})";
            }
            else
            {
                return this.AuthorName;
            }
        }
    }
}
