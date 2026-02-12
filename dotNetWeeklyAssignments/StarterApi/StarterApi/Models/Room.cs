
namespace StarterApi.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Type {  get; set; }
        
        public int Capacity { get; set; }

        public bool IsAvailable {  get; set; }

        internal int Max(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
