# Queue System

## RabbbitMQ


### Run RabbitMQ

To successfully use the examples you will need a running RabbitMQ server.
```
docker run --rm -d -p 15672:15672 -p 5672:5672 rabbitmq:3.8-management
```

Locate the RabbitMQ folder
```
cd RabbitMQ
```

### Demo one: "Hello World!"

Run the consumer
```
dotnet run -p .\Receive\
```

Run the producer
```
dotnet run -p .\Send\
```

### Demo two: Work Queues


### Reference
[RabbitMQ tutorial - C#](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)

## NATS

## NATS Streaming
