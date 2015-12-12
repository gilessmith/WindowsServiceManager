namespace WindowsServiceManager.Core.Domain
{
    using System;

    public class Tag : IEquatable<Tag>
    {
        private readonly string tagText;

        public Tag(string tagText)
        {
            if (tagText == null)
            {
                throw new ArgumentNullException("tagText");
            }

            this.tagText = tagText;
        }

        public string TagText
        {
            get
            {
                return this.tagText;
            }
        }

        public static bool operator ==(Tag left, Tag right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Tag left, Tag right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return this.tagText.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            var otherTag = other as Tag;
            if (otherTag == null)
            {
                return false;
            }

            return this.Equals(otherTag);
        }

        public bool Equals(Tag other)
        {
            if (other == null)
            {
                return false;
            }

            return this.tagText.Equals(other.tagText, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return string.Format("Tag: ({0})", this.tagText);
        }
    }
}