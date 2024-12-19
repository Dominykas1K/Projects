namespace Restaurant_app
{
    public class Table
    {
        public int TableNumber { get; set; }
        public int TableSeats { get; set; }
        public bool IsOccupied { get; set; }

        public Table(int tableNumber, int tableSeats)
        {
            TableNumber = tableNumber;
            TableSeats = tableSeats;
            IsOccupied = false;
        }

        public void Occupy()
        {
            IsOccupied = true;
        }
        public void Free()
        {
            IsOccupied = false;
        }
    }
}
