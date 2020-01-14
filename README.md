[Link referência](https://dev.to/mviegas/pt-br-introducao-ao-rabbitmq-com-net-core-15oc)



RabbitMQ com .NET Core

Quem faz o que dentro do RabbitMQ
Exchange
Sendo um pouco repetitivo, a Exchange é um artefato de roteamento que funciona como um carteiro responsável por entregar as mensagens. Quando uma mensagem é publicada numa exchange, é enviada uma propriedade (setada por quem envia) chamada routing key. Essa key funciona como o endereço do destinatário. A exchange olha a key e sabe para onde entregar.

Dito isso, Existem quatro tipos exchange no RabbitMQ:

Direct: a mensagem é enviada para uma fila com o mesmo nome da routing key. Se a routing key não for informada, ela é enviada para uma fila padrão.

Fanout: a mensagem é distribuída para todas as filas associadas (falaremos sobre isso mais abaixo). Esse tipo de exchange ignora a routing key.

Topic: a mensagem é distribuída de acordo com um padrão enviado pela routing key.

Header: a mensagem é distribuída de acordo com seus cabeçalhos. Dessa forma, é feito um match com qual consumidor deve receber aquela mensagem.

Queues (filas)
Recebem as mensagens da exchange e armazenam até que um consumidor se conecte para retirar as mensagens de lá. O nome sugere, isso é feito seguindo uma lógica FIFO (first-in, first-out). Podem ter os seguintes atributos:

Durable: a fila sobrevive ao restart do message broker. O RabbitMQ possui um banco de dados chamado Mnesia aonde armazena essas informações.
Exclusive: possui somente 1 consumidor e morre quando não há mais consumidores.
Autodelete: morre quando não há mais mensagens.
Binds (associações)
Para que uma exchange entregue uma mensagem para uma fila, deve haver uma associação, um bind entre elas. Isso pode ser feito de maneira programática por quem envia ou através de uma interface web que o RabbitMQ disponibiliza para gerenciamento do broker.

Virtual hosts (vhosts)
Tudo isso que falamos acima, são entidades do RabbitMQ. Um grupo lógico dessas entidades é chamado de virtual host. Um vhost funciona como um tenant dentro do RabbitMQ, que, inclusive, é descrito (na doc sobre vhosts)[https://www.rabbitmq.com/vhosts.html] por essa razão um sistema multi-tenant.

É importante frisar que um vhost é um separação lógica e não física dessas entidades. Separar esses recursos fisicamente é detalhe de implementação de infra-estrutura.

Container no Docker com RabbitMQ
docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 15672:15672 rabbitmq:3-management

Criando os projetos Console
dotnet new console -o rabbitmq-demo-consumer
dotnet new console -o rabbitmq-demo-publisher

Inserindo depedência do RabbitMQ.Client
dotnet add package RabbitMQ.Client

dotnet run 
