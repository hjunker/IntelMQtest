using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Simple test client for IntelMQ API Collector
 * 
 * read the docs:
 * https://intelmq.readthedocs.io/en/latest/user/bots.html#id42
 * https://intelmq.readthedocs.io/en/latest/dev/data-harmonization.html
 *
 * */

namespace IntelMQtest
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
