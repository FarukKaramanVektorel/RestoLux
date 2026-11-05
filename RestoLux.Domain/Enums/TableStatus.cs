namespace RestoLux.Domain.Enums;

public enum TableStatus
{
    Available = 0,
    Reserved = 1,
    Occupied = 2,
    OrderPending = 3,
    Preparing = 4,
    BillRequested = 5,
    Cleaning = 6,
    OutOfService = 7
}
