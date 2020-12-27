using NHibernate.Collection.Generic;
using NHibernate.DebugHelpers;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace CiccioSoft.NhbCollections.Binding
{
    [Serializable]
    [DebuggerTypeProxy(typeof(CollectionProxy<>))]
    public class PersistentBindingSet<T> : PersistentGenericSet<T>, IBindingList, IRaiseItemChangedEvents
    {
        private ListChangedEventHandler listChanged;

        #region Constructors

        public PersistentBindingSet() { }
        public PersistentBindingSet(ISessionImplementor session)
            : base(session) { }
        public PersistentBindingSet(ISessionImplementor session, ISet<T> original)
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
        }

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

        #endregion

        #region IList

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

        #endregion IRaiseItemChangedEvents interface
    }
}
