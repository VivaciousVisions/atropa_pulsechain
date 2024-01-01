
using Apparition.Retaliation;
using Dysnomia.Domain;
using System.Collections.Concurrent;
using System.Numerics;
using System.Text;
using System.Windows;
using Windows.Foundation.Diagnostics;
using static Dysnomia.Domain.Tare;

namespace Dysnomia
{
    public static class Apparition
    {
        static public bool Stub = true;
        static public BigInteger ID;
        static public RetaliationWindow Window;
        static public Object Tau;
        static public ConcurrentQueue<Tare.MSG> MsgQueue;
        static public short LogLevel = 1;
        static public OutputCaller Output;

        static Apparition()
        {
            ID = Math.Random();
            Tau = new Object();
            MsgQueue = new ConcurrentQueue<Tare.MSG>();
        }

        static public void Input(Tare.MSG A)
        {
            if (A.Priority >= LogLevel) new Task(() => { lock (Tau) MsgQueue.Enqueue(A); }).Start();
        }

        public delegate void OutputCaller(String A);
    }
}
