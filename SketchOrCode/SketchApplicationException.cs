using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    internal class SketchApplicationException : Exception
    {
        public SketchApplicationException(string message) : base(message)
        {

        }
        public SketchApplicationException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
