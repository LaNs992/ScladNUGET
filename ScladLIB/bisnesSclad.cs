namespace ScladLIB
{
    public class bisnesSclad<SCL> where SCL : class
    {
        private List<SCL> ScldBL = new List<SCL>();

        public bisnesSclad() { }
        public List<SCL> Get()
        {
            return ScldBL;
        }

        public void Add(SCL data)
        {
            ScldBL.Add(data);
        }
        public void Remove(SCL data)
        {
            ScldBL.Remove(data);
        }

        public void Update(SCL id, SCL data)
        {
            var index = ScldBL.IndexOf(id);
            ScldBL[index] = data;
        }
    }
}