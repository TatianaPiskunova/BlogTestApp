# Web-приложение, реалижующий блог на основе Asp.Net Core
Приложение Блог на ASP.NET 7.0
Использован шаблон MVC

Страницы созданы при помощи Bootstrap и css свойств

Пользователи:
_Гости_  - могут только просматривать посты и комментарии к ним
Зарегистрированные и авторизированные пользователи могут добавлять посты, публиковать комментарии и редактировать свои сообщения
_Admin_ (логин Boss, пароль &Aa1234  ) - получает список всех зарегистрированных пользователей


Функционал:
На главной странице отображаются все посты из БД. При нажатии на кнопку "Читать далее", открывается страница с постом и комментариями к этому посту. На этой странице можно публиковать комментарии и редактировать название и текст своего поста.

БД - MSSQL, создается при помощи миграций

Таблица Posts включает в себя название поста, текст, имяя пользователя и изображение
Таблица Comment включает в себя текст, дата создания, пользователя и внешний ключ, который соединяет комментарий с постом
