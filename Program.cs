decimal Capital;
decimal Percentage;
bool basesFirstCapital;

Console.WriteLine("Enter the remaingin balance of your mortgage!");
Capital = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Enter the % that you want to pay off every month direct to capital");
Percentage = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("The percentage will be fijo?");
basesFirstCapital = Convert.ToBoolean(Console.ReadLine());

List<decimal> Remainging = new();
List<decimal> Payments = new();
if (basesFirstCapital)
{
    var PaymentFijo = Capital * (Percentage / 100);
    Console.WriteLine($"If every month you pay: {PaymentFijo}");
    while (Capital > 0)
    {
        ProcessPay(PaymentFijo);
    }
}
else
{
    Console.WriteLine($"If every month you pay: {Percentage}% of current capital");
    while (Capital > 1)
    {
        ProcessPay(Capital * (Percentage / 100));
    }
}
Console.WriteLine($"You will end to pay the mortgage on {Remainging.Count} months");
Console.WriteLine("Here is a amortitation table");
int counter = 1;
foreach (var item in Remainging)
{
    Console.WriteLine($"{counter} Month: Payed={Payments[counter-1]} Balance={item}");
    counter++;
}

void ProcessPay(decimal pay)
{
    Capital -= pay;
    Remainging.Add(Capital);
    Payments.Add(pay);
}