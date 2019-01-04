using System;
using System.IO;
using FluentFTP;

namespace FileParsing
{
    /// <summary>
    /// FtpProvider based on System.Net.FtpClient class for use with Qoniac.Ovalis.DataImport.Core.Net.SimpleFtpClient 
    /// </summary>
    internal sealed class FluentFtpProvider : IDisposable
    {
        private readonly FtpClient _ftpClient;

        /// <summary>
        /// Initializes a new instance of NetFtpProvider
        /// </summary>
        public FluentFtpProvider()
        {
            _ftpClient = new FtpClient
            {
                Host = "ftp://speedtest.tele2.net/"
            };
        }

        /// <summary>
        /// Provides a stream to read data from a file on the FTP server
        /// </summary>
        /// <param name="path">Path to the file to read</param>
        /// <returns>Stream to read data</returns>
        public Stream OpenRead(string path)
        {
            return _ftpClient.OpenRead(path);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the NetFtpProvider
        /// </summary>
        public void Dispose()
        {
            _ftpClient.Disconnect();
            _ftpClient.Dispose();
        }
    }
}
