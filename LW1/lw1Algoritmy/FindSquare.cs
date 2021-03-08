using System.Collections.Generic;

namespace lw1Algoritmy
{
    public class FindSquare
    {

        public int FindSqare( List<List<int>> matrix, int matrixSize )
        {
            FindAllCells( 0, 0, matrix, matrixSize );

            if( matrix[ matrixSize ][ matrixSize ] != 2 )
            {
                FindAllCellsIfLabirintGaveNoExit( matrixSize, matrixSize, matrix, matrixSize );
            }


            var result = ( Find( matrix, matrixSize ) * 9 ) - 36;

            return result;
        }

        private int Find( List<List<int>> matrix, int matrixSize )
        {
            var allWalls = 0;
            for( int i = 0; i < matrixSize + 1; i++ )
            {
                for( int j = 0; j < matrixSize + 1; j++ )
                {
                    if( matrix[ i ][ j ] == 2 )
                        allWalls += howMuchWallsNear( i, j, matrix, matrixSize );
                }
            }

            return allWalls;
        }



        private int howMuchWallsNear( int y, int x, List<List<int>> matrix, int matrixSize )
        {
            var count = 0;

            if( x != matrixSize )
                if( matrix[ y ][ x + 1 ] == 1 )
                    count++;
            if( x != 0 )
                if( matrix[ y ][ x - 1 ] == 1 )
                    count++;
            if( y != matrixSize )
                if( matrix[ y + 1 ][ x ] == 1 )
                    count++;
            if( y != 0 )
                if( matrix[ y - 1 ][ x ] == 1 )
                    count++;
            if( x == matrixSize )
                count++;
            if( x == 0 )
                count++;
            if( y == matrixSize )
                count++;
            if( y == 0 )
                count++;

            return count;
        }

        private void FindAllCells( int x, int y, List<List<int>> matrix, int matrixSize )
        {
            if( matrix[ y ][ x ] == 0 )
            {
                matrix[ y ][ x ] = 2;
                if( x != matrixSize )
                    FindAllCells( x + 1, y, matrix, matrixSize );
                if( x != 0 )
                    FindAllCells( x - 1, y, matrix, matrixSize );
                if( y != matrixSize )
                    FindAllCells( x, y + 1, matrix, matrixSize );
                if( y != 0 )
                    FindAllCells( x, y - 1, matrix, matrixSize );
            }

            return;
        }

        private void FindAllCellsIfLabirintGaveNoExit( int x, int y, List<List<int>> matrix, int matrixSize )
        {
            if( matrix[ y ][ x ] == 0 )
            {
                matrix[ y ][ x ] = 2;
                if( x != matrixSize )
                    FindAllCells( x + 1, y, matrix, matrixSize );
                if( x != 0 )
                    FindAllCells( x - 1, y, matrix, matrixSize );
                if( y != matrixSize )
                    FindAllCells( x, y + 1, matrix, matrixSize );
                if( y != 0 )
                    FindAllCells( x, y - 1, matrix, matrixSize );
            }

            return;
        }
    }

}

