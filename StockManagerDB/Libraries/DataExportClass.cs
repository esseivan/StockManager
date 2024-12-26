using System.Collections.Generic;
using System.Linq;

namespace StockManagerDB
{
    /// <summary>
    /// Used to export the data into a file
    /// </summary>
    public class DataExportClass
    {
        public DataExportClass() { }

        public DataExportClass(
            Dictionary<string, Part> parts,
            Dictionary<string, Project> projects,
            Dictionary<string, ProjectOrderInfos> orders
        )
        {
            if (parts != null)
            {
                Parts = parts.Values.ToList();
                Parts.Sort(new Part.CompareMPN());
            }

            if (projects != null)
            {
                Projects = projects.Values.ToList();
                Projects.Sort(new Project.CompareName());
            }

            if (orders != null)
            {
                Orders = orders.Values.ToList();
                Orders.Sort(new ProjectOrderInfos.CompareName());
            }
        }

        public List<Part> Parts { get; set; }
        public List<Project> Projects { get; set; }
        public List<ProjectOrderInfos> Orders { get; set; }

        public Dictionary<string, Part> GetParts()
        {
            if (Parts == null)
            {
                return null;
            }

            return new Dictionary<string, Part>(Parts.ToDictionary(p => p.MPN, p => p));
        }

        public Dictionary<string, Project> GetProjects()
        {
            if (Projects == null)
            {
                return null;
            }

            return new Dictionary<string, Project>(Projects.ToDictionary(p => p.Name, p => p));
        }

        public Dictionary<string, ProjectOrderInfos> GetOrders()
        {
            if (Orders == null)
            {
                return null;
            }

            return new Dictionary<string, ProjectOrderInfos>(
                Orders.ToDictionary(p => p.name, p => p)
            );
        }
    }
}
