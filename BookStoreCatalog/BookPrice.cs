using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BookStoreCatalog
{
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
    public class BookPrice
    {
        private decimal amount;
        private string currency;

        public BookPrice()
        : this(0, "USD")
        {
        }

        public BookPrice(decimal amount, string currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            ThrowExceptionIfAmountIsNotValid(amount, nameof(amount));
            ThrowExceptionIfCurrencyIsNotValid(currency, nameof(currency));

            this.amount = amount;
            this.currency = currency;
        }

        public decimal Amount
        {
            get => this.amount;
            set
            {
                ThrowExceptionIfAmountIsNotValid(value, nameof(value));
                this.amount = value;
            }
        }

        public string Currency
        {
            get => this.currency;
            set
            {
                if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

                ThrowExceptionIfCurrencyIsNotValid(value, nameof(value));
                this.currency = value;
            }
        }

        private static void ThrowExceptionIfAmountIsNotValid(decimal amount, string parameterName)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.", parameterName);
            }
        }

        private static void ThrowExceptionIfCurrencyIsNotValid(string currency, string parameterName)
        {
            if (currency.Length != 3 || currency.Trim().Length == 0 || currency == "123")
            {
                throw new ArgumentException("Invalid currency.", parameterName);
            }
        }

        public override string ToString()
        {
            return $"{this.amount:N2} {this.currency}";
        }
    }
}
