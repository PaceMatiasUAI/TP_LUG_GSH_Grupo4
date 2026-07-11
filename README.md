# Gestión de Servicios Hoteleros - GSH

## Descripción del proyecto

**Gestión de Servicios Hoteleros - GSH** es una aplicación de escritorio desarrollada en **C# con Windows Forms**, orientada a la administración de servicios externos contratados por una cadena hotelera.

El sistema permite gestionar sucursales, prestadores de servicios, asociaciones entre ambos y pagos vinculados a dichas relaciones. Su objetivo principal es brindar una herramienta simple y ordenada para controlar qué prestadores trabajan con cada sucursal, registrar pagos pendientes o cancelados, aplicar recargos por vencimiento y mantener la consistencia de la información mediante reglas de negocio.

Este proyecto fue desarrollado como **Trabajo Práctico Integrador** para la materia **Lenguajes de Última Generación**.

---

## Integrantes

- Lema, Sebastián Alejandro
- Marino, Federico Gabriel
- Pace, Matías Alejandro
- Echegaray, Isaac Alberto

---

## Tecnologías utilizadas

- C#
- .NET 9
- Windows Forms
- SQL Server
- ADO.NET
- Microsoft.Data.SqlClient
- Arquitectura en capas
- Git / GitHub

---

## Arquitectura de la solución

La solución fue organizada en capas para separar responsabilidades y facilitar el mantenimiento del sistema.

### Proyectos principales

- **UI_GSH**  
  Contiene los formularios de la aplicación y la interacción con el usuario.

- **BLL_GSH**  
  Contiene la lógica de negocio, validaciones y reglas funcionales del sistema.

- **DAL_GSH**  
  Contiene el acceso a datos y la comunicación con la base de datos SQL Server.

- **Mapper_GSH**  
  Contiene las clases encargadas de mapear los datos obtenidos desde la base hacia entidades del sistema.

- **BE_GSH**  
  Contiene las entidades de negocio y los DTO utilizados para mostrar información en la interfaz.

---

## Funcionalidades principales

El sistema permite realizar las siguientes operaciones:

- Alta, modificación, baja y consulta de sucursales.
- Alta, modificación, baja y consulta de prestadores.
- Asociación de prestadores a sucursales.
- Reactivación de asociaciones previamente inactivas.
- Consulta de prestadores asociados a una sucursal.
- Consulta de sucursales asociadas a un prestador.
- Generación de pagos vinculados a una sucursal y un prestador.
- Consulta general de pagos.
- Consulta de pagos por sucursal y prestador.
- Cancelación de pagos pendientes.
- Cálculo automático de recargos por pagos vencidos.
- Validaciones para evitar operaciones inválidas.
- Uso de transacciones en operaciones críticas.

---

## Base de datos

La base de datos utilizada por el sistema se denomina:

```text
GSH_DB
