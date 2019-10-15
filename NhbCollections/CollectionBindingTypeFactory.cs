using CiccioSoft.NhbCollections.Binding;
using NHibernate.Type;

namespace CiccioSoft.NhbCollections
{
    public class CollectionBindingTypeFactory : NHibernate.Type.DefaultCollectionTypeFactory
    {
        public override CollectionType Bag<T>(string role, string propertyRef)
        {
            return new GenericBindingBagType<T>(role, propertyRef);
        }

        public override CollectionType List<T>(string role, string propertyRef)
        {
            return new GenericBindingListType<T>(role, propertyRef);
        }

        public override CollectionType Set<T>(string role, string propertyRef)
        {
            return new GenericBindingSetType<T>(role, propertyRef);
        }
    }
}