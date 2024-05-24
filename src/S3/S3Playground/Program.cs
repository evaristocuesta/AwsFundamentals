
using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();

await using var inputImageStream = new FileStream("./face.jpg", FileMode.Open, FileAccess.Read);

var putImageRequest = new PutObjectRequest
{
    BucketName = "ecgs3bucket", 
    Key = "images/face.jpg", 
    ContentType = "image/jpeg",
    InputStream = inputImageStream
};

await s3Client.PutObjectAsync(putImageRequest);

await using var inputCsvStream = new FileStream("./movies.csv", FileMode.Open, FileAccess.Read);

var putCsvRequest = new PutObjectRequest
{
    BucketName = "ecgs3bucket",
    Key = "files/movies.csv",
    ContentType = "text/csv",
    InputStream = inputCsvStream
};

await s3Client.PutObjectAsync(putCsvRequest);