﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class TrianglesRecognizer : PrimitiveRecognizer
    {
        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, int length)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 2; i < length; i += 3)
                {
                    if (array[i] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId);
                        item.IndexIDList.Add(array[i - 2]);
                        item.IndexIDList.Add(array[i - 1]);
                        item.IndexIDList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
            }

            return lastIndexIdList;
        }

        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, int length, uint primitiveRestartIndex)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                uint i = 0;
                while (i + 2 < length)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        i++;
                    }
                    else
                    {
                        if (array[i + 2] == lastVertexId)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId);
                            item.IndexIDList.Add(array[i + 0]);
                            item.IndexIDList.Add(array[i + 1]);
                            item.IndexIDList.Add(array[i + 2]);
                            lastIndexIdList.Add(item);
                        }

                        i += 3;
                    }
                }
            }

            return lastIndexIdList;
        }

    }
}
