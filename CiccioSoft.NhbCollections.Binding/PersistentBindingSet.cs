using NHibernate.Collection.Generic;
using NHibernate.Engine;

namespace CiccioSoft.NhbCollections.Binding
{
    public class PersistentBindingSet<T> : PersistentGenericSet<T>
    {
        public PersistentBindingSet()
        {
        }

        public PersistentBindingSet(ISessionImplementor session) : base(session)
        {
        }

        public PersistentBindingSet(ISessionImplementor session, ISet<T> original) : base(session, original)
        {
        }
    }
}
