using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Procedural_Generation
{
    internal class MeshGenerator
    {
        Vector3[] vertices;
        int[] triangles;

        int xSize;
        int zSize;

        public MeshGenerator(int xSize, int zSize)
        {
            this.xSize = xSize;
            this.zSize = zSize;
        }

        public void Generate()
        {
            vertices = new Vector3[(xSize + 1) * (zSize + 1)];

            for (int i = 0, z = 0; z <= zSize; z++)
            {
                for (int x = 0; x <= xSize; x++)
                {
                    //New random seed
                    PerlinNoise.Initialize(new Random().Next());
                    float y = PerlinNoise.Generate(x * 0.3f, z * 0.3f);
                    vertices[i] = new Vector3(x, y, z);
                    i++;
                }
            }

            int verticesCount = 0;
            int trianglesCount = 0;
            triangles = new int[xSize * zSize * 6];

            for (int z = 0; z < zSize; z++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    //Both triangles together make a square
                    //Add verticesCount and trianglesCount so that after each triangle is made, we will go that many coordinates over to the next triangle
                    //Bottom left triangle
                    triangles[0 + trianglesCount] = 0 + verticesCount;
                    triangles[1 + trianglesCount] = xSize + 1 + verticesCount;
                    triangles[2 + trianglesCount] = 1 + verticesCount;
                    //Top right triangle
                    triangles[3 + trianglesCount] = 1 + verticesCount;
                    triangles[4 + trianglesCount] = xSize + 1 + verticesCount;
                    triangles[5 + trianglesCount] = xSize + 2 + verticesCount;

                    verticesCount++;
                    trianglesCount += 6;
                }

                verticesCount++;
            }
        }

        public void PrintMesh()
        {
            Console.WriteLine();

            for (int i = 0; i < vertices.Length; i++)
            {
                //Console.WriteLine(vertices[i].Y);
            }

            string str = "   ";

            for (int n = 0, i = 0; i <= zSize; i++)
            {
                for (int j = 0; j <= xSize; j++)
                {
                    if (vertices[n].Y > 0.5)
                    {
                        str += "X ";
                    }
                    else
                    {
                        str += "O ";
                    }

                    //Console.WriteLine(vertices[n].Y);
                    n++;
                }
                
                Console.WriteLine(str);
                str = "   ";
            }
        }
    }
}
