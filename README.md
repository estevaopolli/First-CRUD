# Sistema de Autenticação feito com JavaScript e C# .NET
Esse um projeto de estudo para entender como funciona a comunicação entre Front-End e Back-End em um sistema de autenticação.  
Para o desenvolvimento do projeto utilizei HTML e CSS e JavaScript no Front-End e C# .NET para o back-end

## Front-End
No Front-End o JavaScript é dividido em três códigos:  
* api.js que envia as requisições para o back-end por meio de funções assíncronas exportadas.
* validateSignup.js que importa a função "singup()" do api.js e os envia os dados de cadastro.
* validateLogin.js que importa a função "login()" do api.js e os envia os dados preenchidos no login.

## Back-End
O Back-End é uma minimal API desenvolvida com C# que recebe as requisições do front-end, criptografa e verifica a senha utilizando a classe PasswordHasher nativa do ASP.NET. Ele também é responsável em verificar se as credenciais do usuário estão existem no sistema.

## Banco de Dados
No momento a aplicação não funciona com um banco de dados externo. Ele salva as informações diretamente na memória do sistema. Mas pretendo incrementa-lo muito em breve utilizando o SQL Server.

