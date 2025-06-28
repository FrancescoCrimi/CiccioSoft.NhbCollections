using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Binding
{
    public class GenericBindingSetType<T> : GenericSetType<T>
    {
        public GenericBindingSetType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
