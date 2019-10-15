using CiccioSoft.Collections.Generic;
using NHibernate;
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
    public class GenericBindingSetType<T> : GenericSetType<T>
    {
        public GenericBindingSetType(string role, string propertyRef)
            : base(role, propertyRef) { }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentBindingSet<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            if (!(collection is ISet<T>) && !(collection is IBindingList))
            {
                if (!(collection is ICollection<T>))
                    throw new HibernateException(Role + " must be an implementation of ISet<T> or ICollection<T>");
                return new PersistentBindingSet<T>(session, new BindingSet<T>((ISet<T>)collection));
            }
            return new PersistentBindingSet<T>(session, (ISet<T>)collection);
        }

        public override object Instantiate(int anticipatedSize)
        {
            return new BindingSet<T>();
        }
    }
}
