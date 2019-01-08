using System;

namespace HandyKeras.Data
{
    internal class InternalStr
    {
        public static readonly string InstallKerasCmd = @"-m pip install keras";

        public static readonly string PythonPath = $"{AppDomain.CurrentDomain.BaseDirectory}Component/python";

        public static readonly string PythonExePath = $"{AppDomain.CurrentDomain.BaseDirectory}Component/python/python.exe";
    }
}