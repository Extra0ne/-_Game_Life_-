using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeInOcean
{
    class Predator : Prey
    {
        public const int DefTimeToFeed = 6;
        public const char DefImagePredators = 'P';
        
        public Predator ( ICellable o, Coordinate Offset, char Image = DefImagePredators, int timeToReproduse = 6, int timeToFeed = DefTimeToFeed )
            : base(o,Offset, Image, timeToReproduse)
        {
            
            _timeToFeed = timeToFeed;
        }

        public override void Process()    
        {
            bool IsDie = false;
            Coordinate from = Offset;
            Coordinate toEmpty = (Coordinate)_ocean.GetEmptyNeighborCoord ( Offset );
            Coordinate toPrey = (Coordinate)_ocean.GetPreyNeighborCoord ( Offset );
            if ( (_ocean.GetCellAt ( from ) as Predator).TimeToFeed == 0 )
            {
                _ocean.AssignCellAt ( from, new Cell ( _ocean, from ) );
                _ocean.GetCellAt ( from ).Display ();
                IsDie = true;
            }
            if ( !IsDie )
            {
                if ( from != toPrey )
                {
                    MoveFrom ( from, toPrey );
                    (_ocean.GetCellAt ( toPrey ) as Predator).TimeToFeed = 6;
                    if ( (_ocean.GetCellAt ( toPrey ) as Predator).TimeToReproduse == 0 )
                    {
                        Reproduse ( from );
                    }
                    else
                    {
                        (_ocean.GetCellAt ( toPrey ) as Predator).TimeToReproduse -= 1;
                    }
                }
                else
                {
                    if ( from != toEmpty )
                    {
                        MoveFrom ( from, toEmpty );
                        (_ocean.GetCellAt ( toEmpty ) as Predator).TimeToFeed -= 1;
                        if ( (_ocean.GetCellAt ( toEmpty ) as Predator).TimeToReproduse == 0 )
                        {
                            Reproduse ( from );
                        }
                        else
                        {
                            (_ocean.GetCellAt ( toEmpty ) as Predator).TimeToReproduse -= 1;
                        }
                    }
                    else
                    {
                        (_ocean.GetCellAt ( from ) as Predator).TimeToFeed -= 1;
                    }
                }
            }
        }
        public override void Reproduse(Coordinate anOffset) 
        {
            _ocean.AssignCellAt ( anOffset, new Predator ( _ocean, anOffset ) );
            _ocean.GetCellAt ( anOffset ).Display ();
        }
        public int TimeToFeed
        {
            get
            {
                return _timeToFeed;
            }
            set
            {
                _timeToFeed = value;
            }
        }
        private int _timeToFeed;
    }
}
