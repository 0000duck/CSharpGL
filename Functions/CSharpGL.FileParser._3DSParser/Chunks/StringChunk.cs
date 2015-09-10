﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public abstract class StringChunk : ChunkBase
    {
        protected string Content;

        public override void Process(ParsingContext context)
        {
            ProcessString(context);
        }

        private void ProcessString(ParsingContext context)
        {
            var reader = context.reader;

            StringBuilder builder = new StringBuilder();

            byte b = reader.ReadByte();
            uint idx = 0;
            while (b != 0)
            {
                builder.Append((char)b);
                b = reader.ReadByte();
                idx++;
            }
            this.BytesRead += idx + 1;

            this.Content = builder.ToString();
        }
    }
}
