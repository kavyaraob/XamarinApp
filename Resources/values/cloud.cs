using System;

using Amazon.S3;
using Amazon.S3.Model;
using System.IO;


namespace Calculator
{ 
	public class cloud

	{    

		public static void saveFile()
		{
		string accessKey = "*********************";
		string secretKey = "******************************************";

			AmazonS3Client s3 = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.USEast1);


			var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var fileName = Path.Combine(path, "write.txt");
			PutObjectRequest request = new PutObjectRequest{
			BucketName = "calculatorkrao1",
			Key = "EquationList",
				FilePath = fileName,

		};

		System.Threading.Tasks.Task<PutObjectResponse> response = s3.PutObjectAsync(request);



	}


	}
			


}

