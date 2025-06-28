using CiccioSoft.Collections.Generic;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CiccioSoft.NhbCollections.Ciccio
{
    [Serializable]
    public class GenericCiccioListType<T> : GenericListType<T>
    {
        public GenericCiccioListType(string role, string propertyRef)
            : base(role, propertyRef) { }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentCiccioList<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            if (collection is IBindingList && collection is INotifyCollectionChanged)
                return new PersistentCiccioList<T>(session, (IList<T>)collection);
            else
                return new PersistentCiccioList<T>(session, new BindingCollection<T>((IEnumerable<T>)collection));
        }

        public override object Instantiate(int anticipatedSize)
        {
            return anticipatedSize <= 0 ? new CiccioList<T>() : new CiccioList<T>(anticipatedSize + 1);
        }
    }
}
