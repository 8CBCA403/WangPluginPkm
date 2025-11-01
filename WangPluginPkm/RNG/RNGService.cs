using PKHeX.Core;
using System;
using System.Collections.Generic;
using MethodsRNG = WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.RNG
{
    internal class RNGService
    {
        private readonly CheckRules _rules;

        private delegate bool Gen32(ref PKM pk, uint seed, byte form);
        private delegate uint Next32(uint seed);

        private readonly Dictionary<MethodType, Gen32> _gen32Map;
        private readonly Dictionary<MethodType, Next32> _next32Map;

        public RNGService(CheckRules rules)
        {
            _rules = rules ?? throw new ArgumentNullException(nameof(rules));

            _gen32Map = new Dictionary<MethodType, Gen32>
         {
             { MethodType.None, (ref PKM pk, uint s, byte f) => MethodsRNG.NoMethod.GenPkm(ref pk, _rules) },
             { MethodType.Method1, (ref PKM pk, uint s, byte f) => MethodsRNG.Method1RNG.GenPkm(ref pk, s, _rules) },
             { MethodType.Method1_Unown, (ref PKM pk, uint s, byte f) => MethodsRNG.UnownRNG.GenPkm(ref pk,1, s, _rules, f) },
             { MethodType.Method2, (ref PKM pk, uint s, byte f) => MethodsRNG.Method2RNG.GenPkm(ref pk, s, _rules) },
             { MethodType.Method2_Unown, (ref PKM pk, uint s, byte f) => MethodsRNG.UnownRNG.GenPkm(ref pk,2, s, _rules, f) },
             { MethodType.Method3, (ref PKM pk, uint s, byte f) => MethodsRNG.Method3RNG.GenPkm(ref pk, s, _rules) },
             { MethodType.Method3_Unown, (ref PKM pk, uint s, byte f) => MethodsRNG.UnownRNG.GenPkm(ref pk,3, s, _rules, f) },
             { MethodType.Method4, (ref PKM pk, uint s, byte f) => MethodsRNG.Method4RNG.GenPkm(ref pk, s, _rules) },
             { MethodType.Method4_Unown, (ref PKM pk, uint s, byte f) => MethodsRNG.UnownRNG.GenPkm(ref pk,4, s, _rules, f) },
             { MethodType.XD, (ref PKM pk, uint s, byte f) => MethodsRNG.XDColoRNG.GenPkm(ref pk, s, _rules) },
             { MethodType.Overworld8, (ref PKM pk, uint s, byte f) => MethodsRNG.Overworld8RNG.GenPkm(ref pk, s, _rules) },
             { MethodType.Roaming8b, (ref PKM pk, uint s, byte f) => MethodsRNG.Roaming8bRNG.GenPkm(ref pk, s, _rules) },
             { MethodType.BACD_R, (ref PKM pk, uint s, byte f) => MethodsRNG.BACD.GenPkm(ref pk, s &0xFFFF, _rules,0) },
             { MethodType.BACD_U, (ref PKM pk, uint s, byte f) => MethodsRNG.BACD.GenPkm(ref pk, s, _rules,1) },
             { MethodType.BACD_R_S, (ref PKM pk, uint s, byte f) => MethodsRNG.BACD.GenPkm(ref pk, s &0xFFFF, _rules,2) },
             { MethodType.Method1Roaming, (ref PKM pk, uint s, byte f) => MethodsRNG.Method1Roaming.GenPkm(ref pk, s, _rules) },
             { MethodType.Channel, (ref PKM pk, uint s, byte f) => MethodsRNG.ColoRNG.GenPkm(ref pk, s, _rules) },
             { MethodType.ChannelJirachi, (ref PKM pk, uint s, byte f) => MethodsRNG.JiColoRNG.GenPkm(ref pk, s, _rules) },
             { MethodType.E_Reader, (ref PKM pk, uint s, byte f) => MethodsRNG.E_Reader.GenPkm(ref pk, s, _rules) },
             { MethodType.ChainShiny, (ref PKM pk, uint s, byte f) => MethodsRNG.ChainShiny.GenPkm(ref pk, s, _rules) },
             { MethodType.G5MGShiny, (ref PKM pk, uint s, byte f) => MethodsRNG.G5MGShiny.GenPkm(ref pk, s, _rules) },
             { MethodType.Gen5Wild, (ref PKM pk, uint s, byte f) => MethodsRNG.Gen5Wild.GenPkm(ref pk, s, _rules) },
             { MethodType.PokeWalker, (ref PKM pk, uint s, byte f) => MethodsRNG.PokeWalker.GenPkm(ref pk, _rules) },
             { MethodType.PokeSpot, (ref PKM pk, uint s, byte f) => MethodsRNG.PokeSpot.GenPkm(ref pk, s, _rules) },

         };

            _next32Map = new Dictionary<MethodType, Next32>
             {
             { MethodType.Method1, s => MethodsRNG.Method1RNG.Next(s) },
             { MethodType.Method1_Unown, s => MethodsRNG.UnownRNG.Next(s) },
             { MethodType.Method2, s => MethodsRNG.Method2RNG.Next(s) },
             { MethodType.Method2_Unown, s => MethodsRNG.UnownRNG.Next(s) },
             { MethodType.Method3, s => MethodsRNG.Method3RNG.Next(s) },
             { MethodType.Method3_Unown, s => MethodsRNG.UnownRNG.Next(s) },
             { MethodType.Method4, s => MethodsRNG.Method4RNG.Next(s) },
             { MethodType.Method4_Unown, s => MethodsRNG.UnownRNG.Next(s) },
             { MethodType.XD, s => MethodsRNG.XDColoRNG.Next(s) },
             { MethodType.Overworld8, s => MethodsRNG.Overworld8RNG.Next(s) },
             { MethodType.Roaming8b, s => MethodsRNG.Roaming8bRNG.Next(s) },
             { MethodType.BACD_R, s => MethodsRNG.BACD.Next(s) },
             { MethodType.BACD_U, s => MethodsRNG.BACD.Next(s) },
             { MethodType.BACD_R_S, s => MethodsRNG.BACD.Next(s) },
             { MethodType.Method1Roaming, s => MethodsRNG.Method1Roaming.Next(s) },
             { MethodType.Channel, s => MethodsRNG.ColoRNG.Next(s) },
             { MethodType.ChannelJirachi, s => MethodsRNG.JiColoRNG.Next(s) },
             { MethodType.E_Reader, s => MethodsRNG.E_Reader.Next(s) },
             { MethodType.ChainShiny, s => MethodsRNG.ChainShiny.Next(s) },
             { MethodType.G5MGShiny, s => MethodsRNG.G5MGShiny.Next(s) },
             { MethodType.Gen5Wild, s => MethodsRNG.Gen5Wild.Next(s) },
             { MethodType.PokeWalker, s => MethodsRNG.PokeWalker.Next(s) },
             { MethodType.PokeSpot, s => MethodsRNG.PokeSpot.Next(s) },
             };
        }

        public bool GenPkm(ref PKM pk, uint seed, byte form = 0)
        {
            if (_gen32Map.TryGetValue(_rules.Method, out var gen))
                return gen(ref pk, seed, form);
            throw new NotSupportedException($"Method {_rules.Method} not supported");
        }

        public bool GenPkm(ref PKM pk, ulong seed64, byte form = 0)
        {
            return _rules.Method == MethodType.Lumiose
            ? MethodsRNG.LumioseRNG.GenPkm(ref pk, seed64, _rules)
            : GenPkm(ref pk, checked((uint)seed64), form);
        }

        public uint NextSeed(uint seed)
        {
            if (_next32Map.TryGetValue(_rules.Method, out var next))
                return next(seed);
            throw new NotSupportedException($"Method {_rules.Method} not supported");
        }

        public ulong NextSeed(ulong seed64)
        {
            return _rules.Method == MethodType.Lumiose
            ? MethodsRNG.LumioseRNG.Next(seed64)
            : NextSeed(checked((uint)seed64));
        }
    }
}
