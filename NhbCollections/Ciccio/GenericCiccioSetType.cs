using CiccioSoft.Collections.Generic;
using NHibernate;
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
    public class GenericCiccioSetType<T> : GenericSetType<T>
    {
        public GenericCiccioSetType(string role, string propertyRef)
            : base(role, propertyRef) { }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentCiccioSet<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            if (!(collection is ISet<T>) && !(collection is IBindingList) && !(collection is INotifyCollectionChanged))
            {
                if (!(collection is ICollection<T>))
                    throw new HibernateException(Role + " must be an implementation of ISet<T> or ICollection<T>");
                return new PersistentCiccioSet<T>(session, new CiccioSet<T>((ISet<T>)collection));
            }
            return new PersistentCiccioSet<T>(session, (ISet<T>)collection);
        }

        public override object Instantiate(int anticipatedSize)
        {
            return new CiccioSet<T>();
        }
    }
}
