﻿using StudioCore.Scene;
using System;
using System.Numerics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veldrid;

namespace StudioCore.DebugPrimitives
{
    public class DbgPrimSolid : DbgPrim
    {
        //public override IGFXShader<DbgPrimSolidShader> Shader => GFX.DbgPrimSolidShader;

        //protected override PrimitiveType PrimType => PrimitiveType.TriangleList;

        public int TriCount => Indices.Length / 3;

        public void AddQuad(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Color color)
        {
            AddTri(a, b, c, color);
            AddTri(a, c, d, color);
        }

        public void AddTri(Vector3 a, Vector3 b, Vector3 c, Color color)
        {
            AddTri(a, b, c, color, color, color);
        }

        public void AddTri(Vector3 a, Vector3 b, Vector3 c, Color colorA, Color colorB, Color colorC)
        {
            var dir = Vector3.Cross(b - a, c - a);
            var norm = Vector3.Normalize(dir);

            var vertA = new VertexPositionColorNormal(a, colorA, norm);
            var vertB = new VertexPositionColorNormal(b, colorB, norm);
            var vertC = new VertexPositionColorNormal(c, colorC, norm);

            int vertIndexA = Array.IndexOf(Vertices, vertA);
            int vertIndexB = Array.IndexOf(Vertices, vertB);
            int vertIndexC = Array.IndexOf(Vertices, vertC);

            //If vertex A can't be recycled from an old one, make a new one.
            if (vertIndexA == -1)
            {
                AddVertex(vertA);
                vertIndexA = Vertices.Length - 1;
            }

            //If vertex B can't be recycled from an old one, make a new one.
            if (vertIndexB == -1)
            {
                AddVertex(vertB);
                vertIndexB = Vertices.Length - 1;
            }

            //If vertex C can't be recycled from an old one, make a new one.
            if (vertIndexC == -1)
            {
                AddVertex(vertC);
                vertIndexC = Vertices.Length - 1;
            }

            AddIndex((short)vertIndexC);
            AddIndex((short)vertIndexB);
            AddIndex((short)vertIndexA);

            //if (NeedToRecreateVertBuffer)
            //{
            //    VertBuffer = new VertexBuffer(GFX.Device, 
            //        typeof(VertexPositionColor), Vertices.Length, BufferUsage.WriteOnly);
            //    VertBuffer.SetData(Vertices);
            //    NeedToRecreateVertBuffer = false;
            //} 

            //if (NeedToRecreateIndexBuffer)
            //{
            //    IndexBuffer = new IndexBuffer(GFX.Device, IndexElementSize.ThirtyTwoBits, Indices.Length, BufferUsage.WriteOnly);
            //    IndexBuffer.SetData(Indices);
            //    NeedToRecreateIndexBuffer = false;
            //}
        }

        protected override void DisposeBuffers()
        {
            //VertBuffer?.Dispose();
        }

        public override DbgPrim Instantiate(string newName, Transform newLocation, Color? newNameColor = null)
        {
            var newPrim = new DbgPrimSolid();
            newPrim.Indices = Indices;
            newPrim.GeomBuffer = GeomBuffer;
            newPrim.Vertices = Vertices;
            newPrim.NeedToRecreateGeomBuffer = NeedToRecreateGeomBuffer;

            newPrim.Transform = newLocation;

            newPrim.Name = newName;

            newPrim.NameColor = newNameColor ?? NameColor;

            return newPrim;
        }

        public override void Render(Renderer.IndirectDrawEncoder encoder, SceneRenderPipeline sp)
        {
            throw new NotImplementedException();
        }

        public override void CreateDeviceObjects(Veldrid.GraphicsDevice gd, CommandList cl, SceneRenderPipeline sp)
        {
            throw new NotImplementedException();
        }
    }
}
