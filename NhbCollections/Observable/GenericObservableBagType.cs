using CiccioSoft.Collections.Generic;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CiccioSoft.NhbCollections.Observable
{
    [Serializable]
    public class GenericObservableBagType<T> : GenericBagType<T>
    {
        public GenericObservableBagType(string role, string propertyRef)
            : base(role, propertyRef) { }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentObservableBag<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            if (collection is INotifyCollectionChanged)
                return new PersistentObservableBag<T>(session, (IEnumerable<T>)collection);
            else
                return new PersistentObservableBag<T>(session, new ObservableList<T>((IEnumerable<T>)collection));
        }

        public override object Instantiate(int anticipatedSize)
        {
            return anticipatedSize <= 0 ? new ObservableList<T>() : new ObservableList<T>(anticipatedSize + 1);
        }
    }
}
