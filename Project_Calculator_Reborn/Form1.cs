using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Calculator_Reborn {
	public partial class Form1 : Form {
		private string ops = "+-x÷^Mod";
		private Boolean resultC = false;
		private List<string> eq = new List<string>();
		private string inputBackup;

		private Boolean neg = false;

//        private List<string> history = new List<string>();
		private double mem = 0;

		private Boolean expC = false;
		private Boolean exp1stInputC = false;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			inputBox.Text = "0";
			inputBox.Focus();
		}

		private void inputBox_KeyPress(object sender, KeyPressEventArgs e) {
			String key = e.KeyChar.ToString();
			//MessageBox.Show(key);
			switch (key) {
				case "0":
					type("0");
					break;
				case "1":
					type("1");
					break;
				case "2":
					type("2");
					break;
				case "3":
					type("3");
					break;
				case "4":
					type("4");
					break;
				case "5":
					type("5");
					break;
				case "6":
					type("6");
					break;
				case "7":
					type("7");
					break;
				case "8":
					type("8");
					break;
				case "9":
					type("9");
					break;
				case ".":
					type(".");
					break;
				case "+":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "+", neg);
					break;
				case "-":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "-", neg);
					break;
				case "*":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "x", neg);
					break;
				case "/":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "÷", neg);
					break;
				case "\b":
					erase();
					break;
				case "\r":
					inputBox.Text = Exp();
					switch (neg) {
						case false:
							eq.Add(inputBox.Text);
							break;
						case true:
							eq.Add("-" + inputBox.Text);
							state(neg = false);
							break;
					}
					calculate();
					break;
			}
		}

		private void buttonClick(object sender, EventArgs e) {
			Button bClick = (Button) sender;
			//MessageBox.Show(Convert.ToString(bClick));
			switch (bClick.Text) {
				case "±":
					state(neg = !neg);
					break;
				case "0":
					type("0");
					break;
				case "1":
					type("1");
					break;
				case "2":
					type("2");
					break;
				case "3":
					type("3");
					break;
				case "4":
					type("4");
					break;
				case "5":
					type("5");
					break;
				case "6":
					type("6");
					break;
				case "7":
					type("7");
					break;
				case "8":
					type("8");
					break;
				case "9":
					type("9");
					break;
				case ".":
					type(".");
					break;
				case "+":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "+", neg);
					break;
				case "-":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "-", neg);
					break;
				case "x":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "x", neg);
					break;
				case "÷":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "÷", neg);
					break;
				case "⇦":
					erase();
					break;
				case "CE":
					clearError();
					break;
				case "C":
					clear();
					break;
				case "=":
					inputBox.Text = Exp();
					switch (neg) {
						case false:
							eq.Add(inputBox.Text);
							break;
						case true:
							eq.Add("-" + inputBox.Text);
							state(neg = false);
							break;
					}
					calculate();
					break;
				case "M+":
					inputBox.Text = Exp();
					addMem();
					break;
				case "M-":
					inputBox.Text = Exp();
					removeMem();
					break;
				case "MR":
					inputBox.Text = mem.ToString();
					break;
				case "MC":
					clearMem();
					break;
				case "x²":
					inputBox.Text = Exp();
					if (inputBox.Text != "0") {
						double n = Convert.ToDouble(inputBox.Text);
						inputBox.Text = exponent(n, 2).ToString();
						state(neg = false);
						resultC = true;
					}
					break;
				case "x³":
					inputBox.Text = Exp();
					if (inputBox.Text != "0") {
						double n1 = Convert.ToDouble(inputBox.Text);
						inputBox.Text = exponent(n1, 3).ToString();
						resultC = true;
					}
					break;
				case "xʸ":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "^", neg);
					break;
				case "Mod":
					inputBox.Text = Exp();
					addInput(inputBox.Text, "Mod", neg);
					break;
				case "Exp":
					if (expC == false & inputBox.Text != "0") {
						expC = true;
						exp1stInputC = true;
						inputBackup = inputBox.Text;
						inputBox.Text += ".e+0";
					}
					break;
				case "10ˣ":
					inputBox.Text = Exp();
					double n2 = Convert.ToDouble(inputBox.Text);
					inputBox.Text = exponent(10, n2).ToString();
					resultC = true;
					break;
				case "n!":
					inputBox.Text = Exp();
					double n3 = Convert.ToDouble(inputBox.Text);
					inputBox.Text = fac(Convert.ToDouble(n3)).ToString();
					resultC = true;
					break;
			}
		}

		private void type(string n) {
			if (expC == true) {
				if (n == "0") { }
				else if (exp1stInputC == true) {
					inputBox.Text = inputBox.Text.Substring(0, inputBox.TextLength - 1) + n;
					exp1stInputC = false;
				}
				else {
					inputBox.Text += n;
				}
			}
			else if (resultC == true) {
				if (n==".") {
					inputBox.Text = "0.";
					resultC = false;
				}
				else {
					inputBox.Text = n;
					resultC = false;	
				}
			}
			else if (inputBox.Text == "0" & n != ".") {
				inputBox.Text = n;
			}
			else if (n!=".") {
				inputBox.Text += n;
			}
			else if (inputBox.Text.Contains(".")!=true & n==".") {
				inputBox.Text += n;
			}
		}

		private void erase() {
			if (inputBox.TextLength > 1) {
				if (expC == true) {
					if (inputBox.Text.Substring(inputBackup.Length, (inputBox.TextLength - inputBackup.Length)) == ".e+0") {
						inputBox.Text = inputBackup;
						expC = false;
					}
					else //if (inputBox.Text.Substring(inputBackup.Length, (inputBox.TextLength-inputBackup.Length-1))==".e+" & inputBox.Text.Substring(inputBox.TextLength, 1)!="0")
					{
						inputBox.Text = inputBox.Text.Substring(0, inputBox.TextLength - 1) + "0";
						exp1stInputC = true;
					}
				}
				else {
					inputBox.Text = inputBox.Text.Substring(0, inputBox.TextLength - 1);
				}
			}
			else {
				inputBox.Text = "0";
			}
		}

		private void clear() {
			state(neg = false);
			inputBox.Text = "0";
			eq.Clear();
			updateDis();
			inputBox.Focus();
		}

		private void clearError() {
			if (displayBox.TextLength < 2) { }
			else if (inputBox.Text != "0" | neg != false) {
				inputBox.Text = "0";
				state(neg = false);
			}
			else {
				eq.RemoveRange(eq.Count - 2, 2);
				updateDis();
			}
		}

		private void addInput(string n, string op, Boolean p) {
			if (displayBox.Text == "" & n == "0") { }
			else if (n == "0") {
				eq.RemoveRange(eq.Count - 1, 1);
				eq.Add(op);
				updateDis();
				inputBox.Text = "0";
			}
			else {
				switch (p) {
					case false:
						eq.Add(n);
						eq.Add(op);
						break;
					case true:
						eq.Add(Convert.ToString(0 - Convert.ToDouble(n)));
						eq.Add(op);
						state(neg = false);
						break;
				}
				updateDis();
				inputBox.Text = "0";
			}
		}

		private void state(Boolean i) {
			switch (i) {
				case false:
					negBox.Text = "";
					break;
				case true:
					negBox.Text = "-";
					break;
			}
		}

		private void updateDis() {
			string displayEq = String.Join("", eq);
			displayBox.Text = displayEq;
			inputBox.Focus();
		}

		private void addMem() {
			switch (neg) {
				case true:
					mem -= Convert.ToDouble(inputBox.Text);
					state(neg = false);
					break;
				case false:
					mem += Convert.ToDouble(inputBox.Text);
					break;
			}
			inputBox.Text = "0";
			if (mem != 0) {
				displayM.Text = "M";
				buttonMC.Enabled = true;
				buttonMminus.Enabled = true;
				buttonMR.Enabled = true;
			}
			memDisplay.Text = mem.ToString();
			inputBox.Focus();
		}

		private void removeMem() {
			switch (neg) {
				case true:
					mem += Convert.ToDouble(inputBox.Text);
					state(neg = false);
					break;
				case false:
					mem -= Convert.ToDouble(inputBox.Text);
					break;
			}
			memDisplay.Text = mem.ToString();
			inputBox.Text = "0";
		}

		private void clearMem() {
			mem = 0;
			displayM.Text = "";
			buttonMC.Enabled = false;
			buttonMR.Enabled = false;
			buttonMminus.Enabled = false;
			memDisplay.Text = "";
			inputBox.Focus();
		}

		private double exponent(double n, double i) {
			double result = 1;
			if (i == 0) {
				return 1;
			}
			if (i == 1) {
				return n;
			}
			if (i > 1) {
				return result *= n * exponent(n, i - 1);
			}
			i *= -1;
			result /= n * exponent(n, i - 1);
			return result;
		}

		private String Exp() {
			if (expC == true) {
				double result = Convert.ToDouble(inputBackup) * (exponent(10,
					                Convert.ToInt32(inputBox.Text.Substring((inputBackup.Length + 3),
						                (inputBox.Text.Length - inputBackup.Length - 3)))));
				expC = false;
				return result.ToString();
			}
			return inputBox.Text;
		}

		private double fac(double n) {
			if (n <= 0) {
				return 1;
			}
			return n *= fac(n - 1);
		}

		private void calculate() {
			exponentY();
			mod();
			division();
			multiplication();
			subtraction();
			addition();
			displayBox.Clear();
			string displayAns = String.Join("", eq);
			inputBox.Text = displayAns;
			eq.Clear();
			resultC = true;
			inputBox.Focus();
		}

		private void exponentY() {
			int i = eq.IndexOf("^");
			if (i != -1) {
				double result = exponent(Convert.ToDouble(eq[i - 1]), Convert.ToInt32(eq[i + 1]));
				eq.Insert(i - 1, Convert.ToString(result));
				eq.RemoveRange(i, 3);
				exponentY();
			}
		}

		private void mod() {
			int i = eq.IndexOf("Mod");
			if (i != -1) {
				double result = Convert.ToDouble(eq[i - 1]) % Convert.ToInt32(eq[i + 1]);
				eq.Insert(i - 1, Convert.ToString(result));
				eq.RemoveRange(i, 3);
				mod();
			}
		}

		private void division() {
			int i = eq.IndexOf("÷");
			if (i != -1) {
				double result = Convert.ToDouble(eq[i - 1]) / Convert.ToDouble(eq[i + 1]);
				eq.Insert(i - 1, Convert.ToString(result));
				eq.RemoveRange(i, 3);
				division();
			}
		}

		private void multiplication() {
			int i = eq.IndexOf("x");
			if (i != -1) {
				double result = Convert.ToDouble(eq[i - 1]) * Convert.ToDouble(eq[i + 1]);
				eq.Insert(i - 1, Convert.ToString(result));
				eq.RemoveRange(i, 3);
				multiplication();
			}
		}

		private void addition() {
			int i = eq.IndexOf("+");
			if (i != -1) {
				double result = Convert.ToDouble(eq[i - 1]) + Convert.ToDouble(eq[i + 1]);
				eq.Insert(i - 1, Convert.ToString(result));
				eq.RemoveRange(i, 3);
				addition();
			}
		}

		private void subtraction() {
			int i = eq.IndexOf("-");

			if (i != -1) {
				double result = Convert.ToDouble(eq[i - 1]) - Convert.ToDouble(eq[i + 1]);
				eq.Insert(i - 1, Convert.ToString(result));
				eq.RemoveRange(i, 3);
				subtraction();
			}
		}

  
    }
}