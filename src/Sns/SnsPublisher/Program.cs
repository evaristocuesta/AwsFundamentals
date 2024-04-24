using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SnsPublisher;
using System.Text.Json;

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "contact@evaristocuesta.com",
    FullName = "Evaristo Cuesta",
    DateOfBirh = new DateTime(1976, 7, 3),
    GitHubUserName = "evaristocuesta"
};

var snsClient = new AmazonSimpleNotificationServiceClient();

var topicArnResponse = await snsClient.FindTopicAsync("customers");

var publishRequest = new PublishRequest
{
    TopicArn = topicArnResponse.TopicArn,
    Message = JsonSerializer.Serialize(customer),
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

_ = await snsClient.PublishAsync(publishRequest);
