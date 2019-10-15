using CiccioSoft.Collections.Generic;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CiccioSoft.NhbCollections.Observable
{
    [Serializable]
    public class GenericObservableListType<T> : GenericListType<T>
    {
        public GenericObservableListType(string role, string propertyRef)
            : base(role, propertyRef) { }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentObservableList<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            if (collection is IBindingList && collection is INotifyCollectionChanged)
                return new PersistentObservableList<T>(session, (IList<T>)collection);
            else
                return new PersistentObservableList<T>(session, new ObservableList<T>((IEnumerable<T>)collection));
        }

        public override object Instantiate(int anticipatedSize)
        {
            return anticipatedSize <= 0 ? new ObservableList<T>() : new ObservableList<T>(anticipatedSize + 1);
        }
    }
}
