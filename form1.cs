namespace CalculatorApp
{
  public partial class Form1 : Form
  {
    double firstNum = 0, secondNum = 0, result = 0;
    bool showingResult = false, waitingForSecond = false;
    string operation = "";
  

    public Form1()
    {
        InitializeComponent();
    }

    private void NumberButton_Click(object sender, EventArgs e)
    {
      Button button = (Button)sender;

      if (txtDisplay.Text == "0" || showingResult)
        txtDisplay.Text = button.Text;
      else
        txtDisplay.Text += button.Text;

      showingResult = false;
      waitingForSecond = false;
    }

    private void OperatorButton_Click(object sender, EventArgs e)
    {
      Button button = (Button)sender;

      if (waitingForSecond)
      {
        operation = button.Text;
        return;
      }

      if (!double.TryParse(txtDisplay.Text, out firstNum)) return;
      operation = button.Text;
      txtDisplay.Clear();
      waitingForSecond = true;
    }

    private void btnEquals_Click(object sender, EventArgs e)
    {
      try
      {
        if (waitingForSecond) return;
        secondNum = double.Parse(txtDisplay.Text);

        switch (operation)
        {
          case "+": result = firstNum + secondNum; break;
          case "-": result = firstNum - secondNum; break;
          case "x": result = firstNum * secondNum; break;
          case "÷":
            if (secondNum == 0)
              throw new DivideByZeroException();
            
            result = firstNum / secondNum; break;
        }

        txtDisplay.Text = result.ToString();
        showingResult = true;
      }
      
      catch
      {
        txtDisplay.Text = "Can't divide by zero";
        operation = "";
        waitingForSecond = false;
        showingResult = true;
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      firstNum = 0;
      secondNum = 0;
      result = 0;
      operation = "";
      txtDisplay.Text = "0";
      waitingForSecond = false;
    }

    private void btnDecimal_Click(object sender, EventArgs e)
    {
      if (!txtDisplay.Text.Contains(".")) txtDisplay.Text += ".";
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      Button? target = null;

      switch (e.KeyCode)
      {
        case Keys.D0: case Keys.NumPad0: target = btn0; break;
        case Keys.D1: case Keys.NumPad1: target = btn1; break;
        case Keys.D2: case Keys.NumPad2: target = btn2; break;
        case Keys.D3: case Keys.NumPad3: target = btn3; break;
        case Keys.D4: case Keys.NumPad4: target = btn4; break;
        case Keys.D5: case Keys.NumPad5: target = btn5; break;
        case Keys.D6: case Keys.NumPad6: target = btn6; break;
        case Keys.D7: case Keys.NumPad7: target = btn7; break;
        case Keys.D8: case Keys.NumPad8: target = btn8; break;
        case Keys.D9: case Keys.NumPad9: target = btn9; break;

        case Keys.Add: target = Plus; break;
        case Keys.Subtract: target = Minus; break;
        case Keys.Multiply: target = Multiply; break;
        case Keys.Divide: target = Divide; break;

        case Keys.Decimal: case Keys.OemPeriod: target = Decimal; break;

        case Keys.Back: Backspace();
        e.Handled = true;
        e.SuppressKeyPress = true;
        return;
      }

      if (target == null)
      {
        if (e.Shift && e.KeyCode == Keys.Oemplus) target = Plus;      
        else if (e.KeyCode == Keys.OemMinus)      target = Minus;          
        else if (e.Shift && e.KeyCode == Keys.D8) target = Multiply;  
        else if (e.KeyCode == Keys.Oem2)          target = Divide;         
        else if (e.KeyCode == Keys.Oemplus)       target = btnEquals;         
      }

      if (target != null)
      {
        target.PerformClick();
        e.Handled = true;
        e.SuppressKeyPress = true; 
      }
    }

    private void Backspace()
    {
      if (showingResult) return;

      if (txtDisplay.Text.Length > 1) txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
        
      else txtDisplay.Text = "0";
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Enter)
      {
        btnEquals.PerformClick();
        return true;
      }

      return base.ProcessCmdKey(ref msg, keyData);
    }
  }
}