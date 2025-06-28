using NHibernate.Collection.Generic;
using NHibernate.Engine;
using System.Collections.Generic;

namespace CiccioSoft.NhbCollections.Ciccio
{
    internal class PersistentCiccioBag<T> : PersistentGenericBag<T>
    {
        public PersistentCiccioBag()
        {
        }

        public PersistentCiccioBag(ISessionImplementor session) : base(session)
        {
        }

        public PersistentCiccioBag(ISessionImplementor session, IEnumerable<T> coll) : base(session, coll)
        {
        }
    }
}
