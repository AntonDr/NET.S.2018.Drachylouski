using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath,destinationPath);


            FileStream inStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
           
            long bytes = inStream.Length;
            byte [] b = new byte[bytes];

            int count = inStream.Read(b, 0, (int) bytes);

            inStream.Close();

            FileStream outStream = new FileStream(destinationPath, FileMode.Open, FileAccess.Write);

            outStream.Write(b,0,(int)bytes);

            outStream.Close();

            return count;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            StreamReader inReader = new StreamReader(sourcePath);

            string str = inReader.ReadToEnd();


            inReader.Close();

            byte[] bytes = System.Text.Encoding.Default.GetBytes(str);

            MemoryStream memoryStream = new MemoryStream(bytes,0,bytes.Length);

            byte [] nBytes = new byte[bytes.Length];

            memoryStream.Write(nBytes,0,nBytes.Length);

            char [] charArray = System.Text.Encoding.Default.GetChars(nBytes);

            StreamWriter outWriter = new StreamWriter(destinationPath);

            outWriter.Write(charArray);

            memoryStream.Close();
            outWriter.Close();

            return charArray.Length;
            
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            FileStream inStream = new FileStream(sourcePath,FileMode.Open,FileAccess.Read);
            
            int size = (int) inStream.Length;

            FileStream outStream = new FileStream(destinationPath, FileMode.Open, FileAccess.Write);

            inStream.CopyTo(outStream,size);

            inStream.Close();
            outStream.Close();

            return size;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            StreamReader streamReader = new StreamReader(sourcePath);

            string str = streamReader.ReadToEnd();

            streamReader.Close();

            StreamWriter streamWriter = new StreamWriter(destinationPath);

            streamWriter.Write(str);

            streamWriter.Close();

            return System.Text.Encoding.Default.GetBytes(str).Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            FileStream inStream = new FileStream(sourcePath,FileMode.Open,FileAccess.Read);
            BufferedStream bufferedStream = new BufferedStream(inStream);

            byte[] bytes = new byte[(int)inStream.Length];
            bufferedStream.Read(bytes, 0, bytes.Length);
            
            FileStream outStream = new FileStream(destinationPath,FileMode.Open,FileAccess.Write);
            outStream.Write(bytes,0,bytes.Length);

            bufferedStream.Close();
            inStream.Close();
            outStream.Close();

            return bytes.Length;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            FileStream inStream = new FileStream(sourcePath,FileMode.Open,FileAccess.Read);

            int size =(int)inStream.Length;

            StreamReader streamReader = new StreamReader(inStream);

            inStream.Close();

            string str = streamReader.ReadLine();

            streamReader.Close();

            StreamWriter streamWriter = new StreamWriter(destinationPath);

            streamWriter.Write(str);

            streamWriter.Close();

            return size;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            StreamReader streamReader = new StreamReader(sourcePath);

            string lhs = streamReader.ReadToEnd();

            streamReader.Close();

            StreamReader secondStreamReader = new StreamReader(destinationPath);

            string rhs = secondStreamReader.ReadToEnd();

            secondStreamReader.Close();

            return lhs == rhs;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            {
                throw   new ArgumentException("Invadlid adres");
            }
        }

        #endregion

        #endregion

    }
}
