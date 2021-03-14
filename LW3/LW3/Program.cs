using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LW3
{
    public class BankParams
    {
        public int NumberOfBank { get; set; }
        public int DistnaceFromStart { get; set; }
        public int Money { get; set; }

        public BankParams( int numberOfBank, int distnaceFromStart, int money )
        {
            NumberOfBank = numberOfBank;
            DistnaceFromStart = distnaceFromStart;
            Money = money;
        }
    }

    class Program
    {
        static void Main( string[] args )
        {
            var input = File.ReadAllLines( "../../../Input.txt" );
            var firstLine = input[ 0 ].Split( ' ' ).ToList();
            var numberOfBanks = int.Parse( firstLine[ 0 ] );
            var minDistance = int.Parse( firstLine[ 1 ] );
            var banks = new List<BankParams>();

            for( int i = 0; i <= numberOfBanks; i++ )
            {
                if( i == 0 )
                    continue;

                var line = input[ i ].Split( ' ' ).ToList();
                banks.Add( new BankParams( i, int.Parse( line[ 0 ] ), int.Parse( line[ 1 ] ) ) );
            }



            var maxMoneyBank = banks[ 0 ];
            var maxMoneySecondBank = banks[ 0 ];

            for( int i = 0; i < banks.Count(); i++ )
            {
                if( i != banks.Count() - 1 )
                {
                    if( banks[ i + 1 ].Money > maxMoneyBank.Money )
                    {
                        if( banks[ i + 1 ].DistnaceFromStart - maxMoneyBank.DistnaceFromStart >= minDistance )
                        {
                            maxMoneySecondBank = maxMoneyBank;
                        }
                        maxMoneyBank = banks[ i + 1 ];
                    }

                    if( banks[ i + 1 ].Money > maxMoneySecondBank.Money )
                    {
                        if( maxMoneyBank.DistnaceFromStart - banks[ i + 1 ].DistnaceFromStart >= minDistance || banks[ i + 1 ].DistnaceFromStart - maxMoneyBank.DistnaceFromStart >= minDistance )
                            maxMoneySecondBank = banks[ i + 1 ];
                    }
                }
            }

            Console.WriteLine( maxMoneyBank.Money + maxMoneySecondBank.Money );
            Console.WriteLine( maxMoneyBank.NumberOfBank + " " + maxMoneySecondBank.NumberOfBank );
        }
    }
}
