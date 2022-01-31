<h1 align="center">Test Task</h1>

---
<h2>Database</h2>
    <p1>CarContext</p1> - <p1>Здесь содержатся параметы для бызы данных  которой я взаимодействую через Entity Framework</p1>
    <p1>CarRepo</p1> - <p1>Тут описаны все взаимодействия EF с GraphQL</p1>
    <p1>DbInit - Тут всё понятно по названию. Подключение к бд и её инициализация
    <p1>ICarRepo - В этом скрипте описаны все мутации и запросы к GraphQL

<h2>GraphQL</h2>
    <h3>Types</h3>
        <p1>CarModelObject - Описание объекта для взаимодействия, модели CarModel, о ней чуть позже 
        <p1>CarObject - Описание объекта для взаимодействия, модели Car, о ней тоже чуть позже
        <p1>ReportObject - Описание объекта для взаимодействия отчёта(Всякие ошибки, успехи и тд)
        <p1>Statistics - Описание объекта для взаимодействия статистики
        <p1>CarSchema - Объясняет GraphQL где описаны запросы к ней же
        <p1>MutationObject - Описание запросов в виде мутаций
        <p1>QueryObject - Описание запросов для получения данных
    <h3>Models</h3>
        <p1>Car - Модель EF объекта машины
        <p1>CarModel - Модель EF объекта изготовителя