namespace lw1Algoritmy
{

    class Program
    {
        static void Main( string[] args )
        {
            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();
            FindSquare findSquare = new FindSquare();
            var matrix = fileReader.GetMatrix();
            var matrixSize = fileReader.MatrixSize;
            var result = findSquare.FindSqare( matrix, matrixSize - 1 );

            fileWriter.GetOutput( result.ToString() );
        }
    }
}

