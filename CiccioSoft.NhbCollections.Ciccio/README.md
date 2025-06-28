# CiccioSoft.NhbCollections.Ciccio
[![Nuget](https://img.shields.io/nuget/v/CiccioSoft.NhbCollections)](https://www.nuget.org/packages/CiccioSoft.NhbCollections/)


## Summary
This library adds support for IBindingList and INotifyCollectionChanged to NHibernate bag, set and list.


## How To

### to add IBindingList and INotifyCollectionChanged to NHibernate bag, set and list:
```csharp
NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
...
configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, 
  "CiccioSoft.NhbCollections.Ciccio.CollectionCiccioTypeFactory, CiccioSoft.NhbCollections.Ciccio");
```
