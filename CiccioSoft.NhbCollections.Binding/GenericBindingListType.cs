using NHibernate.Type;

namespace CiccioSoft.NhbCollections.Binding
{
    public class GenericBindingListType<T> : GenericListType<T>
    {
        public GenericBindingListType(string role, string propertyRef) : base(role, propertyRef)
        {
        }
    }
}
