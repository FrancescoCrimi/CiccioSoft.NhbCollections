using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Ciccio
{
    internal class GenericCiccioSetType<T> : GenericSetType<T>
    {
        public GenericCiccioSetType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
