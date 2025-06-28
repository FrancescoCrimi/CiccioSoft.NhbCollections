using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Observable
{
    internal class GenericObservableBagType<T> : GenericBagType<T>
    {
        public GenericObservableBagType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
