using System.IO;

namespace P04.CopyBinaryFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open);
            using FileStream writer = new FileStream("../../../newImage", FileMode.Create);

            while(true)
            {
                byte[] buffer = new byte[4096];
                int count = reader.Read(buffer, 0, buffer.Length);

                if(count == 0)
                {
                    break;
                }

                writer.Write(buffer);
            }



        }
    }
}
