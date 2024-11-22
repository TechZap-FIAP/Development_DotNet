# Documentação da API - TechZap

Esta documentação descreve a plataforma **S.O.L** da empresa **TechZap**, uma solução SaaS desenvolvida para auxiliar as pessoas, empresas e entre outros a alcançarem metas de sustentabilidade e economia de energia.

## Integrantes

- **RM99513** - Rodrigo Batista Freire - Java Advanced
- **RM99562** - Kaique Santos de Andrade - Mobile Development
- **RM99466** - Marcelo Augusto de Mello Paixão - Development with .NET e DevOps & Cloud Computing
- **RM97967** - Vinicius Oliveira de Almeida - Mastering Database
- **RM98644** - Thiago Martins Bezerra - Disruptive Architectures (IA)

# Primeiros Passos

Abra o projeto clicando no arquivo **APITechZap.sln**

Após isto, abra os seguintes arquivos: 
- techzap-firebase.json
- appsettings.json

Coloque os dados que estão nos arquivos do Drive abaixo,

- [Link das Credenciais](https://drive.google.com/drive/folders/1_hxC8T8OORYzpQQ6GbnM_xU3mdbvykQR?usp=sharing)

# API Endpoints

## Address Controller
- **GET** -> `/api/address/{userId}` (Get Address by User ID)
- **POST** -> `/api/address/{userId}` (Add Address for User)
- **PUT** -> `/api/address/{userId}` (Update Address for User)

## Users Controller
- **POST** -> `/api/user/login` (User Login)
- **GET** -> `/api/user` (Get All Users)
- **GET** -> `/api/user/{id}` (Get User by ID)
- **POST** -> `/api/user/register` (Register New User)
- **PUT** -> `/api/user/update/{userId}` (Update User)
- **DELETE** -> `/api/user/delete/{userId}` (Delete User)
- **POST** -> `/api/user/reactivate/{userId}` (Reactivate User)
- **POST** -> `/api/user/forgot-password/{actualEmail}` (Reset Password)

## User Additional Data Controller
- **GET** -> `/api/user-additional-data/{userId}` (Get Additional Data by User ID)
- **POST** -> `/api/user-additional-data/{userId}` (Add Additional Data for User)
- **PUT** -> `/api/user-additional-data/{userId}` (Update Additional Data for User)

## Solar Panel Controller
- **POST** -> `/api/solar-panel` (Add Solar Panel)
- **POST** -> `/api/solar-panel/type/{solarPanelId}` (Add Type for Solar Panel)
- **GET** -> `/api/solar-panel` (Get All Solar Panels)
- **GET** -> `/api/solar-panel/{id}` (Get Solar Panel by ID)

## Wind Turbine Controller
- **POST** -> `/api/wind-turbine` (Add Wind Turbine)
- **POST** -> `/api/wind-turbine/type/{windTurbineId}` (Add Type for Wind Turbine)
- **GET** -> `/api/wind-turbine` (Get All Wind Turbines)
- **GET** -> `/api/wind-turbine/{id}` (Get Wind Turbine by ID)

## Contracted Plan Controller
- **POST** -> `/api/contracted-plan/add-contracted-plan/{userId}` (Add Contracted Plan)
- **GET** -> `/api/contracted-plan/get-contracted-plan/{userId}` (Get Contracted Plans by User ID)
- **DELETE** -> `/api/contracted-plan/del-contracted-plan/{planId}` (Delete Contracted Plan)

## AI Controller
- **GET** -> `/api/support` (AI Support Service)

# Observações

O método de IA para o suporte e auxilio ao cliente não funciona, pois não temos créditos ou recursos necessários para manté-lo funcional.