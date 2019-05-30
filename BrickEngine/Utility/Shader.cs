using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace BrickEngine.Utility
{
    public class Shader
    {
        private Dictionary<string, int> _uniforms;

        public int ProgramID { get; }

        public Shader(string vertexFileName)
        {
            ProgramID = GL.CreateProgram();
            _uniforms = new Dictionary<string, int>();

            if (ProgramID == 0)
            {
                Console.WriteLine("Error: Could not create shader.");
                Environment.Exit(1);
            }

            AddShader(vertexFileName, ShaderType.VertexShader);
            CompileShader();
        }

        public Shader(string vertexFileName, string fragmentFileName)
        {
            ProgramID = GL.CreateProgram();
            _uniforms = new Dictionary<string, int>();

            if(ProgramID == 0)
            {
                Console.WriteLine("Error: Could not create shader.");
                Environment.Exit(1);
            }

            AddShader(vertexFileName, ShaderType.VertexShader);
            AddShader(fragmentFileName, ShaderType.FragmentShader);
            CompileShader();
        }

        private static string ReadShader(string filename)
        {
            var shader = new StringBuilder();
            try
            {
                using (var reader = new StreamReader(filename))
                {
                    string line = reader.ReadToEnd();
                    shader.Append(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Debug.Log(e.ToString());
                Environment.Exit(1);
            }
            

            return shader.ToString();
        }

        private void AddShader(string filename, ShaderType type)
        {
            var shader = ReadShader(filename);
            var shaderID = GL.CreateShader(type);

            if(shaderID == 0)
            {
                Console.WriteLine("Error: Could not create shader.");
                Debug.Log("Error: Could not create shader.");
                Environment.Exit(1);
            }

            GL.ShaderSource(shaderID, shader);
            GL.CompileShader(shaderID);
            GL.GetShader(shaderID, ShaderParameter.CompileStatus, out var compileStatus);
            if (compileStatus == 0)
            {
                Console.WriteLine("Error: Shader compiling error. Could not compile shader.");
                Console.WriteLine(GL.GetShaderInfoLog(shaderID));
                Debug.Log("Error: Shader compiling error. Could not compile shader. " + GL.GetShaderInfoLog(shaderID));
                Environment.Exit(1);
            }

            GL.AttachShader(ProgramID, shaderID);
        }

        private void CompileShader()
        {
            GL.LinkProgram(ProgramID);
            GL.GetProgram(ProgramID, GetProgramParameterName.LinkStatus, out var linkStatus);

            if (linkStatus == 0)
            {
                Console.WriteLine("Error: Could not link shader program.");
                Console.WriteLine(GL.GetProgramInfoLog(ProgramID));
                Debug.Log("Error: Could not link shader program. " + GL.GetProgramInfoLog(ProgramID));
                Environment.Exit(1);
            }

            GL.ValidateProgram(ProgramID);
            GL.GetProgram(ProgramID, GetProgramParameterName.ValidateStatus, out var validationStatus);
            if (validationStatus == 0)
            {
                Console.WriteLine("Error: Could not validate shader program.");
                Console.WriteLine(GL.GetProgramInfoLog(ProgramID));
                Debug.Log("Error: Could not validate shader program. " + GL.GetProgramInfoLog(ProgramID));
                Environment.Exit(1);
            }
        }

        private int GetUniformLocation(string uniformName) => GL.GetUniformLocation(ProgramID, uniformName);

        #region Uniform loading
        public void LoadInt(string uniformName, int value) => GL.Uniform1(_uniforms[uniformName], value);
        public void LoadFloat(string uniformName, float value) => GL.Uniform1(_uniforms[uniformName], value);
        public void LoadDouble(string uniformName, double value) => GL.Uniform1(_uniforms[uniformName], value);
        public void LoadBool(string uniformName, bool value) => GL.Uniform1(_uniforms[uniformName], value ? 1 : 0);
        public void LoadVector(string uniformName, Vector2 value) => GL.Uniform2(_uniforms[uniformName], value);
        public void LoadVector(string uniformName, Vector3 value) => GL.Uniform3(_uniforms[uniformName], value);
        public void LoadVector(string uniformName, Vector4 value) => GL.Uniform4(_uniforms[uniformName], value);
        public void LoadMatrix(string uniformName, Matrix4 value) => GL.UniformMatrix4(_uniforms[uniformName], true, ref value);
        #endregion

        public void Start()
        {
            GL.UseProgram(ProgramID);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Stop() => GL.UseProgram(0);

        public void AddUniform(string uniformName)
        {
            var uniform = GetUniformLocation(uniformName);
            if(uniform == -1)
            {
                Console.WriteLine("Error: Could not find uniform " + uniformName + ".");
                Debug.Log("Error: Could not find uniform " + uniformName + ".");
                Environment.Exit(-1);
            }

            _uniforms.Add(uniformName, uniform);
        }

        public int GetAttribute(string name)
        {
            var attributeID = 0;
            attributeID = GL.GetAttribLocation(ProgramID, name);

            if(attributeID == -1)
                Debug.Log($"Error binding attribute {name}");

            return attributeID;
        }
    }
}
