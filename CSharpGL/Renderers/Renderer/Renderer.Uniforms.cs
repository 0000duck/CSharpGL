﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class Renderer
    {
        protected List<UniformVariable> uniformVariables = new List<UniformVariable>();

        //protected OrderedCollection<string> uniformVariableNames = new OrderedCollection<string>(", ");
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformValue<T>(string varNameInShader, out T value) where T : struct
        {
            value = default(T);
            bool gotUniform = false;
            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (T)(item as UniformSingleVariable).GetValue();
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }

        public bool SetUniform(string varNameInShader, ValueType value)
        {
            bool gotUniform = false;
            bool updated = false;
            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    updated = (item as UniformSingleVariable).SetValue(value);
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                if (ShaderProgram == null)
                { throw new Exception(string.Format("{0} is not initialized!", this.GetType().Name)); }

                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                UniformSingleVariable variable = GetVariable(value, varNameInShader);
                variable.SetValue(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        private UniformSingleVariable GetVariable(ValueType value, string varNameInShader)
        {
            Type t = value.GetType();
            Type varType;

            if (variableDict == null)
            {
                variableDict = new Dictionary<Type, Type>();
                variableDict.Add(typeof(bool), typeof(UniformBool));
                variableDict.Add(typeof(float), typeof(UniformFloat));
                variableDict.Add(typeof(vec2), typeof(UniformVec2));
                variableDict.Add(typeof(vec3), typeof(UniformVec3));
                variableDict.Add(typeof(vec4), typeof(UniformVec4));
                variableDict.Add(typeof(mat2), typeof(UniformMat2));
                variableDict.Add(typeof(mat3), typeof(UniformMat3));
                variableDict.Add(typeof(mat4), typeof(UniformMat4));
                variableDict.Add(typeof(samplerValue), typeof(UniformSampler));
            }

            if (variableDict.TryGetValue(t, out varType))
            {
                object variable = Activator.CreateInstance(varType, varNameInShader);
                return variable as UniformSingleVariable;
            }
            else
            {
                throw new Exception(string.Format(
                    "UniformVariable type [{0}] doesn't exists or not included in the variableDict!",
                    t));
            }
        }

        static Dictionary<Type, Type> variableDict;


    }
}
