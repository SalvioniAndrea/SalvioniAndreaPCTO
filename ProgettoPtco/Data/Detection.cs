namespace ProgettoPtco.Data
{
    public class Detection
    {
        public int id { get; set; }
        public int idDevice { get; set; }
        public int temperatura { get; set; }
        public int umidita { get; set; }
        public int pressione { get; set; }
        public int altitudine { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
