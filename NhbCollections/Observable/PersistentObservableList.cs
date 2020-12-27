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
    public class PersistentObservableList<T> : PersistentGenericList<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private NotifyCollectionChangedEventHandler collectionChanged;
        private PropertyChangedEventHandler propertyChanged;

        #region Constructors

        public PersistentObservableList() { }

        public PersistentObservableList(ISessionImplementor session)
            : base(session) { }

        public PersistentObservableList(ISessionImplementor session, IList<T> list)
            : base(session, list) { CaptureEventHandlers(); }

        #endregion

        public override void BeforeInitialize(ICollectionPersister persister, int anticipatedSize)
        {
            base.BeforeInitialize(persister, anticipatedSize);
            CaptureEventHandlers();
        }

        private void CaptureEventHandlers()
        {
            if (WrappedList is INotifyCollectionChanged ncc)
                ncc.CollectionChanged += (sender, e) => collectionChanged?.Invoke(this, e);
            if (WrappedList is INotifyPropertyChanged npc)
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
