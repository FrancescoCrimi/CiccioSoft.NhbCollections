using NHibernate.Collection.Generic;
using NHibernate.Engine;
using System.Collections.Generic;

namespace CiccioSoft.NhbCollections.Observable
{
    internal class PersistentObservableList<T> : PersistentGenericList<T>
    {
        public PersistentObservableList()
        {
        }

        public PersistentObservableList(ISessionImplementor session) : base(session)
        {
        }

        public PersistentObservableList(ISessionImplementor session, IList<T> list) : base(session, list)
        {
        }
    }
}
