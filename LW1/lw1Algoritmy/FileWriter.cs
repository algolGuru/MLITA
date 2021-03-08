using System.IO;

namespace lw1Algoritmy
{
    public class FileWriter
    {
        const string FilePath = "../../../OUTPUT.txt";

        public void GetOutput( string result)
        {
            StreamWriter streamWriter = File.CreateText( FilePath );
            streamWriter.Write( result );
            streamWriter.Close();
        }
    }
}

