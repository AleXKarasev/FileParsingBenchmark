using System;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace FileParsing
{
    public class FileParser
    {
        [Benchmark]
        public void InMemoryParsing()
        {
            ParseFileStream(ftpStream =>
            {
                var memoryStream = new MemoryStream();

                var buffer = new byte[16 * 1024];
                int read;
                while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }

                memoryStream.Position = 0;

                Parse(memoryStream);
            });
        }

        [Benchmark]
        public void StreamingParsing()
        {
            ParseFileStream(Parse);
        }

        private void ParseFileStream(Action<Stream> parse)
        {
            using (var ftpClient = new FluentFtpProvider())
            {
                parse(ftpClient.OpenRead("100MB.zip"));
            }
        }

        private void Parse(Stream inputStream)
        {
            var byteCount = 0;

            const int bufferSize = 5 * 1024 * 1024;
            var blockHeader = new byte[14];
            var buffer = new byte[bufferSize];

            bool init = true;
            int readerStart = 0;
            int readerLength = buffer.Length;
            int readByte;
            while ((readByte = inputStream.Read(buffer, readerStart, readerLength)) > 0)
            {
                byteCount += readByte;

                if (init) // set block header
                {
                    Array.Copy(buffer, 0, blockHeader, 0, blockHeader.Length);
                    init = false;
                }

                int lastPosition = 512;

                var cutSize = lastPosition;
                var tailSize = buffer.Length - cutSize;
                Array.Copy(buffer, cutSize, buffer, 0, tailSize);
                readerStart = tailSize;
                readerLength = cutSize;
                // reset search position
            }
        }
    }
}
