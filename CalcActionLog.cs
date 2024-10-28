using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_6
{
	internal class CalcActionLog
	{
		public CalcAction CalcAction { get; private set; }

		public int CalcArgument { get; private set; }

		public double CalcArgumentD { get; private set; }

		public CalcActionLog(CalcAction calcAction, int calcArgument)
		{
			CalcAction = calcAction;
			CalcArgument = calcArgument;
		}

		public CalcActionLog(CalcAction calcAction, double calcArgument)
		{
			CalcAction = calcAction;
			CalcArgumentD = calcArgument;
		}
	}
}
