namespace MortgageLoanCalculator;

class Program
{
    static void Main(string[] args)
    {
        Mortgage house1 = new Mortgage();
    }
}

public class Mortgage
{
    public decimal PurchasePrice { get; set; }
    public decimal InterestRate { get; set; }
    public decimal DownPayment { get; set; }
    public int Years { get; set; }
    public decimal HoaPayment { get; set; }
    public decimal LoanAmount { get; set; }
    public decimal HoaYearlyTotal { get; set; }
    public decimal HomeownerInsurancePayment { get; set; }
    public decimal PropertyTaxPayment { get; set; }
    public decimal EquityPercentage { get; set; }
    public decimal MortgageInsurancePayment { get; set; }
    public bool PmiRequired { get; set; }
    public decimal MonthlyMortgagePayment { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal PaymentToIncomeRatio { get; set; }
    public bool LoanApproved { get; set; }
    public decimal TotalMonthlyPayment { get; set; }
    public decimal MonthlyInsurance { get; set; }
    public decimal MonthlyPropertyTax { get; set; }
    public decimal OriginationFee { get; set; }
    public decimal ClosingCosts { get; set; }
    public decimal MarketValue { get; set; }
    
    private static decimal homeownerInsuranceRate = 0.0075m;
    private static decimal propertyTaxRate = 0.0125m;
    private static decimal originationFeeRate = 0.01m;
    private static decimal closingCostsFee = 2500m;

    //Constructor that calls the three main methods of the Mortgage Class
    public Mortgage()
    {
        GetLoanInfo();
        CalculateValues();
        DisplayInfo();
    }

    //Method that prompts user input and stores critical loan information
    public void GetLoanInfo()
    {
        decimal purchasePrice;
        Console.WriteLine("Enter the home purchase price.");
        while (!decimal.TryParse(Console.ReadLine(), out purchasePrice))
        {
            Console.WriteLine("Enter a valid purchase price.");
        }

        decimal interestRate;
        Console.WriteLine("Enter the interest rate of the loan.");
        while (!decimal.TryParse(Console.ReadLine(), out interestRate))
        {
            Console.WriteLine("Enter a valid interest rate.");
        }

        decimal downPayment;
        Console.WriteLine("Enter the down payment amount.");
        while (!decimal.TryParse(Console.ReadLine(), out downPayment))
        {
            Console.WriteLine("Enter a valid down payment amount.");
        }

        int years;
        Console.WriteLine("Enter the length of the loan in years.");
        while (!int.TryParse(Console.ReadLine(), out years))
        {
            Console.WriteLine("Enter a valid number of years.");
        }

        //Series of loops and conditionals that checks for a HOA and calculates yearly total for HOA
        Console.WriteLine("Is there an HOA? Enter yes or no.");
        string? hoaChecker;
        do
        {
            string? input = Console.ReadLine();
            hoaChecker = input != null ? input.ToLower() : "";
            if (hoaChecker == "yes")
            {
                Console.WriteLine("Enter the HOA monthly payment amount.");
            }
        } while (hoaChecker != "no" && hoaChecker != "yes");

        decimal hoaPayment = 0;
        if (hoaChecker == "yes")
        {
            while (!decimal.TryParse(Console.ReadLine(), out hoaPayment))
            {
                Console.WriteLine("Enter a valid HOA payment amount.");
            }
        }

        decimal monthlyIncome;
        Console.WriteLine("Enter your monthly income.");
        while (!decimal.TryParse(Console.ReadLine(), out monthlyIncome) || monthlyIncome <= 0)
        {
            Console.WriteLine("Enter a valid monthly income amount.");
        }

        decimal marketValue;
        Console.WriteLine("Enter the current market value of the home.");
        while (!decimal.TryParse(Console.ReadLine(), out marketValue) || marketValue <= 0)
        {
            Console.WriteLine("Enter a valid market value.");
        }

        PurchasePrice = purchasePrice;
        InterestRate = interestRate;
        DownPayment = downPayment;
        Years = years;
        HoaPayment = hoaPayment;
        MonthlyIncome = monthlyIncome;
        MarketValue = marketValue;
    }

    //Method to handle all calculations
    private void CalculateValues()
    {
        //Calculate fees and loan amount
        OriginationFee = PurchasePrice * originationFeeRate;
        ClosingCosts = closingCostsFee;
        LoanAmount = PurchasePrice - DownPayment + OriginationFee + ClosingCosts;
        
        HoaYearlyTotal = HoaPayment * 12;
        HomeownerInsurancePayment = homeownerInsuranceRate * PurchasePrice;
        PropertyTaxPayment = propertyTaxRate * PurchasePrice;
        
        // Fix equity calculation to use market value
        EquityPercentage = (DownPayment / MarketValue) * 100;
        
        //Calculate monthly mortgage payment using corrected loan amount
        decimal monthlyInterestRate = (InterestRate / 100) / 12;
        int numberOfPayments = Years * 12;
        
        if (monthlyInterestRate > 0)
        {
            decimal power = (decimal)Math.Pow((double)(1 + monthlyInterestRate), numberOfPayments);
            MonthlyMortgagePayment = LoanAmount * (monthlyInterestRate * power) / (power - 1);
        }
        else
        {
            //If interest rate is 0%, simple division
            MonthlyMortgagePayment = LoanAmount / numberOfPayments;
        }
        
        //PMI calculation 
        if (EquityPercentage < 10)
        {
            PmiRequired = true;
            MortgageInsurancePayment = (LoanAmount * 0.01m) / 12;
        }
        else
        {
            PmiRequired = false;
            MortgageInsurancePayment = 0;
        }

        //Calculate monthly breakdown
        MonthlyInsurance = HomeownerInsurancePayment / 12;
        MonthlyPropertyTax = PropertyTaxPayment / 12;
        
        //Calculate total monthly payment
        TotalMonthlyPayment = MonthlyMortgagePayment + MonthlyInsurance + MonthlyPropertyTax +
                            HoaPayment + MortgageInsurancePayment;

        //Calculate payment-to-income ratio and loan approval using total payment
        PaymentToIncomeRatio = (TotalMonthlyPayment / MonthlyIncome) * 100;
        LoanApproved = PaymentToIncomeRatio < 25;
    }

    //Method to format and display the loan info
    public void DisplayInfo()
    {
        Console.WriteLine("\n----------- Mortgage Loan Summary -----------");
        Console.WriteLine($"{"Purchase Price:",-30}{PurchasePrice,15:C}");
        Console.WriteLine($"{"Market Value:",-30}{MarketValue,15:C}");
        Console.WriteLine($"{"Down Payment:",-30}{DownPayment,15:C}");
        Console.WriteLine($"{"Origination Fee (1%):",-30}{OriginationFee,15:C}");
        Console.WriteLine($"{"Closing Costs:",-30}{ClosingCosts,15:C}");
        Console.WriteLine($"{"Total Loan Amount:",-30}{LoanAmount,15:C}");
        Console.WriteLine($"{"Interest Rate:",-30}{InterestRate,14:F2}%");
        Console.WriteLine($"{"Loan Term:",-30}{Years + " years",15}");
        Console.WriteLine($"{"Equity Percentage:",-30}{EquityPercentage,14:F2}%");

        Console.WriteLine("\n--- Monthly Payment Breakdown ---");
        Console.WriteLine($"{"Principal & Interest:",-30}{MonthlyMortgagePayment,15:C}");
        Console.WriteLine($"{"Homeowner Insurance:",-30}{MonthlyInsurance,15:C}");
        Console.WriteLine($"{"Property Tax:",-30}{MonthlyPropertyTax,15:C}");
        Console.WriteLine($"{"HOA Fees:",-30}{HoaPayment,15:C}");
        
        if (PmiRequired)
        {
            Console.WriteLine($"{"Mortgage Insurance (PMI):",-30}{MortgageInsurancePayment,15:C}");
        }
        else
        {
            Console.WriteLine($"{"Mortgage Insurance (PMI):",-30}{"$0.00",15}");
        }
        
        Console.WriteLine($"{"TOTAL MONTHLY PAYMENT:",-30}{TotalMonthlyPayment,15:C}");

        Console.WriteLine("\n--- Annual Costs ---");
        Console.WriteLine($"{"HOA Yearly Total:",-30}{HoaYearlyTotal,15:C}");
        Console.WriteLine($"{"Homeowner Insurance:",-30}{HomeownerInsurancePayment,15:C}");
        Console.WriteLine($"{"Property Tax:",-30}{PropertyTaxPayment,15:C}");

        Console.WriteLine("\n--- Loan Decision ---");
        Console.WriteLine($"{"Monthly Income:",-30}{MonthlyIncome,15:C}");
        Console.WriteLine($"{"Payment-to-Income Ratio:",-30}{PaymentToIncomeRatio,14:F2}%");
        
        if (LoanApproved)
        {
            Console.WriteLine($"{"Loan Recommendation:",-30}{"APPROVED",15}");
            Console.WriteLine("Your total monthly payment is less than 25% of your monthly income.");
        }
        else
        {
            Console.WriteLine($"{"Loan Recommendation:",-30}{"DENIED",15}");
            Console.WriteLine("Your total monthly payment exceeds 25% of your monthly income.");
            Console.WriteLine("\nSuggestions to improve loan approval:");
            Console.WriteLine("• Consider increasing your down payment");
            Console.WriteLine("• Look for a more affordable home");
            Console.WriteLine("• Consider a longer loan term to reduce payments");
            Console.WriteLine("• Increase your monthly income");
        }
        Console.WriteLine("---------------------------------------------");
    }
}
