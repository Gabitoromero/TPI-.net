namespace Domain.Model
{
    public abstract class BusinessEntity
    {
        int _Id;
        string _State;

        public int ID { get; set; }
        public string State { get; set; }
    }
}
