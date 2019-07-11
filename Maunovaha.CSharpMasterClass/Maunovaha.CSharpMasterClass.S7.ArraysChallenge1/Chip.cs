using System;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Chip : IEquatable<Chip>
    {
        public string Value { get; }
        public bool IsNumber => Value != "X" && Value != "O";
        public static Chip X => new Chip("X");
        public static Chip O => new Chip("O");

        public Chip(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;

        public bool Equals(Chip other) => other.Value == Value;
    }
}
