using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace GenerateObjects
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            var gen = new Generator();

            gen.StartGenerateSurvey(1000);

            gen.TimeOutSurvey(5000);

            gen.AbortSurvey();
        }
    }
}
