﻿using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRageMath;
using JSONParser;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        JSON Parser = null;

        public Program()
        {
        }

        public void Save()
        {
        }

        public void Main(string argument, UpdateType updateSource)
        {
            // This will deserialize the argument, for demonstration purposes

            if (argument != "")
                Parser = new JSON(argument);
            if( Parser.ParsingComplete() ) // if parsing is complete...
            {
                Echo("argument has been parsed!");
                Echo(Parser.Result.ToString(true));  // ... output the prettified json
            }
            else  // else...
            {
                Runtime.UpdateFrequency = UpdateFrequency.Once; // ... we'll continue on the next tick
                Echo("Parsing (" + Parser.Progress + "%)..."); // ... and output the parsing progress
            }
        }
    }
}