using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Ciccio
{
    internal class GenericCiccioBagType<T> : GenericBagType<T>
    {
        public GenericCiccioBagType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
