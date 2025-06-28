using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Ciccio
{
    internal class GenericCiccioListType<T> : GenericListType<T>
    {
        public GenericCiccioListType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
