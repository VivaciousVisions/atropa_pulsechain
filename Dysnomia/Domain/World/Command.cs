﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dysnomia.Domain.World
{
    public class Command : Daemon
    {
        new public static string Name = "Command";
        new public static String Description = "Not Set Description";
        public String[]? Args;

        public Command() : base() {
            Args = null;
        }

        public Command(String Eta) {
            byte[] From = Encoding.Default.GetBytes(Name);

            Tokenize(Eta);
            object? EXE = null;
            Type[] Commands = GetCommands();

            foreach(Type C in Commands)
                if(C.Name.ToLower() == Name.ToLower())
                {
                    EXE = Activator.CreateInstance(C, null);
                    if (EXE == null) throw new Exception("Null Command Instance");
                    if (Args == null) throw new Exception("Null Args");
                    Command CEXE = ((Command)EXE);
                    CEXE.Args = Args;
                    CEXE.Theta = new Living();
                    Theta = CEXE.Theta;
                    if (EXE == null || CEXE.Theta == null) throw new Exception("Catastrophic Failure");
                    CEXE.Theta.Run(CEXE.Phi);
                    break;
                }

            if (EXE == null || Theta == null)
                Logging.Log(new Tare.MSG(From, Encoding.Default.GetBytes(Name + ": Not Found"), 6));
        }

        private void Tokenize(String Eta)
        {
            List<String> _args = Eta.Split(" ").ToList();
            Name = _args[0];
            Args = _args.Skip(1).ToArray();
        }

        public Type[] GetCommands()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => String.Equals(t.Namespace, "Dysnomia.Domain.bin", StringComparison.Ordinal))
                .ToArray();
        }
    }
}
