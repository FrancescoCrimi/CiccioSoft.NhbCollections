using NHibernate.Collection.Generic;
using NHibernate.DebugHelpers;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace CiccioSoft.NhbCollections.Ciccio
{
    [Serializable]
    [DebuggerTypeProxy(typeof(CollectionProxy<>))]
    public class PersistentCiccioBag<T> : PersistentGenericBag<T>, IBindingList, IRaiseItemChangedEvents, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ListChangedEventHandler listChanged;
        private NotifyCollectionChangedEventHandler collectionChanged;
        private PropertyChangedEventHandler propertyChanged;


        #region Constructors

        public PersistentCiccioBag() { }
        public PersistentCiccioBag(ISessionImplementor session)
            : base(session) { }
        public PersistentCiccioBag(ISessionImplementor session, IEnumerable<T> coll)
            : base(session, coll) { CaptureEventHandlers(); }

        #endregion


        public override void BeforeInitialize(ICollectionPersister persister, int anticipatedSize)
        {
            base.BeforeInitialize(persister, anticipatedSize);
            CaptureEventHandlers();
        }

        private void CaptureEventHandlers()
        {
            if (InternalBag is IBindingList ibl)
                ibl.ListChanged += (sender, e) => listChanged?.Invoke(this, e);
            if (InternalBag is INotifyCollectionChanged ncc)
                ncc.CollectionChanged += (sender, e) => collectionChanged?.Invoke(this, e);
            if (InternalBag is INotifyPropertyChanged npc)
                npc.PropertyChanged += (sender, e) => propertyChanged?.Invoke(this, e);
        }


        #region INotifyCollectionChanged

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
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

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                Initialize(false);
                propertyChanged += value;
            }
            remove { propertyChanged -= value; }
        }

        #endregion


        #region IBindingList

        event ListChangedEventHandler IBindingList.ListChanged
        {
            add
            {
                Initialize(false);
                listChanged += value;
            }
            remove { listChanged -= value; }
        }
        object IBindingList.AddNew() => throw new NotSupportedException();
        bool IBindingList.AllowNew => false;
        bool IBindingList.AllowEdit => true;
        bool IBindingList.AllowRemove => true;
        bool IBindingList.SupportsChangeNotification => true;
        bool IBindingList.SupportsSearching => false;
        bool IBindingList.SupportsSorting => false;
        bool IBindingList.IsSorted => false;
        PropertyDescriptor IBindingList.SortProperty => null;
        ListSortDirection IBindingList.SortDirection => ListSortDirection.Ascending;
        void IBindingList.ApplySort(PropertyDescriptor prop, ListSortDirection direction) => throw new NotSupportedException();
        void IBindingList.RemoveSort() => throw new NotSupportedException();
        int IBindingList.Find(PropertyDescriptor prop, object key) => throw new NotSupportedException();
        void IBindingList.AddIndex(PropertyDescriptor prop) { }
        void IBindingList.RemoveIndex(PropertyDescriptor prop) { }

        #endregion IBindingList


        #region IRaiseItemChangedEvents
        bool IRaiseItemChangedEvents.RaisesItemChangedEvents
        {
            get
            {
                Initialize(false);
                return ((IRaiseItemChangedEvents)InternalBag).RaisesItemChangedEvents;
            }
        }
        #endregion IRaiseItemChangedEvents
    }
}
