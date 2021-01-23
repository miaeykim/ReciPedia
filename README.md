# ReciPedia

ReciPedia is recipe sharing web application constructed with MVC design pattern.

## Technologies
- C#
- .NET Core 2.1
- SQL Server 2016
- Bootstrap version: 4.3.1


## Features
### Login & Register
- ASP.NET Core Identity
- Dependency Injection (`AccountController` - `IUserRepository` - `EFUserRepository`)

### Recipe CRUD
![](https://user-images.githubusercontent.com/52260097/105570329-0bd14200-5d8c-11eb-9048-dd8fdae8e3d4.gif)

- Non-registered user only can view recipes
- Registered user gets authority to manage (add, edit, delete) own recipes.
- Dependency Injection (`AdminController` - `IRecipeRepository` - `EFRecipeRepository`)

### Filter & Search
![](https://user-images.githubusercontent.com/52260097/105570345-1d1a4e80-5d8c-11eb-9808-1613df8584f5.gif)

Category dropdown and search string are executed by LINQ Query Operation.

### Paging
`PagingInfo` ViewModel
```C#
public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
```

## Screenshots
![](https://user-images.githubusercontent.com/52260097/105570587-bbf37a80-5d8d-11eb-9f07-9544d9074256.PNG)
Landing Page

![](https://user-images.githubusercontent.com/52260097/105570589-bdbd3e00-5d8d-11eb-9d1b-cfc1f10a50d5.PNG)
Recipe List Page

![](https://user-images.githubusercontent.com/52260097/105570590-bdbd3e00-5d8d-11eb-8b7f-2a4250a9a7a8.PNG)
Recipe Detail Page

![](https://user-images.githubusercontent.com/52260097/105570591-be55d480-5d8d-11eb-9d9e-10536f45fff7.PNG)
Login Page

![](https://user-images.githubusercontent.com/52260097/105570592-beee6b00-5d8d-11eb-9b05-290a5afb4bac.PNG)
Register Page

![](https://user-images.githubusercontent.com/52260097/105570594-beee6b00-5d8d-11eb-8cb7-74d40b8abaf0.PNG)
Admin Page
