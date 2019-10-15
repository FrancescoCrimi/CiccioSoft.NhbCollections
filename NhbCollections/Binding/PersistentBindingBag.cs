using NHibernate.Collection.Generic;
using NHibernate.DebugHelpers;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace CiccioSoft.NhbCollections.Binding
{
    [Serializable]
    [DebuggerTypeProxy(typeof(CollectionProxy<>))]
    public class PersistentBindingBag<T> : PersistentGenericBag<T>, IBindingList, IRaiseItemChangedEvents
    {
        private ListChangedEventHandler listChanged;


        #region Constructors

        public PersistentBindingBag() { }
        public PersistentBindingBag(ISessionImplementor session)
            : base(session) { }
        public PersistentBindingBag(ISessionImplementor session, IEnumerable<T> coll)
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
        void IBindingList.ApplySort(PropertyDescriptor prop, ListSortDirection direction) => throw new NotSupportedException();
        void IBindingList.RemoveSort() => throw new NotSupportedException();
        int IBindingList.Find(PropertyDescriptor prop, object key) => throw new NotSupportedException();
        void IBindingList.AddIndex(PropertyDescriptor prop) { }
        void IBindingList.RemoveIndex(PropertyDescriptor prop) { }

        #endregion


        #region IRaiseItemChangedEvents

        bool IRaiseItemChangedEvents.RaisesItemChangedEvents
        {
            get
            {
                Initialize(false);
                return ((IRaiseItemChangedEvents)InternalBag).RaisesItemChangedEvents;
            }
        }

        #endregion IRaiseItemChangedEvents interface
    }
}
