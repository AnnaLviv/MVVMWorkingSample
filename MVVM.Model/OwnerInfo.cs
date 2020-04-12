using System;

namespace MVVM.Model
{
    public class OwnerInfo : IEquatable<OwnerInfo>
    {
        public string UserName { get; }
        public string GreetingName { get; }

        public OwnerInfo(string userName, string greetingName)
        {
            UserName = userName;
            GreetingName = greetingName;
        }

        bool IEquatable<OwnerInfo>.Equals(OwnerInfo other)
        {
            return Equals(other);
        }

        public override bool Equals(object obj)
        {
            return obj is OwnerInfo other
            && other.GetType() == GetType()
            && Equals(other.UserName, UserName)
            && Equals(other.GreetingName, GreetingName);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 41;
                hash = hash * 43 + UserName.GetHashCode();
                hash = hash * 43 + GreetingName.GetHashCode();
                return hash;
            }
        }

    }
}
