using CiccioSoft.NhbCollections.Observable;
using NHibernate.Type;

namespace CiccioSoft.NhbCollections
{
    public class CollectionObservableTypeFactory : NHibernate.Type.DefaultCollectionTypeFactory
    {
        public override CollectionType Bag<T>(string role, string propertyRef)
        {
            return new GenericObservableBagType<T>(role, propertyRef);
        }

        public override CollectionType List<T>(string role, string propertyRef)
        {
            return new GenericObservableListType<T>(role, propertyRef);
        }

        public override CollectionType Set<T>(string role, string propertyRef)
        {
            return new GenericObservableSetType<T>(role, propertyRef);
        }
    }
}