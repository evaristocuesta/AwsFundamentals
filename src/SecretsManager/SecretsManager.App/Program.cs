using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var secretsManagerClient = new AmazonSecretsManagerClient();

var listSecretVersionRequest = new ListSecretVersionIdsRequest
{
    SecretId = "ApiKey",
    IncludeDeprecated = true
};

try
{
    var versionResponse = await secretsManagerClient.ListSecretVersionIdsAsync(listSecretVersionRequest);

    foreach (var version in versionResponse.Versions)
    {
        Console.WriteLine($"{version.VersionId} - {version.CreatedDate}");
    }
}
catch (ResourceNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

var request = new GetSecretValueRequest
{
    SecretId = "ApiKey", 
    VersionStage = "AWSCURRENT"
};

try
{
    var response = await secretsManagerClient.GetSecretValueAsync(request);
    Console.WriteLine(response.SecretString);
}
catch (ResourceNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

var describeSecretRequest = new DescribeSecretRequest
{
    SecretId = "ApiKey"
};

try
{
    var describeResponse = await secretsManagerClient.DescribeSecretAsync(describeSecretRequest);

    Console.WriteLine(describeResponse.CreatedDate);
}
catch (ResourceNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}



