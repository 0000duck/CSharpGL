﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// Create, update and delete a framebuffer object.
    /// </summary>
    public partial class Framebuffer : IDisposable
    {
        private static readonly uint[] attachment_id =
        {
			OpenGL.GL_COLOR_ATTACHMENT0,
			OpenGL.GL_COLOR_ATTACHMENT1,
			OpenGL.GL_COLOR_ATTACHMENT2,
			OpenGL.GL_COLOR_ATTACHMENT3,
			OpenGL.GL_COLOR_ATTACHMENT4,
			OpenGL.GL_COLOR_ATTACHMENT5,
			OpenGL.GL_COLOR_ATTACHMENT6,
			OpenGL.GL_COLOR_ATTACHMENT7,
			OpenGL.GL_COLOR_ATTACHMENT8,
			OpenGL.GL_COLOR_ATTACHMENT9,
			OpenGL.GL_COLOR_ATTACHMENT10,
			OpenGL.GL_COLOR_ATTACHMENT11,
			OpenGL.GL_COLOR_ATTACHMENT12,
			OpenGL.GL_COLOR_ATTACHMENT13,
			OpenGL.GL_COLOR_ATTACHMENT14,
			OpenGL.GL_COLOR_ATTACHMENT15,
        };

        private uint[] framebufferId = new uint[1];
        public uint FramebufferId
        {
            get { return framebufferId[0]; }
        }

        private List<FramebufferTexture> m_color = new List<FramebufferTexture>();
        private FramebufferTexture m_depth;
        private int m_width;
        private int m_height;

        private static OpenGL.glGenFramebuffersEXT glGenFramebuffers;
        private static OpenGL.glBindFramebufferEXT glBindFramebuffer;
        private static OpenGL.glFramebufferTexture2DEXT glFramebufferTexture2D;
        private static OpenGL.glCheckFramebufferStatusEXT glCheckFramebufferStatus;
        private static OpenGL.glDeleteFramebuffersEXT glDeleteFramebuffers;

        static Framebuffer()
        {
            glGenFramebuffers = OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>();
            glBindFramebuffer = OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>();
            glFramebufferTexture2D = OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>();
            glCheckFramebufferStatus = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>();
            glDeleteFramebuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteFramebuffersEXT>();
        }

        private void setup(FramebufferTexture color0, bool depth)
        {
            m_width = color0.width();
            m_height = color0.height();

            /* Create render buffer object for depth buffering */
            if (depth)
            {
                m_depth = new FramebufferTexture();
                m_depth.setFormat(OpenGL.GL_DEPTH_COMPONENT24, m_width, m_height, OpenGL.GL_DEPTH_COMPONENT, false, false);
            }
            else
            {
                m_depth = null;
            }

            /* Create and bind new FBO */
            glGenFramebuffers(1, framebufferId);
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);

            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
                attachment_id[m_color.Count], OpenGL.GL_TEXTURE_2D, color0.glID(), 0);
            m_color.Add(color0);

            if (m_depth != null)
            {
                glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
                    OpenGL.GL_DEPTH_ATTACHMENT, OpenGL.GL_TEXTURE_2D, m_depth.glID(), 0);
            }

            uint result = glCheckFramebufferStatus(OpenGL.GL_FRAMEBUFFER);

            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE)
            {
                throw new Exception("Failed to create frame buffer object!");
            }

            useAllAttachments();

            /* Uibind FBO */
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
        }

        public Framebuffer(List<FramebufferTexture> color, bool depth)
        {
            setup(color[0], depth);
            for (int i = 1; i < color.Count; ++i)
            {
                addColorAttachment(color[i]);
            }
        }

        public Framebuffer(FramebufferTexture color0, bool depth)
        {
            setup(color0, depth);
        }
        public Framebuffer(int width, int height, bool depth, bool interpol)
        {
            FramebufferTexture texture = new FramebufferTexture();
            texture.setFormat(OpenGL.GL_RGBA16F, width, height, OpenGL.GL_RGBA, false, interpol);

            setup(texture, depth);
        }

        public void addColorAttachment(FramebufferTexture tex)
        {
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
                attachment_id[m_color.Count], tex.glTarget(), tex.glID(), 0);
            uint result = glCheckFramebufferStatus(OpenGL.GL_FRAMEBUFFER);
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);

            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE)
            {
                throw new Exception("Failed to attach extra color buffer!");
            }

            m_color.Add(tex);

            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
            useAllAttachments();
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
        }

        public void addColorAttachment(uint internalfmt, uint format, bool mipmap, bool interpol)
        {
            FramebufferTexture texture = new FramebufferTexture();

            texture.setFormat(internalfmt, m_width, m_height, format, mipmap, interpol);

            addColorAttachment(texture);
        }

        public void swapColorAttachment(Framebuffer other, int index)
        {
            FramebufferTexture tmp = m_color[index];
            m_color[index] = other.m_color[index];
            other.m_color[index] = tmp;

            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
                attachment_id[index], m_color[index].glTarget(), m_color[index].glID(), 0);
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);

            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, other.framebufferId[0]);
            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
                attachment_id[index], other.m_color[index].glTarget(), other.m_color[index].glID(), 0);
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);

            ErrorCode error = (ErrorCode)OpenGL.GetError();
            if (error != ErrorCode.NoError)
            {
                throw new Exception(string.Format("OpenGL Error: {0}", error));
            }
        }

        public void useAllAttachments()
        {
            OpenGL.GetDelegateFor<OpenGL.glDrawBuffers>()(m_color.Count, attachment_id);
        }

        public void bind()
        {
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
        }
        public void release()
        {
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
        }

        public void clear(uint bits)
        {
            bind();
            OpenGL.Clear(bits);
            release();
        }

        public void bindDraw()
        {
            glBindFramebuffer(OpenGL.GL_DRAW_FRAMEBUFFER, framebufferId[0]);
        }
        public void releaseDraw()
        {
            glBindFramebuffer(OpenGL.GL_DRAW_FRAMEBUFFER, 0);
        }

        public void bindRead()
        {
            glBindFramebuffer(OpenGL.GL_READ_FRAMEBUFFER, framebufferId[0]);
        }
        public void releaseRead()
        {
            glBindFramebuffer(OpenGL.GL_READ_FRAMEBUFFER, 0);
        }

        public FramebufferTexture color(int i)
        {
            return m_color[i];
        }

        public FramebufferTexture depth() { return m_depth; }

        public void resize(int width, int height)
        {
            m_width = width;
            m_height = height;
            for (int i = 0; i < m_color.Count; ++i)
            {
                m_color[i].resize(m_width, m_height);
            }

            if (m_depth != null)
            {
                m_depth.resize(m_width, m_height);
            }

            // rebind the textures
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
            for (int i = 0; i < m_color.Count; ++i)
            {
                glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
                   attachment_id[i], OpenGL.GL_TEXTURE_2D, m_color[i].glID(), 0);
            }
            if (m_depth != null)
            {
                glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
                   OpenGL.GL_DEPTH_ATTACHMENT, OpenGL.GL_TEXTURE_2D, m_depth.glID(), 0);
            }
            // check status
            uint result = glCheckFramebufferStatus(OpenGL.GL_FRAMEBUFFER);
            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE)
            {
                throw new Exception("Failed to create frame buffer object!");
            }
            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
        }

        public uint glID() { return framebufferId[0]; }
        public int width() { return m_width; }
        public int height() { return m_height; }
    }
}
