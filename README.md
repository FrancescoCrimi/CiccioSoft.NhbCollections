# CiccioSoft.NhbCollections
[![Nuget](https://img.shields.io/nuget/v/CiccioSoft.NhbCollections)](https://www.nuget.org/packages/CiccioSoft.NhbCollections/)


## Summary
This library adds support for IBindingList and INotifyCollectionChanged to NHibernate bag, set and list.


## How To

### to add IBindingList to NHibernate bag, set and list:
```csharp
NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
...
configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass,
  "CiccioSoft.NhbCollections.CollectionBindingTypeFactory, CiccioSoft.NhbCollections");
```

### to add INotifyCollectionChanged to NHibernate bag, set and list:
```csharp
NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
...
configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass,
  "CiccioSoft.NhbCollections.CollectionObservableTypeFactory, CiccioSoft.NhbCollections");
```

### to add IBindingList and INotifyCollectionChanged to NHibernate bag, set and list:
```csharp
NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
...
configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, 
  "CiccioSoft.NhbCollections.CollectionCiccioTypeFactory, CiccioSoft.NhbCollections");
```
