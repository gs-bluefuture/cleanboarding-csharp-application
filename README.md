# Clean Boarding 🚢

## 🎯 Escopo do Projeto
Este projeto é uma API REST para gerenciar um sistema de cadastro e gerenciamento de navios. A API permite criar, consultar, atualizar e deletar informações de navios no sistema.

## 📌 Overview
"Clean Boarding" é uma solução inovadora projetada para melhorar a gestão da água de lastro em navios, visando prevenir bioinvasões que podem causar danos significativos aos ecossistemas marinhos. Este projeto utiliza tecnologia de ponta para monitorar, tratar e realizar o deslastro de água de maneira segura e eficiente.

## 🚀 Solução
A solução "Clean Boarding" inclui:
- **Monitoramento em Tempo Real:** Utilização de sensores IoT para monitorar continuamente a qualidade da água de lastro e detectar quaisquer sinais de contaminação ou presença de organismos invasores.
- **Tratamento Eficiente:** Aplicação de tecnologias avançadas para neutralizar organismos nocivos antes que a água seja descarregada.
- **Deslastro Seguro:** Liberação da água tratada em áreas aprovadas e seguras, longe das zonas costeiras, para evitar impactos ambientais adversos.

### Principais Funcionalidades
- **Cadastrar Navios**: Adiciona novos navios ao sistema.
- **Visualizar Navios**: Permite a consulta de todos os navios cadastrados ou de um navio específico pelo ID.
- **Atualizar Navios**: Atualiza informações de um navio existente.
- **Deletar Navios**: Remove um navio do sistema.

## 🚀 Como Executar o Projeto

### Pré-Requisitos
Para executar este projeto, você precisará:
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Um sistema de gerenciamento de banco de dados Oracle
- Visual Studio ou outro editor de código que suporte C# e ASP.NET Core

### Passos para Execução
1. **Clone o Repositório**
```bash
   git clone <url-do-repositorio>
   cd <pasta-do-projeto>
```

2. **Configurar a String de Conexão**

3. Abra o arquivo appsettings.json.

4. Modifique a string de conexão OracleConnection para apontar para seu banco de dados Oracle.

5. **No terminal ou no console de comando do Visual Studio, execute:**
```bash
dotnet ef database update
``` 

6. **Iniciar o Projeto**

7. **Ao rodar a aplicação, será aberto uma guia do seu navegador padrão com o swagger configurado para testar as requisições.**

8. **Acessar a API via Swagger**


## 📝 Endpoints para Teste

### **Endpoint de GET**
- GET /api/navio: Retorna uma lista de todos os navios.
- GET /api/navio/{id}: Retorna um navio específico pelo ID.

### **Endpoint de POST**
- POST /api/navio: Cria um novo navio. Requer um corpo de solicitação com os detalhes do navio.

### **Endpoint de PUT**
- PUT /api/navio/{id}: Atualiza um navio existente. Requer o ID do navio e um corpo de solicitação com os detalhes atualizados.

### **Endpoint de DELETE**
- DELETE /api/navio/{id}: Deleta um navio pelo ID.

### Autores
---
- <sub><b>RM96920 - Matheus Ramos de Pierro</b></sub>
- <sub><b>RM97187 - Victor Shimada Serete</b></sub>
- <sub><b>RM97121 - Gabriel Tricerri André Niacaris</b></sub>
- <sub><b>RM97097 - Felipe de Lima Santiago</b></sub>
- <sub><b>RM97136 - Thiago Gyorgy Teixeira de Castro</b></sub>
