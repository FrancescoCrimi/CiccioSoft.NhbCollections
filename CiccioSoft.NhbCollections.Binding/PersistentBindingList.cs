using NHibernate.Collection.Generic;
using NHibernate.Engine;

namespace CiccioSoft.NhbCollections.Binding
{
    public class PersistentBindingList<T> : PersistentGenericList<T>
    {
        public PersistentBindingList()
        {
        }

        public PersistentBindingList(ISessionImplementor session) : base(session)
        {
        }

        public PersistentBindingList(ISessionImplementor session, IList<T> list) : base(session, list)
        {
        }
    }
}
