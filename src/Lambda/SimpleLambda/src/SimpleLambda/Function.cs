using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SimpleLambda;
public class Function
{

    /// <summary>
    /// A simple example function
    /// </summary>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public string FunctionHandler(Hello request, ILambdaContext context)
    {
        string message = $"Hi from {request.World}";
        context.Logger.LogInformation(message);
        return message;
    }

    public class Hello
    {
        public string World { get; set; } = string.Empty;
    }
}
