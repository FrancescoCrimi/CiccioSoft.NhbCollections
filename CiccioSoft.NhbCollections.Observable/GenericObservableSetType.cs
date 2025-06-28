using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Observable
{
    internal class GenericObservableSetType<T> : GenericSetType<T>
    {
        public GenericObservableSetType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
