using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_6;

internal class CalculatorException : Exception
{
	// private string v;

	public CalculatorException(string v, Stack<CalcActionLog> actionLogs) : base(v)
	{
		ActionLogs = actionLogs;
	}

	public CalculatorException(string v, Exception e) : base(v)
	{

	}

	public override string ToString()
	{
		return Message + ":" + string.Join("\n",ActionLogs.Select(x => $"{x.CalcAction} {x.CalcArgument}"));
	}

	public Stack<CalcActionLog> ActionLogs { get; private set; }
}

internal class CalculatorDivideByZeroException : CalculatorException
{
	private string v;

	public CalculatorDivideByZeroException(string v, Stack<CalcActionLog> ActionLogs) : base(v, ActionLogs)
	{
		
	}

	public CalculatorDivideByZeroException(string v, Exception e) : base(v, e)
	{

	}
}

internal class CalculateOperationCauseOverflowException : CalculatorException
{
	private string v;

	public CalculateOperationCauseOverflowException(string v, Stack<CalcActionLog> ActionLogs) : base(v, ActionLogs)
	{

	}

	public CalculateOperationCauseOverflowException(string v, Exception e) : base(v, e)
	{

	}
}
