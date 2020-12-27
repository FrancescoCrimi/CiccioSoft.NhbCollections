using NHibernate.Collection.Generic;
using NHibernate.DebugHelpers;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace CiccioSoft.NhbCollections.Observable
{
    [Serializable]
    [DebuggerTypeProxy(typeof(CollectionProxy<>))]
    public class PersistentObservableSet<T> : PersistentGenericSet<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private NotifyCollectionChangedEventHandler collectionChanged;
        private PropertyChangedEventHandler propertyChanged;

        #region Constructors

        public PersistentObservableSet() { }

        public PersistentObservableSet(ISessionImplementor session)
            : base(session) { }

        public PersistentObservableSet(ISessionImplementor session, ISet<T> original)
            : base(session, original) { CaptureEventHandlers(); }

        #endregion

        public override void BeforeInitialize(ICollectionPersister persister, int anticipatedSize)
        {
            base.BeforeInitialize(persister, anticipatedSize);
            CaptureEventHandlers();
        }

        private void CaptureEventHandlers()
        {
            if (WrappedSet is INotifyCollectionChanged ncc)
                ncc.CollectionChanged += (sender, e) => collectionChanged?.Invoke(this, e);
            if (WrappedSet is INotifyPropertyChanged npc)
                npc.PropertyChanged += (sender, e) => propertyChanged?.Invoke(this, e);
        }

        #region INotifyCollectionChanged

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                Initialize(false);
                collectionChanged += value;
            }
            remove { collectionChanged -= value; }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                Initialize(false);
                propertyChanged += value;
            }
            remove { propertyChanged -= value; }
        }

        #endregion
    }
}
