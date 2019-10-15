using CiccioSoft.Collections.Generic;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CiccioSoft.NhbCollections.Binding
{
    [Serializable]
    public class GenericBindingBagType<T> : GenericBagType<T>
    {
        public GenericBindingBagType(string role, string propertyRef)
            : base(role, propertyRef) { }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentBindingBag<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            if (collection is IBindingList)
                return new PersistentBindingBag<T>(session, (IEnumerable<T>)collection);
            else
                return new PersistentBindingBag<T>(session, new BindingCollection<T>((IEnumerable<T>)collection));
        }

        public override object Instantiate(int anticipatedSize)
        {
            return anticipatedSize <= 0 ? new BindingCollection<T>() : new BindingCollection<T>(anticipatedSize + 1);
        }
    }
}
