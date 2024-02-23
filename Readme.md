# Informações Gerais

PROJETO: TaskManager
OBJETIVO: Desenvolver uma API que permita aos usuários organizar e monitorar suas tarefas diárias, bem como colaborar com colegas de equipe.
DESENVOLVEDOR: Tiago Penha
# 

Dependências:

Visual Studio 2022
https://visualstudio.microsoft.com/pt-br/downloads/

Docker
https://www.docker.com/get-started/

Obs: Neste repositório se encontra a solution TaskManagerNet e dentro da pasta src os projtetos (API, Business, Infrastructure,TaskManager.Tests).

# API
## Resumo:
Aplicação do tipo ASPNET.CORE API, utiliza como backEnd C#, .Net 6.0 e conexão com SQL server, faz uso de controllers

# Business
## Resumo:
Aplicação do tipo ClassLibray responsavel por realizar a regra de negocio da aplicação, contendo as interfaces, modelos e serviços, utiliza como backEnd C#

# Infrastructure
## Resumo:
Aplicação do tipo ClassLibray responsavel por realizar a conexão com o Banco de dados Sql Server, utiliza como backEnd C# e o ORM Entity Framework Core

## _Linguagens utlizadas pela aplicação:_

- C#
- Net 6.0
- Microsoft.EntityFrameworkCore.7.0.16
- Sql Server
- XUnit 
- NSubstitute

# Fase2
## Refinamento:
 1 - Somente o usuário que criou a tarefa, terá o direto de excluir a mesma ?
 2 - Como será feito a distinção de um usuário normal e um usuário gerente ?
 3 - Pode sugir outros tipos de usuários ?
 4 - Usuário do tipo gerente podera excluir um projeto com tasks pendentes ?
 5 - O histórico de atualização será utilizando quando ? Somente para uma eventual analise ou futuramente será incorporado a API ?
 6 - Os usuarios poderam criar categorias para as tarefas, exemplo (Trabalho, Estudo)
 7 - Vamos ter autenticação de usuário na api ?

# Fase 3
## Refinamento:
 1 - Colocaria autenticação JWT ou algo do tipo
 2 - Criaria um crud para usuario
 3 - Enviaria notificações para o dono do projeto, quando a tarefa tiver atualização.
     Para isso utilizaria a Mensageria(RabbitMq) para que fosse feito o envio em background.
