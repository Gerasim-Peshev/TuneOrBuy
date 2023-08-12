# TuneOrBuy

Web application for finding cars, parts and car services, if you need to buy. You also can be a seller, car service owner or just buyer.

# 🛠 Built with:

- [ASP.NET Core 6.0](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-7.0)
- [Entity Framework Core 6.0](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew)
- [Bootstrap](https://getbootstrap.com/)
- [xUnit](https://xunit.net/)
- [Moq](https://github.com/moq/moq)

# Users
|        Права                | Анонимен | Колувач | Продавач | Собственик на сервизи |
|-----------------------------|----------|---------|----------|-----------------------|
| Преглед на всички коли      |    да    |    да   | да       | да                    |
| Преглед на всички части     |    да    |    да   | да       | да                    |
| Преглед на всички сервизи   |    да    |    да   | да       | да                    |
| Детайли на колите           |    да    |    да   | да       | да                    |
| Детайли на частите          |    да    |    да   | да       | да                    |
| Детайли на сервизите        |    да    |    да   | да       | да                    |
| Редакция на колите          |    не    |    не   | да       | не                    |
| Редакция на частите         |    не    |    не   | да       | не                    |
| Редакция на сервизите       |    не    |    не   | не       | да                    |
| Изтриване на колите         |    не    |    не   | да       | не                    |
| Изтриване на частите        |    не    |    не   | да       | не                    |
| Изтриване на сервизите      |    не    |    не   | не       | да                    |
| Списък с любими коли        |    не    |    да   | да       | да                    |
| Списък с любими части       |    не    |    да   | да       | да                    |
| Списък с любими сервизи     |    не    |    да   | да       | да                    |
| Списък с коли за продан     |    не    |    не   | да       | не                    |
| Списък с части за продан    |    не    |    не   | да       | не                    |
| Списък със собстрени сервизи|    не    |    не   | не       | да                    |

Предварително създадени потребители

| User type         | Email                   | Password |
|-------------------|-------------------------|----------|
| Buyer             | buyer@tob.com           | bbbbbb   |
| Seller            | seller@tob.com          | ssssss   |
| Car Service Owner | carserviceowner@tob.com | cccccc   |
| Admin             | admin@tob.com           | admin123 |

# Screenshots:

All cars

![image](https://github.com/Gerasim-Peshev/TuneOrBuy/assets/78636476/a09b144c-3a62-48bf-a019-7a0e9fa4d265)

All parts

![image](https://github.com/Gerasim-Peshev/TuneOrBuy/assets/78636476/461a8698-a674-4c0f-ac89-3d6d9d85487c)

All car services

![image](https://github.com/Gerasim-Peshev/TuneOrBuy/assets/78636476/4f0c49a5-5bbc-4b05-9dc1-e889112ac700)

Car details

![image](https://github.com/Gerasim-Peshev/TuneOrBuy/assets/78636476/f136d3e3-3268-459f-8e38-de6ae3595419)

# Database Diagram:

![image](https://github.com/Gerasim-Peshev/TuneOrBuy/assets/78636476/edff3687-1f1c-4cbb-8269-8819d0365548)
