# ControlAccess
## Descrição:
Projeto de estudo com o objetivo de colocar de fato a mão na massa e aplicar os conhecimentos obtidos em estudos, principalmente relacionado aos conteúdos da carreira de .NET da plataforma Balta.io (https://balta.io/carreiras/desenvolvedor-backend-dotnet)
## Ideia do projeto:
Consideremos uma softhouse que tem seus parceiros (CATs) que por sua vez tem seus clientes e estes tem equipamentos. A finalidade da aplicação é ter os dados de acesso dos equipamentos dos clientes.

O projeto é de fato simples e o problema apresentado pode ser facilmente resolvido com uma aplicação Data Drive realizando as poucas validações necessárias através das notações do EF, mas, como o foco é aplicar o conhecimento obtido, literalmente matei uma formiga com uma fuzil...rs

## O que apliquei:
- Divisão do projeto em subprojetos: api, domain (puro para facilitar a aplicação de testes e reaproveitamento), infra e testes.
- Domínio ricos.
- Injeção de dependência.
- OOP:
  - Classe abstratas e estáticas.
  - Interface.
  - Herança.
  - Polimorfismo.
- DDD
   - CQRS: principalmente com os commands.
   - Validações e não exceptions (Domain Notification) utilizando o pacote flunt e trabalhando com o conceito de fail fast validation.
  - Handlers a partir de um command (garantindo assim a não corrupção de código). Ideia é poder reaproveitar, testar e evitar que a controller tenha muita implementação.
- Repository patter.
  - Classe generica para realização do crud.
  - EF: mapeamento das tabelas feitos via fluent api, persistindo em um banco de dados Mysql e code first com os migrations.
- Testes.
- Aplicação de alguns conceitos do SOLID: como principio da responsabilidade única e trabalhar com a abstração e não com a implementação.