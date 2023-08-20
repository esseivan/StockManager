using System.Collections.Generic;

namespace StockManagerDB
{
    public class ProjectOrderInfos
    {
        public string name { get; set; } = null;
        public int n { get; set; } = 1;
        public bool exactOrder { get; set; } = false;
        public Dictionary<string, Material> materials { get; set; } =
            new Dictionary<string, Material>();


        public class CompareName : IComparer<ProjectOrderInfos>
        {
            public int Compare(ProjectOrderInfos x, ProjectOrderInfos y)
            {
                return x.name.CompareTo(y.name);
            }
        }
    }
}
