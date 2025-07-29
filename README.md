\# Exchange Rate Microservices



Este proyecto implementa una arquitectura basada en microservicios para simular tres proveedores de tasa de cambio y un \*\*orquestador\*\* que consulta todos y retorna la mejor tasa.



---



\## 🧱 Estructura del proyecto



La solución está compuesta por \*\*4 microservicios\*\* independientes:



1\. \*\*ExchangeRateAPI1\*\* - Recibe JSON.

2\. \*\*ExchangeRateAPI2\*\* - Recibe XML.

3\. \*\*ExchangeRateAPI3\*\* - Recibe JSON.

4\. \*\*ExchangeRateOrchestrator\*\* - Orquesta los anteriores y retorna la mejor tasa.



Cada microservicio expone un endpoint `POST /api/v1/ExchangeRate`.



---



\## 🚀 Requisitos



\- \[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

\- Visual Studio 2022 o superior

