using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_6
{
	public class Calculator : ICalc
	{
		public bool doubleFlag=false;
		public event EventHandler<EventArgs> GotResult;
		public int Result = 0;
		public double ResultD = 0;
		public double rem = 0;
		private Stack<int> Results = new Stack<int>();
		private Stack<double> ResultsD = new Stack<double>();
		private Stack<CalcActionLog> actions = new Stack<CalcActionLog>();


		public void Divide(int value)
		{
			if (value==0)
			{
				actions.Push(new CalcActionLog(CalcAction.Divide, value));
				throw new CalculatorDivideByZeroException("Division by zero", actions);
			}
			Results.Push(Result);
			ResultD /= value;
			rem = ResultD - (int)ResultD;
			if (rem > 0)
				doubleFlag = true;
			else
			{
				doubleFlag = false;
				Result = (int)ResultD;
			}
			RaiseEvent();
			// return Result;
		}

		public void Divide(double value)
		{
			if (value == 0)
			{
				actions.Push(new CalcActionLog(CalcAction.Divide, value));
				throw new CalculatorDivideByZeroException("Division by zero", actions);
			}
			ResultsD.Push(ResultD);
			ResultD /= value;
			rem = ResultD - (int)ResultD;
			if (rem > 0)
				doubleFlag = true;
			else
			{
				doubleFlag = false;
				Result = (int)ResultD;
			}
			RaiseEvent();
			// return Result;
		}

		public void Multiply(int value)
		{
			int tmp = value * Result;
			if (tmp > int.MaxValue)
			{
				actions.Push(new CalcActionLog(CalcAction.Multiply, value));
				throw new CalculateOperationCauseOverflowException("Overflow", actions);
			}
			Results.Push(Result);
			Result *= value;
			ResultD = Result;
			RaiseEvent();
			// return Result;
		}

		public void Multiply(double value)
		{
			double tmp = value * Result;
			if (tmp > double.MaxValue)
			{
				actions.Push(new CalcActionLog(CalcAction.Multiply, value));
				throw new CalculateOperationCauseOverflowException("Overflow", actions);
			}
			ResultsD.Push(ResultD);
			ResultD *= value;
			rem = ResultD - (int)ResultD;
			if (rem > 0)
				doubleFlag = true;
			else
			{
				doubleFlag = false;
				Result = (int)ResultD;
			}
			RaiseEvent();
			// return Result;
		}

		public void Subtract(int value)
		{
			long tmp = Result - value;
			if (tmp < int.MinValue || (Result==int.MinValue && value==int.MaxValue))
			{
				actions.Push(new CalcActionLog(CalcAction.Subtract, value));
				throw new CalculateOperationCauseOverflowException("Overflow", actions);
			}
			Results.Push(Result);
			Result -= value;
			ResultD = Result;
			RaiseEvent();
			// return Result;
		}

		public void Subtract(double value)
		{
			double tmp = ResultD - value;
			if (tmp < double.MinValue || (Result == double.MinValue && value == double.MaxValue))
			{
				actions.Push(new CalcActionLog(CalcAction.Subtract, value));
				throw new CalculateOperationCauseOverflowException("Overflow", actions);
			}
			ResultsD.Push(Result);
			ResultD -= value;
			rem = ResultD - (int)ResultD;
			if (rem > 0)
				doubleFlag = true;
			else
			{
				doubleFlag = false;
				Result = (int)ResultD;
			}
			RaiseEvent();
			// return Result;
		}

		public void Sum(int value)
		{
			ulong tmp = (ulong)(value + Result);
			if (tmp > int.MaxValue)
			{
				actions.Push(new CalcActionLog(CalcAction.Sum, value));
				throw new CalculateOperationCauseOverflowException("Overflow", actions);
			}
			Results.Push(Result);
			Result += value;
			ResultD = Result;
			RaiseEvent();
			// return Result;
		}

		public void Sum(double value)
		{
			double tmp = (double)(value + Result);
			if (tmp > double.MaxValue)
			{
				actions.Push(new CalcActionLog(CalcAction.Sum, value));
				throw new CalculateOperationCauseOverflowException("Overflow", actions);
			}
			ResultsD.Push(Result);
			ResultD += value;
			rem = ResultD - (int)ResultD;
			if (rem > 0)
				doubleFlag = true;
			else
			{
				doubleFlag = false;
				Result = (int)ResultD;
			}
			RaiseEvent();
			// return Result;
		}

		private void RaiseEvent()
		{
			GotResult?.Invoke(this, EventArgs.Empty);
		}

		public void CancelLast()
		{
			if (Results.Count > 0)
			{
				Result = Results.Pop();
				RaiseEvent();
			}
			
		}
	}
}
