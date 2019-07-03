namespace NameListApi.Models
{
    public class NameListItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string FirstName {get;set;}

        public string YearOfBirth {get; set;}

       public bool IsComplete { get; set; }
    }
}