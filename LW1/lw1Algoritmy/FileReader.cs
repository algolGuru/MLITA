using System.Collections.Generic;
using System.IO;

namespace lw1Algoritmy
{
    public class FileReader
    {
        const string FilePath = "../../../INPUT.txt";

        public string[] FileText { get; set; }
        public List<List<int>> Matrix { get; set; }
        public int MatrixSize { get; set; }

        public List<List<int>> GetMatrix()
        {
            FileText = File.ReadAllLines( FilePath );
            string martixSizeText = FileText[ 0 ];
            MatrixSize = int.Parse( martixSizeText );
            Matrix = getZeroMatrix( MatrixSize );
            var counter = 0;
            foreach( var line in FileText )
            {
                if( line == FileText[ 0 ] )
                    continue;

                var martixLine = getZeroMatrixLine( MatrixSize );

                for( int j = 0; j < MatrixSize; j++ )
                {
                    if( line[ j ] == '.' )
                    {
                        martixLine[ j ] = 0;
                    }
                    else
                    {
                        martixLine[ j ] = 1;
                    }
                }
                Matrix[ counter ] = martixLine;
                counter++;
            }

            return Matrix;
        }

        private List<List<int>> getZeroMatrix( int matrixSize )
        {
            var matrix = new List<List<int>> { };

            for( int i = 0; i < matrixSize; i++ )
            {
                var matrixLine = new List<int> { };
                for( int j = 0; j < matrixSize; j++ )
                {
                    matrixLine.Add( 0 );
                }
                matrix.Add( matrixLine );
            }

            return matrix;
        }

        private List<int> getZeroMatrixLine( int matrixSize )
        {
            var zeroMatrixLine = new List<int> { };

            for( int i = 0; i < matrixSize; i++ )
            {
                zeroMatrixLine.Add( 0 );
            }

            return zeroMatrixLine;
        }

    }
}

