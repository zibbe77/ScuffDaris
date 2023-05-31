using System;
using System.Numerics;
using System.Collections.Generic;
public class Node : IEquatable<Node>
{
    public readonly int key;
    private int hash = 1;
    public List<Stream> Streams = new();
    public Vector3 point;
    object Star = new();    //Put the star data here, or local star system data

    public Node(int k, Vector3 p)
    {
        key = k;
        point = p;
        hash = this.GetHashCode();
    }

    public override int GetHashCode()
    {
        return ((key + 1) * point.GetHashCode() * 6967) - 1;
    }

    public override bool Equals(object obj)
    {
        return obj is Node && Equals((Node)obj);
    }

    public bool Equals(Node n)
    {
        return hash == n.hash && Star == n.Star;
    }

    public override string ToString() => $"Node: {key}, Stream Count: {Streams.Count}\n{point.X}, {point.Y}, {point.Z}";
}

// public struct Point3 // Temporary Vector3 i guess?
// {
//     public readonly float x, y, z;
//     public Point3(float X, float Y, float Z)
//     {
//         x = X;
//         z = Z;
//         y = Y;
//     }

//     public override bool Equals(object obj)
//     {
//         return obj is Point3 && Equals((Point3) obj);
//     }
//     public bool Equals(Point3 p)
//     {
//         return x == p.x && y == p.y && z == p.z;
//     }
//     public override int GetHashCode()
//     {
//         return ((int)x*7 + (int)y*3 + (int)z*19)*6967-1;
//     }

//     public override string ToString() => $"{x}, {y}, {z}";

// }
