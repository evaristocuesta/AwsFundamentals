using Amazon.SQS;
using Amazon.SQS.Model;
using SqlPublisher;
using System.Text.Json;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "contact@evaristocuesta.com",
    FullName = "Evaristo Cuesta",
    DateOfBirh = new DateOnly(1976, 7, 3), 
    GitHubUserName = "evaristocuesta"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer), 
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        { 
            "MessageType", new MessageAttributeValue
            {
                DataType = "String", 
                StringValue = nameof(CustomerCreated)
            }
        }
    }
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);
Console.WriteLine(response.HttpStatusCode);