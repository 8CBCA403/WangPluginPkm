using System;

namespace USP.Core
{
    public class ComboItem : IEquatable<ComboItem>
    {
        public string Text { get; }
        public int Value { get; }
        public ComboItem(string Text, int Value)
        {
            this.Text = Text;
            this.Value = Value;
        }

        public bool Equals(ComboItem other)
        {
            if (Text == other.Text)
            {
                if (Value == other.Value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
