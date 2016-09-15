﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 持有从<see cref="IBufferable"/>到GLSL中in变量名的对应关系。
    /// 每个<see cref="IBufferable"/>和每个<see cref="Renderer"/>都有一个Map关系。
    /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
    /// <para>This relation map connects <see cref="IBufferable"/> to <see cref="Renderer"/>.</para>
    /// </summary>
    public class PropertyNameMap : IEnumerable<PropertyNameMap.NamePair>
    {
        private List<string> namesInShader = new List<string>();
        private List<string> namesInIBufferable = new List<string>();

        /// <summary>
        /// 持有从<see cref="IBufferable"/>到GLSL中in变量名的对应关系。
        /// 每个<see cref="IBufferable"/>和每个<see cref="Renderer"/>都有一个Map关系。
        /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
        /// <para>This relation map connects <see cref="IBufferable"/> to <see cref="Renderer"/>.</para>
        /// </summary>
        public PropertyNameMap() { }

        /// <summary>
        /// 持有从<see cref="IBufferable"/>到GLSL中in变量名的对应关系。
        /// 每个<see cref="IBufferable"/>和每个<see cref="Renderer"/>都有一个Map关系。
        /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
        /// <para>This relation map connects <see cref="IBufferable"/> to <see cref="Renderer"/>.</para>
        /// </summary>
        /// <param name="nameInShader"></param>
        /// <param name="nameInIBufferable"></param>
        public PropertyNameMap(string nameInShader, string nameInIBufferable)
        {
            this.Add(nameInShader, nameInIBufferable);
        }

        /// <summary>
        /// 持有从<see cref="IBufferable"/>到GLSL中in变量名的对应关系。
        /// 每个<see cref="IBufferable"/>和每个<see cref="Renderer"/>都有一个Map关系。
        /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
        /// <para>This relation map connects <see cref="IBufferable"/> to <see cref="Renderer"/>.</para>
        /// </summary>
        /// <param name="nameInShaders"></param>
        /// <param name="nameInIBufferables"></param>
        public PropertyNameMap(string[] nameInShaders, string[] nameInIBufferables)
        {
            if (nameInShaders == null || nameInIBufferables == null
                || nameInShaders.Length != nameInIBufferables.Length)
            { throw new ArgumentException(); }

            for (int i = 0; i < nameInShaders.Length; i++)
            {
                this.Add(nameInShaders[i], nameInIBufferables[i]);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nameInShader"></param>
        /// <param name="nameInIBufferable"></param>
        public void Add(string nameInShader, string nameInIBufferable)
        {
            this.namesInShader.Add(nameInShader);
            this.namesInIBufferable.Add(nameInIBufferable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public XElement ToXElement()
        {
            XElement result = new XElement(typeof(PropertyNameMap).Name,
                from nameInShader in this.namesInShader
                join nameInIBufferable in this.namesInIBufferable
                on this.namesInShader.IndexOf(nameInShader) equals this.namesInIBufferable.IndexOf(nameInIBufferable)
                select new NamePair(nameInShader, nameInIBufferable).ToXElement()
                );

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static PropertyNameMap Parse(XElement xElement)
        {
            if (xElement.Name != typeof(PropertyNameMap).Name) { throw new Exception(); }

            PropertyNameMap result = new PropertyNameMap();

            foreach (var item in xElement.Elements(typeof(NamePair).Name))
            {
                var pair = NamePair.Parse(item);
                result.namesInShader.Add(pair.VarNameInShader);
                result.namesInIBufferable.Add(pair.NameInIBufferable);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator<NamePair> GetEnumerator()
        {
            List<string> namesInShader = this.namesInShader;
            List<string> namesInIBufferable = this.namesInIBufferable;
            for (int i = 0; i < namesInShader.Count; i++)
            {
                yield return new NamePair(namesInShader[i], namesInIBufferable[i]);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        public class NamePair
        {
            private const string strVarNameInShader = "VarNameInShader";

            /// <summary>
            ///
            /// </summary>
            public string VarNameInShader { get; set; }

            private const string strNameInIBufferable = "NameInIBufferable";

            /// <summary>
            ///
            /// </summary>
            public string NameInIBufferable { get; set; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="nameInShader"></param>
            /// <param name="nameInIBufferable"></param>
            public NamePair(string nameInShader, string nameInIBufferable)
            {
                this.VarNameInShader = nameInShader;
                this.NameInIBufferable = nameInIBufferable;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public XElement ToXElement()
            {
                return new XElement(typeof(NamePair).Name,
                    new XAttribute(strVarNameInShader, VarNameInShader),
                    new XAttribute(strNameInIBufferable, NameInIBufferable));
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="xElement"></param>
            /// <returns></returns>
            public static NamePair Parse(XElement xElement)
            {
                if (xElement.Name != typeof(NamePair).Name)
                { throw new Exception(string.Format("name not match for {0}", typeof(NamePair).Name)); }

                NamePair result = new NamePair(
                    xElement.Attribute(strVarNameInShader).Value,
                    xElement.Attribute(strNameInIBufferable).Value);

                return result;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("shader [{0}] -> model [{1}]", VarNameInShader, NameInIBufferable);
            }
        }
    }
}