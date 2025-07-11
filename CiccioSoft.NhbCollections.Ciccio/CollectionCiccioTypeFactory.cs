﻿using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Ciccio
{
    public class CollectionCiccioTypeFactory : DefaultCollectionTypeFactory
    {
        public override CollectionType Bag<T>(string role, string propertyRef)
        {
            return new GenericCiccioBagType<T>(role, propertyRef);
        }

        public override CollectionType List<T>(string role, string propertyRef)
        {
            return new GenericCiccioListType<T>(role, propertyRef);
        }

        public override CollectionType Set<T>(string role, string propertyRef)
        {
            return new GenericCiccioSetType<T>(role, propertyRef);
        }
    }
}
