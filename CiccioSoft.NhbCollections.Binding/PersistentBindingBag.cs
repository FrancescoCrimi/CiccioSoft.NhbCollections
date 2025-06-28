using NHibernate.Collection.Generic;
using NHibernate.Engine;

namespace CiccioSoft.NhbCollections.Binding
{
    public class PersistentBindingBag<T> : PersistentGenericBag<T>
    {
        public PersistentBindingBag()
        {
        }

        public PersistentBindingBag(ISessionImplementor session) : base(session)
        {
        }

        public PersistentBindingBag(ISessionImplementor session, IEnumerable<T> coll) : base(session, coll)
        {
        }
    }
}
