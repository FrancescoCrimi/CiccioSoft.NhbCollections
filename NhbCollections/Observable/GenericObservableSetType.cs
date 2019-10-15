using CiccioSoft.Collections.Generic;
using NHibernate;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CiccioSoft.NhbCollections.Observable
{
    [Serializable]
    public class GenericObservableSetType<T> : GenericSetType<T>
    {
        public GenericObservableSetType(string role, string propertyRef)
            : base(role, propertyRef) { }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentObservableSet<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            if (!(collection is ISet<T>) && !(collection is INotifyCollectionChanged))
            {
                if (!(collection is ICollection<T>))
                    throw new HibernateException(Role + " must be an implementation of ISet<T> or ICollection<T>");
                return new PersistentObservableSet<T>(session, new ObservableSet<T>((ISet<T>)collection));
            }
            return new PersistentObservableSet<T>(session, (ISet<T>)collection);
        }

        public override object Instantiate(int anticipatedSize)
        {
            return new ObservableSet<T>();
        }
    }
}
