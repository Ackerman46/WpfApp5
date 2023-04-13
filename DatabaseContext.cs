namespace WpfApp1
{
    internal class DatabaseContext : Abonents_ATCEntities
    {
        private static DatabaseContext _context;

        public static DatabaseContext GetContext()
        {
            if (_context == null) { _context = new DatabaseContext(); }
            return _context;
        }
    }
}
