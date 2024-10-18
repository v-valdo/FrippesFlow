!SEPARATION OF CONCERN!
!SINGLE RESPONSIBILITY PRINCIPLE!

Controllers --> funkar som API för vyerna (här injicerar vi repository-klasser för att kalla på databasen)
    - första-stoppet för alla requests till appen!
    - allt som rör user->server interaction

Repositories --> representerar, modellerar och instansierar klasser för databas-handlingar 

Services --> tar hand om all logik och programmering. Lagret mellan controller och services (här görs bla uträkningar/user authentication osv)

Models --> Databas-modellerna (fullständiga tabellerna)

ViewModels --> innehåller de vy-modeller som (i vårt fall) diagrammen ska använda å hämta data från


hälsningar valleballe