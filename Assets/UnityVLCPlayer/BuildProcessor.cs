#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace bosqmode.libvlc
{
    public class BuildProcessor : IPostprocessBuildWithReport
    {
        public int callbackOrder => 0;

        /// <summary>
        /// Copies necessary "plugins" -subfolder to build's plugins -folder in order to make libvlc work in a standalone build
        /// </summary>
        public void OnPostprocessBuild(BuildReport report)
        {
            string outputpath = report.summary.outputPath;
            outputpath = outputpath.Remove(outputpath.IndexOf(Application.productName + ".exe"), Application.productName.Length + 4);
            string target = Path.Combine(outputpath, Application.productName + "_Data", "Plugins", "x86_64", "plugins");
            string source = Path.Combine(Application.dataPath, "Plugins", "x86_64");
            foreach (string dir in Directory.EnumerateDirectories(source))
            {
                if (dir.Contains("VLC"))
                {
                    source = Path.Combine(dir, "plugins");
                }
            }

            Debug.Log("Copying plugins to: " + target);
            // TODO: try not to copy unnecessary .meta files
            FileUtil.CopyFileOrDirectory(source, target);
        }
    }
}
#endif
