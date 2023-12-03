﻿using Dysnomia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dysnomia
{
    public class ည
    {
        public Faung Mu;
        public Fa Rho;
        public Faung Psi;
        public Faung Nu;
        public Mutex Tau = new Mutex();
        public Living Theta;
        public int Kappa;
        public int Chi = 0;
        public int Gamma = 1;

        private int _r = 0;

        public ည()
        {
            Mu = new Faung();
            Rho = new Fa();
            Kappa = 1;
            Psi = Pi(true);
            Theta = new Living(Phi);
        }

        public void Phi()
        {
            int _sleep = 10;
            while (true)
            {
                Tau.WaitOne();
                Mu.Delta.WaitOne();
                Psi.Delta.WaitOne();
                if ((Mu.Chi == 5 | Mu.Chi == 6) && Kappa != 3)
                    throw new Exception("Unplanned");

                if (Kappa == 1)
                {
                    if (Chi == 0)
                        Mu.Theta(Psi.Cone.Coordinate);
                    else if (Chi == 1)
                        Psi.Theta(Mu.Rod.Coordinate);
                    else if (Chi == 2)
                        Psi.Beta(Mu.Omicron);
                    else if (Chi == 3 && Psi.Chi == 4)
                    {
                        Psi.Alpha();
                        Chi++;
                    }
                    else if (Chi == 4 && Mu.Chi == 4)
                    {
                        Mu.Alpha();
                        Chi++;
                    }
                    if (Chi < 3) Chi++;
                } else if(Kappa == 2)
                {
                    if (Chi == 0)
                        Mu.Theta(Psi.Omicron);
                    else if (Chi == 1)
                        Mu.Beta(Psi.Omicron);
                    else if (Chi == 2)
                        Mu.Iota();
                    else if (Chi == 3)
                        Mu.Lambda();
                    else if (Chi == 4)
                        Mu.Alpha();
                    if (Chi < 5) Chi++;
                } else if(Kappa == 3)
                {
                    if (Chi == 0)
                        Psi.Theta(Mu.Omicron);
                    else if (Chi == 1)
                        Psi.Beta(Mu.Omicron);
                    else if (Chi == 2)
                        Psi.Iota();
                    else if (Chi == 3)
                        Psi.Lambda();
                    else if (Chi == 4)
                        Psi.Alpha();
                    else if(Chi == 5 && Mu.Chi == 5)
                    {
                        Mu.Alpha();
                    }
                    else if (Chi == 6 && Mu.Chi == 6)
                    {
                        if (Nu != null) throw new Exception("Collapse");
                        Nu = new Faung(Mu.Upsilon, Mu.Rho, Mu.Pi, Rho.Barn);
                        Mu.Chi = 1;
                        Mu.Beta(Mu.Omicron);
                        Mu.Iota();
                        Mu.Lambda();
                        Psi.Chi = 1;
                        Psi.Beta(Mu.Omicron);
                        Psi.Iota();
                        Psi.Lambda();
                        Psi.Alpha();
                        Chi++;
                    }
                    else if (Chi == 8)
                    {
                        _sleep = 400;
                        _r++;
                    }
                    if (Chi < 5) Chi++;
                }
                Mu.Delta.ReleaseMutex();
                Psi.Delta.ReleaseMutex();
                Tau.ReleaseMutex();
                Thread.Sleep(_sleep);
            }
        }

        public ည(ref Faung Beta, ref Fa Omicron, bool Lambda)
        {
            Beta.Rod.Gamma++;
            Beta.Cone.Gamma++;
            Omicron.Gamma++;
            if (Lambda)
                Mu = new Faung();
            else
                Mu = Beta;
            Rho = Omicron;
            if (Lambda)
            {
                Kappa = 2;
                Psi = Beta;
            }
            else
            {
                Kappa = 3;
                Psi = Pi(false);
            }
            Theta = new Living(Phi);
        }

        public Faung Pi(bool Lambda)
        {
            if (Lambda)
                return new Faung(ref Rho, Mu.Cone.Secret, Mu.Cone.Signal, Mu.Cone.Channel, Mu.Cone.Identity);
            else
                return new Faung(Mu.Cone.Dynamo, Mu.Cone.Ring, Mu.Cone.Barn, Mu.Cone.Manifold);
        }

        /*
        List<Faung*> Affinities() { return List<Faung*>({ Mu, Psi }); }

        ~ည()
        {
            if (Mu.Rod.Gamma <= 1 || Mu.Cone.Gamma <= 1) delete Mu; else { Mu.Rod.Gamma--; Mu.Cone.Gamma--; }
            if (Rho.Gamma == 1) delete Rho; else Rho.Gamma--;
            if (Psi.Rod.Gamma <= 1 || Psi.Cone.Gamma <= 1) delete Psi; else { Psi.Rod.Gamma--; Psi.Cone.Gamma--; }
        }
        */
    }
}
