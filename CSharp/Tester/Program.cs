namespace MortgageLoanCalculator;

class Program
{
    static void Main(string[] args)
    {
        new Mortgage().ProcessLoan();
    }
}

public class Mortgage
{
    // Core loan properties
    public decimal PurchasePrice { get; private set; }
    public decimal InterestRate { get; private set; }
    public decimal DownPayment { get; private set; }
    public int Years { get; private set; }
    public decimal HoaPayment { get; private set; }
    public decimal MonthlyIncome { get; private set; }
    public decimal MarketValue { get; private set; }
    
    // Calculated properties
    public decimal LoanAmount { get; private set; }
    public decimal OriginationFee { get; private set; }
    public decimal ClosingCosts { get; private set; }
    public decimal EquityPercentage { get; private set; }
    public decimal MonthlyMortgagePayment { get; private set; }
    public decimal MortgageInsurancePayment { get; private set; }
    public decimal TotalMonthlyPayment { get; private set; }
    public decimal PaymentToIncomeRatio { get; private set; }
    public bool PmiRequired { get; private set; }
    public bool LoanApproved { get; private set; }
    
    // Constants
    private const decimal HOMEOWNER_INSURANCE_RATE = 0.0075m;
    private const decimal PROPERTY_TAX_RATE = 0.0125m;
    private const decimal ORIGINATION_FEE_RATE = 0.01m;
    private const decimal CLOSING_COSTS_FEE = 2500m;
    private const decimal PMI_RATE = 0.01m;
    private const decimal PMI_THRESHOLD = 10m;
    private const decimal APPROVAL_THRESHOLD = 25m;

    public void ProcessLoan()
    {
        GetLoanInfo();
        CalculateValues();
        DisplayInfo();
    }

    private void GetLoanInfo()
    {
        PurchasePrice = GetValidDecimalInput("Enter the home purchase price.");
        InterestRate = GetValidDecimalInput("Enter the interest rate of the loan.");
        DownPayment = GetValidDecimalInput("Enter the down payment amount.");
        Years = GetValidIntInput("Enter the length of the loan in years.");
        HoaPayment = GetHoaPayment();
        MonthlyIncome = GetValidDecimalInput("Enter your monthly income.", mustBePositive: true);
        MarketValue = GetValidDecimalInput("Enter the current market value of the home.", mustBePositive: true);
    }

    private decimal GetValidDecimalInput(string prompt, bool mustBePositive = false)
    {
        decimal value;
        Console.WriteLine(prompt);
        
        while (!decimal.TryParse(Console.ReadLine(), out value) || (mustBePositive && value <= 0))
        {
            Console.WriteLine(mustBePositive ? 
                "Enter a valid positive amount." : 
                "Enter a valid amount.");
        }
        
        return value;
    }

    private int GetValidIntInput(string prompt)
    {
        int value;
        Console.WriteLine(prompt);
        
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Enter a valid number of years.");
        }
        
        return value;
    }

    private decimal GetHoaPayment()
    {
        Console.WriteLine("Is there an HOA? Enter yes or no.");
        string? response;
        
        do
        {
            response = Console.ReadLine()?.ToLower();
            if (response == "yes")
            {
                return GetValidDecimalInput("Enter the HOA monthly payment amount.");
            }
        } while (response != "no" && response != "yes");
        
        return 0;
    }

    private void CalculateValues()
    {
        // Calculate fees and loan amount
        OriginationFee = PurchasePrice * ORIGINATION_FEE_RATE;
        ClosingCosts = CLOSING_COSTS_FEE;
        LoanAmount = PurchasePrice - DownPayment + OriginationFee + ClosingCosts;
        
        // Calculate equity based on market value
        EquityPercentage = (DownPayment / MarketValue) * 100;
        
        // Calculate monthly mortgage payment
        MonthlyMortgagePayment = CalculateMonthlyPayment();
        
        // Calculate PMI
        PmiRequired = EquityPercentage < PMI_THRESHOLD;
        MortgageInsurancePayment = PmiRequired ? (LoanAmount * PMI_RATE) / 12 : 0;
        
        // Calculate total monthly payment
        decimal monthlyInsurance = (PurchasePrice * HOMEOWNER_INSURANCE_RATE) / 12;
        decimal monthlyPropertyTax = (PurchasePrice * PROPERTY_TAX_RATE) / 12;
        
        TotalMonthlyPayment = MonthlyMortgagePayment + monthlyInsurance + 
                             monthlyPropertyTax + HoaPayment + MortgageInsurancePayment;
        
        // Calculate approval
        PaymentToIncomeRatio = (TotalMonthlyPayment / MonthlyIncome) * 100;
        LoanApproved = PaymentToIncomeRatio < APPROVAL_THRESHOLD;
    }

    private decimal CalculateMonthlyPayment()
    {
        decimal monthlyRate = (InterestRate / 100) / 12;
        int totalPayments = Years * 12;
        
        if (monthlyRate == 0) return LoanAmount / totalPayments;
        
        decimal powerFactor = (decimal)Math.Pow((double)(1 + monthlyRate), totalPayments);
        return LoanAmount * (monthlyRate * powerFactor) / (powerFactor - 1);
    }

    private void DisplayInfo()
    {
        Console.WriteLine("\n----------- Mortgage Loan Summary -----------");
        
        // Loan details
        DisplayLine("Purchase Price:", PurchasePrice);
        DisplayLine("Market Value:", MarketValue);
        DisplayLine("Down Payment:", DownPayment);
        DisplayLine("Origination Fee (1%):", OriginationFee);
        DisplayLine("Closing Costs:", ClosingCosts);
        DisplayLine("Total Loan Amount:", LoanAmount);
        DisplayLine("Interest Rate:", $"{InterestRate:F2}%");
        DisplayLine("Loan Term:", $"{Years} years");
        DisplayLine("Equity Percentage:", $"{EquityPercentage:F2}%");
        
        Console.WriteLine("\n--- Monthly Payment Breakdown ---");
        DisplayLine("Principal & Interest:", MonthlyMortgagePayment);
        DisplayLine("Homeowner Insurance:", (PurchasePrice * HOMEOWNER_INSURANCE_RATE) / 12);
        DisplayLine("Property Tax:", (PurchasePrice * PROPERTY_TAX_RATE) / 12);
        DisplayLine("HOA Fees:", HoaPayment);
        DisplayLine("Mortgage Insurance (PMI):", MortgageInsurancePayment);
        DisplayLine("TOTAL MONTHLY PAYMENT:", TotalMonthlyPayment, isBold: true);
        
        Console.WriteLine("\n--- Loan Decision ---");
        DisplayLine("Monthly Income:", MonthlyIncome);
        DisplayLine("Payment-to-Income Ratio:", $"{PaymentToIncomeRatio:F2}%");
        
        if (LoanApproved)
        {
            DisplayLine("Loan Recommendation:", "APPROVED");
            Console.WriteLine("Your total monthly payment is less than 25% of your monthly income.");
        }
        else
        {
            DisplayLine("Loan Recommendation:", "DENIED");
            Console.WriteLine("Your total monthly payment exceeds 25% of your monthly income.");
            Console.WriteLine("\nSuggestions to improve loan approval:");
            Console.WriteLine("• Consider increasing your down payment");
            Console.WriteLine("• Look for a more affordable home");
            Console.WriteLine("• Consider a longer loan term to reduce payments");
            Console.WriteLine("• Increase your monthly income");
        }
        
        Console.WriteLine("---------------------------------------------");
    }

    private static void DisplayLine(string label, decimal value, bool isBold = false)
    {
        string formattedValue = value.ToString("C");
        Console.WriteLine($"{label,-30}{formattedValue,15}");
    }

    private static void DisplayLine(string label, string value, bool isBold = false)
    {
        Console.WriteLine($"{label,-30}{value,15}");
    }
}
