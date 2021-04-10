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
            var input = File.ReadAllLines( "../../../input1.txt" );
            var points = new List<Point>();

            foreach( var line in input )
            {
                var coords = line.Split( ' ' );
                points.Add( new Point( float.Parse( coords[ 0 ] ), float.Parse( coords[ 1 ] ) ) );
            }


            if( Intersect( points ) )
            {
                Console.WriteLine( "Yes" );
            }
            else
            {
                Console.WriteLine( "No" );
            }

        }

        public static float Area( Point a, Point b, Point c )
        {
            return ( b.X - a.X ) * ( c.Y - a.Y ) - ( b.Y - a.Y ) * ( c.X - a.X );
        }

        public static bool intersect_points( float a, float b, float c, float d )
        {
            if( a > b )
            {
                var temp = a;
                a = b;
                b = temp;
            };
            if( c > d )
            {
                var temp = c;
                c = d;
                d = temp;
            };
            return Math.Max( a, c ) <= Math.Min( b, d );
        }
        public static bool Intersect( List<Point> points )
        {
            Point a = points[ 0 ];
            Point b = points[ 1 ];
            Point c = points[ 2 ];
            Point d = points[ 3 ];

            return intersect_points( a.X, b.X, c.X, d.X )
                && intersect_points( a.Y, b.Y, c.Y, d.Y )
                && Area( a, b, c ) * Area( a, b, d ) <= 0
                && Area( c, d, a ) * Area( c, d, b ) <= 0;
        }
    }
}
