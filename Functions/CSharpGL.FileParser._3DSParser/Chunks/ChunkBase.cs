﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public abstract class ChunkBase
    {
        public ChunkBase Parent;
        public List<ChunkBase> Childern;

        //public ushort ID;
        public uint Length;
        public int BytesRead;

        public ChunkBase()
        {
            this.Childern = new List<ChunkBase>();
        }

        public override string ToString()
        {
            {
                return string.Format("type: {0}, length: {1}, read bytes: {2}", this.GetType().Name, Length, BytesRead);
            }
            //return base.ToString();
        }

        //public abstract ushort GetChunkType();
        public virtual void Process(ParsingContext context)
        {
            var chunk = this;
            var reader = context.reader;

            while (chunk.BytesRead < chunk.Length)
            {
                ChunkBase child = reader.ReadChunk();
                child.Parent = this;
                this.Childern.Add(child);

                child.Process(context);

                chunk.BytesRead += child.BytesRead;
                //Console.WriteLine ( "ID: {0} Length: {1} Read: {2}", chunk.ID.ToString("x"), chunk.Length , chunk.BytesRead );
            }
        }


    }
}
