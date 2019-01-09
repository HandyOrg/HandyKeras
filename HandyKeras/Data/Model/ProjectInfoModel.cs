using System;

namespace HandyKeras.Data.Model
{
    internal class ProjectInfoModel
    {
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModificationTime { get; set; }

        public string Path { get; set; }

        public bool IsFixed { get; set; }
    }
}