using NHibernate.Collection.Generic;
using NHibernate.DebugHelpers;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace CiccioSoft.NhbCollections.Ciccio
{
    [Serializable]
    [DebuggerTypeProxy(typeof(CollectionProxy<>))]
    public class PersistentCiccioSet<T> : PersistentGenericSet<T>, IBindingList, IRaiseItemChangedEvents, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ListChangedEventHandler listChanged;
        private NotifyCollectionChangedEventHandler collectionChanged;
        private PropertyChangedEventHandler propertyChanged;

        #region Constructors

        public PersistentCiccioSet() { }
        public PersistentCiccioSet(ISessionImplementor session)
            : base(session) { }
        public PersistentCiccioSet(ISessionImplementor session, ISet<T> original)
            : base(session, original) { CaptureEventHandlers(); }

        #endregion

        public override void BeforeInitialize(ICollectionPersister persister, int anticipatedSize)
        {
            base.BeforeInitialize(persister, anticipatedSize);
            CaptureEventHandlers();
        }

        private void CaptureEventHandlers()
        {
            if (WrappedSet is IBindingList ibl)
                ibl.ListChanged += (sender, e) => listChanged?.Invoke(this, e);
            if (WrappedSet is INotifyCollectionChanged ncc)
                ncc.CollectionChanged += (sender, e) => collectionChanged?.Invoke(this, e);
            if (WrappedSet is INotifyPropertyChanged npc)
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

        void IBindingList.ApplySort(PropertyDescriptor prop, ListSortDirection direction)
        {
            throw new NotSupportedException();
        }

        void IBindingList.RemoveSort()
        {
            throw new NotSupportedException();
        }

        int IBindingList.Find(PropertyDescriptor prop, object key)
        {
            throw new NotSupportedException();
        }

        void IBindingList.AddIndex(PropertyDescriptor prop)
        {
            // Not supported
        }

        void IBindingList.RemoveIndex(PropertyDescriptor prop)
        {
            // Not supported
        }

        #endregion IBindingList

        #region IList interface

        int ICollection.Count => WrappedSet.Count;
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot => null;
        bool IList.IsFixedSize => false;
        bool IList.IsReadOnly => false;
        object IList.this[int index] { get => ((IList)WrappedSet)[index]; set => throw new NotSupportedException(); }
        void ICollection.CopyTo(Array array, int index) => throw new NotSupportedException();
        int IList.Add(object value) => throw new NotSupportedException();
        void IList.Clear() => throw new NotSupportedException();
        bool IList.Contains(object value) => throw new NotSupportedException();
        int IList.IndexOf(object value) => throw new NotSupportedException();
        void IList.Insert(int index, object value) => throw new NotSupportedException();
        void IList.Remove(object value) => throw new NotSupportedException();
        void IList.RemoveAt(int index) => throw new NotSupportedException();

        #endregion

        #region IRaiseItemChangedEvents

        bool IRaiseItemChangedEvents.RaisesItemChangedEvents
        {
            get
            {
                Initialize(false);
                return ((IRaiseItemChangedEvents)WrappedSet).RaisesItemChangedEvents;
            }
        }

        #endregion IRaiseItemChangedEvents
    }
}
