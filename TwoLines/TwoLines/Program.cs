using System;
using System.Collections.Generic;
using System.IO;

namespace TwoLines
{
    public struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point( float x, float y )
        {
            X = x;
            Y = y;
        }
    }

    class Program
    {
        static void Main( string[] args )
        {
            var input = File.ReadAllLines( "../../../input.txt" );
            var points = new List<Point>();

            foreach( var line in input )
            {
                var coords = line.Split( ' ' );
                points.Add( new Point( float.Parse( coords[ 0 ] ), float.Parse( coords[ 1 ] ) ) );
            }


            if( IsIntersect( points ) )
            {
                Console.WriteLine( "Yes" );
            }
            else
            {
                Console.WriteLine( "No" );
            }

        }



        public static bool IsIntersect( List<Point> points )
        {
            var x1 = points[ 0 ].X;
            var y1 = points[ 0 ].Y;

            var x2 = points[ 1 ].X;
            var y2 = points[ 1 ].Y;

            var x3 = points[ 2 ].X;
            var y3 = points[ 2 ].Y;

            var x4 = points[ 3 ].X;
            var y4 = points[ 3 ].Y;

            var dot = new List<float>();
            float n;

            if( y2 - y1 != 0 )
            {
                float q = ( float ) ( x2 - x1 ) / ( y1 - y2 );
                float sn = ( x3 - x4 ) + ( y3 - y4 ) * q;
                if( sn == 0 )
                {
                    return false;
                }
                var fn = ( x3 - x1 ) + ( y3 - y1 ) * q;   // b(x) + b(y)*q
                n = fn / sn;
            }
            else
            {
                if( y3 - y4 == 0 )
                {
                    return false;
                }
                n = ( y3 - y1 ) / ( y3 - y4 );
            }

            dot.Add( x3 + ( x4 - x3 ) * n );
            dot.Add( y3 + ( y4 - y3 ) * n );

            var pointOfIntersect = new Point( dot[ 0 ], dot[ 1 ] );

            if( ( ( pointOfIntersect.X >= x1 && pointOfIntersect.X <= x2 && pointOfIntersect.Y >= y1 && pointOfIntersect.Y <= y2 ) &&
                ( pointOfIntersect.X >= x3 && pointOfIntersect.X <= x4 && pointOfIntersect.Y >= y3 && pointOfIntersect.Y <= y4 ) ) ||
                ( ( pointOfIntersect.X <= x1 && pointOfIntersect.X >= x2 && pointOfIntersect.Y <= y1 && pointOfIntersect.Y >= y2 ) &&
                ( pointOfIntersect.X <= x3 && pointOfIntersect.X >= x4 && pointOfIntersect.Y <= y3 && pointOfIntersect.Y >= y4 ) )
                )
            {
                return true;
            }
            return false;
        }
    }
}
