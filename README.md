# Json Cache (.net)
This library helps you to save any kind of entity inside a .db file in Json format.

## Installation

JsonCache is available on [Nuget](https://www.nuget.org/packages/JsonCache).

```
dotnet add package JsonCache
```
Use --version to specify a preview version to install.

## Basic Usage

### Instance of JsonCache
```c#
	CacheService cs = new CacheService();
```

### Create and save an entity
```c#
	var user = new User();
	user.Name = "Test User";
	
	await cs.SaveAsync(user);
```

### Create and save a list of entities
```c#
	var userList = new List<User>(...);
	
	await cs.SaveAllAsync(userList);
```

### Get Objects
Using th key of object:
```c#
	await cs.GetByKeyAsync<User>(x => x.Name == "Test User");
```
Get all objects:
```c#
	await cs.GetAllASync<User>();
```

Return null if not find the object.

### Delete by specific object key
```c#
	await cs.DeleteByKeyAsync<User>(x => x.Name == "Test User");
```
### Clear Cache
**Warning:** this methods clear all data from specified object type.
```
	await cs.ClearAsync<User>();
```

## Contributing

We welcome community pull requests for bug fixes, enhancements, and documentation.

