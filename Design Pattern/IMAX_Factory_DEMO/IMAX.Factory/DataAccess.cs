using System.Reflection;
using IMAX.IProjector;

namespace IMAX.Factory
{
    public class DataAccess
    {
        private static string path = "IMAX";

        private static object CreateObject(string packageName, string className)
        {
            packageName = path + "." + packageName;
            className = packageName + "." + className;
            return Assembly.Load(packageName).CreateInstance(className);
        }

        public static ITask CreateProjectorInstance(string projectorName, string className)
        {
            if (projectorName == "A")
                return (ITask)CreateObject("ProjectorA", className);
            else
                return (ITask)CreateObject("ProjectorB", className);
        }

    }
}