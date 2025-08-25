# Важная информация


Для запуска приложения необходимо установить следующие NUGET-пакеты:

<img width="1171" height="322" alt="image" src="https://github.com/user-attachments/assets/061399f2-0757-41e2-8eaf-fe832fe44ef6" />

Протестировать приложение можно через Swagger:

<img width="1618" height="928" alt="image" src="https://github.com/user-attachments/assets/bd1dd367-72a7-4b42-b473-6e0be02dba4b" />


Пример успешного запроса:

<img width="1416" height="400" alt="image" src="https://github.com/user-attachments/assets/0467a69e-a361-4e13-9b98-45ed20bc69f8" />

<img width="1397" height="445" alt="image" src="https://github.com/user-attachments/assets/e71a9843-be1e-476d-ac45-98c3f0d11da6" />


Пример неуспешной валидации:

<img width="1409" height="343" alt="image" src="https://github.com/user-attachments/assets/60692e09-069f-4925-909d-3e2c665d438c" />

<img width="1393" height="505" alt="image" src="https://github.com/user-attachments/assets/0e742d32-7f0f-4b5c-95a3-3d676f18f03c" />


Подключений к бд реализовано в классе DbConnection (строка подключения в appsettings.json):

<img width="1141" height="261" alt="image" src="https://github.com/user-attachments/assets/2b3d94dd-44e0-45ab-8719-47c5a1873fac" />

<img width="832" height="375" alt="image" src="https://github.com/user-attachments/assets/33e19607-31be-47bf-86ec-08c670667450" />

DI и прочие настройки проекта располагаются в классе *Startup*:

<img width="778" height="765" alt="image" src="https://github.com/user-attachments/assets/12445d34-0700-4dee-b90b-c580a4aad3c1" />

Таблицы, их заполнение и процедуры находятся в файле *procedures.txt*
