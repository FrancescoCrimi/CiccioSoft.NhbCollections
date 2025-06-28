using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Binding
{
    public class GenericBindingBagType<T> : GenericBagType<T>
    {
        public GenericBindingBagType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
