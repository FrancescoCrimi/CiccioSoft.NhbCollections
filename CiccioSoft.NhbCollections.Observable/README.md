# CiccioSoft.NhbCollections.Observable
[![Nuget](https://img.shields.io/nuget/v/CiccioSoft.NhbCollections)](https://www.nuget.org/packages/CiccioSoft.NhbCollections/)


## Summary
This library adds support for INotifyCollectionChanged to NHibernate bag, set and list.


## How To

### to add INotifyCollectionChanged to NHibernate bag, set and list:
```csharp
NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
...
configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass,
  "CiccioSoft.NhbCollections.Observable.CollectionObservableTypeFactory, CiccioSoft.NhbCollections.Observable");
```
