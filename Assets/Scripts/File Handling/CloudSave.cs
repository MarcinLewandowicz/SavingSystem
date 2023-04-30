using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using System.Security.Cryptography;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;*/

namespace ML.SavingSystem
{
    public class CloudSave
    {
        //private TransferUtility transferUtility = new TransferUtility();

        private const string awsBucketName = "mlgamebucket";
        private string fileName = "";
        private string filePath = "";


        public void SaveFileToCloud(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;

            // transferUtility.Upload(filePath, awsBucketName, fileName);
        }

        public void LoadFileFromCloud(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;

            // transferUtility.Download(filePath, awsBucketName, fileName);
        }
    }

}