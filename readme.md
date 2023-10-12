# Aplicativo Self-Messaging

O aplicativo Self-Messaging é uma aplicação web construída com ASP.NET MVC que permite aos usuários enviar e receber mensagens.
# Estudo
Este projeto tem como foco proporcionar um ambiente de estudo voltado para o entendimento e prática de filas de mensagens utilizando RabbitMQ e a entrega dessas mensagens em tempo real com SignalR. (WebSocket)

## Funcionalidades:

1. **Envio de Mensagens**:
   - Os usuários podem inserir mensagens em um campo de texto e enviá-las para uma fila, e aguardá-la até a sua entrega.


2. **Integração com Fila (RabbitMQ)**:
   - O aplicativo utiliza RabbitMQ como um mecanismo de fila para processar as mensagens. Cada mensagem é enfileirada para posterior processamento.

3. **WebSocket com SignalR**:
   - O aplicativo utiliza SignalR para fornecer uma experiência de tempo real, permitindo que os usuários vejam atualizações de status sem a necessidade de recarregar a página.

## Tecnologias Utilizadas:

- **ASP.NET MVC**: Estrutura de desenvolvimento web da Microsoft para construir aplicativos escaláveis.

- **RabbitMQ**: Sistema de mensageria para gerenciar a comunicação entre partes do aplicativo.

- **SignalR**: Biblioteca para adicionar funcionalidades em tempo real às aplicações web.

## Como Executar o Aplicativo:

1. Clone o repositório.
2. Certifique-se de ter o .NET SDK e o RabbitMQ instalados.
3. Certifique-se de ter o RabbitMq executando em localhost
3. Execute o aplicativo através do .NET CLI através do comando "dotnet run" e abra-o em um navegador web.
4. Comece a enviar e receber mensagens em tempo real!

## Autor :
``` @Deybson.ferreira ```