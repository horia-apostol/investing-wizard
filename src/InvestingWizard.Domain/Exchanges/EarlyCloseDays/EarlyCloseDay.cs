namespace InvestingWizard.Domain.Exchanges
{
    public class EarlyCloseDay : Holiday
    {
        public TimeOnly? CloseTime { get; set; }
    }
}
