# Teste_Saggezza Test

## Tecnologias
- .NET 6
- SQL Server
- Entity Framework
- JWT
- Docker

## Serviços

### Auth Service
- Registro
- Login
- JWT

### Supplier Service
- Cadastro de fornecedores
- Protegido com JWT

## Como rodar

```bash
docker-compose up --build

## 

Authorization: Bearer TOKEN

##

microservices-test/
│
├── auth-service/
│   └── AuthService/
│       ├── Domain/
│       ├── Application/
│       ├── Infrastructure/
│       ├── API/
│       └── Program.cs
│
├── supplier-service/
│   └── SupplierService/
│       ├── Domain/
│       ├── Application/
│       ├── Infrastructure/
│       ├── API/
│       └── Program.cs
│
├── docker-compose.yml
└── README.md