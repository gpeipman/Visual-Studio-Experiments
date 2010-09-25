namespace Experiments.MeasuringTools
{
    public interface IDatabaseCommand : ICommand
    {
        long RowsReturned { get; }
        long RowsInUnpagedResult { get; }
    }
}
