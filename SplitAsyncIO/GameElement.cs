using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAsyncIO
{

    class GameElement
    { 
        public int Id { get; set; }
        public string Actor { get; set; }
        public int Force { get; set; }
        public string Type { get; set; }
        public string MainLand { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|({5};{6})", Id.ToString(), Actor, Force.ToString(), Type, MainLand, X.ToString(), Y.ToString());
        }
    }
}
