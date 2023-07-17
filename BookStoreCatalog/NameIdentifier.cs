namespace BookStoreCatalog
{
    public class NameIdentifier
    {
        public NameIdentifier(string isniCode)
        {
            if (isniCode is null)
            {
                throw new ArgumentNullException(nameof(isniCode));
            }

            if (!ValidateCode(isniCode))
            {
                throw new ArgumentException("Invalid ISNI code.", nameof(isniCode));
            }

            this.Code = isniCode;
        }

        public string Code { get; init; }

        public Uri GetUri()
        {
            return new Uri($"http://www.isni.org/isni/{this.Code}");
        }

        public override string ToString()
        {
            return this.Code;
        }

        private static bool ValidateCode(string isniCode)
        {
            if (isniCode.Length != 16)
            {
                return false;
            }

            foreach (char c in isniCode)
            {
                if (!char.IsDigit(c) && c != 'X')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
