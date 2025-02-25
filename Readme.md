







# Ejecución

Importante: la aplicación como es de pruebas, dentro de program llama a app.SeedData(); Este método genera usuarios de prueba y datos de vehiculos de prueba. Para los vehiculos se han generado algunos vehiculos con la liberia de datos aleatorios Bogus:
https://github.com/bchavez/Bogus#bogus-api-support

Ejecutar la aplicación con el siguiente comando. Esto levantará un conenedor con la image de .net y la imagen de mssql. Además levantará el swagger en el navegador

```
docker compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

# Entornos

## development 
ejecuta la api en local, contra el mssql en docker

## test
ejecuta api en docker contra mssql en docker, para debuggear desde vscode pero no fuí capaz de hacerlo funcionar por falta de tiempo


## ejecutar test

```
dotnet test test/PruebaGtMotive/PruebaGtMotive.Api.FunctionalTests/
dotnet test test/PruebaGtMotive/PruebaGtMotive.Application.UnitTests/
dotnet test test/PruebaGtMotive/PruebaGtMotive.Domain.UnitTests/
dotnet test test/PruebaGtMotive/PruebaGtMotive.Application.IntegrationTests/
# no implementado, la idea es que no se rompan las reglas del DDD
dotnet test PruebaGtMotive.Architecture.UnitTests/ 

```
# Casos de uso

## crear alquiler
1 obtener datos del usuario listando en el metedo GetUsers
2 listar datos de vehiculo disponibles GetVehiculosDisponibles
3 hacer la petición desde el metodo CreateAlquiler

## Entregar vehiculo
Ir al metodo correspondiente EntregarVehiculo el cual pedirá el userid y el vehiculoid. Para obtener los id se explica en el párrafo anterior.



# Caracteristicas de esta arquitectura haxagonal
* Uso de Strong Types ID
* Uso de Mediatr
* Uso de EF
* Uso de FluentValidation
* Uso del patrón Cqrs, 
* Uso de Result pattern
* Uso de Unit of work
* Los eventos de dominio se alamcenan en una lista en  memoria, esto es facilmente escalable por ejemplo a un outbox pattern, mediante el cual podemos ir almacenando esos eventos en una tabla de bd por ejemplo o pasarlos por mensajería
* En el domino se ven los roles. La idea de esto es generar roles para los usuarios. No está implementado
* No se implementó autenticación, pero es facilmente implementable y además se puede conjuntar con los roles descritos en el paso anterior para poder denegar el acceso en base a estos a diferentes endpoints.