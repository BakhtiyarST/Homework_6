namespace Seminar_6
{
	internal class Program
	{
		

		static void Calculator_GotResult2(object sender, EventArgs e)
		{
			if (((Calculator)sender).doubleFlag)
				Console.WriteLine($"result = {((Calculator)sender).ResultD}");
			else
				Console.WriteLine($"result = {((Calculator)sender).Result}");
		}

		static int CalculateSum(List<int> numbers, Predicate<int> Iseven, Func< int, int, int> func, Action<int> actionSome)
		{
			int sum = 0;
			foreach (var item in numbers)
			{
				if (Iseven(item))
				{
					sum = func(item, sum);
					actionSome(sum);
				}
			}
			return sum;
		}

		static void Task1()
		{
			ICalc calc = new Calculator();

			calc.GotResult += Calculator_GotResult;
			//calc.GotResult += Calculator_GotResult2;
			
			Execute(calc.Sum, int.MaxValue);
			Execute(calc.Sum, int.MaxValue);
			//Execute(calc.Subtract, int.MaxValue);
			//Execute(calc.Multiply, int.MaxValue);
			//Execute(calc.Divide, int.MaxValue);
			//calc.CancelLast();
			//Execute(calc.Multiply, int.MaxValue);
		}

		static void Task2()
		{
			List<int> numbers = new List<int>() {2, 3, 4, 5, 6, 7, 8, 9 };

			int res = CalculateSum(numbers, x => x%2==0, (x,y) => x + y, Console.WriteLine);
			Console.WriteLine(res);
		}

		static void HomeWork_6()
		{
			bool flag = false;
			int count = 0, inValue;
			double inValueD;
			string inValueStr, actionStr;

			Calculator calc = new Calculator();
			// calc.GotResult += Calculator_GotResult;
			calc.GotResult += Calculator_GotResult2;
			
			while (count <= 20)
			{
				count++;
				Console.WriteLine("Enter the operation (*, +, -, / or empty string to exit):");
				actionStr = Console.ReadLine();
				if ((actionStr == "*") || (actionStr == "+") || (actionStr == "-") || (actionStr == "/"))
				{
					Console.WriteLine("Number:");
					inValueStr = Console.ReadLine();
					if (int.TryParse(inValueStr, out inValue) && !calc.doubleFlag)
					{
						switch (actionStr)
						{
							case "*": { calc.Multiply(inValue); } break;
							case "+": { calc.Sum(inValue); } break;
							case "-": { calc.Subtract(inValue); } break;
							case "/": { calc.Divide(inValue); } break;
							default: break;
						}
					}
					else if (double.TryParse(inValueStr, out inValueD))
					{
						switch (actionStr)
						{
							case "*": { calc.Multiply(inValueD); } break;
							case "+": { calc.Sum(inValueD); } break;
							case "-": { calc.Subtract(inValueD); } break;
							case "/": { calc.Divide(inValueD); } break;
							default: break;
						}
					}
					else
					{
						Console.WriteLine("You have to provide numeric values");
						continue;
					}
				}
				else if (actionStr == String.Empty)
				{
					Console.WriteLine("Ending the calculator");
					break;
				}
				else
				{
					Console.WriteLine("You have to enter legal operators (*, +, -, / or empty string to exit");
				}
			}
		}

		static void Calculator_GotResult(object sender, EventArgs e)
		{
			Console.WriteLine($"{((Calculator)sender).Result}");
		}

		static void Execute(Action<int> action, int value = 10)
		{
			try
			{
				action.Invoke(value);
			}
			catch (CalculatorDivideByZeroException ex)
			{
				Console.WriteLine(ex);
			}
			catch (CalculateOperationCauseOverflowException ex)
			{
				Console.WriteLine(ex);
			}
		}

		static void Execute(Action<double> action, double value = 10)
		{
			try
			{
				action.Invoke(value);
			}
			catch (CalculatorDivideByZeroException ex)
			{
				Console.WriteLine(ex);
			}
			catch (CalculateOperationCauseOverflowException ex)
			{
				Console.WriteLine(ex);
			}
		}

		static void Main(string[] args)
		{
			// Task1();
			// Task2();
			// HomeWork_5();
			HomeWork_6();
			
			/*
			ICalc calc = new Calculator();

			calc.GotResult += Calculator_GotResult;

			Execute(calc.Sum, int.MaxValue);
			Execute(calc.Sum, int.MaxValue);
			Execute(calc.Subtract, int.MinValue);
			Execute(calc.Subtract, int.MinValue);
			//Execute(calc.Subtract, int.MaxValue);
			//Execute(calc.Multiply, int.MaxValue);
			//Execute(calc.Divide, int.MaxValue);
			//Execute(calc.Multiply, int.MaxValue);
			*/

		}
	}
}
