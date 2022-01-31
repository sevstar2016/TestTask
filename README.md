<h1 align="center">Test Task</h1>

---
<h2>Database</h2>
    <p1>CarContext</p1> - <p1>Здесь содержатся параметы для бызы данных  которой я взаимодействую через Entity Framework</p1>\
    <p1>CarRepo</p1> - <p1>Тут описаны все взаимодействия EF с GraphQL</p1>\
    DbInit - Тут всё понятно по названию. Подключение к бд и её инициализация\
    ICarRepo - В этом скрипте описаны все мутации и запросы к GraphQL

<h2>GraphQL</h2>
    <h3>Types</h3> \
        CarModelObject - Описание объекта для взаимодействия, модели CarModel, о ней чуть позже 
        CarObject - Описание объекта для взаимодействия, модели Car, о ней тоже чуть позже\
        ReportObject - Описание объекта для взаимодействия отчёта(Всякие ошибки, успехи и тд)\
        Statistics - Описание объекта для взаимодействия статистики\
        CarSchema - Объясняет GraphQL где описаны запросы к ней же\
        MutationObject - Описание запросов в виде мутаций\
        QueryObject - Описание запросов для получения данных\
\
\
    <h3>Models</h3> \
        Car - Модель EF объекта машины\
        CarModel - Модель EF объекта изготовителя