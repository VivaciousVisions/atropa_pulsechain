﻿using Dysnomia.Domain.World;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Dysnomia.Domain
{
    public class Oracle : ConcurrentQueue<byte[]>
    {
        public Faung Mu;
        public Object Tau;
        public Living Theta;

        public Oracle()
        {
            Logging.Log("Oracle", "New Oracle");
            Mu = new Faung();
            Tau = new Object();
            Theta = new Living(Phi);
            Reset();
        }

        public void Fi(Tare.MSG A)
        {
            BigInteger ClientId = new BigInteger(A.From);
            //NetworkStream Writer = Domain.Fi.Psi[ClientId].Mu.GetStream();
            //Writer.WriteByte(222);
        }

        public void ProcessString(String A)
        {
            Logging.Log("Oracle", "NOOP: " + A, 5);
            Buffer B = Encode(A);
            Enqueue(new byte[] { 0x02 });
            Enqueue(B.Bytes);
        }

        public Buffer Encode(String Beta)        
        {
            Logging.Log("Oracle", "Encoding: " + Beta, 1);
            Buffer A = new Buffer(Mu, Encoding.Default.GetBytes(Beta));
            Logging.Log("Oracle", "Encoded Base64: " + Convert.ToBase64String(A.Bytes), 2);
            return A;
        }

        public Buffer Decode(Buffer Beta)
        {
            Logging.Log("Oracle", "Decoding Base64: " + Convert.ToBase64String(Beta.Bytes), 1);
            Buffer B = new Buffer(Mu, Beta.Bytes);
            Logging.Log("Oracle", "Decoded: " + Encoding.Default.GetString(B.Bytes), 2);
            return B;
        }

        public void Reset()
        {
            if (Mu.Rod == null) throw new Exception("Null Rod");
            Logging.Log("Oracle", "Reset", 5);
            Alpha(Mu.Rod.Signal);
        }

        private void Alpha(BigInteger Omicron)
        {
            if (Mu.Rod == null) throw new Exception("Null Rod");
            if (Mu.Cone == null) throw new Exception("Null Cone");
            Logging.Log("Oracle", "Alpha: " + Omicron.ToString(), 4);
            lock (Tau)
            {
                if (Omicron == 0) throw new Exception("Omicron Zero");

                Mu.Charge(Omicron);
                if (Mu.Sigma < 4)
                    throw new Exception("Sigma < 4");
                Mu.Induce();
                Mu.Torque();
                Mu.Amplify();
                Mu.Sustain();
                Mu.React();

                Enqueue(new byte[] { 0x00 });
                Enqueue(Omicron.ToByteArray());
                Enqueue(Mu.Sigma.ToByteArray());
                Enqueue(Mu.Cone.Channel.ToByteArray());
                Enqueue(Mu.Rod.Channel.ToByteArray());
                Enqueue(Mu.Rod.Kappa.ToByteArray());
            }
        }

        public BigInteger Op(String Beta)
        {
            byte[] Iota = Encoding.Unicode.GetBytes(Beta);
            BigInteger Omicron = new BigInteger(Iota);
            return Omicron;
        }

        public void Beta(BigInteger Omicron)
        {
            if (Mu.Rod == null) throw new Exception("Null Rod");
            if (Mu.Cone == null) throw new Exception("Null Cone");
            Logging.Log("Oracle", "Beta: " + Omicron.ToString(), 4);
            lock (Tau)
            {
                if (Mu.Omicron == 0) throw new Exception("Mu Omicron Zero");
                if (Omicron == 0) throw new Exception("Iota Zero");

                BigInteger Lambda = Mu.Rod.Torque(Omicron);
                Lambda = Mu.Rod.Amplify(Lambda);
                Lambda = Mu.Rod.Sustain(Lambda);
                Mu.Rod.React(Lambda, Mu.Cone.Dynamo);
                Mu.Cone.React(Lambda, Mu.Rod.Dynamo);

                Enqueue(new byte[] { 0x01 });
                Enqueue(Omicron.ToByteArray());
                Enqueue(Mu.Cone.Dynamo.ToByteArray());
                Enqueue(Mu.Rod.Dynamo.ToByteArray());
                Enqueue(Mu.Rod.Eta.ToByteArray());
                Enqueue(Mu.Cone.Eta.ToByteArray());
            }
        }

        public BigInteger Next()
        {
            byte[]? Beta;
            if (TryDequeue(out Beta))
                return new BigInteger(Beta);
            else return 0;
        }

        void Phi()
        {
            if (Mu.Rod == null) throw new Exception("Null Rod");
            if (Mu.Cone == null) throw new Exception("Null Cone");
            int _sleep = 20;
            byte[]? OpCode;

            BigInteger Iota, Omicron;

            while (true)
            {
                lock (Tau)
                {
                    if (Count > 0) _sleep = 20;
                    TryDequeue(out OpCode);
                    while (Count > 0)
                    {
                        if (OpCode == null) TryDequeue(out OpCode);
                        if (OpCode == null || OpCode.Length != 1) throw new Exception("Bad OpCode");
                        switch(OpCode[0])
                        {
                            case 0x00:
                                Iota = Next();
                                Omicron = Next();
                                if (Mu.Cone.Mu(Mu.Cone.Barn, Iota, Mu.Cone.Ring) != Omicron) throw new Exception("Invalid Charge");

                                Iota = Next();
                                if (Iota != Mu.Cone.Channel) throw new Exception("Bad Cone Channel");

                                Iota = Next();
                                if (Iota != Mu.Rod.Channel) throw new Exception("Bad Rod Channel");

                                Iota = Next();
                                Omicron = Mu.Rod.Induce(Omicron);
                                Omicron = Mu.Cone.Torque(Omicron);
                                Omicron = Mu.Cone.Amplify(Omicron);
                                Omicron = Mu.Cone.Sustain(Omicron);
                                if (Mu.Rod.Mu(Omicron, Mu.Cone.Channel, Mu.Rod.Channel) != Iota) throw new Exception("Invalid Reaction");
                                Logging.Log("Oracle", "Alpha Operational: " + Omicron.ToString(), 3);
                                break;
                            case 0x01:
                                Iota = Next();
                                Omicron = Next();
                                if (Omicron != Mu.Cone.Dynamo) throw new Exception("Bad Cone Dynamo");
                                Omicron = Next();
                                if (Omicron != Mu.Rod.Dynamo) throw new Exception("Bad Rod Dynamo");

                                Iota = Mu.Rod.Torque(Iota);
                                Iota = Mu.Rod.Amplify(Iota);
                                Iota = Mu.Rod.Sustain(Iota);

                                Omicron = Next();
                                if (Mu.Rod.Mu(Iota, Mu.Rod.Channel, Mu.Cone.Dynamo) != Omicron) throw new Exception("Invalid Rod Eta");

                                Omicron = Next();
                                if (Mu.Cone.Mu(Iota, Mu.Cone.Channel, Mu.Rod.Dynamo) != Omicron) throw new Exception("Invalid Cone Eta");
                                Logging.Log("Oracle", "Beta Operational: " + Omicron.ToString(), 3);
                                break;
                            case 0x02:
                                Iota = Next();
                                Logging.Log("Oracle", "NOOP: " + Iota.ToString(), 1);
                                break;
                            default:
                                throw new Exception("Not Implemented");
                        }

                        if (Count > 0) TryDequeue(out OpCode);
                    }
                    if (Count == 0) _sleep *= 2;

                    foreach (KeyValuePair<BigInteger, Greed> G in Domain.Fi.Psi)
                    {
                        NetworkStream ns = G.Value.Mu.GetStream();
                        ns.WriteByte(111);
                    }
                }
                if (_sleep > 1551) _sleep = 1551;
                Thread.Sleep(_sleep);
            }
        }
    }
}
