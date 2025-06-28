using NHibernate.Collection.Generic;
using NHibernate.Engine;
using System.Collections.Generic;

namespace CiccioSoft.NhbCollections.Observable
{
    internal class PersistentObservableSet<T> : PersistentGenericSet<T>
    {
        public PersistentObservableSet()
        {
        }

        public PersistentObservableSet(ISessionImplementor session) : base(session)
        {
        }

        public PersistentObservableSet(ISessionImplementor session, ISet<T> original) : base(session, original)
        {
        }
    }
}
