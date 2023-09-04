using EposCmd.Net.DeviceCmdSet.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMeasurement
{
    public class Test
    {
        public enum TestMode
        {
            None,
            Free,
            Glue,
            Line,
            Rotary,
        }
        public enum FreeMode
        {
            None,
            Free,
        }
        public enum GlueTest
        {
            Rest,
            MoveToPosition,
            StartTest,
            Testing,
            Release,
            Save,
        }
        public enum LineTest
        {
            Rest,
            MoveToPosition,
            MoveToStart,
            Settings,
            StartTest,
            Testing1,
            Check1,
            Testing2,
            Check2,
            Release,
            Save,
        }
        public enum RotaryTest
        {
            Rest,
            MoveToStart,
            Settings,
            Testing,
            Release,
            Save,
        }
        
        
    }
}
