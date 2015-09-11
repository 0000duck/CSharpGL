﻿using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.ToLegacyOpenGL.ChunkDumpers
{
    public static partial class ChunkDumper
    {
        public static void Dump(this TriangularMeshChunk chunk, ThreeDSModel model)
        {
            foreach (var item in chunk.Children)
            {
                if(item is VerticesListChunk)
                {
                    (item as VerticesListChunk).Dump(model);
                }
                else if(item is FacesDescriptionChunk)
                {
                    (item as FacesDescriptionChunk).Dump(model);
                }
                else if (item is MappingCoordinatesListChunk)
                {
                    (item as MappingCoordinatesListChunk).Dump(model);
                }
                else if (item is LocalCoordinatesSystemChunk)
                {
                    (item as LocalCoordinatesSystemChunk).Dump(model);
                }
            }
        }
    }
}
