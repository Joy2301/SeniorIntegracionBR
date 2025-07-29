# README

# Exchange Rate Microservices

## Instrucciones de Configuración y Ejecución

### Requisitos Previos

#### Instalación de .NET Runtime/SDK
- Descargar e instalar **.NET SDK** (versión recomendada: 8.0 o superior) desde [Microsoft .NET](https://dotnet.microsoft.com/).

---


## Ejecutar el Proyecto

## OPCION 1 - Abrir cada uno de los Proyectos en Visual Studio

1. Asegúrate de tener **Visual Studio 2022** o una versión más reciente instalada.
2. Descarga o clona el repositorio del proyecto.
3. Abre cada uno de los archivos de solución (`.sln`) en Visual Studio.

```
API1/
└── ExchangeRateAPI1/
├── ExchangeRateAPI1.sln
└── ExchangeRateAPI1.csproj

API2/
└── ExchangeRateAPI2/
├── ExchangeRateAPI2.sln
└── ExchangeRateAPI2.csproj

API3/
└── ExchangeRateAPI3/
├── ExchangeRateAPI3.sln
└── ExchangeRateAPI3.csproj

ComparingResultAPI/
└── ExchangeRateOrchestrator/
├── ExchangeRateOrchestrator.sln
└── ExchangeRateOrchestrator.csproj
```

4. Verifica que el **SDK .NET** en la configuración del proyecto sea compatible con tu versión instalada.
5. Compila el proyecto para asegurarte de que no haya errores.

---

## OPCION 2 - Línea de Comandos (dotnet)

Ejecutar cada uno de los microservicios desde la línea de comandos con el SDK de .NET instalado:

```bash
# API 1
dotnet run --project API1/ExchangeRateAPI1/ExchangeRateAPI1.csproj

# API 2
dotnet run --project API2/ExchangeRateAPI2/ExchangeRateAPI2.csproj

# API 3
dotnet run --project API3/ExchangeRateAPI3/ExchangeRateAPI3.csproj

# Orquestador
dotnet run --project ComparingResultAPI/ExchangeRateOrchestrator/ExchangeRateOrchestrator.csproj

 ```

 ---

 ### Cada uno de los micros se ejecutan en los siguientes puertos:

| Microservicio  | Puerto | URL Base                           | Endpoint                        | Formato esperado |
|----------------|--------|------------------------------------|----------------------------------|------------------|
| API 1          | 5276   | `http://localhost:5276`            | `/api1/v1/ExchangeRate`         | JSON             |
| API 2          | 5275   | `http://localhost:5275`            | `/api2/v1/ExchangeRate`         | XML              |
| API 3          | 5274   | `http://localhost:5274`            | `/api3/v1/ExchangeRate`         | JSON (wrapped)   |
| Orquestador    | 5280   | `http://localhost:5280`            | `/compare/v1/ExchangeRate`      | JSON (mejor tasa)|

#### 🔁 API 1

```bash
curl -X 'POST' \
  'http://localhost:5280/api1/v1/ExchangeRate' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "sourceCurrency": "EUR",
  "targetCurrency": "USD",
  "quantity": 63
}'

📎 Request URL:
http://localhost:5276/api1/v1/ExchangeRate

```

#### 🔁 API 2

```bash
curl -X 'POST' \
  'http://localhost:5275/api2/v1/ExchangeRate' \
  -H 'accept: */*' \
  -H 'Content-Type: application/xml' \
  -d '<?xml version="1.0" encoding="UTF-8"?>
<xml>
	<from>DOP</from>
	<to>USD</to>
	<amount>46</amount>
</xml>'

📎 Request URL:
http://localhost:5275/api2/v1/ExchangeRate

```

#### 🔁 API 3

```bash
curl -X 'POST' \
  'http://localhost:5274/api3/v1/ExchangeRate' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "sourceCurrency": "EUR",
  "targetCurrency": "DOP",
  "quantity": 46
}'

📎 Request URL:
http://localhost:5274/api3/v1/ExchangeRate

```


#### 🔁 Orquestador

```bash
curl -X 'POST' \
  'http://localhost:5280/api/orchestrator/v1/ExchangeRate' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "sourceCurrency": "EUR",
  "targetCurrency": "USD",
  "quantity": 63
}'

📎 Request URL:
http://localhost:5280/api/orchestrator/v1/ExchangeRate

```