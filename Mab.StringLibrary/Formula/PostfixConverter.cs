using Mab.StringLibrary.Formula.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    internal class PostfixConverter
    {
       
        public IEnumerable<IFormulaPart> Infix { get; }
		public IEnumerable<IFormulaPart> Postfix { get; private set; }

		public PostfixConverter(IEnumerable<IFormulaPart> infix)
		{
			Infix = infix;
		}


		public double ProcessPostfix()
		{
            try
            {
				Stack<IFormulaPart> datas = new Stack<IFormulaPart>();
				foreach (IFormulaPart current in Postfix)
				{

					IFormulaPart first;
					IFormulaPart secound;
					if (current is OperatorPart)
					{
						first = datas.Pop();
						secound = datas.Pop();
						datas.Push((current as OperatorPart).Do((NumberPart)first, (NumberPart)secound));
					}
					else if (current is NumberPart)
					{
						datas.Push(current);
					}

				}
				if (datas.Count == 1 && datas.Peek() is NumberPart)
				{
					NumberPart res = datas.Pop() as NumberPart;
					return res.Value;
				}
				else
				{
					throw new FormulaParseException();
				}
			}
            catch (System.Exception ex)
            {
				throw new FormulaParseException("process failed!",ex);
            }
			
		}

		public void ConvertToPostFix()
		{
			Stack<IFormulaPart> Oprs=new Stack<IFormulaPart>();
			List<IFormulaPart> result=new List<IFormulaPart>();

			foreach(IFormulaPart c in Infix) 
			{

				// If the scanned character is
				// an operand, add it to output string.
				if (c is NumberPart)
				{
					result.Add(c);
				}

				// If the scanned character is an
				// ‘(‘, Push it to the stack.
				else if (c is ParenthesesPart && (c as ParenthesesPart).IsOpen)
				{
					Oprs.Push(c);
				}

				// If the scanned character is an ‘)’,
				// pop and to output string from the stack
				// until an ‘(‘ is encountered.
				else if (c is ParenthesesPart && (c as ParenthesesPart).IsClose)
				{
					while (!(Oprs.Peek() is ParenthesesPart && (Oprs.Peek() as ParenthesesPart).IsOpen))
					{
						result.Add(Oprs.Pop());
					}
                   

					if(!(Oprs.Count>0 && Oprs.Peek() is ParenthesesPart && (Oprs.Peek() as ParenthesesPart).IsOpen))
                    {
						throw new FormulaParseException();
                    }
                    else
                    {
						Oprs.Pop(); //pop ‘(’
					}
				}

				//If an operator is scanned
				else if(c is OperatorPart)
				{


					while (Oprs.Count != 0 &&  
						   Oprs.Peek() is OperatorPart && 
						   (c as OperatorPart).Precedence <= (Oprs.Peek() as OperatorPart).Precedence)
					{
						result.Add(Oprs.Pop());
						
					}
					Oprs.Push(c);
				}
			}

			// Pop all the remaining elements from the stack
			while (Oprs.Count != 0)
			{
				result.Add(Oprs.Peek());
				Oprs.Pop();
			}
			Postfix = result;
		}
	}
}
