using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BookStoreCatalog
{
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1117:ParametersMustBeOnSameLineOrSeparateLines", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1116:SplitParametersMustStartOnLineAfterDeclaration", Justification = "Reviewed.")]
    public class BookStoreItem
    {
        private BookPublication publication;
        private BookPrice price;
        private int amount;

        public BookPublication Publication
        {
            get => this.publication;
            set => this.publication = value ?? throw new ArgumentNullException(nameof(value));
        }

        public BookPrice Price
        {
            get => this.price;
            set => this.price = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Amount
        {
            get => this.amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Amount cannot be less than zero.");
                }

                this.amount = value;
            }
        }

        public BookStoreItem(string authorName, string isniCode, string title, string publisher, DateTime published,
        BookBindingKind bookBinding, string isbn, decimal priceAmount, string priceCurrency, int amount)
        : this(new BookPublication(authorName, isniCode, title, publisher, published, bookBinding, isbn),
               new BookPrice(priceAmount, priceCurrency), amount)
        {
        }

        public BookStoreItem(BookPublication publication, BookPrice price, int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            this.Publication = publication ?? throw new ArgumentNullException(nameof(publication));
            this.Price = price ?? throw new ArgumentNullException(nameof(price));
            this.Amount = amount;
        }

        public override string ToString()
        {
            string priceString = this.Price.Amount.ToString("N2", CultureInfo.InvariantCulture);
            string formattedPrice = $"{priceString} {this.Price.Currency}";

#pragma warning disable CA1307
            if (priceString.Contains(','))
            {
                formattedPrice = $"\"{formattedPrice}\"";
            }
#pragma warning restore CA1307

            string authorString = this.Publication.Author.HasIsni ? this.Publication.Author.ToString() : this.publication.Author.ToString();

            string amountString = this.Amount.ToString(CultureInfo.InvariantCulture);

            return $"{this.Publication.Title} by {authorString}, {formattedPrice}, {amountString}";
        }
    }
}
