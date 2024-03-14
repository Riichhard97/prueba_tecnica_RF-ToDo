# prueba_tecnica_RF-ToDo

Commandos para migraciones:
dotnet ef database update --context CoreDbContext --startup-project ../API
dotnet ef migrations add MigrationInit --startup-project ../API --context CoreDbContext --output-dir Migrations
