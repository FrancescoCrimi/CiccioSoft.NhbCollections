using NHibernate.Collection.Generic;
using NHibernate.Engine;
using System.Collections.Generic;

namespace CiccioSoft.NhbCollections.Ciccio
{
    internal class PersistentCiccioList<T> : PersistentGenericList<T>
    {
        public PersistentCiccioList()
        {
        }

        public PersistentCiccioList(ISessionImplementor session) : base(session)
        {
        }

        public PersistentCiccioList(ISessionImplementor session, IList<T> list) : base(session, list)
        {
        }
    }
}
