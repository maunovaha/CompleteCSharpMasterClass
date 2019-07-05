using System;

namespace Maunovaha.CSharpMasterClass.S6.OOP
{
    internal class Vector
    {
        public float X { get; } // Property of type float is by default 0.0
        public float Y { get; } // This is "readonly" .. I think
        public float Z { get; } = 1.0f; // This is "readonly" .. I think

        // This is property as well ...
        public static Vector Zero => new Vector(0.0f, 0.0f, 0.0f); // This is "readonly" .. I think

        // This does the same as doing `public int Example { get; set; }`
        // But has much more code, so this is carbage ...
        private int example;

        public int Example
        {
            get => example;
            set => example = value;
        }

        // This shows example of modifying the default setter
        private int something;

        public int Something
        {
            get => something; // Normal getter
            set => something = value * 2; // I could use if/else here and throw Exception as well..
        }

        // Using e.g. the below dont work, because we dont know the "backing-field" name.. 
        // so sometimes we might have to use the above syntax..
        // 
        // public int Better { get; set => ????? = value * 2 }

        public float SomeProperty => X * Y * Z; // Property
        public float SomeMethod() => X * Y * Z; // Method

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Debug()
        {
            Console.WriteLine("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }
    }
}
