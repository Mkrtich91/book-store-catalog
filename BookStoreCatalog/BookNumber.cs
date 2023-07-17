namespace BookStoreCatalog
{
    public class BookNumber
    {
        private readonly string code;

        public BookNumber(string isbnCode)
        {
            if (isbnCode == null)
            {
                throw new ArgumentNullException(nameof(isbnCode));
            }

            if (!ValidateCode(isbnCode) || !ValidateChecksum(isbnCode))
            {
                throw new ArgumentException("Invalid ISBN code.", nameof(isbnCode));
            }

            this.code = isbnCode;
        }

        public string Code => this.code;

        public Uri GetSearchUri()
        {
            string searchLink = $"https://isbnsearch.org/isbn/{this.code}";
            return new Uri(searchLink);
        }

        public override string ToString()
        {
            return this.code;
        }

        private static bool ValidateCode(string isbnCode)
        {
            if (isbnCode == null)
            {
                throw new ArgumentNullException(nameof(isbnCode));
            }

            if (isbnCode.Length != 10)
            {
                return false;
            }

            foreach (char c in isbnCode)
            {
                if (!char.IsDigit(c) && c != 'X')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateChecksum(string isbnCode)
        {
            if (isbnCode == null)
            {
                throw new ArgumentNullException(nameof(isbnCode));
            }

            int checksum = 0;
            for (int i = 0; i < isbnCode.Length; i++)
            {
                if (char.IsDigit(isbnCode[i]))
                {
#pragma warning disable CA1305
                    checksum += (10 - i) * int.Parse(isbnCode[i].ToString());
#pragma warning restore CA1305
                }
                else if (isbnCode[i] == 'X' && i == 9)
                {
                    checksum += 10;
                }
                else
                {
                    return false;
                }
            }

            return checksum % 11 == 0;
        }
    }
}
