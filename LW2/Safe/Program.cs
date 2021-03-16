using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rift
{
    class Point : IEquatable<Point>
    {
        public int Y { get; set; }
        public int X { get; set; }
        public int Value { get; set; }

        public Point( int x, int y, int value )
        {
            X = x;
            Y = y;
            Value = value;
        }

        public bool Equals( Point other )
        {
            if( this.X == other.X && this.Y == other.Y )
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main( string[] args )
        {
            var matrix = new List<List<string>> { };
            var inputMatrix = File.ReadAllLines( "../../../input2.txt" );

            var inputParams = inputMatrix[ 0 ].Split( ' ' );
            var matrixSize = Int32.Parse( inputParams[ 0 ] );
            var riftSize = Int32.Parse( inputParams[ 1 ] );
            var queue = new Queue<Point>();

            foreach( var line in inputMatrix )
            {
                if( line == inputMatrix[ 0 ] )
                    continue;

                var tempLine = new List<string>();

                foreach( var symbol in line )
                {
                    tempLine.Add( symbol.ToString() );
                }

                matrix.Add( tempLine );
            }

            queue.Enqueue( new Point( ( riftSize - 1 ), ( riftSize - 1 ), 0 ) );
            while( queue.ToArray().Length != 0 )
            {
                var element = queue.Dequeue();

                PaintRiftWave( element, riftSize, matrix );
                GoRight( element, riftSize, matrix, queue );
                GoDown( element, riftSize, matrix, queue );
                GoLeft( element, riftSize, matrix, queue );
                GoUp( element, riftSize, matrix, queue );
                if( matrix[ ( matrixSize - 1 ) ][ ( matrixSize - 1 ) ] != "." )
                    break;
            }


            if( matrix[ matrixSize - 1 ][ matrixSize - 1 ] != "." )
                Console.WriteLine( matrix[ matrixSize - 1 ][ matrixSize - 1 ] );
            else
                Console.WriteLine( "No" );
        }

        static void GoRight( Point element, int riftSize, List<List<string>> matrix, Queue<Point> points )
        {
            var canGo = true;
            for( int i = 0; i < riftSize; i++ )
            {
                if( element.X + 1 == matrix.ToArray().Length )
                {
                    canGo = false;
                    break;
                }
                if( matrix[ element.Y - i ][ element.X + 1 ] == "@" )
                {
                    canGo = false;
                    break;
                }
                if( matrix[ element.Y - i ][ element.X + 1 ] != "." )
                {
                    if( points.ToList().Count() == 0 )
                        break;
                    canGo = false;
                    break;
                }
                if( points.ToList().Contains( new Point( element.X + 1, element.Y, element.Value + 1 ) ) )
                {
                    canGo = false;
                    break;
                }
            }

            if( canGo )
                points.Enqueue( new Point( element.X + 1, element.Y, element.Value + 1 ) );
        }

        static void GoDown( Point element, int riftSize, List<List<string>> matrix, Queue<Point> points )
        {
            var canGo = true;
            for( int i = 0; i < riftSize; i++ )
            {
                if( element.Y + 1 == matrix.ToArray().Length )
                {
                    canGo = false;
                    break;
                }
                if( matrix[ element.Y + 1 ][ element.X - i ] == "@" )
                {
                    canGo = false;
                    break;
                }
                if( matrix[ element.Y + 1 ][ element.X - i ] != "." )
                {
                    if( points.ToList().Count() == 0 )
                        break;
                    canGo = false;
                    break;
                }
                if( points.ToList().Contains( new Point( element.X, element.Y + 1, element.Value + 1 ) ) )
                {
                    canGo = false;
                    break;
                }
            }

            if( canGo )
                points.Enqueue( new Point( element.X, element.Y + 1, element.Value + 1 ) );
        }

        static void GoLeft( Point element, int riftSize, List<List<string>> matrix, Queue<Point> points )
        {
            var canGo = true;
            for( int i = 0; i < riftSize; i++ )
            {
                if( element.X < riftSize )
                {
                    canGo = false;
                    break;
                }
                if( matrix[ element.Y - i ][ element.X - riftSize ] != "." )
                {
                    canGo = false;
                    break;
                }
                if( points.ToList().Contains( new Point( element.X - 1, element.Y, element.Value + 1 ) ) )
                {
                    canGo = false;
                    break;
                }
            }

            if( canGo )
                points.Enqueue( new Point( element.X - 1, element.Y, element.Value + 1 ) );
        }

        static void GoUp( Point element, int riftSize, List<List<string>> matrix, Queue<Point> points )
        {
            var canGo = true;
            for( int i = 0; i < riftSize; i++ )
            {
                if( element.Y < riftSize )
                {
                    canGo = false;
                    break;
                }
                if( element.X - i < 0 )
                {
                    canGo = false;
                    break;
                }
                if( matrix[ element.Y - riftSize ][ element.X - i ] != "." )
                {
                    canGo = false;
                    break;
                }
                if( points.ToList().Contains( new Point( element.X, element.Y - 1, element.Value + 1 ) ) )
                {
                    canGo = false;
                    break;
                }
            }

            if( canGo )
                points.Enqueue( new Point( element.X, element.Y - 1, element.Value + 1 ) );
        }

        static void PaintRiftWave( Point element, int riftSize, List<List<string>> matrix )
        {
            var startOfPaintingX = element.X;
            var startOfPaintingY = element.Y;

            for( int i = 0; i < riftSize; i++ )
            {
                for( int j = 0; j < riftSize; j++ )
                {
                    if( ( startOfPaintingY - i ) >= 0 && ( startOfPaintingX - j ) >= 0 )
                        matrix[ startOfPaintingY - i ][ startOfPaintingX - j ] = element.Value.ToString();
                }
            }
        }

        static void Print( List<List<string>> matrix )
        {
            foreach( var line in matrix )
            {
                foreach( var symbol in line )
                {
                    Console.Write( symbol );
                }

                Console.WriteLine();
            }
        }
    }
}
