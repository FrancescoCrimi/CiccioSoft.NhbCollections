using NHibernate.Collection.Generic;
using NHibernate.Engine;
using System.Collections.Generic;

namespace CiccioSoft.NhbCollections.Ciccio
{
    internal class PersistentCiccioSet<T> : PersistentGenericSet<T>
    {
        public PersistentCiccioSet()
        {
        }

        public PersistentCiccioSet(ISessionImplementor session) : base(session)
        {
        }

        public PersistentCiccioSet(ISessionImplementor session, ISet<T> original) : base(session, original)
        {
        }
    }
}
