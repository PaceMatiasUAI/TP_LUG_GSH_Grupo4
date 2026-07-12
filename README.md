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

GSH_DB
Está compuesta por las siguientes tablas:

tbSucursal
tbPrestador
tbContrato
tbPago
tbTipoPago
Relaciones principales
Una sucursal puede tener varios contratos.
Un prestador puede estar asociado a varias sucursales.
La tabla tbContrato representa la asociación entre sucursales y prestadores.
Un contrato puede tener varios pagos asociados.
Un tipo de pago puede estar vinculado a varios pagos.
Reglas de negocio principales

El sistema implementa reglas de negocio orientadas a mantener la consistencia de la información:

No se permiten códigos repetidos para sucursales, prestadores o pagos.
No se permiten altas con datos obligatorios incompletos.
No se permite asociar sucursales o prestadores inactivos.
No se permite generar pagos sin una asociación previa activa.
No se permite generar pagos con importes menores o iguales a cero.
Todo pago se genera inicialmente en estado No Cancelado.
Al cancelar un pago, se registra la fecha de pago, el recargo y el total abonado.
No se permite cancelar dos veces el mismo pago.
No se permite quitar una asociación si posee pagos pendientes.
No se permite eliminar sucursales o prestadores con historial relacionado.
No se permite desactivar sucursales o prestadores con asociaciones activas.
Tipos de pago

El sistema contempla los siguientes medios de pago:

Tipo de pago	Recargo por vencimiento
Transferencia	2%
Cheque	5%

El recargo se aplica automáticamente cuando el pago se cancela luego de la fecha de vencimiento.

Ejecución del proyecto

Para ejecutar el sistema:

Clonar el repositorio.
Abrir la solución en Visual Studio 2022.
Crear la base de datos GSH_DB en SQL Server.
Ejecutar el script de creación de tablas correspondiente.
Verificar la cadena de conexión en el archivo de configuración del proyecto.
Establecer UI_GSH como proyecto de inicio.
Compilar y ejecutar la solución.
Cadena de conexión

El sistema utiliza una cadena de conexión configurada con el nombre: GSH_DB
La misma debe apuntar a la instancia local o remota de SQL Server donde se encuentre creada la base de datos.

Ejemplo orientativo:
<connectionStrings>
  <add name="GSH_DB"
       connectionString="Data Source=.;Initial Catalog=GSH_DB;Integrated Security=True;TrustServerCertificate=True"
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
Estado del proyecto

El proyecto se encuentra funcional e incluye:

Interfaz gráfica desarrollada en Windows Forms.
Arquitectura en capas.
Persistencia en base de datos.
Reglas de negocio implementadas.
Manejo de asociaciones entre entidades.
Gestión y cancelación de pagos.
Cálculo de recargos.
Uso de transacciones.
Documentación del sistema.
