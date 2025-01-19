// See https://aka.ms/new-console-template for more information
using Procedural_Generation;

int xSize = 20;
int zSize = 20;

MeshGenerator mg = new MeshGenerator(xSize, zSize);

mg.Generate();
mg.PrintMesh();