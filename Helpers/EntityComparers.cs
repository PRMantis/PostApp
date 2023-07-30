using PostApp.Tables;

namespace PostApp.Helpers
{
    public class KlientaiComparer : EqualityComparer<Klientai>
    {

        public override bool Equals(Klientai c1, Klientai c2)
        {
            if (c1 == null && c2 == null)
                return true;
            else if (c1 == null || c2 == null)
                return false;

            return (c1.Name == c2.Name &&
                    c1.Address == c2.Address);
        }

        public override int GetHashCode(Klientai c)
        {
            string hCode = c.Address + c.Name;
            return hCode.GetHashCode();
        }
    }
}
