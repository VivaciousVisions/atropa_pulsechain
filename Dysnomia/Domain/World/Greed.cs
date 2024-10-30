﻿#pragma warning disable CS0168

using Dysnomia.Domain.bin;
using Dysnomia.Lib;
using ExtensionMethods;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Dysnomia.Lib.Tare;

namespace Dysnomia.Domain.World
{
    public class Greed : Daemon
    {
        new public static string Name = "Greed";
        new public static String Description = "Greed Daemon";

        public readonly String Host;
        public readonly int Port;
        public BigInteger ClientId;

        public TcpClient Mu;
        public Fan Rho;
        public bool Cone = false;
        public bool TimedOut = false;

        public Greed(BigInteger Proxy, Conjunction Chi)
        {
            ClientId = Math.Random();
            if (Controller.Fi.Psi[Proxy].Cone != true) throw new Exception("Proxy Must Be Cone");
            Host = Controller.Fi.Psi[Proxy].Host;
            Port = Controller.Fi.Psi[Proxy].Port;
            Mu = Controller.Fi.Psi[Proxy].Mu;
            Rho = new Fan(ClientId, Proxy);
            Rho[Proxy].Upsilon = Chi;
            Theta = new Living(Phi);
            Cone = true;
        }

        public Greed(String _Host, int _Port)
        {
            ClientId = Math.Random();
            Host = _Host;
            Port = _Port;
            Mu = new TcpClient();
            Rho = new Fan();
            Theta = new Living(Phi);
        }

        public Greed(TcpClient Iota)
        {
            if (Iota.Client.RemoteEndPoint as IPEndPoint == null) throw new Exception("Null Client");
            Host = ((IPEndPoint)Iota.Client.RemoteEndPoint).Address.ToString();
            Port = ((IPEndPoint)Iota.Client.RemoteEndPoint).Port;
            Mu = Iota;
            Rho = new Fan();
            Theta = new Living(Phi);
            Cone = true;
        }

        /*
        public Lib.Buffer Encode(String Beta)
        {
            Logging.Log("Greed", "Encoding: " + Beta, 1);
            if (Psi == null) throw new Exception("Null Psi");
            Lib.Buffer A = new Lib.Buffer(Psi, Encoding.Default.GetBytes(Beta));
            Logging.Log("Greed", "Encoded Base64: " + Convert.ToBase64String(A.Bytes), 2);
            return A;
        }

        public Lib.Buffer Decode(Lib.Buffer Beta)
        {
            Logging.Log("Greed", "Decoding Base64: " + Convert.ToBase64String(Beta.Bytes), 1);
            if (Psi == null) throw new Exception("Null Psi");
            Lib.Buffer B = new Lib.Buffer(Psi, Beta.Bytes);
            Logging.Log("Greed", "Decoded: " + Encoding.Default.GetString(B.Bytes), 2);
            return B;
        }
        */

        public byte[] ProxyEncrypt(byte[] Data, Fang Iota)
        {
            byte[][] Proxies = new byte[][] { Controller.Fi.Nu.ToArray()[0] }.Concat(Iota.Upsilon.ToArray()).ToArray();
            foreach (byte[] Omicron in Proxies)
            {
                BigInteger Lambda = new BigInteger(Omicron);
                if (Controller.Fi.Psi[Lambda].Rho[Controller.Fi.Psi[Lambda].Rho.ProxyId].Psi != null)
                {
                    Controller.Fi.Psi[Lambda].Rho[Controller.Fi.Psi[Lambda].Rho.ProxyId].Psi.Encode(
                        Data, 
                        ref Controller.Fi.Psi[Lambda].Rho[Controller.Fi.Psi[Lambda].Rho.ProxyId].Eta.Out);
                    Data = Controller.Fi.Psi[Lambda].Rho[Controller.Fi.Psi[Lambda].Rho.ProxyId].Psi.Bytes;
                }
            }
            return Data;
        }

        public void Handshake(String Subject, byte[] Data, Fang Iota)
        {
            if (Theta == null) throw new Exception("Null Theta");
            if (Subject != "Proxy" && Iota.Upsilon != null)
            {
                byte[] ClientIdBytes = ClientId.ToByteArray();
                Output("Proxy", Subject, new byte[] { 0x16 }, 1);
                Data = ProxyEncrypt(Iota.Upsilon.Serialize()
                    .Concat(BitConverter.GetBytes(ClientIdBytes.Length)).Concat(ClientIdBytes)
                    .Concat(BitConverter.GetBytes(Data.Length)).Concat(Data).ToArray(), Iota);
            }

            Logging.Log("Greed", String.Format("{0} {1} Handshake: {2}", Cone ? "Cone" : "Rod", Subject, Encoding.Default.GetString(Data), 1), 2);
            Output("Fi", Subject, Data, 1);
        }

        public void Handshake(String Subject, BigInteger Data, Fang Iota)
        {
            Handshake(Subject, Data.ToByteArray(), Iota);
        }

        public void NextHandshake(ref BigInteger Beta, ref Fang Iota)
        {
            if (Theta == null) throw new Exception("Null Theta");
            if (Iota.HandshakeState >= 0x06)
            {
                try
                {
                    Iota.HandshakeState = (short)Beta;
                } catch
                {
                    int i = 99;
                }
                return;
            }

            if (Cone)
            {
                if(Iota.Mu.Tau.IsZero)
                {
                    Iota.Mu.Tau = Iota.Mu.Avail(Beta);
                    Handshake("Tau", Iota.Mu.Tau, Iota);
                    Iota.HandshakeState = 0x01;
                }
                else if (Iota.Mu.Pole.IsZero && Iota.PeerChannel.IsZero)
                {
                    Iota.Mu.Form(Beta);
                    Iota.Mu.Polarize();
                    Handshake("Pole", Iota.Mu.Pole, Iota);
                    Iota.HandshakeState = 0x02;
                }
                else if (Iota.Mu.Coordinate.IsZero)
                {
                    Iota.Mu.Conjugate(ref Beta);
                    Iota.Mu.Conify();
                    Handshake("Foundation", Iota.Mu.Foundation, Iota);
                    Handshake("Channel", Iota.Mu.Channel, Iota);
                    Iota.HandshakeState = 0x03;
                }
                else if (Iota.Mu.Element.IsZero && Iota.PeerFoundation.IsZero)
                {
                    Iota.PeerFoundation = Beta;
                    Iota.HandshakeState = 0x04;
                }
                else if (Iota.Mu.Element.IsZero && Iota.PeerChannel.IsZero)
                {
                    Iota.PeerChannel = Beta;
                    Iota.Mu.Saturate(Iota.PeerFoundation, Iota.PeerChannel);
                    Iota.Mu.Bond();
                    Handshake("Dynamo", Iota.Mu.Dynamo, Iota);
                    Iota.HandshakeState = 0x05;
                }
                else if (Iota.Mu.Barn.IsZero)
                {
                    Iota.PeerDynamo = Beta;
                    Iota.Mu.Adduct(Iota.PeerDynamo);
                    Iota.Mu.Open();
                    Logging.Log("Greed", "Cone Handshake Complete: " + Iota.Mu.Barn, 2);
                    Iota.Psi = new Lib.Buffer(Iota.Mu.Ring, Iota.Mu.Coordinate, Iota.Mu.Manifold, Iota.Mu.Barn, Iota.Mu.Element);
                    Iota.HandshakeState = 0x06;
                }
            }
            else
            {
                if (Iota.Mu.Alpha.IsZero)
                {
                    Iota.Mu.Alpha = Iota.Mu.Avail(Beta);
                    Handshake("Alpha", Iota.Mu.Alpha, Iota);
                    Iota.HandshakeState = 0x01;
                }
                else if (Iota.Mu.Pole.IsZero && Iota.PeerChannel.IsZero)
                {
                    Iota.Mu.Form(Beta);
                    Iota.Mu.Polarize();
                    Handshake("Pole", Iota.Mu.Pole, Iota);
                    Iota.HandshakeState = 0x02;
                }
                else if (Iota.Mu.Coordinate.IsZero)
                {
                    Iota.Mu.Conjugate(ref Beta);
                    Iota.HandshakeState = 0x03;
                }
                else if (Iota.Mu.Element.IsZero && Iota.PeerFoundation.IsZero)
                {
                    Iota.PeerFoundation = Beta;
                    Iota.HandshakeState = 0x04;
                }
                else if (Iota.Mu.Element.IsZero && Iota.PeerChannel.IsZero)
                {
                    Iota.PeerChannel = Beta;
                    Iota.Mu.Saturate(Iota.PeerFoundation, Iota.PeerChannel);
                    Iota.Mu.Bond();
                    Handshake("Foundation", Iota.Mu.Foundation, Iota);
                    Handshake("Channel", Iota.Mu.Channel, Iota);
                    Handshake("Dynamo", Iota.Mu.Dynamo, Iota);
                    Iota.HandshakeState = 0x05;
                }
                else if (Iota.Mu.Barn.IsZero)
                {
                    Iota.PeerDynamo = Beta;
                    Iota.Mu.Adduct(Iota.PeerDynamo);
                    Iota.Mu.Open();
                    Logging.Log("Greed", "Rod Handshake Complete: " + Iota.Mu.Barn, 2);
                    Iota.Psi = new Lib.Buffer(Iota.Mu.Ring, Iota.Mu.Coordinate, Iota.Mu.Manifold, Iota.Mu.Barn, Iota.Mu.Element);
                    Avail(Iota.Mu.Signal, ref Iota);
                    Form(Iota.Mu.Channel, ref Iota);
                    Iota.Psi.Pi();
                    Iota.Psi.Rho();
                    Iota.Eta = (Iota.Psi.Mu.Upsilon, Iota.Psi.Mu.Upsilon);
                    if (Iota.Nu != null) throw new Exception("Non Null Nu");
                    Iota.Nu = Controller.Fi.Psi[ClientId].Rho[0].Mu.OpenSerialization();
                    Iota.Sigma = new Conjunction();
                    Iota.HandshakeState = 0x06;
                    Logging.Log("Greed", "Connected: " + ClientId, 6);
                }
            }
        }

        public void Avail(BigInteger Signal, ref Fang Iota)
        {
            if (Iota.Psi == null) throw new Exception("Null Psi");
            if (Theta == null) throw new Exception("Null Theta");
            Iota.Psi.Alpha(Signal);
            Input("Fi", "ALPHA", new byte[] { 0x08 }, 1);
            Input("Fi", "ALPHA Signal", Signal.ToByteArray(), 1);
        }

        public void Form(BigInteger Channel, ref Fang Iota)
        {
            if (Iota.Psi == null) throw new Exception("Null Psi");
            if (Theta == null) throw new Exception("Null Theta");
            Iota.Psi.Beta(Channel.ToByteArray(), false);
            if (Iota.Psi.Bytes == null) throw new Exception("Encoding Failure");
            Input("Fi", "BETA", new byte[] { 0x09 }, 1);
            Input("Fi", "BETA Psi", Iota.Psi.Bytes, 1);
        }

        public void Disconnect()
        {
            try {
                Greed? Beta;
                Controller.Fi.Psi.TryRemove(ClientId, out Beta);
                try {
                    Rho[0].Rho.Write(Encoding.Default.GetBytes(String.Format("\r\n\r\n\r\n\r\n{0}\r\n", DysnomiaTime.Now)));
                    Rho[0].Rho.Write(Encoding.Default.GetBytes("Pre-Alpha Chatlog Milestone Test Client Available At https://github.com/busytoby/atropa_pulsechain\r\n"));
                    Rho[0].Rho.Close();
                } catch (Exception E) { }
            } catch (Exception E) { }
            try {
                Mu.Close();
            } catch (Exception E) { }
            Logging.Log("Greed", "Disconnected " + Host, 6);
        }

        public void Procede(Span<Byte> Iota, ref Fang Omicron)
        {
            Conjunction Omega;
            BigInteger ProxyTo;
            byte[] ProxyData;

            switch (Omicron.HandshakeState)
            {
                case 0x12:
                    String ChatString = Encoding.Default.GetString(Iota);
                    Omicron.Psi.Gamma(ChatString);
                    Logging.Log("CHAT", ChatString, 12);
                    break;
                case 0x13:
                    Omicron.Psi.Encode(Iota.ToArray(), ref Omicron.Eta.In);
                    Omicron.Psi.Gamma();
                    Logging.Log("ECHAT", Omicron.Psi.ToString(), 12);
                    break;
                case 0x14:
                    Omicron.Sigma.Enqueue(new byte[] { 0x14 });
                    Omicron.Sigma.Enqueue(Iota.ToArray());
                    Logging.Log("QUERY", Encoding.Default.GetString(Iota), 1);
                    break;
                case 0x16:
                    BigInteger NuProxyId = new BigInteger(Controller.Fi.Nu.ToArray()[0]);
                    Controller.Fi.Psi[NuProxyId].Rho[Controller.Fi.Psi[NuProxyId].Rho.ProxyId].Psi.Encode(
                        Iota.ToArray(), ref Controller.Fi.Psi[NuProxyId].Rho[Controller.Fi.Psi[NuProxyId].Rho.ProxyId].Eta.In);
                    Omicron.Psi.Encode(Iota.ToArray(), ref Omicron.Eta.In);
                    Omega = Conjunction.Deserialize(Omicron.Psi.Bytes);
                    ProxyTo = new BigInteger(Omega.ToArray()[0]);
                    ProxyData = Omega.Serialize();
                    if (Omega.Count == 3)
                    {
                        Controller.Fi.Psi[ProxyTo].Output("Fi", "New Proxy", new byte[] { 0x17 }, 1);
                        Controller.Fi.Psi[ProxyTo].Output("Fi", "New Proxy", ProxyData, 1);
                    }
                    else if (Omega.Count == 4)
                    {
                        Controller.Fi.Psi[ProxyTo].Output("Fi", Omega.ToArray()[1], new byte[] { 0x17 }, 1);
                        Controller.Fi.Psi[ProxyTo].Output("Fi", Omega.ToArray()[1], ProxyData, 1);
                    }
                    else throw new Exception("Bad Omega Count");
                    break;
                case 0x17:
                    if (Omicron.Psi != null)
                    {
                        Omicron.Psi.Encode(Iota.ToArray(), ref Omicron.Eta.In);
                        Omega = Conjunction.Deserialize(Omicron.Psi.Bytes);
                        
                    }
                    else Omega = Conjunction.Deserialize(Iota.ToArray());
                    Conjunction Upsilon = new Conjunction();
                    while (Omega.Count > 2)
                        Upsilon.Enqueue(Omega.NextBytes());
                    ProxyTo = Omega.Next();
                    if (Omicron.Psi == null)
                    {
                        BigInteger Data = Omega.Next();
                        Fang Chi = Rho[ProxyTo];
                        Chi.HandshakeState = 0x00;
                        NextHandshake(ref Data, ref Chi);
                        Chi.HandshakeState = 0x07;
                        Chi.Rho.WaitingForProxy = true;
                        Controller.Fi.Psi[ProxyTo].Rho[Controller.Fi.Psi[ProxyTo].Rho.ProxyId].Rho.WaitingForProxy = false;
                    }
                    else
                    {
                        throw new Exception("Not Yet Implemented");
                    }
                    break;
                default:
                    throw new Exception("Cannot Procede With Handshake State");
            }
            Omicron.HandshakeState = 0x07;
        }

        protected override void Phi()
        {
            Thread.Sleep(10);
            if (Theta == null) throw new Exception("Null Theta");
            if (Rho[Rho.ProxyId].Upsilon == null)
            {
                if (!Mu.Connected && Theta.In.Count == 0 && Cone == false)
                    Mu.Connect(new IPEndPoint(Dns.GetHostAddresses(Host)[0], Port));
            }

            byte[] bytes = new byte[256];
            Rho[Rho.ProxyId].Rho = new DysnomiaNetworkStream(Mu);
            Stopwatch stopwatch = new Stopwatch();
            short Resets = 0;

            Span<Byte> Omicron = new Span<Byte>(bytes);
            Tare? Lambda;

            if (Rho[Rho.ProxyId].Upsilon != null) {
                Controller.Fi.Psi.TryAdd(ClientId, this);
                byte[] ClientIdBytes = ClientId.ToByteArray();
                Input("Fi", "Xi", ClientIdBytes, 1);
                Output("Fi", "Proxy", new byte[] { 0x16 }, 1);
                byte[] ConnectionString = Rho[Rho.ProxyId].Upsilon.Serialize()
                    .Concat(BitConverter.GetBytes(ClientIdBytes.Length)).Concat(ClientIdBytes)
                    .Concat(BitConverter.GetBytes(ClientIdBytes.Length)).Concat(ClientIdBytes).ToArray();
                Output("Fi", "Xi", ProxyEncrypt(ConnectionString, Rho[Rho.ProxyId]), 1);
                Rho[Rho.ProxyId].Rho.WaitingForProxy = true;
            }

            while (Mu.Connected)
            {
                try
                {
                    stopwatch.Start();
                    while (Theta.In.Count > 0)
                    {
                        string From, Subject;
                        byte[] Data, Priority;
                        if (!Theta.In.TryDequeue(out Lambda)) throw new Exception("Cannot Dequeue");
                        From = Lambda.NextString();
                        Subject = Lambda.NextString();
                        Data = Lambda.NextBytes();
                        Priority = Lambda.NextBytes();
                        if (Cone && Subject == "Xi")
                        {
                            BigInteger Delta = new BigInteger(Data);
                            ClientId = Delta;
                            Fang Chi = Rho[Rho.ProxyId];
                            NextHandshake(ref Delta, ref Chi);
                            stopwatch.Reset();
                            if (Rho[Rho.ProxyId].Upsilon != null) Rho[Rho.ProxyId].HandshakeState = 0x07;
                        }
                        else if (Cone) throw new Exception("Cone Should No Longer Be Running In Greed");
                        else if (Subject == "ALPHA" && Data.Length == 1 && Data[0] == 0x08)
                        {
                            if (!Theta.In.TryDequeue(out Lambda)) throw new Exception("Cannot Dequeue");
                            From = Lambda.NextString();
                            Subject = Lambda.NextString();
                            Data = Lambda.NextBytes();
                            Priority = Lambda.NextBytes();
                            BigInteger Delta = new BigInteger(Data);
                            Handshake("Alpha", 0x08, Rho[Rho.ProxyId]);
                            Handshake("Alpha", Delta, Rho[Rho.ProxyId]);
                            if (Rho[Rho.ProxyId].Nu == null) throw new Exception("Null Nu");
                            Rho[Rho.ProxyId].Nu.Join(new byte[] { 0x08 }, Delta.ToByteArray());
                        }
                        else if (Subject == "BETA" && Data.Length == 1 && Data[0] == 0x09)
                        {
                            if (Rho[Rho.ProxyId].Psi == null) throw new Exception("Null Psi");
                            if (Rho[Rho.ProxyId].Psi.Bytes == null) throw new Exception("Null Psi Bytes");
                            if (!Theta.In.TryDequeue(out Lambda)) throw new Exception("Cannot Dequeue");
                            From = Lambda.NextString();
                            Subject = Lambda.NextString();
                            Data = Lambda.NextBytes();
                            Priority = Lambda.NextBytes();
                            Handshake("Beta", 0x09, Rho[Rho.ProxyId]);
                            Handshake("Beta", Data, Rho[Rho.ProxyId]);
                            if (Rho[Rho.ProxyId].Nu == null) throw new Exception("Null Nu");
                            Rho[Rho.ProxyId].Nu.Join(new byte[] { 0x09 }, Rho[Rho.ProxyId].Mu.Channel.ToByteArray());
                        }
                        else if (Subject == "SAY" && Data.Length == 1 && Data[0] == 0x12)
                        {
                            if (Rho[Rho.ProxyId].Psi == null) throw new Exception("Null Psi");
                            if (Rho[Rho.ProxyId].Psi.Bytes == null) throw new Exception("Null Psi Bytes");
                            if (!Theta.In.TryDequeue(out Lambda)) throw new Exception("Cannot Dequeue");
                            From = Lambda.NextString();
                            Subject = Lambda.NextString();
                            Data = Lambda.NextBytes();
                            Priority = Lambda.NextBytes();
                            Handshake("Say", 0x12, Rho[Rho.ProxyId]);
                            Handshake("Say", Data, Rho[Rho.ProxyId]);
                        }
                        else if (Subject == "ESAY" && Data.Length == 1 && Data[0] == 0x13)
                        {
                            if (Rho[Rho.ProxyId].Psi == null) throw new Exception("Null Psi");
                            if (Rho[Rho.ProxyId].Psi.Bytes == null) throw new Exception("Null Psi Bytes");
                            if (!Theta.In.TryDequeue(out Lambda)) throw new Exception("Cannot Dequeue");
                            From = Lambda.NextString();
                            Subject = Lambda.NextString();
                            Rho[Rho.ProxyId].Psi.Encode(Lambda.NextBytes(), ref Rho[Rho.ProxyId].Eta.Out);
                            Data = Rho[Rho.ProxyId].Psi.Bytes;
                            Priority = Lambda.NextBytes();
                            Handshake("Esay", 0x13, Rho[Rho.ProxyId]);
                            Handshake("Esay", Data, Rho[Rho.ProxyId]);
                        }
                        else throw new Exception("Unknown Handshake Subject");
                    }

                    while (Theta.Out.Count > 0)
                    {
                        if (!Theta.Out.TryDequeue(out Lambda)) throw new Exception("Cannot Dequeue");
                        short OpCode = Lambda.OpCode();
                        if (OpCode != 0x10 && OpCode != 0x11 && OpCode != 0x17) throw new Exception("Unknown OpCode");
                        byte[] Timestamp = Lambda.NextBytes();
                        string From = Lambda.NextString();
                        byte[] Subject = null;
                        if(OpCode == 0x11 || OpCode == 0x17)
                            Subject = Lambda.NextBytes();
                        byte[] Data = Lambda.NextBytes();
                        byte[] Priority = Lambda.NextBytes();
                        Rho[Rho.ProxyId].Rho.Write(Data);
                        Rho[Rho.ProxyId].Rho.Write(Encoding.Default.GetBytes(Fi.DLE));
                        if (OpCode == 0x17)
                        {
                            BigInteger ProxyId = new BigInteger(Subject);
                            Controller.Fi.Psi[ProxyId].Rho[Controller.Fi.Psi[ProxyId].Rho.ProxyId].Rho.WaitingForProxy = false;
                        }
                    }

                    Thread.Sleep(200);
                    if (Rho[Rho.ProxyId].Rho.DataAvailable)
                    {
                        Thread.Sleep(200);
                        int size = Rho[Rho.ProxyId].Rho.Read(Omicron);

                        int A, B;
                        for (int i = A = B = 0; i < size; i++)
                        {
                            //if (i == A && Omicron[A] == 0x07) { A++; continue; }
                            if (i == A && Omicron[A] != 0x10) B = -1;
                            if (i >= A && Omicron.Slice(i, 4).SequenceEqual<Byte>(Encoding.Default.GetBytes(Fi.DLE)))
                            {
                                if (B == 0) A = i + 4;
                                B = i - A;
                            }
                            if (B <= 0) continue;

                            Span<Byte> Slice = Omicron.Slice(A, B);

                            Fang Chi = Rho[Rho.ProxyId];

                            if (Rho[Rho.ProxyId].HandshakeState <= 0x07)
                            {
                                BigInteger Alpha = new BigInteger(Slice);
                                NextHandshake(ref Alpha, ref Chi);
                            }
                            else
                                Procede(Slice, ref Chi);
                            stopwatch.Reset();

                            A = i + 4;
                            B = 0;
                            i += 3;
                        }
                        Omicron.Clear();
                    }

                    if (Cone && Rho[Rho.ProxyId].HandshakeState == 0x06)
                    {
                        Input("Fi", "OK", new byte[] { 0x07 }, 1);
                        return;
                    }
                    stopwatch.Stop();
                    if (Rho[Rho.ProxyId].Mu.Barn.IsZero && stopwatch.Elapsed.TotalSeconds > 3000)
                        if (++Resets > 2) throw new Exception("Handshake Timeout");
                        else
                        {
                            Logging.Log("Greed", "Handshake Timeout, Sending Reset", 6);
                            Output("Fi", "Reset", new byte[] { 0x06 }, 1);
                            Rho[Rho.ProxyId].Mu = new Fa();
                            stopwatch.Reset();
                        }
                    stopwatch.Start();
                } catch (Exception E) {
                    //Logging.Log("Fi", E.Message, 7);
                    //if (E.StackTrace != null) Logging.Log("Fi", E.StackTrace, 7);
                    Disconnect(); 
                    return; 
                }
            }
        }
    }
}
