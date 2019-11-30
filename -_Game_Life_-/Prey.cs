using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeInOcean
{
    class Prey : Cell
    {
        public const int DefTimeToReproduse = 6;
        public const char DefImagePrey = 'f';

        public Prey(ICellable o, Coordinate Offset, char Image = DefImagePrey, int timeToReproduse = DefTimeToReproduse)
            : base(o, Offset, Image)
        {
            
            _timeToReproduse = timeToReproduse; 
        }
        public override void Process() 
        {
            Coordinate from = Offset;
            Coordinate toEmpty = _ocean.GetEmptyNeighborCoord ( Offset );
            if ( from != toEmpty )
            {
                
                MoveFrom ( from, toEmpty );
                if ( (_ocean.GetCellAt ( toEmpty ) as Prey).TimeToReproduse == 0 )
                {
                    Reproduse(from);
                }
                else
                {
                    (_ocean.GetCellAt ( toEmpty ) as Prey).TimeToReproduse -= 1;
                }
            }
        }
        public void MoveFrom(Coordinate from, Coordinate to) 
        {
            _ocean.AssignCellAt ( to, _ocean.GetCellAt ( from ) );
            _ocean.GetCellAt ( to ).Display ();
            _ocean.AssignCellAt ( from, new Cell ( _ocean, from ) );
            _ocean.GetCellAt ( from ).Display ();         
        }
        public override void Reproduse(Coordinate anOffset)  
        {
            _ocean.AssignCellAt ( anOffset, new Prey ( _ocean, anOffset ) );
            _ocean.GetCellAt ( anOffset ).Display ();
        }
        public int TimeToReproduse
        {
            get
            {
                return _timeToReproduse;
            }
            set
            {
                _timeToReproduse = value;
            }
        }
        private int _timeToReproduse;
    }
}
