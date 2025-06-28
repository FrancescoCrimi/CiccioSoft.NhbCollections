using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Observable
{
    internal class GenericObservableListType<T> : GenericListType<T>
    {
        public GenericObservableListType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
