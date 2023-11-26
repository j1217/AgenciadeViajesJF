# Agencia de Viajes: Gestión de Hoteles y Reservas

## Introducción
El proyecto "Agencia de Viajes: Gestión de Hoteles y Reservas" se desarrolló en Visual Studio 2022 con .NET 6, siguiendo una arquitectura exagonal para garantizar modularidad y mantenibilidad. Este sistema tiene como objetivo principal facilitar a los viajeros la reserva de hoteles según sus preferencias. Utiliza SQL Server como base de datos y se implementó la metodología de código en el enfoque de Entity Framework y Scaffolding. A continuación, se presenta una visión general del proyecto, su estructura y las tecnologías utilizadas.

## Objetivos del Proyecto
El objetivo principal del proyecto es proporcionar una plataforma robusta para la gestión de hoteles y reservas, permitiendo a los viajeros realizar operaciones como buscar hoteles, seleccionar habitaciones y realizar reservas. También se tiene en cuenta la asociación de contactos de emergencia para cada reserva.

## Tecnologías Utilizadas
- **Visual Studio 2022:** Entorno de desarrollo integrado (IDE) utilizado para la creación del proyecto.
- **.NET 6:** Framework utilizado para el desarrollo de la aplicación.
- **SQL Server:** Motor de base de datos relacional utilizado para almacenar y gestionar los datos.
- **Entity Framework:** ORM (Object-Relational Mapping) utilizado para la interacción con la base de datos.
- **Inyección de Dependencias:** Se emplea para mejorar la modularidad y flexibilidad del código, respetando los principios SOLID.
- **Clean Code:** Se aplican prácticas de programación limpias y legibles para mejorar la comprensión y mantenimiento del código.
- **AutoMapper:** Utilizado para mapear entidades y DTOs, simplificando la transferencia de datos entre capas.

## Principios SOLID y Clean Code
El código sigue los principios SOLID, que son un conjunto de buenas prácticas de diseño de software, y se adhiere a los principios de Clean Code, fomentando la legibilidad y mantenimiento del código.

## Estructura del Proyecto
El proyecto está estructurado en capas, siguiendo una arquitectura exagonal:

- **AgenciadeViajesJF:** Capa de aplicación que contiene los controladores (controllers) que exponen los endpoints API para interactuar con el sistema.
- **AgenciadeViajesJF.Application:** Capa de servicios que encapsula la lógica de negocio.
- **AgenciadeViajesJF.Domain:** Capa de dominio que contiene las entidades y reglas de negocio.
- **AgenciadeViajesJF.Infrastructure:** Capa de infraestructura que implementa las interfaces definidas en la capa de aplicación.

## Arquitectura Exagonal
La arquitectura exagonal, también conocida como arquitectura de puertos y adaptadores, se implementa para separar claramente el núcleo de la aplicación de los detalles de implementación. En este proyecto, la capa de aplicación (AgenciadeViajesJF) actúa como el núcleo, que contiene la lógica de negocio y los casos de uso. Esta capa se comunica con el exterior a través de puertos, que son interfaces definidas en el proyecto AgenciadeViajesJF.Application. Los adaptadores en AgenciadeViajesJF.Infrastructure implementan estas interfaces para interactuar con bases de datos, servicios externos y otros detalles de implementación.

Esta arquitectura facilita la adaptabilidad del sistema, ya que los cambios en los detalles de implementación no afectan el núcleo de la aplicación. Además, mejora la prueba unitaria y la modularidad del código al permitir la fácil sustitución de adaptadores.

## Implementación de Base de Datos en Código
La metodología de implementación de base de datos en código se realizó mediante el uso de Entity Framework y Scaffolding. Esto proporciona una manera eficiente de generar modelos y contexto a partir de una base de datos existente.

## Conclusiones
El proyecto proporciona una solución escalable y mantenible para la gestión de hoteles y reservas, siguiendo las mejores prácticas de desarrollo en .NET 6 y respetando los principios de diseño SOLID. La arquitectura exagonal contribuye a una separación clara entre el núcleo de la aplicación y los detalles de implementación, facilitando la adaptabilidad y el mantenimiento del sistema.
