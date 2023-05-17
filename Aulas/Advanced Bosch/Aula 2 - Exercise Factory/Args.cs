public class ProcessArgs
{
    private static ProcessArgs empty = new ProcessArgs();
    public static ProcessArgs Empty => empty;
}
 
public class DismissalArgs : ProcessArgs
{
    public Company Company { get; set; }
    public Employe Employe { get; set; }
}
 
public class WagePaymentArgs : ProcessArgs
{
    public Company Company { get; set; }
    public Employe Employe { get; set; }
}