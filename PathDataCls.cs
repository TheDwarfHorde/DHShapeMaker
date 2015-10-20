using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ShapeMaker
{

    [Serializable]
    public class PData
    {
        public PointF[] Lines
        {
            get;
            set;
        }
        public int LineType
        {
            get;
            set;
        }
        public bool ClosedType
        {
            get;
            set;
        }
        public bool IsLarge
        {
            get;
            set;
        }
        public bool RevSweep
        {
            get;
            set;
        }
        public string Alias
        {
            get;
            set;
        }
        public string Meta
        {
            get;
            set;
        }
        public bool SolidFill
        {
            get;
            set;
        }
        public bool LoopBack
        {
            get;
            set;
        }
        public PData(PointF[] _coords, bool _closed, int _lineType, bool _islarge,bool _revsweep,string _alias,bool _loopback)
        {
            Lines = _coords;
            LineType = _lineType;
            ClosedType = _closed;
            IsLarge = _islarge;
            RevSweep = _revsweep;
            Alias = _alias;
            LoopBack = _loopback;
        }
        public PData()
        {

        }
    }
}
