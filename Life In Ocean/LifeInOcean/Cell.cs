using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeInOcean
{
    public class Cell
    {
        public const char DefImageCell = '-';
        protected readonly ICellable _ocean;

        public Cell ( ICellable ocean, Coordinate Offset, char Image = DefImageCell )
        {
            _ocean = ocean;
            _offset = Offset;
            _image = Image;
        }

        ~Cell()
        {
        }
        public Coordinate Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
            }
        }
        public char Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public void Display() 
        {
            Console.SetCursorPosition(Offset.X, Offset.Y);
            Console.Write ( Image );
        }
        public virtual void Process()
        {
            
        }
        public virtual void Reproduse(Coordinate anOffset)
        {
           
        }
        
        public Cell GetCopy () 
        {
            Cell c = (Cell) MemberwiseClone ();
            return c;
        }
        private char _image;
        private Coordinate _offset;

    }
}
