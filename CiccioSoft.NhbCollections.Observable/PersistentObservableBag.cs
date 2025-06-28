using NHibernate.Collection.Generic;
using NHibernate.Engine;
using System.Collections.Generic;

namespace CiccioSoft.NhbCollections.Observable
{
    internal class PersistentObservableBag<T> : PersistentGenericBag<T>
    {
        public PersistentObservableBag()
        {
        }

        public PersistentObservableBag(ISessionImplementor session) : base(session)
        {
        }

        public PersistentObservableBag(ISessionImplementor session, IEnumerable<T> coll) : base(session, coll)
        {
        }
    }
}
